namespace Zxl.Builder
{
    partial class DockRole
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
            this.cmsRole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRoles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.treeRole = new DevExpress.XtraTreeList.TreeList();
            this.bName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsRole.SuspendLayout();
            this.cmsRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeRole)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsRole
            // 
            this.cmsRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEdit,
            this.cmsiDel});
            this.cmsRole.Name = "contextMenuBd";
            this.cmsRole.Size = new System.Drawing.Size(125, 48);
            // 
            // cmsiEdit
            // 
            this.cmsiEdit.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEdit.Name = "cmsiEdit";
            this.cmsiEdit.Size = new System.Drawing.Size(124, 22);
            this.cmsiEdit.Text = "编辑角色";
            this.cmsiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // cmsiDel
            // 
            this.cmsiDel.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDel.Name = "cmsiDel";
            this.cmsiDel.Size = new System.Drawing.Size(124, 22);
            this.cmsiDel.Text = "删除角色";
            this.cmsiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // cmsRoles
            // 
            this.cmsRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csmiAdd});
            this.cmsRoles.Name = "contextMenuBd";
            this.cmsRoles.Size = new System.Drawing.Size(153, 48);
            // 
            // csmiAdd
            // 
            this.csmiAdd.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.csmiAdd.Name = "csmiAdd";
            this.csmiAdd.Size = new System.Drawing.Size(152, 22);
            this.csmiAdd.Text = "添加角色";
            this.csmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // treeRole
            // 
            this.treeRole.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bName,
            this.bDescription});
            this.treeRole.ContextMenuStrip = this.cmsRoles;
            this.treeRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRole.Location = new System.Drawing.Point(0, 0);
            this.treeRole.LookAndFeel.SkinName = "iMaginary";
            this.treeRole.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeRole.Name = "treeRole";
            this.treeRole.OptionsBehavior.AutoChangeParent = false;
            this.treeRole.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeRole.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeRole.OptionsBehavior.ShowToolTips = false;
            this.treeRole.OptionsBehavior.SmartMouseHover = false;
            this.treeRole.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeRole.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeRole.OptionsView.ShowCheckBoxes = true;
            this.treeRole.Size = new System.Drawing.Size(267, 461);
            this.treeRole.TabIndex = 2;
            this.treeRole.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeRole_MouseClick);
            this.treeRole.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeRole_MouseDoubleClick);
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
            // DockRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 461);
            this.Controls.Add(this.treeRole);
            this.Name = "DockRole";
            this.ShowIcon = false;
            this.TabText = "角色列表";
            this.Text = "角色列表";
            this.cmsRole.ResumeLayout(false);
            this.cmsRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsRole;
        private System.Windows.Forms.ToolStripMenuItem cmsiEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsiDel;
        private System.Windows.Forms.ContextMenuStrip cmsRoles;
        private System.Windows.Forms.ToolStripMenuItem csmiAdd;
        private DevExpress.XtraTreeList.TreeList treeRole;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;

    }
}