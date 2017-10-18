using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Zxl.Data;
using Zxl.Workflow;

namespace Zxl.Builder
{
    public partial class businessProcessCtrl : UserControl
    {

        public IBusinessService BusinessService = new BusinessService();


        private WorkflowControl workflowControl = null;
        private WorkflowEngine workflowEngine = null;
        public businessProcessCtrl()
        {
            InitializeComponent();

            workflowControl = new WorkflowControl();
            workflowControl.Dock = DockStyle.Fill;
            this.Controls.Add(workflowControl);

            workflowEngine = new WorkflowEngine();
            workflowControl.Document = workflowEngine.Document;
            workflowControl.RedrawAll();
        }

        private SYS_BUSINESSPROCESS _currProcess;
        public SYS_BUSINESSPROCESS CurrProcess
        {
            get
            {
                return _currProcess;
            }
            set
            {
                _currProcess = value;
            }
        }

        private void nbiSelector_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.SELECT);
        }

        private void nbiStart_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.START);
        }

        private void nbiEnd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.END);
        }

        private void nbiManual_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.MANUAL);
        }

        private void nbiArrow_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.LINE);
        }
    }
}
