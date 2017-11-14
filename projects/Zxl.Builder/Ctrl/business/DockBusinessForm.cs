using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;
using Zxl.WorkflowDesigner;

using FormDesigner;

namespace Zxl.Builder
{
    public partial class DockBusinessForm : DockContent
    {
        public IBusinessService BusinessServcie = new BusinessService();

        public FormMain MainForm
        {
            get
            {
                return MainForm;
            }
            set
            {
                dp.MainForm = value;
            }
        }

        DockControl dc = new DockControl();
        DockCurrBusinessData dcbd = new DockCurrBusinessData();
        DockProperty dp = new DockProperty();
        DockFormDesigner dfd = new DockFormDesigner();
        public DockBusinessForm(SYS_BUSINESSFORM CurrForm)
        {
            InitializeComponent();

            dc.TabText = "工具箱";
            dc.Show(this.dockPanel1, DockState.DockLeft);
            dc.CloseButton = false;
            this.dockPanel1.DockLeftPortion = 0.1;

            dcbd.TabText = "业务数据";
            // 业务数据
            dcbd.CurrBusinessData = BusinessServcie.BusinessData(BusinessServcie.Business(CurrForm.REF_BUSINESS_ID).REF_BUSINESSDATA_ID);
            dcbd.Show(this.dockPanel1, DockState.DockRight);
            this.dockPanel1.DockRightPortion = 0.15;

            dp.TabText = "控件属性";
            dp.Show(this.dockPanel1);
            dp.DockTo(this.dockPanel1, DockStyle.Right);

            dfd.CurrForm = CurrForm;
            dfd.DockProperty = dp; ///////////////////初使化属性框
            dfd.DockCurrBusinessData = dcbd; ///////////////////初使化业务数据
            dfd.Show(this.dockPanel1);
            DockWindowFactory.Instance.DockWindowCollection.Add(dfd);
            DockWindowFactory.Instance.CurrDockWindow = dfd;
        }
    }
}
