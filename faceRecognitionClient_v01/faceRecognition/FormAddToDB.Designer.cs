namespace faceRecognition
{
    partial class FormAddToDB
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
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.btnAddToDB = new System.Windows.Forms.Button();
            this.VideoBox = new Emgu.CV.UI.ImageBox();
            this.tableLayoutElements = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutLbl = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.flowLayoutBtns = new System.Windows.Forms.FlowLayoutPanel();
            this.removeRow = new System.Windows.Forms.Button();
            this.addRow = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пресетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flowCheckAndBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.chkAddMethod = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.tableLayoutElements.SuspendLayout();
            this.flowLayoutLbl.SuspendLayout();
            this.flowLayoutBtns.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.btnsTableLayout.SuspendLayout();
            this.flowCheckAndBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTable
            // 
            this.dataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Location = new System.Drawing.Point(524, 3);
            this.dataTable.Name = "dataTable";
            this.dataTable.RowHeadersVisible = false;
            this.dataTable.Size = new System.Drawing.Size(515, 299);
            this.dataTable.TabIndex = 38;
            // 
            // btnAddToDB
            // 
            this.btnAddToDB.Location = new System.Drawing.Point(362, 3);
            this.btnAddToDB.Name = "btnAddToDB";
            this.btnAddToDB.Size = new System.Drawing.Size(144, 32);
            this.btnAddToDB.TabIndex = 37;
            this.btnAddToDB.Text = "Добавить в базу";
            this.btnAddToDB.UseVisualStyleBackColor = true;
            this.btnAddToDB.Click += new System.EventHandler(this.btnAddToDB_Click);
            // 
            // VideoBox
            // 
            this.VideoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoBox.Location = new System.Drawing.Point(3, 3);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(515, 299);
            this.VideoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VideoBox.TabIndex = 36;
            this.VideoBox.TabStop = false;
            // 
            // tableLayoutElements
            // 
            this.tableLayoutElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutElements.ColumnCount = 2;
            this.tableLayoutElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutElements.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutElements.Controls.Add(this.VideoBox, 0, 0);
            this.tableLayoutElements.Controls.Add(this.flowLayoutLbl, 0, 1);
            this.tableLayoutElements.Controls.Add(this.dataTable, 1, 0);
            this.tableLayoutElements.Controls.Add(this.btnsTableLayout, 1, 1);
            this.tableLayoutElements.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutElements.Name = "tableLayoutElements";
            this.tableLayoutElements.RowCount = 2;
            this.tableLayoutElements.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutElements.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutElements.Size = new System.Drawing.Size(1042, 395);
            this.tableLayoutElements.TabIndex = 41;
            // 
            // flowLayoutLbl
            // 
            this.flowLayoutLbl.Controls.Add(this.lblInfo);
            this.flowLayoutLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutLbl.Location = new System.Drawing.Point(3, 363);
            this.flowLayoutLbl.Name = "flowLayoutLbl";
            this.flowLayoutLbl.Size = new System.Drawing.Size(515, 29);
            this.flowLayoutLbl.TabIndex = 40;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 40;
            // 
            // flowLayoutBtns
            // 
            this.flowLayoutBtns.Controls.Add(this.removeRow);
            this.flowLayoutBtns.Controls.Add(this.addRow);
            this.flowLayoutBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutBtns.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutBtns.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutBtns.Name = "flowLayoutBtns";
            this.flowLayoutBtns.Size = new System.Drawing.Size(509, 37);
            this.flowLayoutBtns.TabIndex = 39;
            // 
            // removeRow
            // 
            this.removeRow.Location = new System.Drawing.Point(389, 3);
            this.removeRow.Name = "removeRow";
            this.removeRow.Size = new System.Drawing.Size(117, 32);
            this.removeRow.TabIndex = 40;
            this.removeRow.Text = "Удалить поле";
            this.removeRow.UseVisualStyleBackColor = true;
            this.removeRow.Click += new System.EventHandler(this.removeRow_Click);
            // 
            // addRow
            // 
            this.addRow.Location = new System.Drawing.Point(266, 3);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(117, 32);
            this.addRow.TabIndex = 39;
            this.addRow.Text = "Добавить поле";
            this.addRow.UseVisualStyleBackColor = true;
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пресетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1042, 24);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пресетыToolStripMenuItem
            // 
            this.пресетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьВФайлToolStripMenuItem,
            this.загрузитьИзФайлаToolStripMenuItem});
            this.пресетыToolStripMenuItem.Name = "пресетыToolStripMenuItem";
            this.пресетыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.пресетыToolStripMenuItem.Text = "Пресеты";
            // 
            // сохранитьВФайлToolStripMenuItem
            // 
            this.сохранитьВФайлToolStripMenuItem.Name = "сохранитьВФайлToolStripMenuItem";
            this.сохранитьВФайлToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.сохранитьВФайлToolStripMenuItem.Text = "Сохранить в файл";
            this.сохранитьВФайлToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // загрузитьИзФайлаToolStripMenuItem
            // 
            this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
            this.загрузитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
            this.загрузитьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem_Click);
            // 
            // btnsTableLayout
            // 
            this.btnsTableLayout.ColumnCount = 1;
            this.btnsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.btnsTableLayout.Controls.Add(this.flowLayoutBtns, 0, 0);
            this.btnsTableLayout.Controls.Add(this.flowCheckAndBtn, 0, 1);
            this.btnsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnsTableLayout.Location = new System.Drawing.Point(524, 308);
            this.btnsTableLayout.Name = "btnsTableLayout";
            this.btnsTableLayout.RowCount = 2;
            this.btnsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.38095F));
            this.btnsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.btnsTableLayout.Size = new System.Drawing.Size(515, 84);
            this.btnsTableLayout.TabIndex = 41;
            // 
            // flowCheckAndBtn
            // 
            this.flowCheckAndBtn.Controls.Add(this.btnAddToDB);
            this.flowCheckAndBtn.Controls.Add(this.chkAddMethod);
            this.flowCheckAndBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCheckAndBtn.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowCheckAndBtn.Location = new System.Drawing.Point(3, 46);
            this.flowCheckAndBtn.Name = "flowCheckAndBtn";
            this.flowCheckAndBtn.Size = new System.Drawing.Size(509, 35);
            this.flowCheckAndBtn.TabIndex = 40;
            // 
            // chkAddMethod
            // 
            this.chkAddMethod.AutoSize = true;
            this.chkAddMethod.Location = new System.Drawing.Point(186, 3);
            this.chkAddMethod.Name = "chkAddMethod";
            this.chkAddMethod.Size = new System.Drawing.Size(170, 17);
            this.chkAddMethod.TabIndex = 38;
            this.chkAddMethod.Text = "Добавить как новую запись";
            this.chkAddMethod.UseVisualStyleBackColor = true;
            // 
            // FormAddToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 420);
            this.Controls.Add(this.tableLayoutElements);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(99999, 99999);
            this.MinimumSize = new System.Drawing.Size(1000, 425);
            this.Name = "FormAddToDB";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Добавление в базу";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAddToDB_FormClosed);
            this.Load += new System.EventHandler(this.FormAddToDb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).EndInit();
            this.tableLayoutElements.ResumeLayout(false);
            this.flowLayoutLbl.ResumeLayout(false);
            this.flowLayoutLbl.PerformLayout();
            this.flowLayoutBtns.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.btnsTableLayout.ResumeLayout(false);
            this.flowCheckAndBtn.ResumeLayout(false);
            this.flowCheckAndBtn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.Button btnAddToDB;
        private Emgu.CV.UI.ImageBox VideoBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutElements;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutBtns;
        private System.Windows.Forms.Button removeRow;
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutLbl;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пресетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel btnsTableLayout;
        private System.Windows.Forms.FlowLayoutPanel flowCheckAndBtn;
        private System.Windows.Forms.CheckBox chkAddMethod;



    }
}

