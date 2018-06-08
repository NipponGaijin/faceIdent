#! /usr/bin/python
# -*- coding: utf-8 -*-

import time
import io
import cv2
import numpy
import re
import sqlite3
import dlib
import glob
import os
import json


from PIL import Image
from http.server import BaseHTTPRequestHandler, HTTPServer
from scipy.spatial import distance
from random import choice
from string import ascii_letters
from string import digits
from datetime import datetime



HOST_NAME = '192.168.0.21' # !!!REMEMBER TO CHANGE THIS!!!
PORT_NUMBER = 1111 # Maybe set this to 9000.
DB_NAME = 'faces.db'

def searchInDb(desc):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    selectedData = []
    sel = cursor.execute("select id, desc, rawstring from face")
    targetIndex = 0
    result = ''
    jsonFilenames = {}
    for line in sel:
        if len(desc) != 0:
            euclidianDistanse = distance.euclidean(numpy.array(line[1].split('|'), dtype=float), numpy.array(desc.split('|'), dtype=float))
            if euclidianDistanse < 0.6:
                targetIndex = line[0]
                result = line[2]
                sel2 = cursor.execute("SELECT images from groupImages WHERE id = ?", (line[0],))
                sel2 = [i[0] for i in sel2]
                jsonFilenames = json.loads(sel2[0])
    
    conn.close()
    if result == "":
        return "<NOTFOUND>"
    else:
        json_dict = {}
        json_dict['content'] = json.loads(result)
        json_dict['id'] = targetIndex
        json_dict['filenames'] = jsonFilenames
        result = json.dumps(json_dict, ensure_ascii=False)
        return result

def create_filename():
    filename = "".join(choice(ascii_letters + digits) for i in range(20)) + ".png"
    return filename

def appendToDb(keywords, rawstring, desc, image):
    if desc != '':
        conn = sqlite3.connect(DB_NAME)
        cursor = conn.cursor()
        sel = cursor.execute("SELECT key, desc, id FROM face")
        full_select = [line[::1] for line in sel]
        filename = create_filename()
        euclidianDistanse = 0
        
        if len(full_select) != 0: 
            for line in full_select:
                if line[0].count(filename) > 1:
                    while line[0].count(filename) > 1:
                        filename = create_filename()
                        
        if len(full_select) != 0:
            for line in full_select:
                euclidianDistanse = distance.euclidean(
                    numpy.array(line[1].split('|'), dtype=float), numpy.array(desc.split('|'), dtype=float))
                if euclidianDistanse < 0.6:
                    sel = cursor.execute("SELECT images FROM groupImages WHERE id = ?", (line[2],))
                    sel = [i[0] for i in sel]
                    upd_desc = cursor.execute("UPDATE face SET desc = ?, key = ? WHERE id = ?", (desc , filename, line[2]))
#                     print(sel[0])
                    jsonDict = json.loads(sel[0])
                    jsonDict.update({filename: filename})
                    jsonString = json.dumps(jsonDict, ensure_ascii=False)
                    upd = cursor.execute("UPDATE groupImages SET images = ? WHERE id = ?", (jsonString, line[2]))
                    break
        print(len(full_select))            
        if len(full_select) == 0 or euclidianDistanse > 0.6:
            ins = cursor.execute("INSERT INTO face (rawstring, keywords, desc, key) VALUES( ?, ?, ?, ?)",
                                 (rawstring, keywords, desc, filename))
            sel = cursor.execute("SELECT id FROM face WHERE key = ?", (filename,))
            sel = [i[0] for i in sel]
            jsonDict = {filename: filename}
            jsonString = json.dumps(jsonDict, ensure_ascii=False)
            ins2 = cursor.execute("INSERT INTO groupImages (id, images) VALUES(?, ?)", (sel[0], jsonString))
        
        conn.commit()
        conn.close()
        image_name = 'images/%s' % filename 
        cv2.imwrite(image_name, image)

def getDescriptor(img):
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    detector = dlib.get_frontal_face_detector()
    dets = detector(gray, 1)
    sp = dlib.shape_predictor('shape_predictor_68_face_landmarks.dat')
    facerec = dlib.face_recognition_model_v1('dlib_face_recognition_resnet_model_v1.dat')
    faceDescriptor = []
    for i, d in enumerate(dets):
            if len(dets) < 2:
                shape = sp(img, d)
                face_desc_list = facerec.compute_face_descriptor(img, shape)
                face_desc_string = ""
                for i, value in enumerate(face_desc_list):
                    if i != len(face_desc_list) - 1:
                        face_desc_string += str(value) + "|"
                    else:
                        face_desc_string += str(value)
                        
                faceDescriptor.append(face_desc_string)
    
    if len(faceDescriptor) != 0:
        return faceDescriptor[0]
    else:
        return ""


def parseDataFromPost(dict_of_data):
    keywords = ''
    for value in dict_of_data.values():
        keywords += value + "<key>"
    return keywords

def countOfRowsInDB():
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    count = 0
    res = cursor.execute("SELECT COUNT(*) FROM face")
    for line in res:
        count = line
    conn.close()
    return count[0]

def textSearchingInDB(searchString):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    results = []
    res = cursor.execute("SELECT id, keywords FROM face")
    full_select = [line[::1] for line in res]
    conn.close()
    for line in full_select:
        if re.search(searchString.upper(), line[1].upper()):
            results.append(line[0])
    if len(results) == 0:
        return "NOTFOUND"
    else:
        return(results)

