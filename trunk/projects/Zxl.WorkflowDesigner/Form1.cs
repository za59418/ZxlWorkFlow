using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.WorkflowDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            workflowEngine = new WorkflowEngine();
            workflowControl.Document = workflowEngine.Document;
            workflowControl.OnInit += new WorkflowControl.InitEventHandler(oninit);
            workflowControl.OnSave += new WorkflowControl.SaveEventHandler(onsave);
            workflowControl.RedrawAll();
        }
        private void oninit(object sender, EventArgs e) { }
        private void onsave(object sender, EventArgs e) { }


        private WorkflowEngine workflowEngine;


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.START);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.END);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.MANUAL);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.LINE);
        }
    }
}
