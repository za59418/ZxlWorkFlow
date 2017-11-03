namespace Zxl.Builder
{
    partial class DockOrg
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
            this.cmsOrg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.csmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsOrgs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.treeOrg = new DevExpress.XtraTreeList.TreeList();
            this.bName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsOrg.SuspendLayout();
            this.cmsOrgs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeOrg)).BeginInit();
            this.SuspendLayout();
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
            this.treeOrg.Size = new System.Drawing.Size(240, 460);
            this.treeOrg.TabIndex = 2;
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
            // DockOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 460);
            this.Controls.Add(this.treeOrg);
            this.Name = "DockOrg";
            this.ShowIcon = false;
            this.TabText = "活动列表";
            this.Text = "活动列表";
            this.cmsOrg.ResumeLayout(false);
            this.cmsOrgs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeOrg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsOrg;
        private System.Windows.Forms.ToolStripMenuItem csmiEdit;
        private System.Windows.Forms.ToolStripMenuItem csmiDel;
        private System.Windows.Forms.ContextMenuStrip cmsOrgs;
        private System.Windows.Forms.ToolStripMenuItem csmiAdd;
        private DevExpress.XtraTreeList.TreeList treeOrg;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;

    }
}