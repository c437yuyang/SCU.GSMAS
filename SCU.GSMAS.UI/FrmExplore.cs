using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using SCU.GSMAS.DAL;
using SCU.GSMAS.Model;
using SCU.GSMAS.BLL;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Reflection;

namespace SCU.GSMAS.UI
{
    public partial class FrmExplore : DevComponents.DotNetBar.RibbonForm
    {

        private TblFieldBll filedBll = new TblFieldBll();
        private TblSpecimenBll spBll = new TblSpecimenBll();
        private TblImageBll imBll = new TblImageBll();
        private Thread _thReceive;
        private FrmExplore()
        {
            InitializeComponent();
        }
        private static FrmExplore _instance;
        private static readonly object syn = new object();
        public static FrmExplore CreateInstance()
        {
            if (_instance == null)
                lock (syn)
                {
                    if (_instance == null || _instance.IsDisposed)
                    {
                        _instance = new FrmExplore();
                    }
                }
            return _instance;
        }


        private void FrmExplore_Load(object sender, EventArgs e)
        {
            SetAdvStyle();
            loadDataToAdvTree();
        }

        private void SetAdvStyle()
        {
            advTree1.Nodes.Clear();
            advTree1.View = eView.Tile;
            // Define group node style
            ElementStyle groupStyle = new ElementStyle();
            groupStyle.TextColor = Color.Navy;
            groupStyle.Font = new Font(advTree1.Font.FontFamily, 9.5f);
            groupStyle.Name = "groupstyle";
            advTree1.Styles.Add(groupStyle);

            // Define sub-item style, simply to make text gray
            ElementStyle subItemStyle = new ElementStyle();
            subItemStyle.TextColor = Color.Gray;
            subItemStyle.Name = "subitemstyle";
            advTree1.Styles.Add(subItemStyle);
        }

        /// <summary>
        /// �������ݵ�treeView������ComboBox
        /// </summary>
        private void loadDataToAdvTree()
        {
            advTree1.Nodes.Clear();
            cb_field.Items.Clear();
            cb_field.Items.Add("ȫ��");
            //�������ؿ����ڵ�
            List<TblField> listFiled = filedBll.GetList();
            foreach (TblField field in listFiled)
            {
                Node groupNode = new Node(field.fd_name, advTree1.Styles["groupstyle"]);
                groupNode.Expanded = true;
                groupNode.Tag = field.fd_id; //�����ҵ�field
                advTree1.Nodes.Add(groupNode);
                cb_field.Items.Add(field); //�ȼ��ؿ������֣�����걾���ָ����л���̬����
                //���ݿ������ر걾
                List<TblSpecimen> specimens = spBll.GetListByFieldId(field.fd_id);
                foreach (TblSpecimen sp in specimens)
                {
                    Node subNode = CreateChildNode(sp.sp_name, sp.sp_no, Properties.Resources.Folder, advTree1.Styles["subitemstyle"]);
                    subNode.Tag = sp.sp_id;//�����ҵ�sp
                    subNode.Editable = false;
                    subNode.DragDropEnabled = false;
                    groupNode.Nodes.Add(subNode);
                }
            }
            cb_field.SelectedIndex = 0;//��ѡ��ȫ��

        }

        private Node CreateChildNode(string nodeText, string subText, Image image, ElementStyle subItemStyle)
        {
            Node childNode = new Node(nodeText);
            childNode.Image = image;
            childNode.Cells.Add(new Cell(subText, subItemStyle));
            return childNode;
        }

        private void FrmExplore_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void cbPage_Click(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {

        }

        private void advTree1_DoubleClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��������comboBoxѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_field_Click(object sender, EventArgs e)
        {
            if (cb_field.SelectedItem.ToString() == "ȫ��") //�ж�ѡ��ȫ�����������
            {
                advTree1.SelectedIndex = -1;
                this.dgvExplore.DataSource = imBll.GetDataTable();
                return;
            }
            int index = getTreeIndexByName(advTree1.Nodes, cb_field.SelectedItem.ToString()); //�ҵ���Ӧ�����ؼ���itemIndex
            if (index != -1)
                advTree1.SelectedNode = advTree1.Nodes[index];

            LoadSelectItem(); //�����������tree�ؼ�ѡ�е�item������

            //2.Ȼ��Ϊѡ�еĿ�������(�걾)comboBox
            cb_sp.Items.Clear();
            //���ﲻ��д�����ַ�ʽ��1�Ǹ��ݵ�ǰѡ�е�����ȥ��������ӽڵ�����ƣ����ǻ�Υ��֮ǰcomboBox�����item����model��ԭ��
            //2���ٲ�һ�����ݿ⣬���ǻ��������ݿ⸺����
            //for (int i=0;i!= advTree1.Nodes[index].Nodes.Count; ++i)
            //{
            //    cb_sp.Items.Add()
            //}

            //�ڶ��ַ�ʽ:
            List<TblSpecimen> list = spBll.GetListByFieldId((int)advTree1.SelectedNode.Tag);
            cb_sp.Items.Add("ȫ��");
            foreach (TblSpecimen sp in list)
            {
                cb_sp.Items.Add(sp);
            }
            cb_sp.SelectedIndex = 0; //��ѡ��ȫ��
        }

        private int getTreeIndexByName(NodeCollection nodes, string ItemName)
        {
            foreach (Node node in nodes)
            {
                if (node.Text == ItemName)
                    return node.Index;
            }
            return -1; //û�ҵ�
        }

        private void cb_field_ComboBoxTextChanged(object sender, EventArgs e)
        {
        }

        private void advTree1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(advTree1.SelectedIndex); //ǰ�������������е�index
            //Console.WriteLine(advTree1.SelectedNode.Index); //�������ڵ�ǰ�ڵ��µ�index
            LoadSelectItem();
        }

