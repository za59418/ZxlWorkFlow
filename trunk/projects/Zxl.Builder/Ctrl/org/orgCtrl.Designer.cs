namespace Zxl.Builder
{
    partial class orgCtrl
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
            this.treeOrg = new DevExpress.XtraTreeList.TreeList();
            this.bName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsOrgs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOrg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.csmiDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeOrg)).BeginInit();
            this.cmsOrgs.SuspendLayout();
            this.cmsOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeOrg
            // 
            this.treeOrg.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bName,
            this.bDescription});
            this.treeOrg.ContextMenuStrip = this.cmsOrgs;
            this.treeOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOrg.Location = new System.Drawing.Point(0, 0);
            this.treeOrg.LookAndFeel.SkinName = "iMaginary";
            this.treeOrg.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeOrg.Name = "treeOrg";
            this.treeOrg.OptionsBehavior.AutoChangeParent = false;
            this.treeOrg.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeOrg.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeOrg.OptionsBehavior.ShowToolTips = false;
            this.treeOrg.OptionsBehavior.SmartMouseHover = false;
            this.treeOrg.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeOrg.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeOrg.OptionsView.ShowCheckBoxes = true;
            this.treeOrg.Size = new System.Drawing.Size(363, 579);
            this.treeOrg.TabIndex = 0;
            this.treeOrg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeOrg_MouseClick);
            this.treeOrg.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeOrg_MouseDoubleClick);
            // 
            // bName
            // 
            this.bName.Caption = "名称";
            this.bName.FieldName = "ROLENAME";
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
            // cmsOrgs
            // 
            this.cmsOrgs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csmiAdd});
            this.cmsOrgs.Name = "contextMenuBd";
            this.cmsOrgs.Size = new System.Drawing.Size(153, 48);
            // 
            // csmiAdd
            // 
            this.csmiAdd.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.csmiAdd.Name = "csmiAdd";
            this.csmiAdd.Size = new System.Drawing.Size(152, 22);
            this.csmiAdd.Text = "添加机构";
            this.csmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // cmsOrg
            // 
            this.cmsOrg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csmiEdit,
            this.csmiDel});
            this.cmsOrg.Name = "contextMenuBd";
            this.cmsOrg.Size = new System.Drawing.Size(125, 48);
            // 
            // csmiEdit
            // 
            this.csmiEdit.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.csmiEdit.Name = "csmiEdit";
            this.csmiEdit.Size = new System.Drawing.Size(124, 22);
            this.csmiEdit.Text = "编辑机构";
            this.csmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // csmiDel
            // 
            this.csmiDel.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.csmiDel.Name = "csmiDel";
            this.csmiDel.Size = new System.Drawing.Size(124, 22);
            this.csmiDel.Text = "删除机构";
            this.csmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // orgCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeOrg);
            this.Name = "orgCtrl";
            this.Size = new System.Drawing.Size(363, 579);
            ((System.ComponentModel.ISupportInitialize)(this.treeOrg)).EndInit();
            this.cmsOrgs.ResumeLayout(false);
            this.cmsOrg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeOrg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;
        private System.Windows.Forms.ContextMenuStrip cmsOrgs;
        private System.Windows.Forms.ToolStripMenuItem csmiAdd;
        private System.Windows.Forms.ContextMenuStrip cmsOrg;
        private System.Windows.Forms.ToolStripMenuItem csmiEdit;
        private System.Windows.Forms.ToolStripMenuItem csmiDel;
    }
}
