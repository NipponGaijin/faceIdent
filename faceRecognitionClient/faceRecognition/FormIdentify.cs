using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cvb;
using Emgu.Util;
using System.Net;

namespace faceRecognition
{
    public partial class FormIdentify : Form
    {
        FormAddToDB formAddToDB = new FormAddToDB();
        FormFullTextSearch formFullTextSearch = new FormFullTextSearch();
        Capture capWebcam = null;
        getWebCam getWebCam = new getWebCam();
        Image<Bgr, Byte> imgOriginal;       //Чистое изображение
        Image<Gray, Byte> imgProcessed;     //Изображение с фильтром
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        bool flag = false;
        bool faceYep = false;
        bool photoSaved = false;
        static bool requestIsStarted;
        static bool stringResponsed = false;
        static bool buttonEnable = true;
        static string strToPost;
        static string responsedString;
        

        public FormIdentify()
        {
            InitializeComponent();
        }

        private void FormIdentify_Load(object sender, EventArgs e)
        {
            try
            {
                capWebcam = getWebCam.cam;               // инициализируем объект записи с дефолтной вебки
            }
            catch (NullReferenceException exept)       // ошибка, если запись неудалась
            {
                return;
            }
            dataTableIndent.ColumnCount = 2;
            dataTableIndent.Columns[0].Name = "Название поля";
            dataTableIndent.Columns[1].Name = "Содержание поля";
            dataTableIndent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataTableIndent.AllowUserToAddRows = false;
            dataTableIndent.ReadOnly = true;
            Application.Idle += processFrameAndUpdGui;
        }
        private void FormIdentify_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebcam != null)
            {
                getWebCam.disposeCam();
            }

        }
        private void processFrameAndUpdGui(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = capWebcam.QueryFrame(); //.Resize(imageBox1.Width, imageBox1.Height, INTER.CV_INTER_LANCZOS4)
            Image<Bgr, Byte> imageROI = image;
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            //Ищем признаки лица
            MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(cascade, 1.2, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(200, 200));

            if (Faces[0].Length > 0)
            {
                lblInformation.Text = "";
                //faceYep = true;
            }
            else
            {
                lblInformation.Text = "Дождитесь, пока лицо будет обведено рамкой";
                //faceYep = false;
            }
            if (Faces[0].Length == 0)
            {
                flag = true;
            }
            foreach (MCvAvgComp face in Faces[0])
            {
                //if (flag)
                //{
                if (Faces[0].Length > 0 && flag)
                {
                    imageROI.Save("2.jpg");
                    flag = false;
                    photoSaved = true;
                    buttonEnable = false;
                }
                
                    
                //}
                image.Draw(face.rect, new Bgr(Color.Green), 5);
            }
            //Выводим обработаное приложение
            VideoBox.Image = image;

            if (photoSaved && !requestIsStarted)
            {
                Thread thrd = new Thread(sendPostRequest);
                thrd.Start();
                buttonEnable = false;
                goIdentify.Enabled = false;
                photoSaved = false;
            }
            if (stringResponsed)
            {
                updateTable();
                stringResponsed = false;
            }
            if (buttonEnable)
            {
                
                goIdentify.Enabled = true;
            }
            else
            {
                goIdentify.Enabled = false;
            }
        }

        private void updateTable()
        {
            if (responsedString != "" && responsedString != null)
            {
                lblFoundStatus.Text  = "Пользователь найден";
                string[] strSplitted = System.Text.RegularExpressions.Regex.Split(responsedString, @"\\row\\");
                dataTableIndent.Rows.Clear();
                for (int i = 0; i < strSplitted.Length; i++)
                {
                    if (strSplitted[i] != "")
                    {
                        dataTableIndent.Rows.Add();
                        dataTableIndent.Rows[i - 1].Cells["Название поля"].Value = (String)strSplitted[i].Split('=')[0];
                        dataTableIndent.Rows[i - 1].Cells["Содержание поля"].Value = (String)strSplitted[i].Split('=')[1];
                    }
                }
            }
            else if (responsedString == "")
            {
                lblFoundStatus.Text = "Пользователь не найден, добавьте его";
            }
            responsedString = null;
            

        }

        static void sendPostRequest()
        {
            requestIsStarted = true;
            try
            {
                byte[] imageByte = File.ReadAllBytes(@"E:\prj\facerecBackup\faceRecognitionClient\faceRecognition\bin\Release\2.jpg");
                byte[] stringToRequest = Encoding.UTF8.GetBytes("searchInDb\\method\\");
                WebRequest request = WebRequest.Create("http://localhost:1111");
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
                
                string[] splitted = System.Text.RegularExpressions.Regex.Split(responseFromServer, @"\\length\\");
                reader.Close();
                dataStream.Close();
                response.Close();
                string[] a = System.Text.RegularExpressions.Regex.Split(splitted[1], @"\\content\\");
                if (a[0] == "Succsess POST")
                {
                    buttonEnable = true;
                    stringResponsed = true;
                    responsedString = System.Text.RegularExpressions.Regex.Split(responseFromServer, @"\\content\\")[1];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                buttonEnable = true;
            }
            finally
            {
                requestIsStarted = false;
            }

        }


        private void goIdentify_Click(object sender, EventArgs e)
        {
            //if (faceYep)
            //{
                flag = true;
            //}
            
            lblFoundStatus.Text = "";
        }
        private void addUser_Click(object sender, EventArgs e)
        {
            formAddToDB.ShowDialog();
            lblFoundStatus.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formFullTextSearch.ShowDialog();
        }


    }
}
