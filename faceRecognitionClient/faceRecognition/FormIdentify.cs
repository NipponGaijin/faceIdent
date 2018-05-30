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
using System.Threading.Tasks;

namespace faceRecognition
{

    public partial class FormIdentify : Form
    {
        FormAddToDB formAddToDB = new FormAddToDB();
        FormFullTextSearch formFullTextSearch = new FormFullTextSearch();
        Capture capWebcam = null;
        getWebCam getWebCam = new getWebCam();
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        bool readyToNewFace = false;
        bool photoSaved = false;
        Task updateRecordTask;
        Task deleteRecordTask;
        Task sendPostRequestTask;
        static bool requestIsStarted;
        static int idInDb = 0;
        static bool stringResponsed = false;
        static bool buttonEnable = true;
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
            toolButtonPanel.Visible = false;
            Application.Idle += processFrameAndUpdGui;
        }
        private void FormIdentify_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebcam != null)
            {
                getWebCam.disposeCam();
            }
            if (File.Exists("savedIdentifyFrame.jpg"))
            {
                File.Delete("savedIdentifyFrame.jpg");
            }

        }

        private void processFrameAndUpdGui(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = capWebcam.QueryFrame(); //.Resize(imageBox1.Width, imageBox1.Height, INTER.CV_INTER_LANCZOS4)
            Image<Bgr, Byte> imageROI = image;
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            //Ищем признаки лица
            MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(cascade, 1.2, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(150, 150));

            if (updateRecordTask != null && !updateRecordTask.IsCompleted)
            {
                toolButtonPanel.Enabled = false;
            }
            else
            {
                toolButtonPanel.Enabled = true;
            }

            buttonIdentify.Enabled = !requestIsStarted;

            if (Faces[0].Length == 0)
            {
                lblInformation.Text = "Дождитесь, пока лицо будет обведено рамкой";
                readyToNewFace = true;
                buttonEnable = false;
            }

            if (Faces[0].Length > 1)
            {
                lblInformation.Text = "В кадре больше одного лица";
                buttonEnable = false;
            }

            //else if (Faces[0].Length == 0)
            //{
                
            //    //faceYep = false;
            //}
            foreach (MCvAvgComp face in Faces[0])
            {
                //if (flag)
                //{
                if (Faces[0].Length > 0 && Faces[0].Length < 2)
                {
                    lblInformation.Text = "";
                    buttonEnable = true;
                }
                
                if (readyToNewFace || buttonEnable)
                {
                    try
                    {
                        imageROI.Save("savedIdentifyFrame.jpg");
                        photoSaved = true;
                        //buttonEnable = false;
                    }
                    catch (Exception exc) { MessageBox.Show(exc.ToString()); }
                }
                image.Draw(face.rect, new Bgr(Color.Green), 6);
            }
            //Выводим обработаное приложение
            VideoBox.Image = image;

            if (photoSaved && requestIsStarted == false && readyToNewFace && buttonEnable)
            {
                lblSearching.Text = "Идет поиск, ожидайте...";
                readyToNewFace = false;
                //Thread thrd = new Thread(sendPostRequest);
                //thrd.Start();
                sendPostRequestTask = Task.Run(() => sendPostRequest());
                buttonEnable = false;
                //goIdentify.Enabled = false;
                photoSaved = false;
            }
            
            if (stringResponsed)
            {
                lblSearching.Text = "";
                updateTable();
                stringResponsed = false;
            }
        }

        private void updateTable()
        {
            if (responsedString != "" && responsedString != null)
            {
                lblFoundStatus.Text  = "Пользователь найден";
                string[] strSplitted = System.Text.RegularExpressions.Regex.Split(responsedString, @"<<row>>");
                dataTableIndent.Rows.Clear();
                toolButtonPanel.Visible = false;
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
                dataTableIndent.Rows.Clear();
                toolButtonPanel.Visible = false;
                lblFoundStatus.Text = "Пользователь не найден, добавьте его";
            }
            responsedString = null;
            

        }

        async void sendPostRequest()
        {
            requestIsStarted = true;
            try
            {
                WebTools postClass = new WebTools();

                string responseFromServer = postClass.postImageToServer("http://localhost:1111", "savedIdentifyFrame.jpg", "identify_and_search");
                
                string[] splitted = System.Text.RegularExpressions.Regex.Split(responseFromServer, @"<length>");
                
                //reader.Close();
                //dataStream.Close();
                //response.Close();
                string[] a = System.Text.RegularExpressions.Regex.Split(splitted[1], @"<content>");
                if (a[0] == "Succsess POST")
                {
                    requestIsStarted = false;
                    buttonEnable = true;
                    stringResponsed = true;
                    string resultingString = System.Text.RegularExpressions.Regex.Split(responseFromServer, @"<content>")[1];
                    responsedString = System.Text.RegularExpressions.Regex.Split(resultingString, @"<id>")[0];
                    idInDb = int.Parse(System.Text.RegularExpressions.Regex.Split(resultingString, @"<id>")[1]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                buttonEnable = true;
                requestIsStarted = false;
            }
            //finally
            //{
            //    requestIsStarted = false;
            //}

        }

        private string formingDataString()
        {
            string formedString = System.String.Empty;
            for (int i = 0; i < dataTableIndent.RowCount; i++)
            {
                formedString += "<<row>>" + (String)dataTableIndent["Название поля", i].Value + "=" + (String)dataTableIndent["Содержание поля", i].Value;
            }
            return formedString;
        }

        private void goIdentify_Click(object sender, EventArgs e)
        {
            //if (faceYep)
            //{
                readyToNewFace = true;
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

        private void dataTableIndent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            toolButtonPanel.Visible = true;
        }

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            deleteRecordTask = Task.Run(() => deleteRecord(idInDb));
            dataTableIndent.Rows.Clear();
        }        
        async void deleteRecord(int id)
        {
            WebTools deletingRecordOnServer = new WebTools();
            try
            {
                string response = deletingRecordOnServer.deleteRecordRequest("http://localhost:1111", id);
                if (response != "<OK>")
                {
                    MessageBox.Show("Не удалено");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        async void updateRecord(int id, string updatedString)
        {
            WebTools updatingRecordOnServer = new WebTools();
            try
            {
                string response = updatingRecordOnServer.updateRecordRequest("http://localhost:1111", id, updatedString);
                if (response != "<OK>")
                {
                    MessageBox.Show("Не обновлено");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void buttonUpdateRecord_Click(object sender, EventArgs e)
        {
            string updatedString = formingDataString();
            updateRecordTask = Task.Run(() => updateRecord(idInDb, updatedString));
        }

        private void buttonIdentify_Click(object sender, EventArgs e)
        {
            buttonEnable = true;
            readyToNewFace = true;
        }

        private void clearTable_Click(object sender, EventArgs e)
        {
            dataTableIndent.Rows.Clear();
        }
    }
}
