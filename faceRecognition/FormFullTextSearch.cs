using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace faceRecognition
{
    public partial class FormFullTextSearch : Form
    {
        
        public FormFullTextSearch()
        {
            InitializeComponent();
        }

        private void FormFullTextSearch_Load(object sender, EventArgs e)
        {
            string getRequestData;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:1111/");
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)req.GetResponse();
                Stream responseData = response.GetResponseStream();
                StreamReader readResponse = new StreamReader(responseData);
                getRequestData = readResponse.ReadToEnd();
                response.Close();
                responseData.Close();
                readResponse.Close();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.ToString());
                this.Close();
            }
        }

        private void searchingRequest()
        {
            string searchPhrase = txtSearchInfo.Text;
            string requestPhrase = "fullTextSearch\\method\\<text>" + searchPhrase; 
            WebRequest req = WebRequest.Create("http://localhost:1111/");
            req.Method = "POST";
            byte[] requestByte = Encoding.UTF8.GetBytes(requestPhrase);
            req.ContentLength = requestByte.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestByte, 0, requestByte.Length);
            requestStream.Close();

            WebResponse res = req.GetResponse();
            requestStream = res.GetResponseStream();
            StreamReader readResponse = new StreamReader(requestStream);
            string readedResponse = readResponse.ReadToEnd();
            readResponse.Close();
            requestStream.Close();
            res.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchInfo.Text.ToString()))
            {
                searchingRequest();
            }
            
        }
        
    }
}
