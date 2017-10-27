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

                panelForm.Left = 20;
                panelForm.Top = 20;
                //if(value.Direction == FormDirection.HORIZONTAL)
                //{
                //    panelForm.Width = 1024;
                //    panelForm.Height = 768;
                //}
                //else
                //{
                //    panelForm.Width = 768;
                //    panelForm.Height = 1024;
                //}
                _document = value;
            }
        }

        private void FormControl_Resize(object sender, EventArgs e)
        {
            int pageSize = Height - hScrollBar.Height;
            vScrollBar.LargeChange = pageSize;
            vScrollBar.Maximum = panelForm.Height + 40;

            pageSize = Width - vScrollBar.Width;
            hScrollBar.LargeChange = pageSize;
            hScrollBar.Maximum = panelForm.Width + 40;
        }

        private void panelForm_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();

            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseDown(e.X, e.Y);
                CurrentTool.AfterControlCreate();
            }
        }

        private void panelForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseMove(e.X, e.Y);
            }
        }

        private void panelForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentTool.OnMouseUp(e.X, e.Y);
            }
        }

        private void panelForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _document.OpenPropertyDialogAtPoint(e.X, e.Y);
            RedrawAll();
        }

        private void panelForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除", "系统消息",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    foreach (Control control in Document.DeleteSelected())
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
            panelForm.Top = -e.NewValue + 20;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            panelForm.Left = -e.NewValue + 20;            
        }

        public void RedrawAll()
        {
            panelForm.Invalidate();
        }

        private void panelForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (null != _document && _document.ControlList != null)
            {
                foreach (Control control in _document.ControlList)
                {
                    if (control is LineControl)
                        control.Draw(g);
                }
                foreach (Control control in _document.ControlList)
                {
                    if (!(control is LineControl))
                    {
                        BaseControl act = control as BaseControl;
                        //this.panelForm.Controls.Add(act.MyCtrl);
                        control.Draw(g);
                    }
                }
            }
        }

        public delegate void InitEventHandler(object sender, EventArgs e);
        public delegate void SaveEventHandler(object sender, EventArgs e);
        public event InitEventHandler OnInit;
        public event SaveEventHandler OnSave;

        private void FormControl_Load(object sender, EventArgs e)
        {
            CurrentTool = new SelectorTool();
            OnInit(sender, e);
        }

        private void cmsiSave_Click(object sender, EventArgs e)
        {
            OnSave(this, e);
        }

        private void cmsiArrange_Click(object sender, EventArgs e)
        {
            RedrawAll();
        }
    }
}
