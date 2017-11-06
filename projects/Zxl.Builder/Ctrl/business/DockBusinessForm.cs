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
            dc.TabText = "控件列表";
            dc.Show(this.dockPanel1, DockState.DockRight);
            dc.CloseButton = false;
            this.dockPanel1.DockRightPortion = 0.1;

            DockFormDesigner dfd = new DockFormDesigner();
            dfd.CurrForm = CurrForm;
            dfd.Show(this.dockPanel1);
        }
    }
}
