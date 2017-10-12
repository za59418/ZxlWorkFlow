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
            this.UName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).BeginInit();
            this.cmsUsers.SuspendLayout();
            this.cmsUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeUser
            // 
            this.treeUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.UName});
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
            this.treeUser.OptionsView.ShowHorzLines = false;
            this.treeUser.OptionsView.ShowVertLines = false;
            this.treeUser.Size = new System.Drawing.Size(284, 554);
            this.treeUser.TabIndex = 0;
            this.treeUser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeUser_MouseClick);
            this.treeUser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeUser_MouseDoubleClick);
            // 
            // UName
            // 
            this.UName.Caption = "名称";
            this.UName.FieldName = "NAME";
            this.UName.MinWidth = 31;
            this.UName.Name = "UName";
            this.UName.OptionsColumn.AllowEdit = false;
            this.UName.Visible = true;
            this.UName.VisibleIndex = 0;
            // 
            // cmsUsers
            // 
            this.cmsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAdd});
            this.cmsUsers.Name = "contextMenuBd";
            this.cmsUsers.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsAdd
            // 
            this.cmsAdd.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsAdd.Name = "cmsAdd";
            this.cmsAdd.Size = new System.Drawing.Size(152, 22);
            this.cmsAdd.Text = "添加用户";
            this.cmsAdd.Click += new System.EventHandler(this.cmsAddUser_Click);
            // 
            // cmsUser
            // 
            this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiDel});
            this.cmsUser.Name = "contextMenuBd";
            this.cmsUser.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsiDel
            // 
            this.cmsiDel.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDel.Name = "cmsiDel";
            this.cmsiDel.Size = new System.Drawing.Size(124, 22);
            this.cmsiDel.Text = "删除用户";
            this.cmsiDel.Click += new System.EventHandler(this.cmsDelUser_Click);
            // 
            // userCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeUser);
            this.Name = "userCtrl";
            this.Size = new System.Drawing.Size(284, 554);
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).EndInit();
            this.cmsUsers.ResumeLayout(false);
            this.cmsUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UName;
        private System.Windows.Forms.ContextMenuStrip cmsUsers;
        private System.Windows.Forms.ToolStripMenuItem cmsAdd;
        private System.Windows.Forms.ContextMenuStrip cmsUser;
        private System.Windows.Forms.ToolStripMenuItem cmsiDel;
    }
}
