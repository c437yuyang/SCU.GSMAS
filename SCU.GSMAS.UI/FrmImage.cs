using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SCU.GSMAS.UI
{
    public partial class FrmImage : DevComponents.DotNetBar.RibbonForm
    {
        private FrmImage()
        {
            InitializeComponent();
        }

        private static FrmImage _instance;
        private static readonly object syn = new object();
        public static FrmImage CreateInstance()
        {
            if (_instance == null)
                lock (syn)
                {
                    if (_instance == null || _instance.IsDisposed)
                    {
                        _instance = new FrmImage();
                    }
                }
            return _instance;
        }

        private void FrmImage_Load(object sender, EventArgs e)
        {

        }


        public void loadImage(Image img)
        {
            disposeImage();
            pictureBox1.Image = img;

        }

        public void disposeImage()
        {
            if(pictureBox1.Image!=null)
                pictureBox1.Image.Dispose();
        }

    }
}