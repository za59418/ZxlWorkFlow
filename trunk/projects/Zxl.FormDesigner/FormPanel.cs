using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.FormDesigner
{
    public partial class FormPanel : Control
    {
        public FormPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
    }
}
