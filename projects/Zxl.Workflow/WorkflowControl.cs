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
                _document = value;
            }
        }


        private void WorkflowControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseDown(e.X, e.Y);
                CurrentTool.AfterActivityCreate();
            }
        }

        private void WorkflowControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseMove(e.X, e.Y);
            }
        }

        private void WorkflowControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseUp(e.X, e.Y);
            }
        }

        private void WorkflowControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (null != _document && _document.ActivityList != null)
            {
                foreach (Activity activity in _document.ActivityList)
                {
                    activity.Draw(g);
                }
            }
        }

        private void WorkflowControl_Load(object sender, EventArgs e)
        {
            CurrentTool = new SelectorTool();
        }

        public void RedrawAll()
        {
            this.Invalidate();
        }

    }
}
