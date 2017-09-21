using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraTab.Buttons;

namespace Zxl.Builder
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XtraTabControl MainTab = null;

        public FormMain()
        {
            InitializeComponent();

            MainTab = new XtraTabControl();
            MainTab.Dock = DockStyle.Fill;
            this.Controls.Add(MainTab);

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
            newPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
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
    }
}
