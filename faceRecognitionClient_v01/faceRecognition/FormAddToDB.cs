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
        public Capture capWebcamAdd;
        getWebCam webcamAdd = new getWebCam();
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        Task sendPostRequestTask;
        bool readyToIdentify = false;
        static bool requestStarted = false;
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
            //var faceRectangle = null;
            btnAddToDB.Enabled = !requestStarted;
            if (Faces[0].Length > 0)
            {
                readyToIdentify = true;
                lblInfo.Text = "";
                foreach (MCvAvgComp face in Faces[0])
                {
                    image.Draw(face.rect, new Bgr(Color.Green), 5);
                }
            }
            else
            {
                readyToIdentify = false;
                lblInfo.Text = "Дождитесь, пока лицо будет обведено рамкой";
            }

            //Выводим обработаное приложение
            VideoBox.Image = image;
            
            
        }

        async void addUser(bool newUser)
        {
            try
            {
                requestStarted = true;
                string jsonString = formingDataString();
                if (jsonString != "NOT OK")
                {
                    WebTools postImageAndUserInfo = new WebTools();
                    if (newUser)
                    {
                        string responseFromServer = postImageAndUserInfo.postImageToServer(address, "savedAddFrame.jpg", "append_user_to_db", jsonString);
                        
                    }
                    else
                    {
                        string responseFromServer = postImageAndUserInfo.postImageToServer(address, "savedAddFrame.jpg", "update_user_record_or_add_new", jsonString);
                        if (responseFromServer == "<BAD DESCRIPTOR>")
                        {
                            MessageBox.Show("Лицо не обнаружено");
                        }
                    }
                    
                }
                
                requestStarted = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                requestStarted = false;
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
            
            if (readyToIdentify && !requestStarted)
            {
                try
                {
                    Image<Bgr, Byte> imageToAdd = capWebcamAdd.QueryFrame();
                    imageToAdd.Save("savedAddFrame.jpg");
                    if (chkAddMethod.Checked)
                    {
                        sendPostRequestTask = Task.Run(() => addUser(chkAddMethod.Checked));
                    }
                    else
                    {
                        sendPostRequestTask = Task.Run(() => addUser(chkAddMethod.Checked));
                    }
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
           
        }
    }
}

