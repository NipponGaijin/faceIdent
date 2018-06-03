namespace faceRecognition
{
    partial class FormCalibrateAndSetServer
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
            this.VideoStream = new Emgu.CV.UI.ImageBox();
            this.Max = new System.Windows.Forms.Label();
            this.TBMax = new System.Windows.Forms.TrackBar();
            this.TBMin = new System.Windows.Forms.TrackBar();
            this.lblINFP = new System.Windows.Forms.Label();
            this.lblTBValueMAX = new System.Windows.Forms.Label();
            this.lblTBValueMIN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.NumericUpDown();
            this.minn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VideoStream)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoStream
            // 
            this.VideoStream.Location = new System.Drawing.Point(13, 13);
            this.VideoStream.Name = "VideoStream";
            this.VideoStream.Size = new System.Drawing.Size(324, 214);
            this.VideoStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VideoStream.TabIndex = 2;
            this.VideoStream.TabStop = false;
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Location = new System.Drawing.Point(343, 13);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(89, 39);
            this.Max.TabIndex = 3;
            this.Max.Text = "Максимальный \r\nразмер \r\nлица";
            // 
            // TBMax
            // 
            this.TBMax.Location = new System.Drawing.Point(432, 12);
            this.TBMax.Maximum = 400;
            this.TBMax.Name = "TBMax";
            this.TBMax.Size = new System.Drawing.Size(356, 45);
            this.TBMax.TabIndex = 5;
            this.TBMax.Scroll += new System.EventHandler(this.TBMax_Scroll);
            // 
            // TBMin
            // 
            this.TBMin.Location = new System.Drawing.Point(432, 102);
            this.TBMin.Maximum = 400;
            this.TBMin.Name = "TBMin";
            this.TBMin.Size = new System.Drawing.Size(356, 45);
            this.TBMin.TabIndex = 6;
            this.TBMin.Scroll += new System.EventHandler(this.TBMin_Scroll);
            // 
            // lblINFP
            // 
            this.lblINFP.AutoSize = true;
            this.lblINFP.Location = new System.Drawing.Point(439, 164);
            this.lblINFP.Name = "lblINFP";
            this.lblINFP.Size = new System.Drawing.Size(276, 26);
            this.lblINFP.TabIndex = 7;
            this.lblINFP.Text = "Перемещайте ползунки таким образом, чтобы лицо \r\nна видеопотоке отслеживалось ста" +
    "бильно";
            // 
            // lblTBValueMAX
            // 
            this.lblTBValueMAX.AutoSize = true;
            this.lblTBValueMAX.Location = new System.Drawing.Point(794, 23);
            this.lblTBValueMAX.Name = "lblTBValueMAX";
            this.lblTBValueMAX.Size = new System.Drawing.Size(35, 13);
            this.lblTBValueMAX.TabIndex = 8;
            this.lblTBValueMAX.Text = "label1";
            // 
            // lblTBValueMIN
            // 
            this.lblTBValueMIN.AutoSize = true;
            this.lblTBValueMIN.Location = new System.Drawing.Point(794, 102);
            this.lblTBValueMIN.Name = "lblTBValueMIN";
            this.lblTBValueMIN.Size = new System.Drawing.Size(35, 13);
            this.lblTBValueMIN.TabIndex = 9;
            this.lblTBValueMIN.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Адресс сервера";
            // 
            // serverAddress
            // 
            this.serverAddress.Location = new System.Drawing.Point(442, 211);
            this.serverAddress.Name = "serverAddress";
            this.serverAddress.Size = new System.Drawing.Size(143, 20);
            this.serverAddress.TabIndex = 11;
            this.serverAddress.Text = "http://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(591, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Порт";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(629, 211);
            this.Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(46, 20);
            this.Port.TabIndex = 13;
            // 
            // minn
            // 
            this.minn.AutoSize = true;
            this.minn.Location = new System.Drawing.Point(343, 102);
            this.minn.Name = "minn";
            this.minn.Size = new System.Drawing.Size(83, 39);
            this.minn.TabIndex = 14;
            this.minn.Text = "Минимальный \r\nразмер \r\nлица";
            // 
            // FormCalibrateAndSetServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 251);
            this.Controls.Add(this.minn);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTBValueMIN);
            this.Controls.Add(this.lblTBValueMAX);
            this.Controls.Add(this.lblINFP);
            this.Controls.Add(this.TBMin);
            this.Controls.Add(this.TBMax);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.VideoStream);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCalibrateAndSetServer";
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCalibrateAndSetServer_FormClosed);
            this.Load += new System.EventHandler(this.FormCalibrateAndSetServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoStream)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox VideoStream;
        private System.Windows.Forms.Label Max;
        private System.Windows.Forms.Label min;
        private System.Windows.Forms.TrackBar TBMax;
        private System.Windows.Forms.TrackBar TBMin;
        private System.Windows.Forms.Label lblINFP;
        private System.Windows.Forms.Label lblTBValueMAX;
        private System.Windows.Forms.Label lblTBValueMIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.Label minn;
    }
}