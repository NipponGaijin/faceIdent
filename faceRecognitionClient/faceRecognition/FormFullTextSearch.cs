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
using System.IO.Compression;
using System.Text.RegularExpressions;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cvb;
using Emgu.Util;

namespace faceRecognition
{
    public partial class FormFullTextSearch : Form
    {
        List<Record> listOfRecords = new List<Record>();
        int currentID;
        int viewedID = 0;

        class Record
        {   // : IEquatable<Record>
            public int Id { get; set; }
            public string Body { get; set; }
            public string FileName { get; set; }
        }

        public FormFullTextSearch()
        {
            InitializeComponent();
        }

        private void FormFullTextSearch_Load(object sender, EventArgs e)
        {
            searchingResults.ColumnCount = 2;
            searchingResults.Columns[0].Name = "Название поля";
            searchingResults.Columns[1].Name = "Содержание поля";
            searchingResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            searchingResults.AllowUserToAddRows = false;
            lableInfo.Text = "";
            lablelCoincidences.Text = "";
            try
            {
                using (WebTools getInfo = new WebTools())
                {
                    labelTotal.Text = "Количество людей в базе: " + getInfo.getUserCountFromServer("http://localhost:1111");
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.ToString());
                this.Close();
            }
        }

        private void searchingRequest()
        {
            try
            {
                lableInfo.Text = "Идет поиск....";
                string searchPhrase = txtSearchInfo.Text;
                WebTools postImageAndInfo = new WebTools();
                byte[] data = postImageAndInfo.fullTextSearchRequest("http://localhost:1111", searchPhrase);
                if (Encoding.UTF8.GetString(data) != "<NOTFOUND>")
                {
                    enableButtons();
                    if (Directory.Exists("archive"))
                    {
                        Directory.Delete("archive", true);
                    }
                    File.WriteAllBytes("1.zip", data);
                    ZipFile.ExtractToDirectory("1.zip", "archive");
                    if (File.Exists("1.zip"))
                    {
                        File.Delete("1.zip");
                    }
                    string[] strSplitted = Regex.Split(Encoding.UTF8.GetString(data), @"<textBegin>");
                    stringProcessAndListForming(strSplitted[1]);
                }
                else
                {
                    stringProcessAndListForming("");
                }
                //byte[] bytes = Encoding.UTF8.GetBytes(readedResponse);
                
            }
            catch (Exception e){
                MessageBox.Show(e.ToString());
            }
            
        }

        private void stringProcessAndListForming(string responsedString)
        {
            if (!string.IsNullOrWhiteSpace(responsedString))
            {
                listOfRecords.Clear();
                lableInfo.Text = "Успешно.";
                string[] strSplitted = System.Text.RegularExpressions.Regex.Split(responsedString, @"<end>");
                for (int i = 0; i < strSplitted.Length; i++)
                {
                    if (strSplitted[i].Length != 0)
                    {
                        int Id = int.Parse(Regex.Split(strSplitted[i], @"<id>")[0]);
                        string Body = Regex.Split(Regex.Split(strSplitted[i], @"<id>")[1], @"<filename>")[0];
                        string FileName = Regex.Split(Regex.Split(strSplitted[i], @"<id>")[1], @"<filename>")[1];
                
                        listOfRecords.Add(new Record
                        {   Id = Id,
                            Body = Body,
                            FileName = FileName});
                    }
                    
                }
                updateGUI(0);

            }
            else
            {
                lableInfo.Text = "Ничего не найдено.";
                lablelCoincidences.Text = "Количество совпадений: 0";
                clearGUI();
            }
        }

