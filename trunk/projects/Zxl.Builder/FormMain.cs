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

        private void metaData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            metaDataCtrl ctrl = new metaDataCtrl();
            ctrl.Dock = DockStyle.Fill;
            //AddPage("元数据管理", ctrl);
            AddTab("元数据管理", ctrl);
        }

        private void businessData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            businessDataCtrl ctrl = new businessDataCtrl();
            ctrl.Dock = DockStyle.Fill;
            //AddPage("业务数据管理", ctrl);
            AddTab("业务数据管理", ctrl);

        }





        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //userCtrl ctrl = new userCtrl();
            //ctrl.Dock = DockStyle.Fill;
            //AddPage("用户管理", ctrl);

            userCtrl ctrl = new userCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddTab("用户管理", ctrl);
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

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            roleCtrl ctrl = new roleCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("角色管理", ctrl);
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            orgCtrl ctrl = new orgCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("机构管理", ctrl);
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

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //businessCtrl ctrl = new businessCtrl();
            //ctrl.Dock = DockStyle.Fill;
            //AddPage("业务管理", ctrl);

            DockPanel businessPanel = new DockPanel();// dockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Left);
            businessPanel.Text = "业务管理";
            ControlContainer container = new ControlContainer();

            businessPanel.Controls.Add(container);
            AddDockPanel(businessPanel, DockingStyle.Left);

            businessCtrl ctrl = new businessCtrl();
            ctrl.Dock = DockStyle.Fill;
            businessPanel.ControlContainer.Controls.Add(ctrl);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DockPanel configPanel = new DockPanel();// dockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Left);
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
            //DockPanel bPanel = null;
            foreach (DockPanel temp in dockManager1.Panels)
            {
                //if (temp.Text == "业务管理")
                //    bPanel = temp;

                if (temp.Text == panel.Text)
                {
                    currPanel = temp;
                    break;
                }

            }
            if (null != currPanel)
            {
                currPanel.Visibility = DockVisibility.Visible;
            }
            else
            {
                dockManager1.AddPanel(style, panel);
                //if (null != bPanel)
                //    panel.DockAsTab(bPanel, 0);
            }
        }

    }
}
