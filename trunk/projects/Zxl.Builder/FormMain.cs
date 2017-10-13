using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab.Buttons;
using DevExpress.XtraBars.Docking;

namespace Zxl.Builder
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XtraTabControl MainTab = null;

        public FormMain()
        {
            InitializeComponent();

            //MainTab = new XtraTabControl();
            //MainTab.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders; // 显示关闭按钮
            //MainTab.CloseButtonClick += new EventHandler(CloseButtonClick); // 关闭事件
            //MainTab.Dock = DockStyle.Fill;
            //this.Controls.Add(MainTab);

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();
        }


        void Init()
        {
            businessCtrl bCtrl = new businessCtrl();
            bCtrl.MainForm = this;
            bCtrl.Dock = DockStyle.Fill;
            businessPanel.ControlContainer.Controls.Add(bCtrl);

            metaDataCtrl mdCtrl = new metaDataCtrl();
            mdCtrl.MainForm = this;
            mdCtrl.Dock = DockStyle.Fill;
            metaDataPanel.ControlContainer.Controls.Add(mdCtrl);

            businessDataCtrl bdCtrl = new businessDataCtrl();
            bdCtrl.MainForm = this;
            bdCtrl.Dock = DockStyle.Fill;
            businessDataPanel.ControlContainer.Controls.Add(bdCtrl);

            userCtrl uCtrl = new userCtrl();
            uCtrl.MainForm = this;
            uCtrl.Dock = DockStyle.Fill;
            userPanel.ControlContainer.Controls.Add(uCtrl);

            roleCtrl rCtrl = new roleCtrl();
            rCtrl.MainForm = this;
            rCtrl.Dock = DockStyle.Fill;
            rolePanel.ControlContainer.Controls.Add(rCtrl);

            orgCtrl oCtrl = new orgCtrl();
            oCtrl.MainForm = this;
            oCtrl.Dock = DockStyle.Fill;
            orgPanel.ControlContainer.Controls.Add(oCtrl);
        }

        private void CloseButtonClick(object sender, EventArgs e)//关闭选项卡方法  
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text  
            foreach (XtraTabPage page in MainTab.TabPages)//遍历得到和关闭的选项卡一样的Text  
            {
                if (page.Text == name)
                {
                    MainTab.TabPages.Remove(page);
                    page.Dispose();
                    return;
                }
            }
        }  

        private void AddPage(string title, UserControl ctrl)
        {
            if (MainTab.TabPages.Count!=0)
            {
                for (int i=0;i< MainTab.TabPages.Count;i++)
                {
                    XtraTabPage page = MainTab.TabPages[i];
                    if (title == page.Text)
                    {
                        MainTab.SelectedTabPageIndex = i;
                        return;
                    }
                }
            }

            XtraTabPage newPage = new XtraTabPage();
            newPage.Text = title;
            MainTab.TabPages.Add(newPage);
            MainTab.SelectedTabPage = newPage;
            ctrl.Dock = DockStyle.Fill;
            newPage.Controls.Add(ctrl);
        }


        //业务
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DockPanel businessPanel = new DockPanel();
            //businessPanel.Text = "业务管理";
            //ControlContainer container = new ControlContainer();

            //businessPanel.Controls.Add(container);
            //AddDockPanel(businessPanel, DockingStyle.Left);

            //businessCtrl ctrl = new businessCtrl();
            //ctrl.Dock = DockStyle.Fill;
            //businessPanel.ControlContainer.Controls.Add(ctrl);

            this.containerBusiness.Visibility = DockVisibility.Visible;
            this.businessPanel.Visibility = DockVisibility.Visible;
            this.containerBusiness.ActiveChild = this.businessPanel;
        }
        //元数据
        private void metaData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.containerBusiness.Visibility = DockVisibility.Visible;
            this.metaDataPanel.Visibility = DockVisibility.Visible;
            this.containerBusiness.ActiveChild = this.metaDataPanel;
        }
        //业务数据
        private void businessData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.containerBusiness.Visibility = DockVisibility.Visible;
            this.businessDataPanel.Visibility = DockVisibility.Visible;
            this.containerBusiness.ActiveChild = this.businessDataPanel;
        }
        //用户
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.containerOrup.Visibility = DockVisibility.Visible;
            this.userPanel.Visibility = DockVisibility.Visible;
            this.containerOrup.ActiveChild = this.userPanel;
        }
        //角色
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.containerOrup.Visibility = DockVisibility.Visible;
            this.rolePanel.Visibility = DockVisibility.Visible;
            this.containerOrup.ActiveChild = this.rolePanel;
        }
        //机构
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.containerOrup.Visibility = DockVisibility.Visible;
            this.orgPanel.Visibility = DockVisibility.Visible;
            this.containerOrup.ActiveChild = this.orgPanel;
        }

        public void AddTab(string Title, UserControl ctrl)
        {
            DockPanel dockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            ControlContainer controlContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            dockPanel.Text = Title;
            dockPanel.Dock = DockingStyle.Fill;

            AddDockPanel(dockPanel, DockingStyle.Fill);

            controlContainer.Dock = DockStyle.Fill;
            dockPanel.Controls.Add(controlContainer);
            dockPanel.DockedAsTabbedDocument = true;
            controlContainer.TabIndex = 0;
            controlContainer.Controls.Add(ctrl);

        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            emptyCtrl ctrl = new emptyCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("表单管理", ctrl);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            emptyCtrl ctrl = new emptyCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("材料管理", ctrl);
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DockPanel configPanel = new DockPanel();
            configPanel.Text = "系统配置";
            ControlContainer container = new ControlContainer();

            configPanel.Controls.Add(container);
            AddDockPanel(configPanel, DockingStyle.Right);

            configCtrl ctrl = new configCtrl();
            ctrl.Dock = DockStyle.Fill;
            configPanel.ControlContainer.Controls.Add(ctrl);
        }

        void AddDockPanel(DockPanel panel, DockingStyle style)
        {
            DockPanel currPanel = null;
            foreach (DockPanel temp in dockManager1.Panels)
            {
                if (temp.Text == panel.Text)
                {
                    currPanel = temp;
                    break;
                }
            }
            if (null != currPanel)
            {
                currPanel.Visibility = DockVisibility.Visible;
                tabbedView1.ActivateDocument(currPanel);
            }
            else
            {
                dockManager1.AddPanel(style, panel);
            }
        }
    }
}
