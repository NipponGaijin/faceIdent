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
            this.buttonUpdateRecord = new System.Windows.Forms.Button();
            this.buttonDeleteRecord = new System.Windows.Forms.Button();
            this.dataTableIndent = new System.Windows.Forms.DataGridView();
            this.clearTable = new System.Windows.Forms.Button();
            this.labelInfoFlowLayout.SuspendLayout();
            this.buttonsFlowLayout.SuspendLayout();
            this.tableTools.SuspendLayout();
            this.tableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.toolButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIndent)).BeginInit();
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
            this.labelInfoFlowLayout.Location = new System.Drawing.Point(152, 3);
            this.labelInfoFlowLayout.Name = "labelInfoFlowLayout";
            this.labelInfoFlowLayout.Size = new System.Drawing.Size(445, 52);
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
            this.btnAddUser.Location = new System.Drawing.Point(725, 3);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(126, 52);
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
            this.buttonsFlowLayout.Location = new System.Drawing.Point(0, 325);
            this.buttonsFlowLayout.Name = "buttonsFlowLayout";
            this.buttonsFlowLayout.Size = new System.Drawing.Size(987, 61);
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
            this.tableTools.Location = new System.Drawing.Point(15, 3);
            this.tableTools.Name = "tableTools";
            this.tableTools.RowCount = 1;
            this.tableTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTools.Size = new System.Drawing.Size(969, 58);
            this.tableTools.TabIndex = 45;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(857, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 52);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Искать пользователя";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // buttonIdentify
            // 
            this.buttonIdentify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIdentify.Location = new System.Drawing.Point(603, 3);
            this.buttonIdentify.Name = "buttonIdentify";
            this.buttonIdentify.Size = new System.Drawing.Size(116, 52);
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
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.tableContainer.Controls.Add(this.VideoBox, 0, 0);
            this.tableContainer.Controls.Add(this.toolButtonPanel, 1, 0);
            this.tableContainer.Controls.Add(this.dataTableIndent, 2, 0);
            this.tableContainer.Location = new System.Drawing.Point(12, 12);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 1;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableContainer.Size = new System.Drawing.Size(969, 300);
            this.tableContainer.TabIndex = 49;
            // 
            // VideoBox
            // 
            this.VideoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoBox.Location = new System.Drawing.Point(3, 3);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(452, 294);
            this.VideoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VideoBox.TabIndex = 50;
            this.VideoBox.TabStop = false;
            // 
            // toolButtonPanel
            // 
            this.toolButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolButtonPanel.ColumnCount = 1;
            this.toolButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.toolButtonPanel.Controls.Add(this.buttonUpdateRecord);
            this.toolButtonPanel.Controls.Add(this.buttonDeleteRecord, 0, 1);
            this.toolButtonPanel.Controls.Add(this.clearTable, 0, 2);
            this.toolButtonPanel.Location = new System.Drawing.Point(461, 3);
            this.toolButtonPanel.Name = "toolButtonPanel";
            this.toolButtonPanel.RowCount = 3;
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.54945F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.45055F));
            this.toolButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.toolButtonPanel.Size = new System.Drawing.Size(104, 128);
            this.toolButtonPanel.TabIndex = 52;
            // 
            // buttonUpdateRecord
            // 
            this.buttonUpdateRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUpdateRecord.Location = new System.Drawing.Point(3, 3);
            this.buttonUpdateRecord.Name = "buttonUpdateRecord";
            this.buttonUpdateRecord.Size = new System.Drawing.Size(98, 37);
            this.buttonUpdateRecord.TabIndex = 0;
            this.buttonUpdateRecord.Text = "Редактировать\r\nзапись\r\n";
            this.buttonUpdateRecord.UseVisualStyleBackColor = true;
            this.buttonUpdateRecord.Click += new System.EventHandler(this.buttonUpdateRecord_Click);
            // 
            // buttonDeleteRecord
            // 
            this.buttonDeleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteRecord.Location = new System.Drawing.Point(3, 46);
            this.buttonDeleteRecord.Name = "buttonDeleteRecord";
            this.buttonDeleteRecord.Size = new System.Drawing.Size(98, 36);
            this.buttonDeleteRecord.TabIndex = 1;
            this.buttonDeleteRecord.Text = "Удалить\r\nзапись";
            this.buttonDeleteRecord.UseVisualStyleBackColor = true;
            this.buttonDeleteRecord.Click += new System.EventHandler(this.buttonDeleteRecord_Click);
            // 
            // dataTableIndent
            // 
            this.dataTableIndent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataTableIndent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataTableIndent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableIndent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableIndent.Location = new System.Drawing.Point(571, 3);
            this.dataTableIndent.Name = "dataTableIndent";
            this.dataTableIndent.RowHeadersVisible = false;
            this.dataTableIndent.Size = new System.Drawing.Size(395, 294);
            this.dataTableIndent.TabIndex = 51;
            this.dataTableIndent.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableIndent_CellValueChanged);
            // 
            // clearTable
            // 
            this.clearTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearTable.Location = new System.Drawing.Point(3, 88);
            this.clearTable.Name = "clearTable";
            this.clearTable.Size = new System.Drawing.Size(98, 37);
            this.clearTable.TabIndex = 2;
            this.clearTable.Text = "Очистить таблицу";
            this.clearTable.UseVisualStyleBackColor = true;
            this.clearTable.Click += new System.EventHandler(this.clearTable_Click);
            // 
            // FormIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 386);
            this.Controls.Add(this.tableContainer);
            this.Controls.Add(this.buttonsFlowLayout);
            this.MinimumSize = new System.Drawing.Size(1000, 425);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIndent)).EndInit();
            this.ResumeLayout(false);

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




    }
}