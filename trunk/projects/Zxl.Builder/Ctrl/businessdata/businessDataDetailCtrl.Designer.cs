namespace Zxl.Builder
{
    partial class businessDataDetailCtrl
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
            ((System.ComponentModel.ISupportInitialize)(this.treeListDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.contextMenuBdt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBusinessDataName.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.treeListDetail.Location = new System.Drawing.Point(0, 57);
            this.treeListDetail.LookAndFeel.SkinName = "iMaginary";
            this.treeListDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeListDetail.Name = "treeListDetail";
            this.treeListDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDetail.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDetail.OptionsView.ShowCheckBoxes = true;
            this.treeListDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.treeListDetail.Size = new System.Drawing.Size(993, 457);
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
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtBusinessDataName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(993, 57);
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
            // businessDataDetailCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListDetail);
            this.Controls.Add(this.panelControl1);
            this.Name = "businessDataDetailCtrl";
            this.Size = new System.Drawing.Size(993, 514);
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

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBusinessDataName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList treeListDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDataType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdLength;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdNullable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDefaultVal;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuBdt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddMetaData;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelMetaData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}
