namespace Zxl.Builder
{
    partial class DockCurrBusinessData
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
            this.treeListDetail = new DevExpress.XtraTreeList.TreeList();
            this.bdName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListDetail
            // 
            this.treeListDetail.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bdName});
            this.treeListDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListDetail.Location = new System.Drawing.Point(0, 0);
            this.treeListDetail.LookAndFeel.SkinName = "iMaginary";
            this.treeListDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeListDetail.Name = "treeListDetail";
            this.treeListDetail.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDetail.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeListDetail.OptionsView.ShowHorzLines = false;
            this.treeListDetail.OptionsView.ShowVertLines = false;
            this.treeListDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.treeListDetail.Size = new System.Drawing.Size(222, 406);
            this.treeListDetail.TabIndex = 7;
            this.treeListDetail.Click += new System.EventHandler(this.treeListDetail_Click);
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
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // DockCurrBusinessData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 406);
            this.Controls.Add(this.treeListDetail);
            this.Name = "DockCurrBusinessData";
            this.TabText = "业务数据";
            this.Text = "业务数据";
            ((System.ComponentModel.ISupportInitialize)(this.treeListDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeListDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdName;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}