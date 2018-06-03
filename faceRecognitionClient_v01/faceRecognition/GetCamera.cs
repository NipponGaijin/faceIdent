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

namespace faceRecognition
{
    class GetCamera
    {
        public Capture webcam;

        public GetCamera()
        {
            webcam = null;
        }

        public void getCamera()
        {
            webcam = new Capture();
        }

        public void disposeCamera()
        {
            webcam.Dispose();
        }
    }
}
