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

namespace Zxl.Builder
{
    public partial class DockBusinessForm : DockContent
    {
        public IBusinessService BusinessServcie = new BusinessService();
        public DockBusinessForm(SYS_BUSINESSFORM CurrForm)
        {
            InitializeComponent();

            DockControl dc = new DockControl();
            dc.TabText = "工具箱";
            dc.Show(this.dockPanel1, DockState.DockLeft);
            dc.CloseButton = false;
            this.dockPanel1.DockLeftPortion = 0.1;

            DockCurrBusinessData dcbd = new DockCurrBusinessData();
            dcbd.TabText = "业务数据";
            // 业务数据
            dcbd.CurrBusinessData = BusinessServcie.BusinessData(BusinessServcie.Business(CurrForm.REF_BUSINESS_ID).REF_BUSINESSDATA_ID);
            dcbd.Show(this.dockPanel1, DockState.DockRight);
            this.dockPanel1.DockRightPortion = 0.15;

            DockProperty dp = new DockProperty();
            dp.TabText = "控件属性";
            dp.Show(this.dockPanel1);
            dp.DockTo(this.dockPanel1, DockStyle.Right);

            DockFormDesigner dfd = new DockFormDesigner();
            dfd.CurrForm = CurrForm;
            dfd.DockProperty = dp; ///////////////////初使化属性框
            dfd.DockCurrBusinessData = dcbd; ///////////////////初使化业务数据
            dfd.Show(this.dockPanel1);
        }
    }
}
