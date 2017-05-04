namespace SCU.GSMAS.UI
{
    partial class FrmExplore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.lbl_field = new DevComponents.DotNetBar.LabelItem();
            this.cb_field = new DevComponents.DotNetBar.ComboBoxItem();
            this.lbl_sp = new DevComponents.DotNetBar.LabelItem();
            this.cb_sp = new DevComponents.DotNetBar.ComboBoxItem();
            this.dgvExplore = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.im_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.im_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.im_fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.im_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.im_resolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.im_saveLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cam_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnFirst = new DevComponents.DotNetBar.ButtonItem();
            this.btnPre = new DevComponents.DotNetBar.ButtonItem();
            this.btnNext = new DevComponents.DotNetBar.ButtonItem();
            this.btnLast = new DevComponents.DotNetBar.ButtonItem();
            this.cbPage = new DevComponents.DotNetBar.ComboBoxItem();
            this.btnGoto = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblCounts = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.lbl = new DevComponents.DotNetBar.LabelItem();
            this.cbPageSize = new DevComponents.DotNetBar.ComboBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExplore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvExplore);
            this.splitContainer1.Panel2.Controls.Add(this.bar1);
            this.splitContainer1.Size = new System.Drawing.Size(834, 518);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.advTree1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.bar2);
            this.splitContainer2.Size = new System.Drawing.Size(240, 518);
            this.splitContainer2.SplitterDistance = 484;
            this.splitContainer2.TabIndex = 2;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(240, 484);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 0;
            this.advTree1.Text = "treeExplore";
            this.advTree1.Click += new System.EventHandler(this.advTree1_Click);
            this.advTree1.DoubleClick += new System.EventHandler(this.advTree1_DoubleClick);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lbl_field,
            this.cb_field,
            this.lbl_sp,
            this.cb_sp});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(240, 29);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // lbl_field
            // 
            this.lbl_field.Name = "lbl_field";
            this.lbl_field.Text = "矿区:";
            // 
            // cb_field
            // 
            this.cb_field.DropDownHeight = 106;
            this.cb_field.ItemHeight = 18;
            this.cb_field.Name = "cb_field";
            this.cb_field.ComboBoxTextChanged += new System.EventHandler(this.cb_field_ComboBoxTextChanged);
            this.cb_field.Click += new System.EventHandler(this.cb_field_Click);
            // 
            // lbl_sp
            // 
            this.lbl_sp.Name = "lbl_sp";
            this.lbl_sp.Text = "标本:";
            // 
            // cb_sp
            // 
            this.cb_sp.DropDownHeight = 106;
            this.cb_sp.ItemHeight = 18;
            this.cb_sp.Name = "cb_sp";
            this.cb_sp.Click += new System.EventHandler(this.cb_sp_Click);
            // 
            // dgvExplore
            // 
            this.dgvExplore.AllowUserToAddRows = false;
            this.dgvExplore.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExplore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExplore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExplore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.im_id,
            this.im_path,
            this.im_fileName,
            this.im_time,
            this.im_resolution,
            this.im_saveLevel,
            this.cam_id,
            this.sp_id,
            this.userId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExplore.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExplore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExplore.EnableHeadersVisualStyles = false;
            this.dgvExplore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvExplore.Location = new System.Drawing.Point(0, 29);
            this.dgvExplore.Name = "dgvExplore";
            this.dgvExplore.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExplore.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvExplore.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExplore.RowTemplate.Height = 23;
            this.dgvExplore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExplore.Size = new System.Drawing.Size(590, 489);
            this.dgvExplore.TabIndex = 5;
            this.dgvExplore.DoubleClick += new System.EventHandler(this.dgvExplore_DoubleClick);
            // 
            // im_id
            // 
            this.im_id.DataPropertyName = "im_id";
            this.im_id.HeaderText = "图像编号";
            this.im_id.Name = "im_id";
            this.im_id.ReadOnly = true;
            // 
            // im_path
            // 
            this.im_path.DataPropertyName = "im_path";
            this.im_path.HeaderText = "图像路径";
            this.im_path.Name = "im_path";
            this.im_path.ReadOnly = true;
            // 
            // im_fileName
            // 
            this.im_fileName.DataPropertyName = "im_fileName";
            this.im_fileName.HeaderText = "图像名称";
            this.im_fileName.Name = "im_fileName";
            this.im_fileName.ReadOnly = true;
            // 
            // im_time
            // 
            this.im_time.DataPropertyName = "im_time";
            this.im_time.HeaderText = "图像拍摄时间";
            this.im_time.Name = "im_time";
            this.im_time.ReadOnly = true;
            this.im_time.Width = 120;
            // 
            // im_resolution
            // 
            this.im_resolution.DataPropertyName = "im_resolution";
            this.im_resolution.HeaderText = "图像清晰度";
            this.im_resolution.Name = "im_resolution";
            this.im_resolution.ReadOnly = true;
            // 
            // im_saveLevel
            // 
            this.im_saveLevel.DataPropertyName = "im_saveLevel";
            this.im_saveLevel.HeaderText = "图像级别";
            this.im_saveLevel.Name = "im_saveLevel";
            this.im_saveLevel.ReadOnly = true;
            // 
            // cam_id
            // 
            this.cam_id.DataPropertyName = "cam_id";
            this.cam_id.HeaderText = "相机参数编号";
            this.cam_id.Name = "cam_id";
            this.cam_id.ReadOnly = true;
            // 
            // sp_id
            // 
            this.sp_id.DataPropertyName = "sp_id";
            this.sp_id.HeaderText = "标本编号";
            this.sp_id.Name = "sp_id";
            this.sp_id.ReadOnly = true;
            // 
            // userId
            // 
            this.userId.DataPropertyName = "userId";
            this.userId.HeaderText = "操作人员";
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnFirst,
            this.btnPre,
            this.btnNext,
            this.btnLast,
            this.cbPage,
            this.btnGoto,
            this.labelItem1,
            this.lblCounts,
            this.labelItem3,
            this.lbl,
            this.cbPageSize,
            this.labelItem2});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(590, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnFirst
            // 
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Text = "首  页";
            // 
            // btnPre
            // 
            this.btnPre.Name = "btnPre";
            this.btnPre.Text = "上一页";
            // 
            // btnNext
            // 
            this.btnNext.Name = "btnNext";
            this.btnNext.Text = "下一页";
            // 
            // btnLast
            // 
            this.btnLast.Name = "btnLast";
            this.btnLast.Text = "尾  页";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // cbPage
            // 
            this.cbPage.DropDownHeight = 106;
            this.cbPage.ItemHeight = 18;
            this.cbPage.Name = "cbPage";
            this.cbPage.Click += new System.EventHandler(this.cbPage_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Text = "Go";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "共有记录";
            // 
            // lblCounts
            // 
            this.lblCounts.Name = "lblCounts";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "条";
            // 
            // lbl
            // 
            this.lbl.Name = "lbl";
            this.lbl.Text = "每页显示";
            // 
            // cbPageSize
            // 
            this.cbPageSize.DropDownHeight = 106;
            this.cbPageSize.ItemHeight = 18;
            this.cbPageSize.Name = "cbPageSize";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "条";
            // 
            // FrmExplore
            // 
            this.ClientSize = new System.Drawing.Size(844, 521);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmExplore";
            this.Text = "FrmExplore";
            this.Load += new System.EventHandler(this.FrmExplore_Load);
            this.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.FrmExplore_QueryAccessibilityHelp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExplore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem lbl_field;
        private DevComponents.DotNetBar.ComboBoxItem cb_field;
        private DevComponents.DotNetBar.LabelItem lbl_sp;
        private DevComponents.DotNetBar.ComboBoxItem cb_sp;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvExplore;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnFirst;
        private DevComponents.DotNetBar.ButtonItem btnPre;
        private DevComponents.DotNetBar.ButtonItem btnNext;
        private DevComponents.DotNetBar.ButtonItem btnLast;
        private DevComponents.DotNetBar.ComboBoxItem cbPage;
        private DevComponents.DotNetBar.ButtonItem btnGoto;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lblCounts;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem lbl;
        private DevComponents.DotNetBar.ComboBoxItem cbPageSize;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn im_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn im_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn im_fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn im_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn im_resolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn im_saveLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cam_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
    }
}