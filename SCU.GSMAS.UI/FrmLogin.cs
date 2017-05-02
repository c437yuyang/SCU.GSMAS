using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCU.GSMAS.UI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (!ValidateDatabaseConnet())
            {
                MessageBoxEx.Show("无法连接到数据库服务器!");
                System.Environment.Exit(0);
            }
        }


        public static bool ValidateDatabaseConnet()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (true) //验证用户名密码是否正确
            {
                FrmMain frm = new FrmMain();
                frm.Show();
                this.Visible = false;
            }
        }
    }
}
