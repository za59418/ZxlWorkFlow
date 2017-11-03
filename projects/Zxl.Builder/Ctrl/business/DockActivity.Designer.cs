namespace Zxl.Builder
{
    partial class DockActivity
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
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiSelector = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiStart = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiEnd = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiManual = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiArrow = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
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
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 262;
            this.navBarControl1.Size = new System.Drawing.Size(262, 459);
            this.navBarControl1.TabIndex = 2;
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
            // DockActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 459);
            this.Controls.Add(this.navBarControl1);
            this.Name = "DockActivity";
            this.ShowIcon = false;
            this.TabText = "活动列表";
            this.Text = "活动列表";
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
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
    }
}