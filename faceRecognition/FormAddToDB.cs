﻿using System;
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
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cvb;
using Emgu.Util;
using System.Net;
using System.Web.Script.Serialization;


namespace faceRecognition
{
    public partial class FormAddToDB : Form
    {
        Capture capWebcamAdd = null;
        getWebCam webcamAdd = new getWebCam();
        static Image<Bgr, Byte> imageFromDb;
        Image<Bgr, Byte> imgOriginal;       //Чистое изображение
        Image<Gray, Byte> imgProcessed;     //Изображение с фильтром
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        Task sendPostRequestTask;
        bool flag = false;
        bool faceYep = false;
        bool photoSaved = false;
        static bool buttonEnable = true;
        static string strToPost;
        public int maxFace;
        public int minFace;
        public string address;
        public FormAddToDB()
        {
            InitializeComponent();
        }

        private void FormAddToDb_Load(object sender, EventArgs e)
        {
            try
            {
                if (capWebcamAdd == null)
                {
                    capWebcamAdd = webcamAdd.setCam();               // инициализируем объект записи с дефолтной вебки
                }
                
            }
            catch (NullReferenceException exept)       // ошибка, если запись неудалась
            {
                return;
            }
            dataTable.ColumnCount = 2;
            dataTable.Columns[0].Name = "Название поля";
            dataTable.Columns[1].Name = "Содержание поля";
            dataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataTable.AllowUserToAddRows = false;
            Application.Idle += processFrameAndUpdGui;
        }


        private void FormAddToDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebcamAdd != null)
            {
                this.Close();
                Application.Idle -= processFrameAndUpdGui;
            }
            if (File.Exists("savedAddFrame.jpg"))
            {
                File.Delete("savedAddFrame.jpg");
            }
        }


        private void processFrameAndUpdGui(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = capWebcamAdd.QueryFrame(); //.Resize(imageBox1.Width, imageBox1.Height, INTER.CV_INTER_LANCZOS4)
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            //Ищем признаки лица
            MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(cascade, 1.2, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(maxFace, minFace));

            if (Faces[0].Length > 0)
            {
                faceYep = true;
            }
            else
            {
                faceYep = false;
            }

            if (Faces[0].Length > 0)
            {
                lblInfo.Text = "";
                foreach (MCvAvgComp face in Faces[0])
                {
                    if (dataTable.RowCount > 0 && flag)
                    {
                        Image<Bgr, Byte> imageROI = image;
                        Rectangle newRect = new Rectangle();
                        newRect.X = face.rect.X - 40;
                        newRect.Y = face.rect.Y - 40;
                        newRect.Width = face.rect.Width + 60;
                        newRect.Height = face.rect.Height + 60;
                        imageROI.ROI = newRect;
                        imageROI.Save("savedAddFrame.jpg");
                        flag = false;
                        photoSaved = true;
                        buttonEnable = false;
                        btnAddToDB.Enabled = false;
                    }
                    
                    image.Draw(face.rect, new Bgr(Color.Green), 5);
                }
            }
            else
            {
                lblInfo.Text = "Дождитесь, пока лицо будет обведено рамкой";
            }

            //Выводим обработаное приложение
            VideoBox.Image = image;
            
            if (photoSaved)
            {
                sendPostRequestTask = Task.Run(() => sendPostRequest());
                buttonEnable = false;
                btnAddToDB.Enabled = false;
                photoSaved = false;
            }
            if (buttonEnable)
            {
                btnAddToDB.Enabled = true;   
            }
            
        }

        async void sendPostRequest()
        {
            try
            {
                string jsonString = formingDataString();
                if (jsonString != "NOT OK")
                {
                    WebTools postImageAndUserInfo = new WebTools();
                    string responseFromServer = postImageAndUserInfo.postImageToServer(address, "savedAddFrame.jpg", "append_user_to_db", jsonString);
                    if (responseFromServer == "Succsess POST")
                    {
                        buttonEnable = true;
                    }
                }
                else
                {
                    buttonEnable = true;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                buttonEnable = true;
            }
            
        }
        private string formingDataString()
        {
            bool isNotOk = false;
            Dictionary<string, string> dictOfTableInfo = new Dictionary<string, string>();
            for (int i = 0; i < dataTable.RowCount; i++)
            {
                if (!String.IsNullOrEmpty((String)dataTable["Содержание поля", i].Value) && !String.IsNullOrEmpty((String)dataTable["Название поля", i].Value))
                {
                    dictOfTableInfo.Add((String)dataTable["Название поля", i].Value, (String)dataTable["Содержание поля", i].Value);
                }
                else
                {
                    MessageBox.Show("В строке " + (i+1).ToString() + " пустое значение!!!");
                    isNotOk = true;
                    break;
                }
                
            }
            if (!isNotOk)
            {
                string jsonString = new JavaScriptSerializer().Serialize(dictOfTableInfo);
                return jsonString;
            }
            else
            {
                return "NOT OK";
            }
        }



        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataTable.RowCount != 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                string textToWrite = System.String.Empty;
                saveDialog.Title = "Save";
                saveDialog.Filter = "Файлы пресетов (*.prsts)|*.prsts| Все файлы (*.*)|*.*";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter write = new StreamWriter(File.Create(saveDialog.FileName));
                    //dataTable.Rows.Clear();
                    for (int i = 0; i < dataTable.RowCount; i++)
                    {
                        if (i != dataTable.RowCount - 1)
                        {
                            textToWrite += (String)dataTable["Название поля", i].Value + "<<row>>";
                        }
                        else
                        {
                            textToWrite += (String)dataTable["Название поля", i].Value;
                        }
                        
                    }
                    write.Write(textToWrite);
                    write.Dispose();
                }
            }
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string readedText = System.String.Empty;
            openFile.Title = "Open";
            openFile.Filter = "Файлы пресетов (*.prsts)|*.prsts| Все файлы (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(openFile.FileName));
                readedText = read.ReadToEnd();
                read.Dispose();
                string[] splitted = System.Text.RegularExpressions.Regex.Split(readedText, @"<<row>>");
                dataTable.Rows.Clear();
                for (int i = 0; i < splitted.Length; i++)
                {
                    dataTable.Rows.Add();
                    dataTable["Название поля", i].Value = splitted[i];
                }

            }
        }

        private void addRow_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Add();
        }

        private void removeRow_Click(object sender, EventArgs e)
        {
            if (dataTable.RowCount > 0)
            {
                int ind = dataTable.SelectedCells[0].RowIndex;
                dataTable.Rows.RemoveAt(ind);
            }
        }

        private void btnAddToDB_Click(object sender, EventArgs e)
        {
            if (faceYep)
            {
                flag = true;
            }
        }
    }
}

