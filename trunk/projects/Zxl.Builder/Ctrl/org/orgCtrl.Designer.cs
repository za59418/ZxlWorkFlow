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
            this.contextMenuRole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddOrg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditOrg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelOrg = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.treeUserOrg = new DevExpress.XtraTreeList.TreeList();
            this.bdName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDataType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdLength = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdNullable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDefaultVal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuRoleDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelUser = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOrgName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeOrg)).BeginInit();
            this.contextMenuRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeUserOrg)).BeginInit();
            this.contextMenuRoleDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeOrg
            // 
            this.treeOrg.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bName,
            this.bDescription});
            this.treeOrg.ContextMenuStrip = this.contextMenuRole;
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
            this.treeOrg.Size = new System.Drawing.Size(322, 514);
            this.treeOrg.TabIndex = 0;
            this.treeOrg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeOrg_MouseUp);
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
            // contextMenuRole
            // 
            this.contextMenuRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddOrg,
            this.tsmiEditOrg,
            this.tsmiDelOrg});
            this.contextMenuRole.Name = "contextMenuBd";
            this.contextMenuRole.Size = new System.Drawing.Size(125, 70);
            // 
            // tsmiAddOrg
            // 
            this.tsmiAddOrg.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAddOrg.Name = "tsmiAddOrg";
            this.tsmiAddOrg.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddOrg.Text = "添加机构";
            this.tsmiAddOrg.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiEditOrg
            // 
            this.tsmiEditOrg.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.tsmiEditOrg.Name = "tsmiEditOrg";
            this.tsmiEditOrg.Size = new System.Drawing.Size(124, 22);
            this.tsmiEditOrg.Text = "编辑机构";
            this.tsmiEditOrg.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelOrg
            // 
            this.tsmiDelOrg.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelOrg.Name = "tsmiDelOrg";
            this.tsmiDelOrg.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelOrg.Text = "删除机构";
            this.tsmiDelOrg.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeOrg);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(993, 514);
            this.splitContainerControl1.SplitterPosition = 322;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.treeUserOrg);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 57);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(666, 457);
            this.panelControl2.TabIndex = 6;
            // 
            // treeUserOrg
            // 
            this.treeUserOrg.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bdName,
            this.bdDescription,
            this.bdDataType,
            this.bdLength,
            this.bdNullable,
            this.bdDefaultVal,
            this.treeListColumn1});
            this.treeUserOrg.ContextMenuStrip = this.contextMenuRoleDetail;
            this.treeUserOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUserOrg.Location = new System.Drawing.Point(2, 2);
            this.treeUserOrg.LookAndFeel.SkinName = "iMaginary";
            this.treeUserOrg.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeUserOrg.Name = "treeUserOrg";
            this.treeUserOrg.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeUserOrg.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeUserOrg.OptionsView.ShowCheckBoxes = true;
            this.treeUserOrg.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.treeUserOrg.Size = new System.Drawing.Size(662, 453);
            this.treeUserOrg.TabIndex = 0;
            this.treeUserOrg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeUserOrg_MouseUp);
            // 
            // bdName
            // 
            this.bdName.Caption = "名称";
            this.bdName.FieldName = "名称";
            this.bdName.MinWidth = 31;
            this.bdName.Name = "bdName";
            this.bdName.OptionsColumn.AllowEdit = false;
            this.bdName.OptionsColumn.FixedWidth = true;
            this.bdName.Visible = true;
            this.bdName.VisibleIndex = 0;
            this.bdName.Width = 200;
            // 
            // bdDescription
            // 
            this.bdDescription.Caption = "昵称";
            this.bdDescription.FieldName = "昵称";
            this.bdDescription.MinWidth = 30;
            this.bdDescription.Name = "bdDescription";
            this.bdDescription.OptionsColumn.AllowEdit = false;
            this.bdDescription.OptionsColumn.FixedWidth = true;
            this.bdDescription.Visible = true;
            this.bdDescription.VisibleIndex = 1;
            this.bdDescription.Width = 80;
            // 
            // bdDataType
            // 
            this.bdDataType.Caption = "移动电话";
            this.bdDataType.FieldName = "移动电话";
            this.bdDataType.MinWidth = 30;
            this.bdDataType.Name = "bdDataType";
            this.bdDataType.OptionsColumn.AllowEdit = false;
            this.bdDataType.OptionsColumn.FixedWidth = true;
            this.bdDataType.Visible = true;
            this.bdDataType.VisibleIndex = 2;
            this.bdDataType.Width = 100;
            // 
            // bdLength
            // 
            this.bdLength.Caption = "固定电话";
            this.bdLength.FieldName = "固定电话";
            this.bdLength.Name = "bdLength";
            this.bdLength.OptionsColumn.AllowEdit = false;
            this.bdLength.OptionsColumn.FixedWidth = true;
            this.bdLength.Visible = true;
            this.bdLength.VisibleIndex = 3;
            this.bdLength.Width = 100;
            // 
            // bdNullable
            // 
            this.bdNullable.Caption = "邮箱";
            this.bdNullable.FieldName = "邮箱";
            this.bdNullable.Name = "bdNullable";
            this.bdNullable.OptionsColumn.AllowEdit = false;
            this.bdNullable.OptionsColumn.FixedWidth = true;
            this.bdNullable.Visible = true;
            this.bdNullable.VisibleIndex = 4;
            this.bdNullable.Width = 150;
            // 
            // bdDefaultVal
            // 
            this.bdDefaultVal.Caption = "创建时间";
            this.bdDefaultVal.FieldName = "创建时间";
            this.bdDefaultVal.Name = "bdDefaultVal";
            this.bdDefaultVal.OptionsColumn.AllowEdit = false;
            this.bdDefaultVal.OptionsColumn.FixedWidth = true;
            this.bdDefaultVal.Visible = true;
            this.bdDefaultVal.VisibleIndex = 5;
            this.bdDefaultVal.Width = 150;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = " ";
            this.treeListColumn1.FieldName = "none";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 6;
            // 
            // contextMenuRoleDetail
            // 
            this.contextMenuRoleDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddUser,
            this.tsmiDelUser});
            this.contextMenuRoleDetail.Name = "contextMenuBdt";
            this.contextMenuRoleDetail.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddUser.Text = "添加用户";
            this.tsmiAddUser.Click += new System.EventHandler(this.cmsAddUser_Click);
            // 
            // tsmiDelUser
            // 
            this.tsmiDelUser.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelUser.Name = "tsmiDelUser";
            this.tsmiDelUser.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelUser.Text = "删除用户";
            this.tsmiDelUser.Click += new System.EventHandler(this.cmsDelUser_Click);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtOrgName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 57);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "当前角色：";
            // 
            // txtOrgName
            // 
            this.txtOrgName.Location = new System.Drawing.Point(105, 21);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Size = new System.Drawing.Size(242, 20);
            this.txtOrgName.TabIndex = 0;
            // 
            // orgCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "orgCtrl";
            this.Size = new System.Drawing.Size(993, 514);
            ((System.ComponentModel.ISupportInitialize)(this.treeOrg)).EndInit();
            this.contextMenuRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeUserOrg)).EndInit();
            this.contextMenuRoleDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrgName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeOrg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtOrgName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTreeList.TreeList treeUserOrg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDataType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdLength;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdNullable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDefaultVal;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuRole;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddOrg;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelOrg;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditOrg;
        private System.Windows.Forms.ContextMenuStrip contextMenuRoleDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}
