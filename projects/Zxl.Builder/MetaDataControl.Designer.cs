namespace Zxl.Builder
{
    partial class MetaDataControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetaDataControl));
            this.treeMetaData = new DevExpress.XtraTreeList.TreeList();
            this.Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Description = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.treeListProperty = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCommit = new System.Windows.Forms.ToolStripButton();
            this.btnRollback = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLock = new System.Windows.Forms.ToolStripButton();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.btnDelRow = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMetaDataName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMetaDataDesc = new DevExpress.XtraEditors.TextEdit();
            this.obj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNullAble = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDefaultVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListProperty)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeMetaData
            // 
            this.treeMetaData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.Name,
            this.Description});
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
            this.treeMetaData.Size = new System.Drawing.Size(322, 514);
            this.treeMetaData.TabIndex = 0;
            this.treeMetaData.Click += new System.EventHandler(this.treeMetaData_Click);
            // 
            // Name
            // 
            this.Name.Caption = "名称";
            this.Name.FieldName = "NAME";
            this.Name.MinWidth = 31;
            this.Name.Name = "Name";
            this.Name.OptionsColumn.AllowEdit = false;
            this.Name.Visible = true;
            this.Name.VisibleIndex = 0;
            // 
            // Description
            // 
            this.Description.Caption = "描述";
            this.Description.FieldName = "DESCRIPTION";
            this.Description.Name = "Description";
            this.Description.OptionsColumn.AllowEdit = false;
            this.Description.Visible = true;
            this.Description.VisibleIndex = 1;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeMetaData);
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
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.toolStrip1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 105);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(666, 409);
            this.panelControl2.TabIndex = 6;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.treeListProperty);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 27);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(662, 380);
            this.panelControl3.TabIndex = 5;
            // 
            // treeListProperty
            // 
            this.treeListProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.treeListProperty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.obj,
            this.pName,
            this.pDescription,
            this.pDataType,
            this.pLength,
            this.pNullAble,
            this.pDefaultVal});
            this.treeListProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListProperty.Enabled = false;
            this.treeListProperty.Location = new System.Drawing.Point(2, 2);
            this.treeListProperty.Name = "treeListProperty";
            this.treeListProperty.RowTemplate.Height = 23;
            this.treeListProperty.Size = new System.Drawing.Size(658, 376);
            this.treeListProperty.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCommit,
            this.btnRollback,
            this.toolStripSeparator1,
            this.btnLock,
            this.btnAddRow,
            this.btnDelRow,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(662, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCommit
            // 
            this.btnCommit.Enabled = false;
            this.btnCommit.Image = ((System.Drawing.Image)(resources.GetObject("btnCommit.Image")));
            this.btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(23, 22);
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Enabled = false;
            this.btnRollback.Image = ((System.Drawing.Image)(resources.GetObject("btnRollback.Image")));
            this.btnRollback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(23, 22);
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLock
            // 
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(23, 22);
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRow.Enabled = false;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(23, 22);
            this.btnAddRow.Text = "toolStripButton4";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelRow.Enabled = false;
            this.btnDelRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRow.Image")));
            this.btnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(23, 22);
            this.btnDelRow.Text = "toolStripButton5";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton6";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMetaDataName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtMetaDataDesc);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 105);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "当前元数据：";
            // 
            // txtMetaDataName
            // 
            this.txtMetaDataName.Location = new System.Drawing.Point(105, 21);
            this.txtMetaDataName.Name = "txtMetaDataName";
            this.txtMetaDataName.Size = new System.Drawing.Size(242, 20);
            this.txtMetaDataName.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(57, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "描述：";
            // 
            // txtMetaDataDesc
            // 
            this.txtMetaDataDesc.Location = new System.Drawing.Point(105, 61);
            this.txtMetaDataDesc.Name = "txtMetaDataDesc";
            this.txtMetaDataDesc.Size = new System.Drawing.Size(242, 20);
            this.txtMetaDataDesc.TabIndex = 1;
            // 
            // obj
            // 
            this.obj.HeaderText = "Column1";
            this.obj.Name = "obj";
            this.obj.Visible = false;
            // 
            // pName
            // 
            this.pName.HeaderText = "名称";
            this.pName.Name = "pName";
            // 
            // pDescription
            // 
            this.pDescription.HeaderText = "描述";
            this.pDescription.Name = "pDescription";
            // 
            // pDataType
            // 
            this.pDataType.HeaderText = "数据类型";
            this.pDataType.Items.AddRange(new object[] {
            "NUMBER",
            "VARCHAR2",
            "CLOB",
            "BLOB",
            "DATE"});
            this.pDataType.Name = "pDataType";
            this.pDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pLength
            // 
            this.pLength.HeaderText = "长度";
            this.pLength.Name = "pLength";
            // 
            // pNullAble
            // 
            this.pNullAble.HeaderText = "可为空";
            this.pNullAble.Name = "pNullAble";
            // 
            // pDefaultVal
            // 
            this.pDefaultVal.HeaderText = "默认值";
            this.pDefaultVal.Name = "pDefaultVal";
            this.pDefaultVal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pDefaultVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MetaDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Size = new System.Drawing.Size(993, 514);
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListProperty)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataDesc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeMetaData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Name;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Description;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMetaDataDesc;
        private DevExpress.XtraEditors.TextEdit txtMetaDataName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCommit;
        private System.Windows.Forms.ToolStripButton btnRollback;
        private System.Windows.Forms.ToolStripButton btnLock;
        private System.Windows.Forms.DataGridView treeListProperty;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripButton btnDelRow;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn obj;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn pDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pNullAble;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDefaultVal;
    }
}
