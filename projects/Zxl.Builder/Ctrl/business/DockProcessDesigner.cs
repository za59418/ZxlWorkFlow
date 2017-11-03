using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;
using Zxl.WorkflowDesigner;


namespace Zxl.Builder
{
    public partial class DockProcessDesigner : DockContent
    {
        public IBusinessService BusinessService = new BusinessService();

        public WorkflowControl workflowControl { get; set; }
        public WorkflowEngine workflowEngine { get; set; }

        public DockProcessDesigner()
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
            workflowControl.Document.CurrProcess = CurrProcess; // 在人工活动上要用，表单和角色都与它有关

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
    }
}
