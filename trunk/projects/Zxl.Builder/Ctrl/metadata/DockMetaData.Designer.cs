namespace Zxl.Builder
{
    partial class DockMetaData
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
            this.cmsMetadata = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMetadatas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.treeMetaData = new DevExpress.XtraTreeList.TreeList();
            this.mName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.mDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cmsMetadata.SuspendLayout();
            this.cmsMetadatas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaData)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsMetadata
            // 
            this.cmsMetadata.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEdit,
            this.cmsiDel});
            this.cmsMetadata.Name = "contextMenuBd";
            this.cmsMetadata.Size = new System.Drawing.Size(137, 48);
            // 
            // cmsiEdit
            // 
            this.cmsiEdit.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEdit.Name = "cmsiEdit";
            this.cmsiEdit.Size = new System.Drawing.Size(136, 22);
            this.cmsiEdit.Text = "编辑元数据";
            this.cmsiEdit.Click += new System.EventHandler(this.cmsEditMetaData_Click);
            // 
            // cmsiDel
            // 
            this.cmsiDel.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDel.Name = "cmsiDel";
            this.cmsiDel.Size = new System.Drawing.Size(136, 22);
            this.cmsiDel.Text = "删除元数据";
            this.cmsiDel.Click += new System.EventHandler(this.cmsDelMetaData_Click);
            // 
            // cmsMetadatas
            // 
            this.cmsMetadatas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAdd});
            this.cmsMetadatas.Name = "contextMenuBd";
            this.cmsMetadatas.Size = new System.Drawing.Size(153, 48);
            // 
            // cmsiAdd
            // 
            this.cmsiAdd.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsiAdd.Name = "cmsiAdd";
            this.cmsiAdd.Size = new System.Drawing.Size(152, 22);
            this.cmsiAdd.Text = "添加元数据";
            this.cmsiAdd.Click += new System.EventHandler(this.cmsAddMetaData_Click);
            // 
            // treeMetaData
            // 
            this.treeMetaData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.mName,
            this.mDescription});
            this.treeMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMetaData.Location = new System.Drawing.Point(0, 0);
            this.treeMetaData.LookAndFeel.SkinName = "iMaginary";
            this.treeMetaData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeMetaData.Name = "treeMetaData";
            this.treeMetaData.OptionsBehavior.AutoChangeParent = false;
            this.treeMetaData.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeMetaData.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeMetaData.OptionsBehavior.ShowToolTips = false;
            this.treeMetaData.OptionsBehavior.SmartMouseHover = false;
            this.treeMetaData.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeMetaData.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeMetaData.OptionsView.ShowCheckBoxes = true;
            this.treeMetaData.Size = new System.Drawing.Size(253, 464);
            this.treeMetaData.TabIndex = 2;
            this.treeMetaData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeMetaData_MouseClick);
            this.treeMetaData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeMetaData_MouseDoubleClick);
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
            // DockMetaData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 464);
            this.Controls.Add(this.treeMetaData);
            this.Name = "DockMetaData";
            this.ShowIcon = false;
            this.TabText = "原数据";
            this.Text = "原数据";
            this.cmsMetadata.ResumeLayout(false);
            this.cmsMetadatas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsMetadata;
        private System.Windows.Forms.ToolStripMenuItem cmsiEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsiDel;
        private System.Windows.Forms.ContextMenuStrip cmsMetadatas;
        private System.Windows.Forms.ToolStripMenuItem cmsiAdd;
        private DevExpress.XtraTreeList.TreeList treeMetaData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn mName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn mDescription;

    }
}