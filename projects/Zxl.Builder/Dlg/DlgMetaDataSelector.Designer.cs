namespace Zxl.Builder
{
    partial class DlgMetaDataSelector
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.treeMetaDataList = new DevExpress.XtraTreeList.TreeList();
            this.bName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaDataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeMetaDataList
            // 
            this.treeMetaDataList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bName,
            this.bDescription});
            this.treeMetaDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMetaDataList.Location = new System.Drawing.Point(2, 2);
            this.treeMetaDataList.LookAndFeel.SkinName = "iMaginary";
            this.treeMetaDataList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeMetaDataList.Name = "treeMetaDataList";
            this.treeMetaDataList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeMetaDataList.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeMetaDataList.OptionsView.ShowCheckBoxes = true;
            this.treeMetaDataList.Size = new System.Drawing.Size(339, 320);
            this.treeMetaDataList.TabIndex = 2;
            // 
            // bName
            // 
            this.bName.Caption = "名称";
            this.bName.FieldName = "NAME";
            this.bName.MinWidth = 31;
            this.bName.Name = "bName";
            this.bName.Visible = true;
            this.bName.VisibleIndex = 0;
            // 
            // bDescription
            // 
            this.bDescription.Caption = "描述";
            this.bDescription.FieldName = "DESCRIPTION";
            this.bDescription.Name = "bDescription";
            this.bDescription.Visible = true;
            this.bDescription.VisibleIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 324);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(343, 43);
            this.panelControl1.TabIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.treeMetaDataList);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(343, 324);
            this.panelControl2.TabIndex = 4;
            // 
            // DlgMetaDataSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 367);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgMetaDataSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "业务数据列表";
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaDataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraTreeList.TreeList treeMetaDataList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bDescription;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
    }
}