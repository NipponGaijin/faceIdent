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
using System.Web.Script.Serialization;

namespace faceRecognition
{

    public partial class FormIdentify : Form
    {
        List<string> filenames;
        FormCalibrateAndSetServer formSettings = new FormCalibrateAndSetServer();
        FormAddToDB formAddToDB = new FormAddToDB();
        FormFullTextSearch formFullTextSearch = new FormFullTextSearch();
        Capture capWebcam = null;
        getWebCam getWebCam = new getWebCam();
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        bool readyToIdentify = false;
        bool readyToNewFace = false;
        bool photoSaved = false;
        bool addingImageStarted = false;
        Task updateRecordTask;
        Task deleteRecordTask;
        Task sendPostRequestTask;
        static bool requestIsStarted;
        static int idInDb = 0;
        static bool stringResponsed = false;
        static bool buttonEnable = true;
        static string responsedString;
        public int maxFace;
        public int minFace;
        public string address = "";
        int currentIndex = 0;

        public FormIdentify()
        {
            InitializeComponent();
        }

        private void FormIdentify_Load(object sender, EventArgs e)
        {
            if (!File.Exists("settings.json"))
            {
                formSettings.identifyForm = this;
                formSettings.ShowDialog();
            }
            else
            {
                settingsLoad();
            }

            try
            {
                capWebcam = getWebCam.setCam();               // инициализируем объект записи с дефолтной вебки
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
            settingsSave();
            if (capWebcam != null)
            {
                getWebCam.disposeCam();
            }
            if (File.Exists("savedIdentifyFrame.jpg"))
            {
                File.Delete("savedIdentifyFrame.jpg");
            }
            deleteAllDownloadedFiles();
        }

        private void processFrameAndUpdGui(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = capWebcam.QueryFrame(); //.Resize(imageBox1.Width, imageBox1.Height, INTER.CV_INTER_LANCZOS4)
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            //Ищем признаки лица
            MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(cascade, 1.2, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(maxFace, maxFace));

            if (updateRecordTask != null && !updateRecordTask.IsCompleted)
            {
                toolButtonPanel.Enabled = false;
            }
            else
            {
                toolButtonPanel.Enabled = true;
            }

            buttonIdentify.Enabled = !requestIsStarted;
            btnAddNewImage.Enabled = !addingImageStarted;

            if (Faces[0].Length == 0)
            {
                lblInformation.Text = "Дождитесь, пока лицо будет обведено рамкой";
                readyToIdentify = false;
            }
            else
            {
                readyToIdentify = true;
            }

            if (Faces[0].Length > 1)
            {
                lblInformation.Text = "В кадре больше одного лица";
                readyToIdentify = false;
            }
            
            foreach (MCvAvgComp face in Faces[0])
            {
                //if (flag)
                //{
                if (Faces[0].Length > 0 && Faces[0].Length < 2)
                {
                    lblInformation.Text = "";
                    //buttonEnable = true;
                }
                image.Draw(face.rect, new Bgr(Color.Green), 6);
            }
            //Выводим обработаное приложение
            VideoBox.Image = image;
            
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
                currentIndex = 0;
                lblFoundStatus.Text  = "Пользователь найден";
                var jsonDict = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(responsedString);
                idInDb = jsonDict["id"];
                filenames = new List<string>(jsonDict["filenames"].Keys);
                Image<Rgb, Byte> downlodadedImage = new Image<Rgb, Byte>("images\\" + filenames[currentIndex]);
                IdentifyedUser.Image = downlodadedImage;
                List<string> listOfKeys = new List<string>(jsonDict["content"].Keys);
                dataTableIndent.Rows.Clear();
                toolButtonPanel.Visible = false;
                for (int i = 0; i < jsonDict["content"].Count; i++)
                {
                     dataTableIndent.Rows.Add();
                     dataTableIndent["Название поля", i].Value = (String)listOfKeys[i];
                     dataTableIndent["Содержание поля", i].Value = (String)jsonDict["content"][listOfKeys[i]];
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

                string responseFromServer = postClass.postImageToServer(address, "savedIdentifyFrame.jpg", "identify_and_search_user");
                
                string[] resultOfRequest = System.Text.RegularExpressions.Regex.Split(responseFromServer, @"<content>");
                if (resultOfRequest[0] == "Succsess POST")
                {
                    var jsonDict = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(resultOfRequest[1]);
                    List<string> listOfKeys = new List<string>(jsonDict["filenames"].Keys);
                    WebTools downloadTool = new WebTools();
                    for (int i = 0; i < listOfKeys.Count; i++)
                    {
                        downloadTool.downloadFileFromServer(listOfKeys[i], address);
                    }
                        
                    requestIsStarted = false;
                    //buttonEnable = true;
                    stringResponsed = true;
                    responsedString = resultOfRequest[1];
                }
                else if (resultOfRequest[0] == "NOTFOUND")
                {
                    responsedString = "";
                    requestIsStarted = false;
                    //buttonEnable = true;
                    stringResponsed = true;
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

        private void settingsSave()
        {
            Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
            dict.Add("address", address);
            dict.Add("maxFace", maxFace);
            dict.Add("minFace", minFace);
            string jsonString = new JavaScriptSerializer().Serialize(dict);
            File.WriteAllText("settings.json", jsonString);
        }
        private void settingsLoad()
        {
            var jsonDict = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(File.ReadAllText("settings.json"));
            address = jsonDict["address"];
            maxFace = jsonDict["maxFace"];
            minFace = jsonDict["minFace"];

        }
        private string formingDataString()
        {
            bool isNotOk = false;
            Dictionary<string, dynamic> dictOfTableInfo = new Dictionary<string, dynamic>();
            dictOfTableInfo.Add("id", idInDb);
            dictOfTableInfo.Add("content", new Dictionary<string, dynamic>());
            for (int i = 0; i < dataTableIndent.RowCount; i++)
            {
                if (!String.IsNullOrEmpty((String)dataTableIndent["Содержание поля", i].Value) && !String.IsNullOrEmpty((String)dataTableIndent["Название поля", i].Value))
                {
                    dictOfTableInfo["content"].Add((String)dataTableIndent["Название поля", i].Value, (String)dataTableIndent["Содержание поля", i].Value);
                }
                else
                {
                    MessageBox.Show("В строке " + (i + 1).ToString() + " пустое значение!!!");
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

        //private void goIdentify_Click(object sender, EventArgs e)
        //{
        //    ////if (faceYep)
        //    ////{
        //    //    readyToNewFace = true;
        //    ////}
           
                
            
        //}
        private void addUser_Click(object sender, EventArgs e)
        {

            formAddToDB.address = address;
            formAddToDB.maxFace = maxFace;
            formAddToDB.minFace = minFace;
            formAddToDB.ShowDialog();
            lblFoundStatus.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formFullTextSearch.address = address;
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
            IdentifyedUser.Image = null;
            toolButtonPanel.Visible = false;
        }        
        async void deleteRecord(int id)
        {
            WebTools deletingRecordOnServer = new WebTools();
            try
            {
                string response = deletingRecordOnServer.deleteRecordRequest(address, id);
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
                string response = updatingRecordOnServer.updateRecordRequest(address, id, updatedString);
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
            if (updatedString != "NOT OK")
            {
                updateRecordTask = Task.Run(() => updateRecord(idInDb, updatedString));
            }

        }

        private void buttonIdentify_Click(object sender, EventArgs e)
        {
            deleteAllDownloadedFiles();
            if (readyToIdentify)
            {
                try
                {
                    Image<Bgr, byte> imageToPost = capWebcam.QueryFrame();
                    imageToPost.Save("savedIdentifyFrame.jpg");
                    lblFoundStatus.Text = "";
                    lblSearching.Text = "Идет поиск, ожидайте...";
                    sendPostRequestTask = Task.Run(() => sendPostRequest());
                }
                catch (Exception exc) { MessageBox.Show(exc.ToString()); }
            }
        }

        private void clearTable_Click(object sender, EventArgs e)
        {
            dataTableIndent.Rows.Clear();
            toolButtonPanel.Visible = false;
        }


        private void settings_Click(object sender, EventArgs e)
        {
            formSettings.identifyForm = this;
            formSettings.faceMax = maxFace;
            formSettings.faceMin = minFace;
            formSettings.address = address;
            formSettings.ShowDialog();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < filenames.Count - 1)
            {
                currentIndex++;
                Image<Bgr, Byte> viewedImage = new Image<Bgr, byte>("images\\" + filenames[currentIndex]);
                IdentifyedUser.Image = viewedImage;
            }
            else
            {
                currentIndex = 0;
                Image<Bgr, Byte> viewedImage = new Image<Bgr, byte>("images\\" + filenames[currentIndex]);
                IdentifyedUser.Image = viewedImage;
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex == 0)
            {
                currentIndex = filenames.Count - 1;
                Image<Bgr, Byte> viewedImage = new Image<Bgr, byte>("images\\" + filenames[currentIndex]);
                IdentifyedUser.Image = viewedImage;
            }
            else
            {
                currentIndex--;
                Image<Bgr, Byte> viewedImage = new Image<Bgr, byte>("images\\" + filenames[currentIndex]);
                IdentifyedUser.Image = viewedImage;
            }
        }
        private void deleteAllDownloadedFiles()
        {
            string[] filesToDelete = Directory.GetFiles("images");
            foreach (var v in filesToDelete)
            {
                File.Delete(v);
            }
        }

        private void btnAddNewImage_Click(object sender, EventArgs e)
        {
            if (idInDb != 0 && readyToIdentify)
            {
                Image<Bgr, Byte> imageToAdd = capWebcam.QueryFrame();
                imageToAdd.Save("imageToAdd.jpg");
                Task addNewImageTask = Task.Run(() => addNewImage(idInDb));
            }
        }
        async void addNewImage(int id)
        {
            addingImageStarted = true;
            try
            {
                WebTools addImage = new WebTools();
                string request = addImage.postImageToServer(address, "imageToAdd.jpg", "add_new_image", id.ToString());
                if (request == "<UPDATED>")
                {
                    addingImageStarted = false;
                    MessageBox.Show("Добавлено".ToString());
                }
                else
                {
                    addingImageStarted = false;
                    MessageBox.Show("Не добавлено".ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                addingImageStarted = false;
            }
        }
    }
}