        private void LoadSelectItem()
        {
            List<TblImage> list = new List<TblImage>();
            DataTable dt = new DataTable();
            //���ض�Ӧ�걾��ͼ���ļ�
            //1.�ж��ǵ���Ŀ������Ǳ걾
            if (advTree1.SelectedNode.Nodes.Count == 0)
            {
                //Ҷ�ڵ�,����ָ���걾��Ӧͼ��
                dgvExplore.DataSource = imBll.GetDataTableBySpId((int)advTree1.SelectedNode.Tag);
            }
            else
            {
                //���ڵ�,����ָ��������Ӧͼ��
                dgvExplore.DataSource = imBll.GetDataTableByFieldId((int)advTree1.SelectedNode.Tag);
            }
        }

        private void cb_sp_Click(object sender, EventArgs e)
        {
            //�߼���������
            //����ѡ��ȫ��֮�⣬����treeView�ؼ���ѡ����
            //if (cb_sp.SelectedItem.ToString() == "ȫ��") //�ж�ѡ��ȫ�����������
            //{
            //    //advTree1.SelectedIndex = -1;
            //    //this.dgvExplore.DataSource = imBll.GetDataTable();
            //    return;
            //}
            //int index = getTreeIndexByName(advTree1.SelectedNode.Nodes,cb_sp.SelectedItem.ToString()); //�ҵ���Ӧ�����ؼ���itemIndex
            //if (index != -1)
            //    advTree1.SelectedNode = advTree1.Nodes[index];

            //LoadSelectItem(); //�����������tree�ؼ�ѡ�е�item������

        }

        private void dgvExplore_DoubleClick(object sender, EventArgs e)
        {
            //��˫���б���ͼ��ʱ����ͼ�񴰿���ʾ��Ӧͼ��

            if (dgvExplore.SelectedRows.Count != 0)
            {
                Image img = getImageByItem();

                if (Common.FrmManager.dicFrms.ContainsKey(typeof(FrmImage).ToString()))
                {
                    FrmImage frm = ((FrmImage)(Common.FrmManager.dicFrms[typeof(FrmImage).ToString()]));
                    frm.loadImage(img);
                    ((FrmMain)(Common.FrmManager.dicFrms[typeof(FrmMain).ToString()])).changeTab(frm.Name);
                }
                else
                {
                    FrmImage frm = FrmImage.CreateInstance();
                    //Common.FrmManager.dicFrms.Add(typeof(FrmImage).ToString(), frm);//��openWindow�����Ѿ�д����Ӵ�����
                    ((FrmMain)(Common.FrmManager.dicFrms[typeof(FrmMain).ToString()])).openWindow(frm, frm.Name);
                    frm.loadImage(img);
                }

            }

        }

        private Image getImageByItem()
        {
            string path = System.Environment.CurrentDirectory + @"\cache\";
            Directory.CreateDirectory(path);
            int imgId = (int)dgvExplore.SelectedRows[0].Cells["im_id"].Value;

            //��黺�����Ƿ��������ͼ�����������ֱ�Ӷ�ȡ���������߳�����ͼ��
            if (!checkCache(imgId))
            {
                //�������߳�����ͼ��
                _thReceive = new Thread(ask);
                _thReceive.Start(imgId);
                _thReceive.IsBackground = true;
                _thReceive.Join();
            }

            string imgPath = @"cache\" + imgId.ToString() + ".jpg";
            //Console.WriteLine(imgPath);
            Image img = Image.FromFile(imgPath);
            return img;


            //return null;



        }

        private bool checkCache(int imgId)
        {
            string cachePath = System.Environment.CurrentDirectory + @"\cache\";

            string[] files = Directory.GetFiles(cachePath);

            foreach(var file in files)
            {
                FileInfo fileinfo = new FileInfo(file);           
                if (fileinfo.Name == imgId.ToString() + ".jpg")
                {
                    return true;
                }
            }
            return false;

        }

        private void ask(object Id)
        {
            int imgId = (int)Id; //����Ҫ�ж�ͼ���Ƿ���ڣ��������������ʾ�û�δ�ҵ�ͼ��
            //���صõ���ͼ���Ű���ID�洢��(cacheĿ¼��)��ÿ������ǰ�ȼ���Ƿ���ڻ���ͼ��
            TcpClient client = new TcpClient();
            //client.Connect(IPAddress.Parse("127.0.0.1"), int.Parse("50000"));
            client.Connect(IPAddress.Parse("192.168.135.100"), int.Parse("50000"));

            using (NetworkStream ns = client.GetStream())
            {
                //��������˷���������ļ�ID

                byte[] idBuffer = BitConverter.GetBytes(imgId);
                byte[] filebuf = new byte[400];
                idBuffer.CopyTo(filebuf, 0);
                ns.Write(filebuf, 0, 400); //���������ļ�ID

                //Directory.CreateDirectory(+@"\cache");

                byte[] filelen = new byte[4];
                ns.Read(filelen, 0, 4);
                int count = BitConverter.ToInt32(filelen, 0);
                //���յ����ļ����������
                using (FileStream fs = new FileStream(@"cache\" + imgId.ToString() + ".jpg", FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[512];
                    int size = 0;//��ʼ����ȡ������Ϊ0   
                    int len = 0;
                    while (len < count)
                    {
                        size = ns.Read(buffer, 0, buffer.Length);
                        fs.Write(buffer, 0, size);
                        len += size;
                    }
                }
            }
            //MessageBoxEx.Show("�������!");
        }


    }
}