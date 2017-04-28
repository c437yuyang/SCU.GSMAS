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
    public partial class FrmMain : DevComponents.DotNetBar.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btn_Explore_Click(object sender, EventArgs e)
        {
            FrmExplore frm = FrmExplore.CreateInstance();
            if(!IsOpenTab(frm.Name))
                openWindow(frm, frm.Name);
        }

        public void openWindow(Form frm, string Name)
        {
            TabItem tp = new DevComponents.DotNetBar.TabItem();
            TabControlPanel tcp = new TabControlPanel();
            tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tcp.Dock = DockStyle.Fill;
            tcp.Location = new Point(0, 0);

            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tcp.Controls.Add(frm);
            tp.Text = frm.Text;
            tp.Name = Name;

            if (!IsOpenTab(Name))
            {
                tcp.TabItem = tp;
                tp.AttachedControl = tcp;
                tabMain.Controls.Add(tcp);
                tabMain.Tabs.Add(tp);
                tabMain.SelectedTab = tp;
            }
            tabMain.Refresh();
        }

        private bool IsOpenTab(string tabName)
        {
            bool isOpened = false;

            foreach (TabItem tab in tabMain.Tabs)
            {
                if (tab.Name == tabName.Trim())
                {
                    isOpened = true;
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
            return isOpened;
        }


        private void tp_MouseDown(object sender, MouseEventArgs e)
        {
            tabMain.SelectedTab = (TabItem)sender;
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DateTime time = System.DateTime.Now;
            lbl_Date.Text = time.ToString();
            lbl_field.Text = "矿区1";
            lbl_uname.Text = "当前用户:ADMIN";
            lbl_specimen.Text = "标本1";
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            FrmRetrieve frm = FrmRetrieve.CreateInstance();
            if (!IsOpenTab(frm.Name))
                openWindow(frm, frm.Name);
        }

        private void btn_changeSkin_Click(object sender, EventArgs e)
        {
            if (styleManager1.ManagerStyle < eStyle.Office2016)
            {
                styleManager1.ManagerStyle++;
            }
            else
            {
                styleManager1.ManagerStyle = 0;
            }
            Console.WriteLine("current style:" + styleManager1.ManagerStyle);

        }

        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            TabItem tb = tabMain.SelectedTab;
            tabMain.Tabs.Remove(tb);
        }

    }
}