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
            this.nbiSelectControl = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiLabel = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiButton = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiTextBox = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiComboBox = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiRadioButton = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiCheckBox = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiLeft = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiRight = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiTop = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiBottom = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiWidth = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiHeight = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiHorizontal = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiVertical = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiSelectGrid = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiGrid = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiEraser = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiMerge = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiSplit = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiRowHeight = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiCelWidth = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiPrintSetting = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiProperty = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiBgImg = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiAddPage = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiDelPage = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.BackColor = System.Drawing.Color.White;
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiSelectControl,
            this.nbiLabel,
            this.nbiButton,
            this.nbiTextBox,
            this.nbiComboBox,
            this.nbiRadioButton,
            this.nbiCheckBox,
            this.nbiLeft,
            this.nbiRight,
            this.nbiTop,
            this.nbiBottom,
            this.nbiWidth,
            this.nbiHeight,
            this.nbiHorizontal,
            this.nbiVertical,
            this.nbiSelectGrid,
            this.nbiGrid,
            this.nbiEraser,
            this.nbiMerge,
            this.nbiSplit,
            this.nbiRowHeight,
            this.nbiCelWidth,
            this.nbiPrintSetting,
            this.nbiProperty,
            this.nbiBgImg,
            this.nbiAddPage,
            this.nbiDelPage});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 272;
            this.navBarControl1.Size = new System.Drawing.Size(272, 319);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "活动列表";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "控件";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSelectControl),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiLabel),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiButton),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiTextBox),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiComboBox),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiRadioButton),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiCheckBox)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nbiSelectControl
            // 
            this.nbiSelectControl.Caption = "选择";
            this.nbiSelectControl.Name = "nbiSelectControl";
            this.nbiSelectControl.SmallImage = global::Zxl.Builder.Properties.Resources.select;
            this.nbiSelectControl.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSelector_LinkClicked);
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
            this.navBarGroup2.Caption = "控件命令";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiLeft),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiRight),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiTop),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiBottom),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiWidth),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiHeight),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiHorizontal),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiVertical)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // nbiLeft
            // 
            this.nbiLeft.Caption = "左对齐";
            this.nbiLeft.Name = "nbiLeft";
            this.nbiLeft.SmallImage = global::Zxl.Builder.Properties.Resources.left;
            this.nbiLeft.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiLeft_LinkClicked);
            // 
            // nbiRight
            // 
            this.nbiRight.Caption = "右对齐";
            this.nbiRight.Name = "nbiRight";
            this.nbiRight.SmallImage = global::Zxl.Builder.Properties.Resources.right;
            this.nbiRight.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiRight_LinkClicked);
            // 
            // nbiTop
            // 
            this.nbiTop.Caption = "上对齐";
            this.nbiTop.Name = "nbiTop";
            this.nbiTop.SmallImage = global::Zxl.Builder.Properties.Resources.top;
            this.nbiTop.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiTop_LinkClicked);
            // 
            // nbiBottom
            // 
            this.nbiBottom.Caption = "下对齐";
            this.nbiBottom.Name = "nbiBottom";
            this.nbiBottom.SmallImage = global::Zxl.Builder.Properties.Resources.bottom;
            this.nbiBottom.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiBottom_LinkClicked);
            // 
            // nbiWidth
            // 
            this.nbiWidth.Caption = "同一长度";
            this.nbiWidth.Name = "nbiWidth";
            this.nbiWidth.SmallImage = global::Zxl.Builder.Properties.Resources.width;
            this.nbiWidth.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiWidth_LinkClicked);
            // 
            // nbiHeight
            // 
            this.nbiHeight.Caption = "同一高度";
            this.nbiHeight.Name = "nbiHeight";
            this.nbiHeight.SmallImage = global::Zxl.Builder.Properties.Resources.height;
            this.nbiHeight.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiHeight_LinkClicked);
            // 
            // nbiHorizontal
            // 
            this.nbiHorizontal.Caption = "水平吸附";
            this.nbiHorizontal.Name = "nbiHorizontal";
            this.nbiHorizontal.SmallImage = global::Zxl.Builder.Properties.Resources.horizontal;
            this.nbiHorizontal.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiHorizontal_LinkClicked);
            // 
            // nbiVertical
            // 
            this.nbiVertical.Caption = "垂直吸附";
            this.nbiVertical.Name = "nbiVertical";
            this.nbiVertical.SmallImage = global::Zxl.Builder.Properties.Resources.vertical;
            this.nbiVertical.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiVertical_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "表格命令";
            this.navBarGroup3.Expanded = true;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSelectGrid),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiGrid),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiEraser),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMerge),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSplit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiRowHeight),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiCelWidth),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiPrintSetting),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiProperty),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiBgImg),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiAddPage),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiDelPage)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // nbiSelectGrid
            // 
            this.nbiSelectGrid.Caption = "选择表格";
            this.nbiSelectGrid.Name = "nbiSelectGrid";
            this.nbiSelectGrid.SmallImage = global::Zxl.Builder.Properties.Resources.select;
            this.nbiSelectGrid.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSelectGrid_LinkClicked);
            // 
            // nbiGrid
            // 
            this.nbiGrid.Caption = "画表格";
            this.nbiGrid.Name = "nbiGrid";
            this.nbiGrid.SmallImage = global::Zxl.Builder.Properties.Resources.table;
            this.nbiGrid.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiGrid_LinkClicked);
            // 
            // nbiEraser
            // 
            this.nbiEraser.Caption = "橡皮擦";
            this.nbiEraser.Name = "nbiEraser";
            this.nbiEraser.SmallImage = global::Zxl.Builder.Properties.Resources.eraser;
            this.nbiEraser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiEraser_LinkClicked);
            // 
            // nbiMerge
            // 
            this.nbiMerge.Caption = "合并单元格";
            this.nbiMerge.Name = "nbiMerge";
            this.nbiMerge.SmallImage = global::Zxl.Builder.Properties.Resources.merge;
            this.nbiMerge.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMerge_LinkClicked);
            // 
            // nbiSplit
            // 
            this.nbiSplit.Caption = "拆分单元格";
            this.nbiSplit.Name = "nbiSplit";
            this.nbiSplit.SmallImage = global::Zxl.Builder.Properties.Resources.split;
            this.nbiSplit.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSplit_LinkClicked);
            // 
            // nbiRowHeight
            // 
            this.nbiRowHeight.Caption = "行等高";
            this.nbiRowHeight.Name = "nbiRowHeight";
            this.nbiRowHeight.SmallImage = global::Zxl.Builder.Properties.Resources.height;
            this.nbiRowHeight.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiRowHeight_LinkClicked);
            // 
            // nbiCelWidth
            // 
            this.nbiCelWidth.Caption = "列等宽";
            this.nbiCelWidth.Name = "nbiCelWidth";
            this.nbiCelWidth.SmallImage = global::Zxl.Builder.Properties.Resources.width;
            this.nbiCelWidth.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiCelWidth_LinkClicked);
            // 
            // nbiPrintSetting
            // 
            this.nbiPrintSetting.Caption = "打印设置";
            this.nbiPrintSetting.Name = "nbiPrintSetting";
            this.nbiPrintSetting.SmallImage = global::Zxl.Builder.Properties.Resources.print;
            this.nbiPrintSetting.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiPrintSetting_LinkClicked);
            // 
            // nbiProperty
            // 
            this.nbiProperty.Caption = "属性设置";
            this.nbiProperty.Name = "nbiProperty";
            this.nbiProperty.SmallImage = global::Zxl.Builder.Properties.Resources.setting;
            this.nbiProperty.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiProperty_LinkClicked);
            // 
            // nbiBgImg
            // 
            this.nbiBgImg.Caption = "背景图案";
            this.nbiBgImg.Name = "nbiBgImg";
            this.nbiBgImg.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiBgImg_LinkClicked);
            // 
            // nbiAddPage
            // 
            this.nbiAddPage.Caption = "增加一页";
            this.nbiAddPage.Name = "nbiAddPage";
            this.nbiAddPage.SmallImage = global::Zxl.Builder.Properties.Resources.pageAdd;
            this.nbiAddPage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiAddPage_LinkClicked);
            // 
            // nbiDelPage
            // 
            this.nbiDelPage.Caption = "删除一页";
            this.nbiDelPage.Name = "nbiDelPage";
            this.nbiDelPage.SmallImage = global::Zxl.Builder.Properties.Resources.pageDel;
            this.nbiDelPage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiDelPage_LinkClicked);
            // 
            // DockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 319);
            this.Controls.Add(this.navBarControl1);
            this.Name = "DockControl";
            this.ShowIcon = false;
            this.TabText = "活动列表";
            this.Text = "工具箱";
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem nbiSelectControl;
        private DevExpress.XtraNavBar.NavBarItem nbiLabel;
        private DevExpress.XtraNavBar.NavBarItem nbiButton;
        private DevExpress.XtraNavBar.NavBarItem nbiTextBox;
        private DevExpress.XtraNavBar.NavBarItem nbiComboBox;
        private DevExpress.XtraNavBar.NavBarItem nbiRadioButton;
        private DevExpress.XtraNavBar.NavBarItem nbiCheckBox;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem nbiLeft;
        private DevExpress.XtraNavBar.NavBarItem nbiRight;
        private DevExpress.XtraNavBar.NavBarItem nbiTop;
        private DevExpress.XtraNavBar.NavBarItem nbiBottom;
        private DevExpress.XtraNavBar.NavBarItem nbiWidth;
        private DevExpress.XtraNavBar.NavBarItem nbiHeight;
        private DevExpress.XtraNavBar.NavBarItem nbiHorizontal;
        private DevExpress.XtraNavBar.NavBarItem nbiVertical;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem nbiSelectGrid;
        private DevExpress.XtraNavBar.NavBarItem nbiGrid;
        private DevExpress.XtraNavBar.NavBarItem nbiEraser;
        private DevExpress.XtraNavBar.NavBarItem nbiMerge;
        private DevExpress.XtraNavBar.NavBarItem nbiSplit;
        private DevExpress.XtraNavBar.NavBarItem nbiRowHeight;
        private DevExpress.XtraNavBar.NavBarItem nbiCelWidth;
        private DevExpress.XtraNavBar.NavBarItem nbiPrintSetting;
        private DevExpress.XtraNavBar.NavBarItem nbiProperty;
        private DevExpress.XtraNavBar.NavBarItem nbiBgImg;
        private DevExpress.XtraNavBar.NavBarItem nbiAddPage;
        private DevExpress.XtraNavBar.NavBarItem nbiDelPage;

    }
}