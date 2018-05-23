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
    public partial class FormAddToDB : Form
    {
        Capture capWebcamAdd = null;
        getWebCam webcamAdd = new getWebCam();
        static Image<Bgr, Byte> imageFromDb;
        Image<Bgr, Byte> imgOriginal;       //Чистое изображение
        Image<Gray, Byte> imgProcessed;     //Изображение с фильтром
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        bool flag = false;
        bool faceYep = false;
        bool photoSaved = false;
        static bool buttonEnable = true;
        static string strToPost;


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
                    capWebcamAdd = webcamAdd.cam;               // инициализируем объект записи с дефолтной вебки
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
            //processFrameAndUpdGui(null, null);
            
        }


        private void FormAddToDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebcamAdd != null)
            {
                this.Close();
                Application.Idle -= processFrameAndUpdGui;
            }
            if (File.Exists("1.jpg"))
            {
                File.Delete("1.jpg");
            }
        }


        private void processFrameAndUpdGui(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = capWebcamAdd.QueryFrame(); //.Resize(imageBox1.Width, imageBox1.Height, INTER.CV_INTER_LANCZOS4)
            Image<Bgr, Byte> imageROI = image;
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            //Ищем признаки лица
            MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(cascade, 1.2, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(200, 200));

            if (Faces[0].Length > 0)
            {
                faceYep = true;
            }
            else
            {
                faceYep = false;
            }
            //textBox1.AppendText(faceYep.ToString() + " : " + Faces[0].Length.ToString() + '\n');
            if (Faces[0].Length > 0)
            {
                lblInfo.Text = "";
                foreach (MCvAvgComp face in Faces[0])
                {
                    if (dataTable.RowCount > 0 && flag)
                    {
                        formingDataString();
                        imageROI.Save("1.jpg");
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
            
            //pictureBox1.Image = image.ToBitmap();
            
            if (photoSaved)
            {
                Thread thrd = new Thread(sendPostRequest);
                thrd.Start();
                buttonEnable = false;
                btnAddToDB.Enabled = false;
                photoSaved = false;
            }
            if (buttonEnable)
            {
                btnAddToDB.Enabled = true;   
            }
            
        }

        static void sendPostRequest()
        {
            try
            {
                byte[] imageByte = File.ReadAllBytes(@"1.jpg");
                //File.Delete("1.jpg");
                byte[] headerStingByte = Encoding.UTF8.GetBytes("appendToDb<method>" + strToPost + "<image>");
                WebRequest request = WebRequest.Create("http://localhost:1111/");
                request.ContentLength = imageByte.Length + headerStingByte.Length;
                request.Method = "POST";
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(headerStingByte, 0, headerStingByte.Length);
                dataStream.Write(imageByte, 0, imageByte.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                if (responseFromServer == "Succsess POST")
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
        private void formingDataString()
        {
            string formedString = System.String.Empty;
            for (int i = 0; i < dataTable.RowCount; i++)
            {
                formedString += "<<row>>" + (String)dataTable["Название поля", i].Value + "=" + (String)dataTable["Содержание поля", i].Value;
            }
            formedString += "<<row>>" + "Дата регистрации=" + DateTime.Now.ToString();
            strToPost = formedString;
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

