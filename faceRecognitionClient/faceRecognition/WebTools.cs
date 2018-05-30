using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;

namespace faceRecognition
{
    class WebTools : IDisposable
    {
        bool disposed = false;
        public string postImageToServer(string serverAddress, string filename, string serverMethod, string strToPost)
        {
            //System.Threading.Thread.Sleep(200);
            byte[] imageByte = File.ReadAllBytes(filename);
            File.Delete(filename);
            byte[] stringToRequest = Encoding.UTF8.GetBytes(strToPost + "<image>");
            WebRequest request = WebRequest.Create(serverAddress + "/" + serverMethod);
            request.ContentLength = imageByte.Length + stringToRequest.Length;
            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(stringToRequest, 0, stringToRequest.Length);
            dataStream.Write(imageByte, 0, imageByte.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        public string postImageToServer(string serverAddress, string filename, string serverMethod)
        {
            System.Threading.Thread.Sleep(200);
            byte[] imageByte = File.ReadAllBytes(filename);
            //File.Delete("2.jpg");
            byte[] stringToRequest = Encoding.UTF8.GetBytes(serverMethod + "<image>");
            WebRequest request = WebRequest.Create(serverAddress + "/" + serverMethod);
            request.ContentLength = imageByte.Length + stringToRequest.Length;
            request.Method = "POST";
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(stringToRequest, 0, stringToRequest.Length);
            dataStream.Write(imageByte, 0, imageByte.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        public byte[] fullTextSearchRequest(string serverAddress, string searchPhrase)
        {
            string requestPhrase = "<text>" + searchPhrase;
            WebRequest req = WebRequest.Create(serverAddress + "/full_text_search");
            req.Method = "POST";
            byte[] requestByte = Encoding.UTF8.GetBytes(requestPhrase);
            req.ContentLength = requestByte.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestByte, 0, requestByte.Length);
            requestStream.Close();

            WebResponse res = req.GetResponse();
            requestStream = res.GetResponseStream();
            byte[] data;
            StreamReader readResponse = new StreamReader(requestStream);
            using (MemoryStream ms = new MemoryStream())
            {
                readResponse.BaseStream.CopyTo(ms);
                data = ms.ToArray();
            }
            readResponse.Close();
            requestStream.Close();
            res.Close();
            return data;
        }

        public string getUserCountFromServer(string serverAddress)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1111/");
            HttpWebResponse response = null;
            response = (HttpWebResponse)req.GetResponse();
            Stream responseData = response.GetResponseStream();
            StreamReader readResponse = new StreamReader(responseData);
            string getRequestData = readResponse.ReadToEnd();
            response.Close();
            responseData.Close();
            readResponse.Close();
            return getRequestData;
        }

        public string deleteRecordRequest(string serverAddress, int id)
        {
            string requestPhrase = "<text>" + id.ToString();
            WebRequest req = WebRequest.Create(serverAddress + "/delete_record");
            req.Method = "POST";
            byte[] requestByte = Encoding.UTF8.GetBytes(requestPhrase);
            req.ContentLength = requestByte.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestByte, 0, requestByte.Length);
            requestStream.Close();

            WebResponse res = req.GetResponse();
            requestStream = res.GetResponseStream();
            StreamReader readResponse = new StreamReader(requestStream);
            string response = readResponse.ReadToEnd();
            readResponse.Close();
            requestStream.Close();
            res.Close();
            return response;
        }

        public string updateRecordRequest(string serverAddress, int id, string updateString)
        {
            string requestPhrase = "<text>" + updateString + "<id>" + id.ToString();
            WebRequest req = WebRequest.Create(serverAddress + "/update_record");
            req.Method = "POST";
            byte[] requestByte = Encoding.UTF8.GetBytes(requestPhrase);
            req.ContentLength = requestByte.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestByte, 0, requestByte.Length);
            requestStream.Close();

            WebResponse res = req.GetResponse();
            requestStream = res.GetResponseStream();
            StreamReader readResponse = new StreamReader(requestStream);
            string response = readResponse.ReadToEnd();
            readResponse.Close();
            requestStream.Close();
            res.Close();
            return response;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        

    }
}
