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


        private void metaData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraTab.XtraTabPage metaDataPage = new XtraTabPage();
            metaDataPage.Text = "元数据管理";
            MainTab.TabPages.Add(metaDataPage);

            MetaDataControl ctrl = new MetaDataControl();
            ctrl.Dock = DockStyle.Fill;
            metaDataPage.Controls.Add(ctrl);
        }
    }
}
