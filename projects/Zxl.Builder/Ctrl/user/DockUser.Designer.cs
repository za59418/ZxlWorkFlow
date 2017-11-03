namespace Zxl.Builder
{
    partial class DockUser
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
            this.components = new System.ComponentModel.Container();
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.treeUser = new DevExpress.XtraTreeList.TreeList();
            this.UName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsUser.SuspendLayout();
            this.cmsUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).BeginInit();
            this.SuspendLayout();
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
            // cmsUsers
            // 
            this.cmsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsAdd});
            this.cmsUsers.Name = "contextMenuBd";
            this.cmsUsers.Size = new System.Drawing.Size(153, 48);
            // 
            // cmsAdd
            // 
            this.cmsAdd.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsAdd.Name = "cmsAdd";
            this.cmsAdd.Size = new System.Drawing.Size(152, 22);
            this.cmsAdd.Text = "添加用户";
            this.cmsAdd.Click += new System.EventHandler(this.cmsAddUser_Click);
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
            this.treeUser.Size = new System.Drawing.Size(278, 489);
            this.treeUser.TabIndex = 2;
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
            // DockUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 489);
            this.Controls.Add(this.treeUser);
            this.Name = "DockUser";
            this.ShowIcon = false;
            this.TabText = "活动列表";
            this.Text = "活动列表";
            this.cmsUser.ResumeLayout(false);
            this.cmsUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsUser;
        private System.Windows.Forms.ToolStripMenuItem cmsiDel;
        private System.Windows.Forms.ContextMenuStrip cmsUsers;
        private System.Windows.Forms.ToolStripMenuItem cmsAdd;
        private DevExpress.XtraTreeList.TreeList treeUser;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UName;

    }
}