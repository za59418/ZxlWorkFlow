using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.FormDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            workflowEngine = new FormEngine();
            workflowControl.Document = workflowEngine.Document;
            workflowControl.OnInit += new FormControl.InitEventHandler(oninit);
            workflowControl.OnSave += new FormControl.SaveEventHandler(onsave);
            workflowControl.RedrawAll();
        }
        private void oninit(object sender, EventArgs e) { }
        private void onsave(object sender, EventArgs e) { }


        private FormEngine workflowEngine;


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.LABEL);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.DATETIMEPICKER);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.TEXTBOX);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.CHECKBOX);
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.RADIOBUTTON);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.LINE);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.BUTTON);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.workflowControl.CurrentTool = workflowEngine.SetCurrentTool(ActivityType.COMBOBOX);
        }
    }
}
