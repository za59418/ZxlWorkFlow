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
            this.treeMetaData = new DevExpress.XtraTreeList.TreeList();
            this.Name = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Description = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaData)).BeginInit();
            this.SuspendLayout();
            // 
            // treeMetaData
            // 
            this.treeMetaData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.Name,
            this.Description});
            this.treeMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMetaData.Location = new System.Drawing.Point(0, 0);
            this.treeMetaData.Name = "treeMetaData";

            this.treeMetaData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeMetaData.LookAndFeel.UseWindowsXPTheme = true;

            this.treeMetaData.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeMetaData.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeMetaData.Size = new System.Drawing.Size(622, 368);
            this.treeMetaData.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.Caption = "Name";
            this.Name.FieldName = "NAME";
            this.Name.Name = "Name";
            this.Name.Visible = true;
            this.Name.VisibleIndex = 0;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.FieldName = "DESCRIPTION";
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 1;
            // 
            // MetaDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeMetaData);
            this.Size = new System.Drawing.Size(622, 368);
            ((System.ComponentModel.ISupportInitialize)(this.treeMetaData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeMetaData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Name;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Description;
    }
}
