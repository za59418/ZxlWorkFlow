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

            DockActivity da = new DockActivity();
            da.TabText = "活动列表";
            da.Show(this.dockPanel1, DockState.DockRight);
            da.CloseButton = false;
            this.dockPanel1.DockRightPortion = 0.1;

            //DockProcessDesigner dpd = new DockProcessDesigner();
            //dpd.CurrProcess = CurrProcess;
            //dpd.Show(this.dockPanel1);
            ////重要
            //da.workflowControl = dpd.workflowControl;
            //da.workflowEngine = dpd.workflowEngine;
        }
    }
}
