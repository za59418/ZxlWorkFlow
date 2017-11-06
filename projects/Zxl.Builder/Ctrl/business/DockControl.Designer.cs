namespace Zxl.Builder
{
    partial class DockControl
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
            this.nbiLabel = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiButton = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiTextBox = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiComboBox = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiRadioButton = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiCheckBox = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiGrid = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiSelector,
            this.nbiLabel,
            this.nbiButton,
            this.nbiTextBox,
            this.nbiComboBox,
            this.nbiRadioButton,
            this.nbiCheckBox,
            this.nbiGrid});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 262;
            this.navBarControl1.Size = new System.Drawing.Size(262, 459);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "活动列表";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "控件";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSelector),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiLabel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiButton),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiTextBox),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiComboBox),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiRadioButton),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiCheckBox)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nbiSelector
            // 
            this.nbiSelector.Caption = "选择";
            this.nbiSelector.Name = "nbiSelector";
            this.nbiSelector.SmallImage = global::Zxl.Builder.Properties.Resources.select;
            // 
            // nbiLabel
            // 
            this.nbiLabel.Caption = "静态文本";
            this.nbiLabel.Name = "nbiLabel";
            this.nbiLabel.SmallImage = global::Zxl.Builder.Properties.Resources.label;
            this.nbiLabel.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiLabel_LinkClicked);
            // 
            // nbiButton
            // 
            this.nbiButton.Caption = "按钮";
            this.nbiButton.Name = "nbiButton";
            this.nbiButton.SmallImage = global::Zxl.Builder.Properties.Resources.button;
            this.nbiButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiButton_LinkClicked);
            // 
            // nbiTextBox
            // 
            this.nbiTextBox.Caption = "文本框";
            this.nbiTextBox.Name = "nbiTextBox";
            this.nbiTextBox.SmallImage = global::Zxl.Builder.Properties.Resources.textbox;
            this.nbiTextBox.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiTextBox_LinkClicked);
            // 
            // nbiComboBox
            // 
            this.nbiComboBox.Caption = "下拉框";
            this.nbiComboBox.Name = "nbiComboBox";
            this.nbiComboBox.SmallImage = global::Zxl.Builder.Properties.Resources.combobox;
            this.nbiComboBox.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiComboBox_LinkClicked);
            // 
            // nbiRadioButton
            // 
            this.nbiRadioButton.Caption = "单选框";
            this.nbiRadioButton.Name = "nbiRadioButton";
            this.nbiRadioButton.SmallImage = global::Zxl.Builder.Properties.Resources.radio;
            this.nbiRadioButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiRadioButton_LinkClicked);
            // 
            // nbiCheckBox
            // 
            this.nbiCheckBox.Caption = "复选框";
            this.nbiCheckBox.Name = "nbiCheckBox";
            this.nbiCheckBox.SmallImage = global::Zxl.Builder.Properties.Resources.checkbox;
            this.nbiCheckBox.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiCheckBox_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "表格";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiGrid)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // nbiGrid
            // 
            this.nbiGrid.Caption = "画表格";
            this.nbiGrid.Name = "nbiGrid";
            this.nbiGrid.SmallImage = global::Zxl.Builder.Properties.Resources.table;
            // 
            // DockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 459);
            this.Controls.Add(this.navBarControl1);
            this.Name = "DockControl";
            this.ShowIcon = false;
            this.TabText = "活动列表";
            this.Text = "控件列表";
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem nbiSelector;
        private DevExpress.XtraNavBar.NavBarItem nbiLabel;
        private DevExpress.XtraNavBar.NavBarItem nbiButton;
        private DevExpress.XtraNavBar.NavBarItem nbiTextBox;
        private DevExpress.XtraNavBar.NavBarItem nbiComboBox;
        private DevExpress.XtraNavBar.NavBarItem nbiRadioButton;
        private DevExpress.XtraNavBar.NavBarItem nbiCheckBox;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem nbiGrid;

    }
}