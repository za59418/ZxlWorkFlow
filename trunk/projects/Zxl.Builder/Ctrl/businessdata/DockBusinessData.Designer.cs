namespace Zxl.Builder
{
    partial class DockBusinessData
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
            this.cmsBusinessData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBusinessDatas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.treeBusinessData = new DevExpress.XtraTreeList.TreeList();
            this.bName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsBusinessData.SuspendLayout();
            this.cmsBusinessDatas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeBusinessData)).BeginInit();
            this.SuspendLayout();
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
            this.treeBusinessData.Size = new System.Drawing.Size(239, 439);
            this.treeBusinessData.TabIndex = 2;
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
            // DockBusinessData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 439);
            this.Controls.Add(this.treeBusinessData);
            this.Name = "DockBusinessData";
            this.ShowIcon = false;
            this.TabText = "业务数据";
            this.Text = "业务数据";
            this.cmsBusinessData.ResumeLayout(false);
            this.cmsBusinessDatas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeBusinessData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsBusinessData;
        private System.Windows.Forms.ToolStripMenuItem cmsiEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsiDel;
        private System.Windows.Forms.ContextMenuStrip cmsBusinessDatas;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private DevExpress.XtraTreeList.TreeList treeBusinessData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;

    }
}