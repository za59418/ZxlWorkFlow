using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.FormDesigner
{
    public partial class FormControl : UserControl
    {
        public FormControl()
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
        private FormDocument _document;
        public FormDocument Document
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

        private void WorkflowControl_Resize(object sender, EventArgs e)
        {
            int pageSize = Height - hScrollBar.Height;
            vScrollBar.LargeChange = pageSize;
            vScrollBar.Maximum = panelWorkflow.Height + 40;

            pageSize = Width - vScrollBar.Width;
            hScrollBar.LargeChange = pageSize;
            hScrollBar.Maximum = panelWorkflow.Width + 40;
        }

        private void panelWorkflow_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();

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

        private void panelWorkflow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _document.OpenPropertyDialogAtPoint(e.X, e.Y);
            RedrawAll();
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
                    {
                        BaseActivity act = activity as BaseActivity;
                        //this.panelWorkflow.Controls.Add(act.MyCtrl);
                        activity.Draw(g);
                    }
                }
            }
        }

        public delegate void InitEventHandler(object sender, EventArgs e);
        public delegate void SaveEventHandler(object sender, EventArgs e);
        public event InitEventHandler OnInit;
        public event SaveEventHandler OnSave;

        private void WorkflowControl_Load(object sender, EventArgs e)
        {
            CurrentTool = new SelectorTool();
            OnInit(sender, e);
        }

        private void cmsiSave_Click(object sender, EventArgs e)
        {
            OnSave(this, e);
        }

        BaseActivity GetNextActivity(BaseActivity currActivity, out LineActivity nextLine)
        {
            foreach (Activity act in _document.ActivityList)
            {
                if (act is LineActivity && (act as LineActivity).Source.ID == currActivity.ID)
                {
                    nextLine = act as LineActivity;
                    return (act as LineActivity).Target;
                }
            }
            nextLine = null;
            return null;
        }

        private void cmsiArrange_Click(object sender, EventArgs e)
        {
            //StartActivity startActivity = null;

            //foreach (Activity act in _document.ActivityList)
            //{
            //    if (act is BaseActivity)
            //    {
            //        BaseActivity bAct = act as BaseActivity;
            //        if (bAct.GetActivityType() == "0")
            //        {
            //            startActivity = bAct as StartActivity;
            //        }
            //    }
            //}

            //LineActivity nextLine = null;
            //BaseActivity nextActivity = null;
            //BaseActivity currActivity = startActivity;
            //int i = 1;
            //string direction = "right";
            //while ((nextActivity = GetNextActivity(currActivity, out nextLine)) != null)
            //{
            //    if (i % 4 == 0)
            //    {
            //        if (direction == "right")
            //            direction = "left";
            //        else
            //            direction = "right";

            //        nextLine.X = currActivity.X;
            //        nextLine.Y = currActivity.Y + 50;
            //        nextActivity.X = currActivity.X;
            //        nextActivity.Y = currActivity.Y + 100;
            //        currActivity = nextActivity;
            //    }
            //    else
            //    {
            //        if (direction == "right")
            //        {
            //            nextLine.X = currActivity.X + 100;
            //            nextLine.Y = currActivity.Y;
            //            nextActivity.X = currActivity.X + 200;
            //            nextActivity.Y = currActivity.Y;
            //            currActivity = nextActivity;
            //        }
            //        else
            //        {
            //            nextLine.X = currActivity.X - 100;
            //            nextLine.Y = currActivity.Y;
            //            nextActivity.X = currActivity.X - 200;
            //            nextActivity.Y = currActivity.Y;
            //            currActivity = nextActivity;
            //        }
            //    }
            //    i++;
            //}

            RedrawAll();
        }
    }
}
