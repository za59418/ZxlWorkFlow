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
using System.Xml;

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
            workflowControl.OnSave += new WorkflowControl.SaveEventHandler(process_Save);
            workflowControl.OnInit += new WorkflowControl.InitEventHandler(process_Init);
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

        private void process_Save(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement layout = doc.CreateElement("processes");
            workflowControl.Document.CreateXml(layout);

            SYS_BUSINESSPROCESS process = CurrProcess;
            process.LAYOUTCONTENT = Encoding.Default.GetBytes(layout.OuterXml); //
            BusinessService.SaveBusinessProcess(process);
        }
        private void process_Init(object sender, EventArgs e)
        {
            /*初使化*/
            SYS_BUSINESSPROCESS process = CurrProcess;
            workflowEngine.Roles = BusinessService.BusinessRoles(CurrProcess.REF_BUSINESS_ID);
            workflowEngine.Forms = BusinessService.BusinessForms(CurrProcess.REF_BUSINESS_ID);
            if (null != process.LAYOUTCONTENT)
            {
                string Layout = Encoding.Default.GetString(process.LAYOUTCONTENT);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Layout);
                workflowEngine.Layout = doc.DocumentElement;
                /**/
                workflowEngine.CreateProcess();
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