def prepare_searched_result(searchString):
    searched_results = textSearchingInDB(searchString)
    result = []
    images_names = []
    ids = []
    if searched_results != "NOTFOUND":
        for line in searched_results:
            conn = sqlite3.connect(DB_NAME)
            cursor = conn.cursor()
            sel = cursor.execute("select rawstring, key, id from face where id=?", [line])
            sel = [i for i in sel]
            result.append([i[0] for i in sel])
            images_names.append([i[1] for i in sel])
            ids.append([i[2] for i in sel])
            conn.close()
        return result, images_names, ids
    else:
        return "NOTFOUND"

def prepare_searched_response(searchString):
    string, image_names, ids = prepare_searched_result(searchString)
    json_dict = {}
    
    if len(string) != 0 and len(image_names) != 0 and len(ids) !=0:
        for i, line in enumerate(image_names):
            json_dict.update({'record' + str(i) : {"id":ids[i][0]}})
            json_dict['record' + str(i)].update({'filename': image_names[i][0]})
            json_dict['record' + str(i)].update({'record_content': json.loads(string[i][0])})
        
        result = json.dumps(json_dict, ensure_ascii=False)
        return result.encode()
    else:
        return "NOTFOUND".encode()

def delete_record(request_string):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    sel = cursor.execute("select images from groupImages where id=?", (request_string,))
    filename = ([i[0] for i in sel])
    filename = json.loads(filename[0])
    filename = [i for i in filename]
    delete = cursor.execute("DELETE FROM face WHERE id=?", (request_string,))
    delete = cursor.execute("DELETE FROM groupImages WHERE id=?", (request_string,))
    conn.commit()
    conn.close()
    for i in filename:
        os.remove('images/' + i)
    return '<OK>'

def update_record(request_string):
#     Добавить строку с 
    id_in_db = request_string['id']
    keywords = parseDataFromPost(request_string['content'])
    json_string = json.dumps(request_string['content'], ensure_ascii=False)
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    upd = cursor.execute("UPDATE face SET rawstring = ?, keywords = ? WHERE id = ?",
                         (json_string, keywords, id_in_db))
    conn.commit()
    conn.close()
    return "<OK>"
    
    
class MyHandler(BaseHTTPRequestHandler):
#     store_path = pjoin(curdir, '1.jpg')
    
    def _set_headers(self):
        
        self.send_response(200)
        self.send_header('Content-type', 'text/html')
        self.end_headers()

    def do_GET(self):
        
        self._set_headers()
        if self.path == "/get_users_count":
            countRows = countOfRowsInDB()
            responseString = str(countRows)
            self.wfile.write(responseString.encode())
        
        if re.findall("download_image/images/\w+\.\w{3,4}" ,self.path):
            filename = re.findall("images/\w+\.\w{3,4}", self.path)[0]
            #filename.replace("/", "\\")
            f = open(filename, "rb")
            byte = f.read()
            f.close()
            
            self.wfile.write(byte)    

    def do_HEAD(self):
        self._set_headers()
        
    def do_POST(self):
        
        # Doesn't do anything with posted data
        self._set_headers()
        params = self.rfile.read(int(self.headers['Content-Length']))
        paramsSplit = params.split(b'<image>')    
        
        if self.path == '/append_user_to_db':
            current_date = datetime.now().strftime("%Y.%m.%d %H:%M:%S")
            data_string = paramsSplit[0].decode()
            data_dict = json.loads(data_string)
            data_dict.update({'Дата регистрации':current_date})
            keywords = parseDataFromPost(data_dict)
            img = Image.open(io.BytesIO(paramsSplit[1]))
            image = cv2.cvtColor(numpy.array(img), cv2.COLOR_BGR2RGB)
            desc = getDescriptor(image)
            appendToDb(keywords, json.dumps(data_dict, ensure_ascii=False), desc, image)
            self.wfile.write("Succsess POST".encode())
            
        elif self.path == '/identify_and_search_user':
            imbyte = paramsSplit[1].replace(b'<image>', b'')
            img = Image.open(io.BytesIO(imbyte))
            image = cv2.cvtColor(numpy.array(img), cv2.COLOR_BGR2RGB)
            desc = getDescriptor(image)
            searched = searchInDb(desc)
            
            if not searched == "<NOTFOUND>":
                sendingString = "Succsess POST<content>" + searched
                self.wfile.write(sendingString.encode('utf-8'))
            else:
                self.wfile.write("NOTFOUND<content>".encode('utf-8'))

        
        elif self.path == '/full_text_search':
            searchString = str(params.decode())
            result = prepare_searched_response(searchString)
            if not result == b"NOTFOUND":
                self.wfile.write(result)
            else:
                self.wfile.write(result)
                
                
        elif self.path == '/delete_user_record':
            returned_string = delete_record(str(params.decode()))
            self.wfile.write(returned_string.encode())
            
            
        elif self.path == '/update_user_record':
            json_dict = json.loads(str(params.decode()))
            if 'Дата обновления' in json_dict['content']:
                json_dict['content']['Дата обновления'] = datetime.now().strftime("%Y.%m.%d %H:%M:%S")
            else:
                json_dict['content'].update({'Дата обновления' : datetime.now().strftime("%Y.%m.%d %H:%M:%S")})
            returned_string = update_record(json_dict)
            self.wfile.write(returned_string.encode())
            
if __name__ == '__main__':
    server_class = HTTPServer
    httpd = server_class((HOST_NAME, PORT_NUMBER), MyHandler)
    print(time.asctime(), "Server Starts - %s:%s" % (HOST_NAME, PORT_NUMBER))
    try:
        httpd.serve_forever()
    except KeyboardInterrupt:
        pass
    httpd.server_close()
    print(time.asctime(), "Server Stops - %s:%s" % (HOST_NAME, PORT_NUMBER))