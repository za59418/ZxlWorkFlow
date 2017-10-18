using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.Workflow
{
    public partial class WorkflowControl : UserControl
    {
        public WorkflowControl()
        {
            InitializeComponent();
        }

        private Tool _currentTool;
        public Tool CurrentTool
        {
            get { return _currentTool; }
            set
            {
                _currentTool = value;
                _currentTool.Ctrl = this;
            }
        }
        private WorkflowDocument _document;
        public WorkflowDocument Document
        {
            get
            {
                return _document;
            }
            set
            {
                vScrollBar.Value = 0;
                hScrollBar.Value = 0;
                panelWorkflow.Left = 20;
                panelWorkflow.Top = 20;
                _document = value;
            }
        }

        private void panelWorkflow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseDown(e.X, e.Y);
                CurrentTool.AfterActivityCreate();
            }
        }

        private void panelWorkflow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseMove(e.X, e.Y);
            }
        }

        private void panelWorkflow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseUp(e.X, e.Y);
            }
        }

        private void panelWorkflow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除", "系统消息",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    foreach (Activity activity in Document.DeleteSelected())
                    {
                        //FireVisualObjectDeleteEvent(deleteObject);
                    }
                    RedrawAll();
                }
            }
        }

        private void WorkflowControl_Load(object sender, EventArgs e)
        {
            CurrentTool = new SelectorTool();
        }

        public Point ScrollOffset
        {
            get
            {
                return new Point(hScrollBar.Value, vScrollBar.Value);
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            panelWorkflow.Top = -e.NewValue + 20;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            panelWorkflow.Left = -e.NewValue + 20;            
        }

        public void RedrawAll()
        {
            panelWorkflow.Invalidate();
        }

        private void panelWorkflow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (null != _document && _document.ActivityList != null)
            {
                foreach (Activity activity in _document.ActivityList)
                {
                    if (activity is LineActivity)
                        activity.Draw(g);
                }
                foreach (Activity activity in _document.ActivityList)
                {
                    if (!(activity is LineActivity))
                        activity.Draw(g);
                }
            }
        }


    }
}
