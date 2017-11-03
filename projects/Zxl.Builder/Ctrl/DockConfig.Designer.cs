namespace Zxl.Builder
{
    partial class DockConfig
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
            this.contextMenuCnfg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.treeConfig = new DevExpress.XtraTreeList.TreeList();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuCnfg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeConfig)).BeginInit();
            this.SuspendLayout();
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
            // 
            // tsmiEditConfig
            // 
            this.tsmiEditConfig.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.tsmiEditConfig.Name = "tsmiEditConfig";
            this.tsmiEditConfig.Size = new System.Drawing.Size(124, 22);
            this.tsmiEditConfig.Text = "编辑配置";
            // 
            // tsmiDelConfig
            // 
            this.tsmiDelConfig.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelConfig.Name = "tsmiDelConfig";
            this.tsmiDelConfig.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelConfig.Text = "删除配置";
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
            this.treeConfig.Size = new System.Drawing.Size(248, 470);
            this.treeConfig.TabIndex = 1;
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
            // DockConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 470);
            this.Controls.Add(this.treeConfig);
            this.Name = "DockConfig";
            this.ShowIcon = false;
            this.TabText = "活动列表";
            this.Text = "配置";
            this.contextMenuCnfg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuCnfg;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelConfig;
        private DevExpress.XtraTreeList.TreeList treeConfig;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;

    }
}