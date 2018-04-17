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
    class getWebCam
    {


        public Capture cam = null;
        

        public getWebCam()
        {
            if(cam == null)
            {
                cam = new Capture();
            }
            
            
        }

        public Capture setCam()
        {
            return cam;
        }
        public void disposeCam()
        {
            cam.Dispose();
        }

    }
}
