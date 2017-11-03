namespace Zxl.Builder
{
    partial class DockMetaDataDetail
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMetaDataName = new DevExpress.XtraEditors.TextEdit();
            this.txtMetaDataDesc = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelRow = new System.Windows.Forms.ToolStripButton();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRollback = new System.Windows.Forms.ToolStripButton();
            this.btnCommit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pDefaultVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNullAble = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeListProperty = new System.Windows.Forms.DataGridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 22);
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
            // txtMetaDataDesc
            // 
            this.txtMetaDataDesc.Location = new System.Drawing.Point(105, 50);
            this.txtMetaDataDesc.Name = "txtMetaDataDesc";
            this.txtMetaDataDesc.Size = new System.Drawing.Size(242, 20);
            this.txtMetaDataDesc.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMetaDataName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtMetaDataDesc);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(914, 89);
            this.panelControl1.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(57, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "描述：";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::Zxl.Builder.Properties.Resources.ok;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton6";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelRow.Enabled = false;
            this.btnDelRow.Image = global::Zxl.Builder.Properties.Resources.decrease;
            this.btnDelRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(23, 22);
            this.btnDelRow.Text = "toolStripButton5";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRow.Enabled = false;
            this.btnAddRow.Image = global::Zxl.Builder.Properties.Resources.add;
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(23, 22);
            this.btnAddRow.Text = "toolStripButton4";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLock
            // 
            this.btnLock.Image = global::Zxl.Builder.Properties.Resources._lock;
            this.btnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(23, 22);
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRollback
            // 
            this.btnRollback.Enabled = false;
            this.btnRollback.Image = global::Zxl.Builder.Properties.Resources.rollback;
            this.btnRollback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(23, 22);
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Enabled = false;
            this.btnCommit.Image = global::Zxl.Builder.Properties.Resources.commit;
            this.btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(23, 22);
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCommit,
            this.btnRollback,
            this.toolStripSeparator1,
            this.btnLock,
            this.toolStripSeparator2,
            this.btnAddRow,
            this.btnDelRow,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(910, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pDefaultVal
            // 
            this.pDefaultVal.HeaderText = "默认值";
            this.pDefaultVal.Name = "pDefaultVal";
            this.pDefaultVal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pDefaultVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pNullAble
            // 
            this.pNullAble.HeaderText = "可为空";
            this.pNullAble.Name = "pNullAble";
            // 
            // pLength
            // 
            this.pLength.HeaderText = "长度";
            this.pLength.Name = "pLength";
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
            // pDescription
            // 
            this.pDescription.HeaderText = "描述";
            this.pDescription.Name = "pDescription";
            // 
            // pName
            // 
            this.pName.HeaderText = "名称";
            this.pName.Name = "pName";
            // 
            // obj
            // 
            this.obj.HeaderText = "Column1";
            this.obj.Name = "obj";
            this.obj.Visible = false;
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
            this.treeListProperty.Size = new System.Drawing.Size(906, 415);
            this.treeListProperty.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.treeListProperty);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 27);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(910, 419);
            this.panelControl3.TabIndex = 5;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.toolStrip1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 89);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(914, 448);
            this.panelControl2.TabIndex = 8;
            // 
            // DockMetaDataDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 537);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "DockMetaDataDetail";
            this.TabText = "DockMetaDataDetail";
            this.Text = "DockMetaDataDetail";
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMetaDataDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMetaDataName;
        private DevExpress.XtraEditors.TextEdit txtMetaDataDesc;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelRow;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnLock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRollback;
        private System.Windows.Forms.ToolStripButton btnCommit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDefaultVal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pNullAble;
        private System.Windows.Forms.DataGridViewTextBoxColumn pLength;
        private System.Windows.Forms.DataGridViewComboBoxColumn pDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn obj;
        private System.Windows.Forms.DataGridView treeListProperty;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}