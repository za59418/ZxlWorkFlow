namespace Zxl.Builder
{
    partial class configCtrl
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
            this.treeConfig = new DevExpress.XtraTreeList.TreeList();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuCnfg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelConfig = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.treeConfig)).BeginInit();
            this.contextMenuCnfg.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeConfig
            // 
            this.treeConfig.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcName});
            this.treeConfig.ContextMenuStrip = this.contextMenuCnfg;
            this.treeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeConfig.Location = new System.Drawing.Point(0, 0);
            this.treeConfig.LookAndFeel.SkinName = "iMaginary";
            this.treeConfig.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeConfig.Name = "treeConfig";
            this.treeConfig.OptionsBehavior.AutoChangeParent = false;
            this.treeConfig.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeConfig.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeConfig.OptionsBehavior.ShowToolTips = false;
            this.treeConfig.OptionsBehavior.SmartMouseHover = false;
            this.treeConfig.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeConfig.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeConfig.OptionsView.ShowCheckBoxes = true;
            this.treeConfig.Size = new System.Drawing.Size(336, 546);
            this.treeConfig.TabIndex = 0;
            this.treeConfig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeCnfg_MouseUp);
            // 
            // tlcName
            // 
            this.tlcName.Caption = "名称";
            this.tlcName.FieldName = "名称";
            this.tlcName.MinWidth = 31;
            this.tlcName.Name = "tlcName";
            this.tlcName.OptionsColumn.AllowEdit = false;
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 0;
            this.tlcName.Width = 90;
            // 
            // contextMenuCnfg
            // 
            this.contextMenuCnfg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddConfig,
            this.tsmiEditConfig,
            this.tsmiDelConfig});
            this.contextMenuCnfg.Name = "contextMenuBd";
            this.contextMenuCnfg.Size = new System.Drawing.Size(125, 70);
            // 
            // tsmiAddConfig
            // 
            this.tsmiAddConfig.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAddConfig.Name = "tsmiAddConfig";
            this.tsmiAddConfig.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddConfig.Text = "添加配置";
            this.tsmiAddConfig.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiEditConfig
            // 
            this.tsmiEditConfig.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.tsmiEditConfig.Name = "tsmiEditConfig";
            this.tsmiEditConfig.Size = new System.Drawing.Size(124, 22);
            this.tsmiEditConfig.Text = "编辑配置";
            this.tsmiEditConfig.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelConfig
            // 
            this.tsmiDelConfig.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelConfig.Name = "tsmiDelConfig";
            this.tsmiDelConfig.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelConfig.Text = "删除配置";
            this.tsmiDelConfig.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // configCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeConfig);
            this.Name = "configCtrl";
            this.Size = new System.Drawing.Size(336, 546);
            ((System.ComponentModel.ISupportInitialize)(this.treeConfig)).EndInit();
            this.contextMenuCnfg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeConfig;
        private System.Windows.Forms.ContextMenuStrip contextMenuCnfg;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditConfig;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
    }
}
