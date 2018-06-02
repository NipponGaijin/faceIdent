namespace faceRecognition
{
    partial class FormFullTextSearch
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
            this.formContent = new System.Windows.Forms.TableLayoutPanel();
            this.searchingResults = new System.Windows.Forms.DataGridView();
            this.toolsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableTextBox = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchInfo = new System.Windows.Forms.TextBox();
            this.tableRightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deleteRecord = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.updateRecord = new System.Windows.Forms.Button();
            this.lableInfo = new System.Windows.Forms.Label();
            this.topTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.image = new Emgu.CV.UI.ImageBox();
            this.ButtonsAndLables = new System.Windows.Forms.TableLayoutPanel();
            this.tableButtonsNextPrev = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lablelCoincidences = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.formContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchingResults)).BeginInit();
            this.toolsPanel.SuspendLayout();
            this.tableTextBox.SuspendLayout();
            this.tableRightPanel.SuspendLayout();
            this.topTable.SuspendLayout();
            this.tableLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.ButtonsAndLables.SuspendLayout();
            this.tableButtonsNextPrev.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formContent
            // 
            this.formContent.ColumnCount = 2;
            this.formContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formContent.Controls.Add(this.searchingResults, 0, 0);
            this.formContent.Controls.Add(this.toolsPanel, 1, 0);
            this.formContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formContent.Location = new System.Drawing.Point(173, 3);
            this.formContent.Name = "formContent";
            this.formContent.RowCount = 1;
            this.formContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formContent.Size = new System.Drawing.Size(775, 266);
            this.formContent.TabIndex = 0;
            // 
            // searchingResults
            // 
            this.searchingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchingResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchingResults.Location = new System.Drawing.Point(3, 3);
            this.searchingResults.Name = "searchingResults";
            this.searchingResults.Size = new System.Drawing.Size(381, 260);
            this.searchingResults.TabIndex = 0;
            // 
            // toolsPanel
            // 
            this.toolsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolsPanel.ColumnCount = 1;
            this.toolsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolsPanel.Controls.Add(this.tableTextBox, 0, 0);
            this.toolsPanel.Location = new System.Drawing.Point(390, 3);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.RowCount = 1;
            this.toolsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolsPanel.Size = new System.Drawing.Size(382, 260);
            this.toolsPanel.TabIndex = 1;
            // 
            // tableTextBox
            // 
            this.tableTextBox.ColumnCount = 1;
            this.tableTextBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTextBox.Controls.Add(this.txtSearchInfo, 0, 0);
            this.tableTextBox.Controls.Add(this.tableRightPanel, 0, 1);
            this.tableTextBox.Controls.Add(this.lableInfo, 0, 2);
            this.tableTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTextBox.Location = new System.Drawing.Point(3, 3);
            this.tableTextBox.Name = "tableTextBox";
            this.tableTextBox.RowCount = 3;
            this.tableTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableTextBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableTextBox.Size = new System.Drawing.Size(376, 254);
            this.tableTextBox.TabIndex = 2;
            // 
            // txtSearchInfo
            // 
            this.txtSearchInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchInfo.Location = new System.Drawing.Point(3, 3);
            this.txtSearchInfo.Name = "txtSearchInfo";
            this.txtSearchInfo.Size = new System.Drawing.Size(370, 20);
            this.txtSearchInfo.TabIndex = 1;
            // 
            // tableRightPanel
            // 
            this.tableRightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableRightPanel.ColumnCount = 1;
            this.tableRightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRightPanel.Controls.Add(this.deleteRecord, 0, 2);
            this.tableRightPanel.Controls.Add(this.btnSearch, 0, 0);
            this.tableRightPanel.Controls.Add(this.updateRecord, 0, 1);
            this.tableRightPanel.Location = new System.Drawing.Point(257, 28);
            this.tableRightPanel.Name = "tableRightPanel";
            this.tableRightPanel.RowCount = 3;
            this.tableRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableRightPanel.Size = new System.Drawing.Size(116, 117);
            this.tableRightPanel.TabIndex = 2;
            // 
            // deleteRecord
            // 
            this.deleteRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteRecord.Location = new System.Drawing.Point(3, 79);
            this.deleteRecord.Name = "deleteRecord";
            this.deleteRecord.Size = new System.Drawing.Size(110, 35);
            this.deleteRecord.TabIndex = 2;
            this.deleteRecord.Text = "Удалить\r\nзапись\r\n";
            this.deleteRecord.UseVisualStyleBackColor = true;
            this.deleteRecord.Click += new System.EventHandler(this.deleteRecord_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.ImageKey = "(none)";
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 27);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Искать";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // updateRecord
            // 
            this.updateRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateRecord.Location = new System.Drawing.Point(3, 36);
            this.updateRecord.Name = "updateRecord";
            this.updateRecord.Size = new System.Drawing.Size(110, 37);
            this.updateRecord.TabIndex = 1;
            this.updateRecord.Text = "Редактировать\r\nзапись\r\n";
            this.updateRecord.UseVisualStyleBackColor = true;
            this.updateRecord.Click += new System.EventHandler(this.updateRecord_Click);
            // 
            // lableInfo
            // 
            this.lableInfo.AutoSize = true;
            this.lableInfo.Location = new System.Drawing.Point(3, 153);
            this.lableInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lableInfo.Name = "lableInfo";
            this.lableInfo.Size = new System.Drawing.Size(47, 13);
            this.lableInfo.TabIndex = 2;
            this.lableInfo.Text = "lableInfo";
            // 
            // topTable
            // 
            this.topTable.ColumnCount = 2;
            this.topTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.topTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topTable.Controls.Add(this.tableLeftPanel, 0, 0);
            this.topTable.Controls.Add(this.formContent, 1, 0);
            this.topTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topTable.Location = new System.Drawing.Point(0, 0);
            this.topTable.Name = "topTable";
            this.topTable.RowCount = 1;
            this.topTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTable.Size = new System.Drawing.Size(951, 272);
            this.topTable.TabIndex = 1;
            // 
            // tableLeftPanel
            // 
            this.tableLeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLeftPanel.ColumnCount = 1;
            this.tableLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLeftPanel.Controls.Add(this.image, 0, 0);
            this.tableLeftPanel.Controls.Add(this.ButtonsAndLables, 0, 1);
            this.tableLeftPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLeftPanel.Name = "tableLeftPanel";
            this.tableLeftPanel.RowCount = 2;
            this.tableLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLeftPanel.Size = new System.Drawing.Size(164, 266);
            this.tableLeftPanel.TabIndex = 3;
            // 
            // image
            // 
            this.image.Enabled = false;
            this.image.Location = new System.Drawing.Point(3, 3);
            this.image.MaximumSize = new System.Drawing.Size(155, 155);
            this.image.MinimumSize = new System.Drawing.Size(155, 155);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(155, 155);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            // 
            // ButtonsAndLables
            // 
            this.ButtonsAndLables.ColumnCount = 1;
            this.ButtonsAndLables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsAndLables.Controls.Add(this.tableButtonsNextPrev, 0, 1);
            this.ButtonsAndLables.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.ButtonsAndLables.Location = new System.Drawing.Point(3, 163);
            this.ButtonsAndLables.Name = "ButtonsAndLables";
            this.ButtonsAndLables.RowCount = 2;
            this.ButtonsAndLables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsAndLables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ButtonsAndLables.Size = new System.Drawing.Size(155, 104);
            this.ButtonsAndLables.TabIndex = 2;
            // 
            // tableButtonsNextPrev
            // 
            this.tableButtonsNextPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableButtonsNextPrev.ColumnCount = 2;
            this.tableButtonsNextPrev.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtonsNextPrev.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtonsNextPrev.Controls.Add(this.buttonPrev, 1, 0);
            this.tableButtonsNextPrev.Controls.Add(this.buttonNext, 0, 0);
            this.tableButtonsNextPrev.Location = new System.Drawing.Point(27, 72);
            this.tableButtonsNextPrev.Name = "tableButtonsNextPrev";
            this.tableButtonsNextPrev.RowCount = 1;
            this.tableButtonsNextPrev.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtonsNextPrev.Size = new System.Drawing.Size(100, 29);
            this.tableButtonsNextPrev.TabIndex = 3;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrev.Location = new System.Drawing.Point(53, 3);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(44, 23);
            this.buttonPrev.TabIndex = 2;
            this.buttonPrev.Text = "Prev.";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Location = new System.Drawing.Point(3, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(44, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lablelCoincidences, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTotal, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(149, 59);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lablelCoincidences
            // 
            this.lablelCoincidences.AutoSize = true;
            this.lablelCoincidences.Location = new System.Drawing.Point(3, 32);
            this.lablelCoincidences.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lablelCoincidences.Name = "lablelCoincidences";
            this.lablelCoincidences.Size = new System.Drawing.Size(95, 13);
            this.lablelCoincidences.TabIndex = 2;
            this.lablelCoincidences.Text = "lablelCoincidences";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(3, 3);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(53, 13);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "labelTotal";
            // 
            // FormFullTextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 272);
            this.Controls.Add(this.topTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(967, 311);
            this.Name = "FormFullTextSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск";
            this.Load += new System.EventHandler(this.FormFullTextSearch_Load);
            this.formContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchingResults)).EndInit();
            this.toolsPanel.ResumeLayout(false);
            this.tableTextBox.ResumeLayout(false);
            this.tableTextBox.PerformLayout();
            this.tableRightPanel.ResumeLayout(false);
            this.topTable.ResumeLayout(false);
            this.tableLeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ButtonsAndLables.ResumeLayout(false);
            this.tableButtonsNextPrev.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formContent;
        private System.Windows.Forms.DataGridView searchingResults;
        private System.Windows.Forms.TableLayoutPanel toolsPanel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchInfo;
        private System.Windows.Forms.TableLayoutPanel topTable;
        private Emgu.CV.UI.ImageBox image;
        private System.Windows.Forms.TableLayoutPanel tableLeftPanel;
        private System.Windows.Forms.TableLayoutPanel tableButtonsNextPrev;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TableLayoutPanel tableTextBox;
        private System.Windows.Forms.TableLayoutPanel tableRightPanel;
        private System.Windows.Forms.Button deleteRecord;
        private System.Windows.Forms.Button updateRecord;
        private System.Windows.Forms.Label lableInfo;
        private System.Windows.Forms.TableLayoutPanel ButtonsAndLables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lablelCoincidences;
        private System.Windows.Forms.Label labelTotal;

    }
}