        private void updateGUI(int index)
        {
            //Обновляем таблицу.
            enableButtons(); 
            lablelCoincidences.Text = "Количество совпадений: " + listOfRecords.Count.ToString();
            string body = listOfRecords[index].Body;
            currentID = listOfRecords[index].Id;
            string[] splittedBody = Regex.Split(body, @"<<row>>");
            searchingResults.Rows.Clear();
            for (int i = 0; i < splittedBody.Length; i++)
            {
                if (splittedBody[i] != "")
                {
                    searchingResults.Rows.Add();
                    searchingResults.Rows[i - 1].Cells["Название поля"].Value = (String)splittedBody[i].Split('=')[0];
                    searchingResults.Rows[i - 1].Cells["Содержание поля"].Value = (String)splittedBody[i].Split('=')[1];
                }
            }
            //string path = ;
            Image<Rgb, Byte> img = new Image<Rgb, Byte>("archive\\archive_dir\\" + listOfRecords[index].FileName);
            Image<Rgb, Byte> resized = img.Resize(img.Width / 4, img.Height / 4, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            image.Image = resized;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchInfo.Text.ToString()))
            {
                searchingRequest();
            }
            
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            
            if (viewedID < listOfRecords.Count() - 1 && listOfRecords.Count != 0)
            {
                viewedID++;
                updateGUI(viewedID);
                
            }
            else if (listOfRecords.Count != 0)
            {
                viewedID = 0;
                updateGUI(viewedID);
            }
            else
            {
                lableInfo.Text = "Список пуст.";
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (viewedID == 0 && listOfRecords.Count != 0)
            {
                viewedID = listOfRecords.Count - 1;
                updateGUI(viewedID);
            }
            else if (listOfRecords.Count != 0)
            {
                viewedID--;
                updateGUI(viewedID);
            }
            else
            {
                lableInfo.Text = "Список пуст.";
            }
        }

        private void deleteRecord_Click(object sender, EventArgs e)
        {
            deleteRecordAndUpdateForm();
        }

        private void deleteRecordAndUpdateForm()
        {
            if (listOfRecords.Count != 0)
            {
                int id = listOfRecords[viewedID].Id;
                try
                {
                    lableInfo.Text = "Идет удаление....";
                    WebTools deleteInfoFromServer = new WebTools();
                    string response = deleteInfoFromServer.deleteRecordRequest("http://localhost:1111", listOfRecords[viewedID].Id);
                    if (response == "<OK>")
                    {
                        lableInfo.Text = "Успешно удалено";
                        listOfRecords.RemoveAt(viewedID);
                        labelTotal.Text = "Количество людей в базе:" + listOfRecords.Count.ToString();
                        if (listOfRecords.Count == 0)
                        {
                            clearGUI();
                        }
                        else
                        {
                            if (viewedID != 0)
                            {
                                viewedID--;
                                updateGUI(viewedID);
                            }
                            else
                            {
                                updateGUI(0);
                            }
                        }
                    }
                    else
                    {
                        lableInfo.Text = "Не удалено";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }   
        }

        private void clearGUI()
        {
            searchingResults.Rows.Clear();
            lablelCoincidences.Text = "";
            image.Image = null;
            buttonNext.Enabled = false;
            buttonPrev.Enabled = false;
            deleteRecord.Enabled = false;
            updateRecord.Enabled = false;
        }

        private void enableButtons()
        {
            buttonNext.Enabled = true;
            buttonPrev.Enabled = true;
            deleteRecord.Enabled = true;
            updateRecord.Enabled = true;
        }

        private void disableButtons()
        {
            buttonNext.Enabled = false;
            buttonPrev.Enabled = false;
            deleteRecord.Enabled = false;
            updateRecord.Enabled = false;
        }

        private void sendUpdateRequest()
        {
            if (listOfRecords.Count != 0)
            {
                string formedString = System.String.Empty;
                for (int i = 0; i < searchingResults.RowCount-1; i++)
                {
                    formedString += "<<row>>" + (String)searchingResults["Название поля", i].Value + "=" + (String)searchingResults["Содержание поля", i].Value;
                }
                //formedString = "update_record<method><text>" + formedString;
                try
                {
                    lableInfo.Text = "Идет обновление....";
                    string searchPhrase = txtSearchInfo.Text;
                    int id = listOfRecords[viewedID].Id;
                    WebTools updateRecordFromServer = new WebTools();
                    string response = updateRecordFromServer.updateRecordRequest("http://localhost:1111", listOfRecords[viewedID].Id, formedString);
                    if (response == "<OK>")
                    {
                        lableInfo.Text = "Успешно обновлено";
                    }
                    else
                    {
                        lableInfo.Text = "Не обновлено";
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void updateRecord_Click(object sender, EventArgs e)
        {
            sendUpdateRequest();
        }
    }
}
