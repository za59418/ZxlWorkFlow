namespace Zxl.Builder
{
    partial class userCtrl
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
            this.treeUser = new DevExpress.XtraTreeList.TreeList();
            this.mName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.mDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMobile = new DevExpress.XtraEditors.TextEdit();
            this.contextMenuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDelUser = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).BeginInit();
            this.contextMenuUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeUser
            // 
            this.treeUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.mName,
            this.mDescription});
            this.treeUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUser.Location = new System.Drawing.Point(0, 0);
            this.treeUser.LookAndFeel.SkinName = "iMaginary";
            this.treeUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeUser.Name = "treeUser";
            this.treeUser.OptionsBehavior.AutoChangeParent = false;
            this.treeUser.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeUser.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeUser.OptionsBehavior.ShowToolTips = false;
            this.treeUser.OptionsBehavior.SmartMouseHover = false;
            this.treeUser.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeUser.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeUser.OptionsView.ShowCheckBoxes = true;
            this.treeUser.Size = new System.Drawing.Size(322, 514);
            this.treeUser.TabIndex = 0;
            this.treeUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contextMenuUser_MouseUp);
            // 
            // mName
            // 
            this.mName.Caption = "名称";
            this.mName.FieldName = "NAME";
            this.mName.MinWidth = 31;
            this.mName.Name = "mName";
            this.mName.OptionsColumn.AllowEdit = false;
            this.mName.Visible = true;
            this.mName.VisibleIndex = 0;
            // 
            // mDescription
            // 
            this.mDescription.Caption = "描述";
            this.mDescription.FieldName = "DESCRIPTION";
            this.mDescription.Name = "mDescription";
            this.mDescription.OptionsColumn.AllowEdit = false;
            this.mDescription.Visible = true;
            this.mDescription.VisibleIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeUser);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(993, 514);
            this.splitContainerControl1.SplitterPosition = 322;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtEmail);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtUserName);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtMobile);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 514);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(45, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "邮箱：";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(105, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(33, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "用户名：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(105, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(242, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "移动电话：";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(105, 61);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(242, 20);
            this.txtMobile.TabIndex = 1;
            // 
            // contextMenuUser
            // 
            this.contextMenuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAddUser,
            this.cmsEditUser,
            this.cmsDelUser});
            this.contextMenuUser.Name = "contextMenuBd";
            this.contextMenuUser.Size = new System.Drawing.Size(153, 92);
            this.contextMenuUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contextMenuUser_MouseUp);
            // 
            // cmsAddUser
            // 
            this.cmsAddUser.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsAddUser.Name = "cmsAddUser";
            this.cmsAddUser.Size = new System.Drawing.Size(152, 22);
            this.cmsAddUser.Text = "添加用户";
            this.cmsAddUser.Click += new System.EventHandler(this.cmsAddUser_Click);
            // 
            // cmsEditUser
            // 
            this.cmsEditUser.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsEditUser.Name = "cmsEditUser";
            this.cmsEditUser.Size = new System.Drawing.Size(152, 22);
            this.cmsEditUser.Text = "编辑用户";
            this.cmsEditUser.Click += new System.EventHandler(this.cmsEditUser_Click);
            // 
            // cmsDelUser
            // 
            this.cmsDelUser.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsDelUser.Name = "cmsDelUser";
            this.cmsDelUser.Size = new System.Drawing.Size(152, 22);
            this.cmsDelUser.Text = "删除用户";
            this.cmsDelUser.Click += new System.EventHandler(this.cmsDelUser_Click);
            // 
            // userCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "userCtrl";
            this.Size = new System.Drawing.Size(993, 514);
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).EndInit();
            this.contextMenuUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn mName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn mDescription;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuUser;
        private System.Windows.Forms.ToolStripMenuItem cmsAddUser;
        private System.Windows.Forms.ToolStripMenuItem cmsEditUser;
        private System.Windows.Forms.ToolStripMenuItem cmsDelUser;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.TextEdit txtMobile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEmail;
    }
}
