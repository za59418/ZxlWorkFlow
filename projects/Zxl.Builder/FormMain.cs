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

            MainTab = new XtraTabControl();
            MainTab.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders; // 显示关闭按钮
            MainTab.CloseButtonClick += new EventHandler(CloseButtonClick); // 关闭事件
            MainTab.Dock = DockStyle.Fill;
            this.Controls.Add(MainTab);


            //控制台
            DockPanel configPanel = new DockPanel();
            configPanel.Text = "控制台";
            ControlContainer container = new ControlContainer();
            configPanel.Controls.Add(container);
            AddDockPanel(configPanel, DockingStyle.Fill);

            TextBox ctrl = new TextBox();
            ctrl.Dock = DockStyle.Fill;
            ctrl.Multiline = true;
            configPanel.ControlContainer.Controls.Add(ctrl);
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
            AddPage("元数据管理", ctrl);
        }

        private void businessData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            businessDataCtrl ctrl = new businessDataCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("业务数据管理", ctrl);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userCtrl ctrl = new userCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("用户管理", ctrl);
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
            businessCtrl ctrl = new businessCtrl();
            ctrl.Dock = DockStyle.Fill;
            AddPage("业务管理", ctrl);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DockPanel configPanel = new DockPanel();// dockManager1.AddPanel(DevExpress.XtraBars.Docking.DockingStyle.Left);
            configPanel.Text = "系统配置";
            ControlContainer container = new ControlContainer();

            configPanel.Controls.Add(container);
            AddDockPanel(configPanel, DockingStyle.Left);

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
            }
            else
            {
                dockManager1.AddPanel(style, panel);
            }
        }
    }
}
