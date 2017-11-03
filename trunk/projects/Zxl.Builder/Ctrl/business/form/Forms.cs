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
using FormDesigner;

namespace Zxl.Builder
{
    public partial class Forms : DockContent
    {
        public Forms()
        {
            InitializeComponent();
            //Dap2xProvoider.CreateFormEditor(this.Handle);
            //Dap2xProvoider.MoveFormEditor(this.Width, this.Height);
        }

        private void Forms_Resize(object sender, EventArgs e)
        {
            //Dap2xProvoider.MoveFormEditor(this.Width, this.Height);
        }

    }
}
