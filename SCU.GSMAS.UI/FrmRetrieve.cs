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
    public partial class FrmRetrieve : DevComponents.DotNetBar.RibbonForm
    {
        public FrmRetrieve()
        {
            InitializeComponent();
        }

        private static FrmRetrieve _instance;
        private static readonly object syn = new object();
        public static FrmRetrieve CreateInstance()
        {
            if (_instance == null)
                lock (syn)
                {
                    if (_instance == null || _instance.IsDisposed)
                    {
                        _instance = new FrmRetrieve();
                    }
                }
            return _instance;
        }
    }
}