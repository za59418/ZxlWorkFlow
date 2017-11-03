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
using  Zxl.WorkflowDesigner;

namespace Zxl.Builder
{
    public partial class DockActivity : DockContent
    {
        public DockActivity()
        {
            InitializeComponent();
        }

        public WorkflowControl workflowControl { get; set; }
        public WorkflowEngine workflowEngine { get; set; }

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
