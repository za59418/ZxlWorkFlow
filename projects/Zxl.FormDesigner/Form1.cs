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

            formEngine = new FormEngine();
            formControl.Document = formEngine.Document;
            formControl.OnInit += new FormControl.InitEventHandler(oninit);
            formControl.OnSave += new FormControl.SaveEventHandler(onsave);
            formControl.RedrawAll();
        }
        private void oninit(object sender, EventArgs e) { }
        private void onsave(object sender, EventArgs e) { }


        private FormEngine formEngine;


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.LABEL);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.DATETIMEPICKER);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.TEXTBOX);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.CHECKBOX);
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.RADIOBUTTON);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.LINE);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.BUTTON);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.COMBOBOX);
        }
    }
}
