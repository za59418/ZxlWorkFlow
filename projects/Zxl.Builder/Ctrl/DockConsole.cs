using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Zxl.Builder
{
    public partial class DockConsole : DockContent
    {
        public DockConsole()
        {
            InitializeComponent();
        }

        public TextBox rtbLog
        {
            get
            {
                return this.textBox1;
           }
        }
    }
}
