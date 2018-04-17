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
            this.addUser = new System.Windows.Forms.Button();
            this.goIdentify = new System.Windows.Forms.Button();
            this.buttonsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableContainer = new System.Windows.Forms.TableLayoutPanel();
            this.dataTableIndent = new System.Windows.Forms.DataGridView();
            this.VideoBox = new Emgu.CV.UI.ImageBox();
            this.labelInfoFlowLayout.SuspendLayout();
            this.buttonsFlowLayout.SuspendLayout();
            this.tableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfoFlowLayout
            // 
            this.labelInfoFlowLayout.Controls.Add(this.lblInformation);
            this.labelInfoFlowLayout.Controls.Add(this.lblFoundStatus);
            this.labelInfoFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfoFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.labelInfoFlowLayout.Location = new System.Drawing.Point(112, 3);
            this.labelInfoFlowLayout.Name = "labelInfoFlowLayout";
            this.labelInfoFlowLayout.Size = new System.Drawing.Size(396, 49);
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
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(514, 3);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(128, 49);
            this.addUser.TabIndex = 39;
            this.addUser.Text = "Добавить пользователя в базу";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // goIdentify
            // 
            this.goIdentify.Location = new System.Drawing.Point(648, 3);
            this.goIdentify.Name = "goIdentify";
            this.goIdentify.Size = new System.Drawing.Size(128, 48);
            this.goIdentify.TabIndex = 3;
            this.goIdentify.Text = "Идентифицировать";
            this.goIdentify.UseVisualStyleBackColor = true;
            this.goIdentify.Click += new System.EventHandler(this.goIdentify_Click);
            // 
            // buttonsFlowLayout
            // 
            this.buttonsFlowLayout.Controls.Add(this.btnSearch);
            this.buttonsFlowLayout.Controls.Add(this.goIdentify);
            this.buttonsFlowLayout.Controls.Add(this.addUser);
            this.buttonsFlowLayout.Controls.Add(this.labelInfoFlowLayout);
            this.buttonsFlowLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonsFlowLayout.Location = new System.Drawing.Point(0, 358);
            this.buttonsFlowLayout.Name = "buttonsFlowLayout";
            this.buttonsFlowLayout.Size = new System.Drawing.Size(994, 61);
            this.buttonsFlowLayout.TabIndex = 46;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(782, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(209, 48);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "Искать пользователя";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tableContainer
            // 
            this.tableContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableContainer.ColumnCount = 2;
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableContainer.Controls.Add(this.dataTableIndent, 0, 0);
            this.tableContainer.Controls.Add(this.VideoBox, 0, 0);
            this.tableContainer.Location = new System.Drawing.Point(12, 12);
            this.tableContainer.Name = "tableContainer";
            this.tableContainer.RowCount = 1;
            this.tableContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableContainer.Size = new System.Drawing.Size(979, 333);
            this.tableContainer.TabIndex = 49;
            // 
            // dataTableIndent
            // 
            this.dataTableIndent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTableIndent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataTableIndent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataTableIndent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableIndent.Location = new System.Drawing.Point(492, 3);
            this.dataTableIndent.Name = "dataTableIndent";
            this.dataTableIndent.RowHeadersVisible = false;
            this.dataTableIndent.Size = new System.Drawing.Size(484, 327);
            this.dataTableIndent.TabIndex = 51;
            // 
            // VideoBox
            // 
            this.VideoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoBox.Location = new System.Drawing.Point(3, 3);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(483, 327);
            this.VideoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VideoBox.TabIndex = 50;
            this.VideoBox.TabStop = false;
            // 
            // FormIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 419);
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
            this.tableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel labelInfoFlowLayout;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblFoundStatus;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button goIdentify;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowLayout;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableContainer;
        private System.Windows.Forms.DataGridView dataTableIndent;
        private Emgu.CV.UI.ImageBox VideoBox;




    }
}