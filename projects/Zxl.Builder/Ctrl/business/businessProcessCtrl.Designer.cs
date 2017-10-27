﻿namespace Zxl.Builder
{
    partial class businessProcessCtrl
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiSelector = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiStart = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiEnd = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiManual = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiArrow = new DevExpress.XtraNavBar.NavBarItem();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiSelector,
            this.nbiStart,
            this.nbiEnd,
            this.nbiManual,
            this.nbiArrow});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 192;
            this.navBarControl1.Size = new System.Drawing.Size(192, 487);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "活动列表";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSelector),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiStart),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiEnd),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiManual),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiArrow)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nbiSelector
            // 
            this.nbiSelector.Caption = "选择";
            this.nbiSelector.Name = "nbiSelector";
            this.nbiSelector.SmallImage = global::Zxl.Builder.Properties.Resources.select;
            this.nbiSelector.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSelector_LinkClicked);
            // 
            // nbiStart
            // 
            this.nbiStart.Caption = "开始";
            this.nbiStart.Name = "nbiStart";
            this.nbiStart.SmallImage = global::Zxl.Builder.Properties.Resources.start;
            this.nbiStart.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiStart_LinkClicked);
            // 
            // nbiEnd
            // 
            this.nbiEnd.Caption = "结束";
            this.nbiEnd.Name = "nbiEnd";
            this.nbiEnd.SmallImage = global::Zxl.Builder.Properties.Resources.end;
            this.nbiEnd.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiEnd_LinkClicked);
            // 
            // nbiManual
            // 
            this.nbiManual.Caption = "人工环节";
            this.nbiManual.Name = "nbiManual";
            this.nbiManual.SmallImage = global::Zxl.Builder.Properties.Resources.manual;
            this.nbiManual.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiManual_LinkClicked);
            // 
            // nbiArrow
            // 
            this.nbiArrow.Caption = "连线";
            this.nbiArrow.Name = "nbiArrow";
            this.nbiArrow.SmallImage = global::Zxl.Builder.Properties.Resources.line;
            this.nbiArrow.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiArrow_LinkClicked);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("bddbe931-58a4-4b5f-b2c3-f42628f7bc90");
            this.dockPanel1.Location = new System.Drawing.Point(793, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 514);
            this.dockPanel1.Text = "活动列表";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 487);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // businessProcessCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel1);
            this.Name = "businessProcessCtrl";
            this.Size = new System.Drawing.Size(993, 514);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem nbiSelector;
        private DevExpress.XtraNavBar.NavBarItem nbiStart;
        private DevExpress.XtraNavBar.NavBarItem nbiEnd;
        private DevExpress.XtraNavBar.NavBarItem nbiManual;
        private DevExpress.XtraNavBar.NavBarItem nbiArrow;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;

    }
}