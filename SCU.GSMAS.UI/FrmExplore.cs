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

namespace SCU.GSMAS.UI
{
    public partial class FrmExplore : DevComponents.DotNetBar.RibbonForm
    {

        private TblFieldBll filedBll = new TblFieldBll();
        private TblSpecimenBll spBll = new TblSpecimenBll();
        private TblImageBll imBll = new TblImageBll();

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
        /// 加载数据到treeView和设置ComboBox
        /// </summary>
        private void loadDataToAdvTree()
        {
            advTree1.Nodes.Clear();
            cb_field.Items.Clear();
            cb_field.Items.Add("全部");
            //遍历记载矿区节点
            List<TblField> listFiled = filedBll.GetList();
            foreach (TblField field in listFiled)
            {
                Node groupNode = new Node(field.fd_name, advTree1.Styles["groupstyle"]);
                groupNode.Expanded = true;
                groupNode.Tag = field.fd_id; //方便找到field
                advTree1.Nodes.Add(groupNode);
                cb_field.Items.Add(field); //先加载矿区部分，后面标本部分根据切换动态加载
                //根据矿区加载标本
                List<TblSpecimen> specimens = spBll.GetListByFieldId(field.fd_id);
                foreach(TblSpecimen sp in specimens)
                {
                    Node subNode = CreateChildNode(sp.sp_name, sp.sp_no, Properties.Resources.Folder, advTree1.Styles["subitemstyle"]);
                    subNode.Tag = sp.sp_id;//方便找到sp
                    subNode.Editable = false;
                    subNode.DragDropEnabled = false;
                    groupNode.Nodes.Add(subNode);
                }
            }
            cb_field.SelectedIndex = 0;//先选中全部

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
        /// （地区）comboBox选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_field_Click(object sender, EventArgs e)
        {
            if(cb_field.SelectedItem.ToString()=="全部") //判断选中全部矿区的情况
            {
                advTree1.SelectedIndex = -1;
                this.dgvExplore.DataSource = imBll.GetDataTable();
                return;
            }
            int index = getTreeIndexByName(advTree1.Nodes,cb_field.SelectedItem.ToString()); //找到对应的树控件的itemIndex
            if(index!=-1)
                advTree1.SelectedNode = advTree1.Nodes[index];

            LoadSelectItem(); //这个函数根据tree控件选中的item来加载

            //2.然后为选中的矿区加载(标本)comboBox
            cb_sp.Items.Clear();
            //这里不好写，两种方式，1是根据当前选中的树形去添加他的子节点的名称，但是会违背之前comboBox加入的item就是model的原则
            //2是再查一次数据库，但是会增加数据库负担。
            //for (int i=0;i!= advTree1.Nodes[index].Nodes.Count; ++i)
            //{
            //    cb_sp.Items.Add()
            //}
            
            //第二种方式:
            List<TblSpecimen> list = spBll.GetListByFieldId((int)advTree1.SelectedNode.Tag);
            cb_sp.Items.Add("全部");
            foreach(TblSpecimen sp in list)
            {
                cb_sp.Items.Add(sp);
            }
            cb_sp.SelectedIndex = 0; //先选中全部
        }

        private int getTreeIndexByName(NodeCollection nodes,string ItemName)
        {
            foreach(Node node in nodes)
            {
                if (node.Text == ItemName)
                    return node.Index;
            }
            return -1; //没找到
        }

        private void cb_field_ComboBoxTextChanged(object sender, EventArgs e)
        {
        }

        private void advTree1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(advTree1.SelectedIndex); //前者是再整颗树中的index
            //Console.WriteLine(advTree1.SelectedNode.Index); //后者是在当前节点下的index
            LoadSelectItem();
        }

        private void LoadSelectItem()
        {
            List<TblImage> list = new List<TblImage>();
            DataTable dt = new DataTable();
            //加载对应标本的图像文件
            //1.判断是点击的矿区还是标本
            if (advTree1.SelectedNode.Nodes.Count == 0)
            {
                //叶节点,加载指定标本对应图像
                dgvExplore.DataSource = imBll.GetDataTableBySpId((int)advTree1.SelectedNode.Tag);
            }
            else
            {
                //根节点,加载指定矿区对应图像
                dgvExplore.DataSource = imBll.GetDataTableByFieldId((int)advTree1.SelectedNode.Tag);
            }
        }

        private void cb_sp_Click(object sender, EventArgs e)
        {
            //逻辑还有问题
            //除了选中全部之外，更改treeView控件的选择项
            //if (cb_sp.SelectedItem.ToString() == "全部") //判断选中全部矿区的情况
            //{
            //    //advTree1.SelectedIndex = -1;
            //    //this.dgvExplore.DataSource = imBll.GetDataTable();
            //    return;
            //}
            //int index = getTreeIndexByName(advTree1.SelectedNode.Nodes,cb_sp.SelectedItem.ToString()); //找到对应的树控件的itemIndex
            //if (index != -1)
            //    advTree1.SelectedNode = advTree1.Nodes[index];

            //LoadSelectItem(); //这个函数根据tree控件选中的item来加载

        }

        private void dgvExplore_DoubleClick(object sender, EventArgs e)
        {
            //当双击列表中图像时，在图像窗口显示对应图像

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
                    //Common.FrmManager.dicFrms.Add(typeof(FrmImage).ToString(), frm);//在openWindow里面已经写了添加窗口了
                    ((FrmMain)(Common.FrmManager.dicFrms[typeof(FrmMain).ToString()])).openWindow(frm, frm.Name);
                    frm.loadImage(img);
                }
                
            }

        }

        private Image getImageByItem()
        {
            string imgPath = (string)dgvExplore.SelectedRows[0].Cells["im_path"].Value
                + "/" + (string)dgvExplore.SelectedRows[0].Cells["im_fileName"].Value;

            //Console.WriteLine(imgPath);
            Image img = Image.FromFile(imgPath);
            return img;
        }
    }
}