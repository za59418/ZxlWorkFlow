namespace Zxl.Builder
{
    partial class businessDataCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeBusinessData = new DevExpress.XtraTreeList.TreeList();
            this.bName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsBusinessDatas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBusinessData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeBusinessData)).BeginInit();
            this.cmsBusinessDatas.SuspendLayout();
            this.cmsBusinessData.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeBusinessData
            // 
            this.treeBusinessData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bName,
            this.bDescription});
            this.treeBusinessData.ContextMenuStrip = this.cmsBusinessDatas;
            this.treeBusinessData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBusinessData.Location = new System.Drawing.Point(0, 0);
            this.treeBusinessData.LookAndFeel.SkinName = "iMaginary";
            this.treeBusinessData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeBusinessData.Name = "treeBusinessData";
            this.treeBusinessData.OptionsBehavior.AutoChangeParent = false;
            this.treeBusinessData.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeBusinessData.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeBusinessData.OptionsBehavior.ShowToolTips = false;
            this.treeBusinessData.OptionsBehavior.SmartMouseHover = false;
            this.treeBusinessData.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeBusinessData.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeBusinessData.OptionsView.ShowCheckBoxes = true;
            this.treeBusinessData.Size = new System.Drawing.Size(279, 525);
            this.treeBusinessData.TabIndex = 0;
            this.treeBusinessData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeBusinessData_MouseClick);
            this.treeBusinessData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeBusinessData_MouseDoubleClick);
            // 
            // bName
            // 
            this.bName.Caption = "名称";
            this.bName.FieldName = "NAME";
            this.bName.MinWidth = 31;
            this.bName.Name = "bName";
            this.bName.OptionsColumn.AllowEdit = false;
            this.bName.Visible = true;
            this.bName.VisibleIndex = 0;
            // 
            // bDescription
            // 
            this.bDescription.Caption = "描述";
            this.bDescription.FieldName = "DESCRIPTION";
            this.bDescription.Name = "bDescription";
            this.bDescription.OptionsColumn.AllowEdit = false;
            this.bDescription.Visible = true;
            this.bDescription.VisibleIndex = 1;
            // 
            // cmsBusinessDatas
            // 
            this.cmsBusinessDatas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd});
            this.cmsBusinessDatas.Name = "contextMenuBd";
            this.cmsBusinessDatas.Size = new System.Drawing.Size(153, 48);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(152, 22);
            this.tsmiAdd.Text = "添加业务数据";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // cmsBusinessData
            // 
            this.cmsBusinessData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEdit,
            this.cmsiDel});
            this.cmsBusinessData.Name = "contextMenuBd";
            this.cmsBusinessData.Size = new System.Drawing.Size(149, 48);
            // 
            // cmsiEdit
            // 
            this.cmsiEdit.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEdit.Name = "cmsiEdit";
            this.cmsiEdit.Size = new System.Drawing.Size(148, 22);
            this.cmsiEdit.Text = "编辑业务数据";
            this.cmsiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // cmsiDel
            // 
            this.cmsiDel.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDel.Name = "cmsiDel";
            this.cmsiDel.Size = new System.Drawing.Size(148, 22);
            this.cmsiDel.Text = "删除业务数据";
            this.cmsiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // businessDataCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeBusinessData);
            this.Name = "businessDataCtrl";
            this.Size = new System.Drawing.Size(279, 525);
            ((System.ComponentModel.ISupportInitialize)(this.treeBusinessData)).EndInit();
            this.cmsBusinessDatas.ResumeLayout(false);
            this.cmsBusinessData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeBusinessData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;
        private System.Windows.Forms.ContextMenuStrip cmsBusinessDatas;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ContextMenuStrip cmsBusinessData;
        private System.Windows.Forms.ToolStripMenuItem cmsiEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsiDel;
    }
}
