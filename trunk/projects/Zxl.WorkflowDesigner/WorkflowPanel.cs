using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.WorkflowDesigner
{
    public partial class WorkflowPanel : Control
    {
        public WorkflowPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
    }
}
