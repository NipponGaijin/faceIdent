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
using System.Web.Script.Serialization;


namespace faceRecognition
{
    public partial class FormFullTextSearch : Form
    {
        List<Record> listOfRecords = new List<Record>();
        int currentID;
        int viewedID = 0;
        public string address;

        class Record
        {   // : IEquatable<Record>
            public int Id { get; set; }
            public Dictionary<string, dynamic> jsonStringDict { get; set; }
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
                    labelTotal.Text = "Количество людей в базе: " + getInfo.getUserCountFromServer(address);
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
                string data = postImageAndInfo.fullTextSearchRequest(address, searchPhrase);
                if (data != "NOTFOUND")
                {
                    enableButtons();
                    stringProcessAndListForming(data);
                }
                else
                {
                    stringProcessAndListForming("");
                }
                
            }
            catch (Exception e){
                MessageBox.Show(e.ToString());
            }
            
        }

        private void stringProcessAndListForming(string responsedString)
        {
            if (!string.IsNullOrWhiteSpace(responsedString))
            {
                WebTools downloadFileWebTool = new WebTools();
                listOfRecords.Clear();
                lableInfo.Text = "Успешно.";
                var jsonDict = new JavaScriptSerializer().Deserialize<Dictionary<string, dynamic>>(responsedString);
                List<string> listOfKeys = new List<string>(jsonDict.Keys);
                for (int i = 0; i < listOfKeys.Count; i++)
                {
                    downloadFileWebTool.downloadFileFromServer(jsonDict[listOfKeys[i]]["filename"], address);
                    
                    listOfRecords.Add(new Record
                    {
                        Id = jsonDict[listOfKeys[i]]["id"],
                        jsonStringDict = jsonDict[listOfKeys[i]]["record_content"],
                        FileName = jsonDict[listOfKeys[i]]["filename"]
                    });
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
            Dictionary<string, dynamic> jsonDict = listOfRecords[index].jsonStringDict;
            currentID = listOfRecords[index].Id;
            List<string> listOfRecordKeys = new List<string>(jsonDict.Keys);
            searchingResults.Rows.Clear();

            for (int i = 0; i < listOfRecordKeys.Count; i++)
            {
                searchingResults.Rows.Add();
                searchingResults.Rows[i].Cells["Название поля"].Value = (String)listOfRecordKeys[i];
                searchingResults.Rows[i].Cells["Содержание поля"].Value = (String)jsonDict[listOfRecordKeys[i]];
            }
            //string path = ;
            Image<Rgb, Byte> img = new Image<Rgb, Byte>("images\\" + listOfRecords[index].FileName.ToString());
            image.Image = img;
            img = null;
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
                    string response = deleteInfoFromServer.deleteRecordRequest(address, listOfRecords[viewedID].Id);
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
                bool isNotOk = false;
                Dictionary<string, dynamic> dictOfTableInfo = new Dictionary<string, dynamic>();
                dictOfTableInfo.Add("id", currentID);
                dictOfTableInfo.Add("content", new Dictionary<string, dynamic>());
                for (int i = 0; i < searchingResults.RowCount; i++)
                {
                    if (!String.IsNullOrEmpty((String)searchingResults["Содержание поля", i].Value) && !String.IsNullOrEmpty((String)searchingResults["Название поля", i].Value))
                    {
                        dictOfTableInfo["content"].Add((String)searchingResults["Название поля", i].Value, (String)searchingResults["Содержание поля", i].Value);
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
                    try
                    {
                        lableInfo.Text = "Идет обновление....";
                        string searchPhrase = txtSearchInfo.Text;
                        int id = listOfRecords[viewedID].Id;
                        WebTools updateRecordFromServer = new WebTools();
                        string response = updateRecordFromServer.updateRecordRequest(address, listOfRecords[viewedID].Id, jsonString);
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
                //formedString = "update_record<method><text>" + formedString;
                
            }
        }

        private void updateRecord_Click(object sender, EventArgs e)
        {
            sendUpdateRequest();
        }

    }
}
