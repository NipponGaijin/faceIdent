namespace faceRecognition
{
    partial class FormIdentify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelInfoFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblFoundStatus = new System.Windows.Forms.Label();
            this.lblSearching = new System.Windows.Forms.Label();
            this.lblUpdateDeleteInfo = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.buttonsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.tableTools = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.buttonIdentify = new System.Windows.Forms.Button();
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.VideoBox = new Emgu.CV.UI.ImageBox();
            this.toolButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.clearTable = new System.Windows.Forms.Button();
            this.buttonUpdateRecord = new System.Windows.Forms.Button();
            this.buttonDeleteRecord = new System.Windows.Forms.Button();
            this.IdentifyedUser = new Emgu.CV.UI.ImageBox();
            this.navButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.btnAddNewImage = new System.Windows.Forms.Button();
            this.dataTableIndent = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settings = new System.Windows.Forms.ToolStripMenuItem();
            this.labelInfoFlowLayout.SuspendLayout();
            this.buttonsFlowLayout.SuspendLayout();
            this.tableTools.SuspendLayout();
            this.tableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.toolButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdentifyedUser)).BeginInit();
            this.navButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIndent)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfoFlowLayout
            // 
            this.labelInfoFlowLayout.Controls.Add(this.lblInformation);
            this.labelInfoFlowLayout.Controls.Add(this.lblFoundStatus);
            this.labelInfoFlowLayout.Controls.Add(this.lblSearching);
            this.labelInfoFlowLayout.Controls.Add(this.lblUpdateDeleteInfo);
            this.labelInfoFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfoFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.labelInfoFlowLayout.Location = new System.Drawing.Point(164, 3);
            this.labelInfoFlowLayout.Name = "labelInfoFlowLayout";
            this.labelInfoFlowLayout.Size = new System.Drawing.Size(445, 57);
            this.labelInfoFlowLayout.TabIndex = 44;
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(3, 0);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(0, 13);
            this.lblInformation.TabIndex = 43;
            // 
            // lblFoundStatus
            // 
            this.lblFoundStatus.AutoSize = true;
            this.lblFoundStatus.Location = new System.Drawing.Point(3, 13);
            this.lblFoundStatus.Name = "lblFoundStatus";
            this.lblFoundStatus.Size = new System.Drawing.Size(0, 13);
            this.lblFoundStatus.TabIndex = 44;
            // 
            // lblSearching
            // 
            this.lblSearching.AutoSize = true;
            this.lblSearching.Location = new System.Drawing.Point(3, 26);
            this.lblSearching.Name = "lblSearching";
            this.lblSearching.Size = new System.Drawing.Size(0, 13);
            this.lblSearching.TabIndex = 45;
            // 
            // lblUpdateDeleteInfo
            // 
            this.lblUpdateDeleteInfo.AutoSize = true;
            this.lblUpdateDeleteInfo.Location = new System.Drawing.Point(3, 39);
            this.lblUpdateDeleteInfo.Name = "lblUpdateDeleteInfo";
            this.lblUpdateDeleteInfo.Size = new System.Drawing.Size(0, 13);
            this.lblUpdateDeleteInfo.TabIndex = 46;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddUser.Location = new System.Drawing.Point(737, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(126, 57);
            this.btnAddUser.TabIndex = 39;
            this.btnAddUser.Text = "Добавить пользователя в базу";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // buttonsFlowLayout
            // 
            this.buttonsFlowLayout.Controls.Add(this.tableTools);
            this.buttonsFlowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonsFlowLayout.Location = new System.Drawing.Point(0, 402);
            this.buttonsFlowLayout.Name = "buttonsFlowLayout";
            this.buttonsFlowLayout.Size = new System.Drawing.Size(1031, 66);
            this.buttonsFlowLayout.TabIndex = 46;
            // 
            // tableTools
            // 
            this.tableTools.ColumnCount = 5;
            this.tableTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.tableTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableTools.Controls.Add(this.labelInfoFlowLayout, 1, 0);
            this.tableTools.Controls.Add(this.btnSearch, 4, 0);
            this.tableTools.Controls.Add(this.btnAddUser, 3, 0);
            this.tableTools.Controls.Add(this.buttonIdentify, 2, 0);
            this.tableTools.Location = new System.Drawing.Point(47, 3);
            this.tableTools.Name = "tableTools";
            this.tableTools.RowCount = 1;
            this.tableTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTools.Size = new System.Drawing.Size(981, 63);
            this.tableTools.TabIndex = 45;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(869, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 57);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Искать пользователя";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // buttonIdentify
            // 
            this.buttonIdentify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIdentify.Location = new System.Drawing.Point(615, 3);
            this.buttonIdentify.Name = "buttonIdentify";
            this.buttonIdentify.Size = new System.Drawing.Size(116, 57);
            this.buttonIdentify.TabIndex = 45;
            this.buttonIdentify.Text = "Идентифицировать";
            this.buttonIdentify.UseVisualStyleBackColor = true;
            this.buttonIdentify.Click += new System.EventHandler(this.buttonIdentify_Click);
            // 
            // tableContainer
            // 
            this.tableContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableContainer.ColumnCount = 3;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374F));
            this.tableContainer.Controls.Add(this.VideoBox, 0, 0);
            this.tableContainer.Controls.Add(this.toolButtonPanel, 1, 0);
            this.tableContainer.Controls.Add(this.dataTableIndent, 2, 0);
            this.tableContainer.Location = new System.Drawing.Point(12, 23);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 1;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.Size = new System.Drawing.Size(1016, 381);
            this.tableContainer.TabIndex = 49;
            // 
            // VideoBox
            // 
            this.VideoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoBox.Location = new System.Drawing.Point(3, 3);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(473, 375);
            this.VideoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VideoBox.TabIndex = 50;
            this.VideoBox.TabStop = false;
            // 
            // toolButtonPanel
            // 
            this.toolButtonPanel.ColumnCount = 1;
            this.toolButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolButtonPanel.Controls.Add(this.clearTable, 0, 2);
            this.toolButtonPanel.Controls.Add(this.buttonUpdateRecord, 0, 0);
            this.toolButtonPanel.Controls.Add(this.buttonDeleteRecord, 0, 1);
            this.toolButtonPanel.Controls.Add(this.IdentifyedUser, 0, 3);
            this.toolButtonPanel.Controls.Add(this.navButtons, 0, 4);
            this.toolButtonPanel.Controls.Add(this.btnAddNewImage, 0, 5);
            this.toolButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolButtonPanel.Location = new System.Drawing.Point(482, 3);
            this.toolButtonPanel.Name = "toolButtonPanel";
            this.toolButtonPanel.RowCount = 7;
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.toolButtonPanel.Size = new System.Drawing.Size(157, 375);
            this.toolButtonPanel.TabIndex = 52;
            // 
            // clearTable
            // 
            this.clearTable.Location = new System.Drawing.Point(3, 83);
            this.clearTable.Name = "clearTable";
            this.clearTable.Size = new System.Drawing.Size(151, 34);
            this.clearTable.TabIndex = 2;
            this.clearTable.Text = "Очистить таблицу";
            this.clearTable.UseVisualStyleBackColor = true;
            this.clearTable.Click += new System.EventHandler(this.clearTable_Click);
            // 
            // buttonUpdateRecord
            // 
            this.buttonUpdateRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpdateRecord.Location = new System.Drawing.Point(3, 3);
            this.buttonUpdateRecord.Name = "buttonUpdateRecord";
            this.buttonUpdateRecord.Size = new System.Drawing.Size(151, 34);
            this.buttonUpdateRecord.TabIndex = 0;
            this.buttonUpdateRecord.Text = "Редактировать\r\nзапись\r\n";
            this.buttonUpdateRecord.UseVisualStyleBackColor = true;
            this.buttonUpdateRecord.Click += new System.EventHandler(this.buttonUpdateRecord_Click);
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteRecord.Location = new System.Drawing.Point(3, 43);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(151, 34);
            this.buttonDeleteRecord.TabIndex = 1;
            this.buttonDeleteRecord.Text = "Удалить\r\nзапись";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.buttonDeleteRecord_Click);
            // 
            // IdentifyedUser
            // 
            this.IdentifyedUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.IdentifyedUser.Location = new System.Drawing.Point(3, 123);
            this.IdentifyedUser.Name = "IdentifyedUser";
            this.IdentifyedUser.Size = new System.Drawing.Size(150, 149);
            this.IdentifyedUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IdentifyedUser.TabIndex = 2;
            this.IdentifyedUser.TabStop = false;
            // 
            // navButtons
            // 
            this.navButtons.ColumnCount = 2;
            this.navButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.navButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.navButtons.Controls.Add(this.buttonPrev, 1, 0);
            this.navButtons.Controls.Add(this.buttonNext, 0, 0);
            this.navButtons.Location = new System.Drawing.Point(3, 278);
            this.navButtons.Name = "navButtons";
            this.navButtons.RowCount = 1;
            this.navButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.navButtons.Size = new System.Drawing.Size(151, 31);
            this.navButtons.TabIndex = 3;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrev.Location = new System.Drawing.Point(78, 3);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(70, 25);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Text = "Prev.";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Location = new System.Drawing.Point(3, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(69, 25);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // btnAddNewImage
            // 
            this.btnAddNewImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddNewImage.Location = new System.Drawing.Point(3, 315);
            this.btnAddNewImage.Name = "btnAddNewImage";
            this.btnAddNewImage.Size = new System.Drawing.Size(151, 39);
            this.btnAddNewImage.TabIndex = 4;
            this.btnAddNewImage.Text = "Добавить новое изображение";
            this.btnAddNewImage.UseVisualStyleBackColor = true;
            this.btnAddNewImage.Click += new System.EventHandler(this.btnAddNewImage_Click);
            // 
            // dataTableIndent
            // 
            this.dataTableIndent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTableIndent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataTableIndent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataTableIndent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableIndent.Location = new System.Drawing.Point(645, 3);
            this.dataTableIndent.Name = "dataTableIndent";
            this.dataTableIndent.RowHeadersVisible = false;
            this.dataTableIndent.Size = new System.Drawing.Size(368, 375);
            this.dataTableIndent.TabIndex = 51;
            this.dataTableIndent.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableIndent_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 24);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menu";
            // 
            // settings
            // 
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(79, 20);
            this.settings.Text = "Настройки";
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // FormIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 468);
            this.Controls.Add(this.tableContainer);
            this.Controls.Add(this.buttonsFlowLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1036, 491);
            this.Name = "FormIdentify";
            this.Text = "Идентификация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormIdentify_FormClosed);
            this.Load += new System.EventHandler(this.FormIdentify_Load);
            this.labelInfoFlowLayout.ResumeLayout(false);
            this.labelInfoFlowLayout.PerformLayout();
            this.buttonsFlowLayout.ResumeLayout(false);
            this.tableTools.ResumeLayout(false);
            this.tableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).EndInit();
            this.toolButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IdentifyedUser)).EndInit();
            this.navButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIndent)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel labelInfoFlowLayout;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblFoundStatus;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowLayout;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableContainer;
        private System.Windows.Forms.DataGridView dataTableIndent;
        private Emgu.CV.UI.ImageBox VideoBox;
        private System.Windows.Forms.Label lblSearching;
        private System.Windows.Forms.TableLayoutPanel tableTools;
        private System.Windows.Forms.TableLayoutPanel toolButtonPanel;
        private System.Windows.Forms.Button buttonUpdateRecord;
        private System.Windows.Forms.Button buttonDeleteRecord;
        private System.Windows.Forms.Label lblUpdateDeleteInfo;
        private System.Windows.Forms.Button buttonIdentify;
        private System.Windows.Forms.Button clearTable;
        private Emgu.CV.UI.ImageBox IdentifyedUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settings;
        private System.Windows.Forms.TableLayoutPanel navButtons;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button btnAddNewImage;




    }
}