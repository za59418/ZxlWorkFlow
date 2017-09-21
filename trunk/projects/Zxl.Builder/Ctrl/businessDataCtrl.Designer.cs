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
            this.contextMenuBd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddBusinessData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditBusinessData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelBusinessData = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.treeListDetail = new DevExpress.XtraTreeList.TreeList();
            this.bdName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDataType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bdLength = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdNullable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bdDefaultVal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuBdt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddMetaData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelMetaData = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBusinessDataName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeBusinessData)).BeginInit();
            this.contextMenuBd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.contextMenuBdt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusinessDataName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeBusinessData
            // 
            this.treeBusinessData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bName,
            this.bDescription});
            this.treeBusinessData.ContextMenuStrip = this.contextMenuBd;
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
            this.treeBusinessData.Size = new System.Drawing.Size(322, 514);
            this.treeBusinessData.TabIndex = 0;
            this.treeBusinessData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeBusinessData_MouseUp);
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
            // contextMenuBd
            // 
            this.contextMenuBd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddBusinessData,
            this.tsmiEditBusinessData,
            this.tsmiDelBusinessData});
            this.contextMenuBd.Name = "contextMenuBd";
            this.contextMenuBd.Size = new System.Drawing.Size(149, 70);
            // 
            // tsmiAddBusinessData
            // 
            this.tsmiAddBusinessData.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAddBusinessData.Name = "tsmiAddBusinessData";
            this.tsmiAddBusinessData.Size = new System.Drawing.Size(148, 22);
            this.tsmiAddBusinessData.Text = "添加业务数据";
            this.tsmiAddBusinessData.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiEditBusinessData
            // 
            this.tsmiEditBusinessData.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.tsmiEditBusinessData.Name = "tsmiEditBusinessData";
            this.tsmiEditBusinessData.Size = new System.Drawing.Size(148, 22);
            this.tsmiEditBusinessData.Text = "编辑业务数据";
            this.tsmiEditBusinessData.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelBusinessData
            // 
            this.tsmiDelBusinessData.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelBusinessData.Name = "tsmiDelBusinessData";
            this.tsmiDelBusinessData.Size = new System.Drawing.Size(148, 22);
            this.tsmiDelBusinessData.Text = "删除业务数据";
            this.tsmiDelBusinessData.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeBusinessData);
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
            this.panelControl2.Controls.Add(this.treeListDetail);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 57);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(666, 457);
            this.panelControl2.TabIndex = 6;
            // 
            // treeListDetail
            // 
            this.treeListDetail.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bdName,
            this.bdDescription,
            this.bdDataType,
            this.bdLength,
            this.bdNullable,
            this.bdDefaultVal,
            this.treeListColumn1});
            this.treeListDetail.ContextMenuStrip = this.contextMenuBdt;
            this.treeListDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDetail.Location = new System.Drawing.Point(2, 2);
            this.treeListDetail.LookAndFeel.SkinName = "iMaginary";
            this.treeListDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeListDetail.Name = "treeListDetail";
            this.treeListDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDetail.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDetail.OptionsView.ShowCheckBoxes = true;
            this.treeListDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.treeListDetail.Size = new System.Drawing.Size(662, 453);
            this.treeListDetail.TabIndex = 0;
            this.treeListDetail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeListDetail_MouseUp);
            // 
            // bdName
            // 
            this.bdName.Caption = "名称";
            this.bdName.FieldName = "NAME";
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
            this.bdDescription.Caption = "描述";
            this.bdDescription.FieldName = "DESCRIPTION";
            this.bdDescription.MinWidth = 30;
            this.bdDescription.Name = "bdDescription";
            this.bdDescription.OptionsColumn.AllowEdit = false;
            this.bdDescription.OptionsColumn.FixedWidth = true;
            this.bdDescription.Visible = true;
            this.bdDescription.VisibleIndex = 1;
            this.bdDescription.Width = 150;
            // 
            // bdDataType
            // 
            this.bdDataType.Caption = "数据类型";
            this.bdDataType.ColumnEdit = this.repositoryItemComboBox1;
            this.bdDataType.FieldName = "DATATYPE";
            this.bdDataType.MinWidth = 30;
            this.bdDataType.Name = "bdDataType";
            this.bdDataType.OptionsColumn.AllowEdit = false;
            this.bdDataType.OptionsColumn.FixedWidth = true;
            this.bdDataType.Visible = true;
            this.bdDataType.VisibleIndex = 2;
            this.bdDataType.Width = 80;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // bdLength
            // 
            this.bdLength.Caption = "长度";
            this.bdLength.FieldName = "LENGTH";
            this.bdLength.Name = "bdLength";
            this.bdLength.OptionsColumn.AllowEdit = false;
            this.bdLength.OptionsColumn.FixedWidth = true;
            this.bdLength.Visible = true;
            this.bdLength.VisibleIndex = 3;
            this.bdLength.Width = 80;
            // 
            // bdNullable
            // 
            this.bdNullable.Caption = "可为空";
            this.bdNullable.ColumnEdit = this.repositoryItemCheckEdit1;
            this.bdNullable.FieldName = "NULLABLE";
            this.bdNullable.Name = "bdNullable";
            this.bdNullable.OptionsColumn.AllowEdit = false;
            this.bdNullable.OptionsColumn.FixedWidth = true;
            this.bdNullable.Visible = true;
            this.bdNullable.VisibleIndex = 4;
            this.bdNullable.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // bdDefaultVal
            // 
            this.bdDefaultVal.Caption = "默认值";
            this.bdDefaultVal.FieldName = "DEFAULTVAL";
            this.bdDefaultVal.Name = "bdDefaultVal";
            this.bdDefaultVal.OptionsColumn.AllowEdit = false;
            this.bdDefaultVal.OptionsColumn.FixedWidth = true;
            this.bdDefaultVal.Visible = true;
            this.bdDefaultVal.VisibleIndex = 5;
            this.bdDefaultVal.Width = 100;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = " ";
            this.treeListColumn1.FieldName = "none";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 6;
            // 
            // contextMenuBdt
            // 
            this.contextMenuBdt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddMetaData,
            this.tsmiDelMetaData});
            this.contextMenuBdt.Name = "contextMenuBdt";
            this.contextMenuBdt.Size = new System.Drawing.Size(137, 48);
            // 
            // tsmiAddMetaData
            // 
            this.tsmiAddMetaData.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAddMetaData.Name = "tsmiAddMetaData";
            this.tsmiAddMetaData.Size = new System.Drawing.Size(136, 22);
            this.tsmiAddMetaData.Text = "添加元数据";
            this.tsmiAddMetaData.Click += new System.EventHandler(this.tsmiAddMetaData_Click);
            // 
            // tsmiDelMetaData
            // 
            this.tsmiDelMetaData.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelMetaData.Name = "tsmiDelMetaData";
            this.tsmiDelMetaData.Size = new System.Drawing.Size(136, 22);
            this.tsmiDelMetaData.Text = "删除元数据";
            this.tsmiDelMetaData.Click += new System.EventHandler(this.tsmiDelMetaData_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtBusinessDataName);
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
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "当前业务数据：";
            // 
            // txtBusinessDataName
            // 
            this.txtBusinessDataName.Location = new System.Drawing.Point(105, 21);
            this.txtBusinessDataName.Name = "txtBusinessDataName";
            this.txtBusinessDataName.Size = new System.Drawing.Size(242, 20);
            this.txtBusinessDataName.TabIndex = 0;
            // 
            // businessDataCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "businessDataCtrl";
            this.Size = new System.Drawing.Size(993, 514);
            ((System.ComponentModel.ISupportInitialize)(this.treeBusinessData)).EndInit();
            this.contextMenuBd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.contextMenuBdt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusinessDataName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeBusinessData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBusinessDataName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTreeList.TreeList treeListDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDataType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdLength;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdNullable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDefaultVal;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuBd;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddBusinessData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelBusinessData;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditBusinessData;
        private System.Windows.Forms.ContextMenuStrip contextMenuBdt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddMetaData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelMetaData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}
