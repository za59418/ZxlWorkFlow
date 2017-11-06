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
        public DockBusinessForm(SYS_BUSINESSFORM CurrForm)
        {
            InitializeComponent();

            DockControl dc = new DockControl();
            dc.TabText = "工具箱";
            dc.Show(this.dockPanel1, DockState.DockLeft);
            dc.CloseButton = false;
            this.dockPanel1.DockLeftPortion = 0.1;

            DockProperty dp = new DockProperty();
            dp.TabText = "控件属性";
            dp.Show(this.dockPanel1, DockState.DockRight);
            this.dockPanel1.DockRightPortion = 0.2;

            DockFormDesigner dfd = new DockFormDesigner();
            dfd.CurrForm = CurrForm;
            dfd.DockProperty = dp; ///////////////////初使化属性框
            dfd.Show(this.dockPanel1);
        }
    }
}
