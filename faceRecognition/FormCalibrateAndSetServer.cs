using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cvb;
using Emgu.Util;


namespace faceRecognition
{

    public partial class FormCalibrateAndSetServer : Form
    {
        public int faceMax;
        public int faceMin;
        public string address;
        public FormIdentify identifyForm;
        HaarCascade cascade = new HaarCascade("haarcascade_frontalface_default.xml");
        Capture capWebcam = null;
        getWebCam getWebCam = new getWebCam();
        public FormCalibrateAndSetServer()
        {
            InitializeComponent();
        }

        private void FormCalibrateAndSetServer_Load(object sender, EventArgs e)
        {
            try
            {
                capWebcam = getWebCam.setCam();               // инициализируем объект записи с дефолтной вебки
            }
            catch (NullReferenceException exept)       // ошибка, если запись неудалась
            {
                return;
            }   
            TBMax.Value = faceMax;
            TBMin.Value = faceMin;
            lblTBValueMAX.Text = TBMax.Value.ToString();
            lblTBValueMIN.Text = TBMin.Value.ToString();
            if (address != null)
            {
                string[] splittedAddress = address.Split(':');
                serverAddress.Text = splittedAddress[0] + ':' + splittedAddress[1];
                Port.Value = int.Parse(splittedAddress[2]);
            }
            Application.Idle += processFrameAndUpdGui;
        }


        private void FormCalibrateAndSetServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            address = serverAddress.Text + ":" + Port.Value.ToString();
            identifyForm.maxFace = faceMax;
            identifyForm.minFace = faceMin;
            identifyForm.address = address;
            this.Close();
            Application.Idle -= processFrameAndUpdGui;
        }

        private void TBMax_Scroll(object sender, EventArgs e)
        {
            faceMax = TBMax.Value;
            lblTBValueMAX.Text = TBMax.Value.ToString();
        }

        private void TBMin_Scroll(object sender, EventArgs e)
        {
            faceMin = TBMin.Value;
            lblTBValueMIN.Text = TBMin.Value.ToString();
        }
        private void processFrameAndUpdGui(object sender, EventArgs e)
        {
            Image<Bgr, Byte> image = capWebcam.QueryFrame();
            Image<Gray, Byte> grayImage = image.Convert<Gray, Byte>();
            MCvAvgComp[][] Faces = grayImage.DetectHaarCascade(cascade, 1.2, 1, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(faceMin, faceMax));
            foreach (MCvAvgComp face in Faces[0])
            {
                image.Draw(face.rect, new Bgr(Color.Green), 6);
            }
            VideoStream.Image = image;
        }
    }
}
