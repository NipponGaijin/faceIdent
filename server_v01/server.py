import time
import io
from PIL import Image
from http.server import BaseHTTPRequestHandler, HTTPServer
import cv2
from os import curdir
from os.path import join as pjoin
import numpy
import re
import sqlite3
import dlib
from scipy.spatial import distance



host = ''
HOST_NAME = host # !!!REMEMBER TO CHANGE THIS!!!
PORT_NUMBER = 1111 # Maybe set this to 9000.
DB_NAME = 'faces.db'

def searchInDb(desc):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    selectedData = []
    sel = cursor.execute("select id, desc from face")
    targetIndex = 0
    for line in sel:
        euclidianDistanse = distance.euclidean(numpy.array(line[1].split('||'), dtype=float), numpy.array(desc.split('||'), dtype=float))
        if euclidianDistanse < 0.6:
            targetIndex = line[0]
            print(euclidianDistanse)
        else:
            print(str(euclidianDistanse) + '> 0.6')
    
    result = ''
    if targetIndex!=0:
        sel = cursor.execute("select rawstring from face where id=?", [targetIndex])
        for line in sel:
            result = line[0]
    

    
    conn.close()
    return result

def appendToDb(keywords, rawstring, desc):
    if desc != '':
        conn = sqlite3.connect(DB_NAME)
        cursor = conn.cursor()
        ins = cursor.execute("INSERT INTO face (rawstring, keywords, date, desc) VALUES( ?, ?, ?, ?)",
                         (rawstring, keywords[0], keywords[1], desc))
        conn.commit()
        conn.close()


def getDescriptor(img):
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    detector = dlib.get_frontal_face_detector()
    dets = detector(gray, 1)
    sp = dlib.shape_predictor('shape_predictor_68_face_landmarks.dat')
    facerec = dlib.face_recognition_model_v1('dlib_face_recognition_resnet_model_v1.dat')
    faceDescriptor = ''
    for i, d in enumerate(dets):
            shape = sp(img, d)      
            faceDescriptor += str(facerec.compute_face_descriptor(img, shape)).replace('\n', '||')
            if i != len(dets) - 1:
                faceDescriptor += '\n'
    return faceDescriptor

def parseDataFromPost(stringToParse):
    keywords = ""
    date = ""
    splitted = stringToParse.split('\\\\row\\\\')
    for line in splitted:
        if line != '':
            keywords += line.split('=')[1] + '||' 
            if line.split('=')[0] == "Дата регистрации":
                date = line.split('=')[1]
    print(date)
    return keywords, date

def countOfRowsInDB():
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    count = 0
    res = cursor.execute("SELECT COUNT(*) FROM face")
    for line in res:
        count = line
    conn.close()
    return count[0]

def searchingInDB(searchString):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    res = cursor.execute("SELECT keywords FROM face")
    for line in res:
        print(line)
    return(1)
    

class MyHandler(BaseHTTPRequestHandler):
    store_path = pjoin(curdir, '1.jpg')
    def _set_headers(self):
        self.send_response(200)
        self.send_header('Content-type', 'text/html')
        self.end_headers()

    def do_GET(self):
        self._set_headers()
        countRows = countOfRowsInDB()
        responseString = "||blk||count rows = " + str(countRows) + "||blk||"
        self.wfile.write(responseString.encode())

    def do_HEAD(self):
        self._set_headers()
        
    def do_POST(self):
        # Doesn't do anything with posted data
        self._set_headers()
        params = self.rfile.read(int(self.headers['Content-Length']))
        paramsSplit = params.split(b'\\image\\')
        method = paramsSplit[0].split(b'\\method\\')[0].decode()
        print(method)
        
        
        if method == 'appendToDb':
            dataString = paramsSplit[0].split(b'\\method\\')[1].decode()
            print(dataString)
            keywordsAndDate = parseDataFromPost(dataString)
            img = Image.open(io.BytesIO(paramsSplit[1]))
            image = cv2.cvtColor(numpy.array(img), cv2.COLOR_BGR2RGB)
            desc = getDescriptor(image)
            appendToDb(keywordsAndDate, dataString, desc)
            self.wfile.write("Succsess POST".encode())
            
        elif method == 'searchInDb':
            imbyte = params.split(b'\\method\\')[1]
            img = Image.open(io.BytesIO(imbyte))
            image = cv2.cvtColor(numpy.array(img), cv2.COLOR_BGR2RGB)
            desc = getDescriptor(image)
            searched = searchInDb(desc)
            print(searched)
            sendingString = "Succsess POST\\content\\\\" + searched
            self.wfile.write(bytes(str(len(sendingString)) + "\\length\\" + sendingString, 'utf-8').decode('unicode-escape').encode('ISO-8859-1'))        
#             self.wfile.write((str(len(sendingString)) + "\\length\\" + sendingString).encode())
        elif method == 'fullTextSearch':
            print(str(params.decode()))
            searchString = str(params.decode()).split('<text>')[1]
            searchingInDB(searchString)
if __name__ == '__main__':
    host = input()
    server_class = HTTPServer
    httpd = server_class((HOST_NAME, PORT_NUMBER), MyHandler)
    print(time.asctime(), "Server Starts - %s:%s" % (HOST_NAME, PORT_NUMBER))
    try:
        httpd.serve_forever()
    except KeyboardInterrupt:
        pass
    httpd.server_close()
    print(time.asctime(), "Server Stops - %s:%s" % (HOST_NAME, PORT_NUMBER))