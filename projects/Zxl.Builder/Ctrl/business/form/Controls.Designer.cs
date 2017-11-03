namespace Zxl.Builder
{
    partial class Controls
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
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiSelector,
            this.nbiStart,
            this.nbiEnd,
            this.nbiManual,
            this.nbiArrow,
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3});
            this.navBarControl1.Location = new System.Drawing.Point(12, 27);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 225;
            this.navBarControl1.Size = new System.Drawing.Size(225, 229);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "活动列表";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "控件";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSelector),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiStart),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiEnd),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiManual),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiArrow),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nbiSelector
            // 
            this.nbiSelector.Caption = "选择";
            this.nbiSelector.Name = "nbiSelector";
            this.nbiSelector.SmallImage = global::Zxl.Builder.Properties.Resources.select;
            // 
            // nbiStart
            // 
            this.nbiStart.Caption = "静态文本";
            this.nbiStart.Name = "nbiStart";
            this.nbiStart.SmallImage = global::Zxl.Builder.Properties.Resources.label;
            // 
            // nbiEnd
            // 
            this.nbiEnd.Caption = "按钮";
            this.nbiEnd.Name = "nbiEnd";
            this.nbiEnd.SmallImage = global::Zxl.Builder.Properties.Resources.button;
            // 
            // nbiManual
            // 
            this.nbiManual.Caption = "文本框";
            this.nbiManual.Name = "nbiManual";
            this.nbiManual.SmallImage = global::Zxl.Builder.Properties.Resources.textbox;
            // 
            // nbiArrow
            // 
            this.nbiArrow.Caption = "下拉框";
            this.nbiArrow.Name = "nbiArrow";
            this.nbiArrow.SmallImage = global::Zxl.Builder.Properties.Resources.combobox;
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "单选框";
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImage = global::Zxl.Builder.Properties.Resources.radio;
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "复选框";
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = global::Zxl.Builder.Properties.Resources.checkbox;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "表格";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "画表格";
            this.navBarItem3.Name = "navBarItem3";
            this.navBarItem3.SmallImage = global::Zxl.Builder.Properties.Resources.table;
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 511);
            this.Controls.Add(this.navBarControl1);
            this.Name = "Controls";
            this.TabText = "Controls";
            this.Text = "Controls";
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
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
    }
}