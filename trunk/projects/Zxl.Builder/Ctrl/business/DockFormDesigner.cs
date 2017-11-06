using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;
using Zxl.WorkflowDesigner;
using FormDesigner;


namespace Zxl.Builder
{
    public partial class DockFormDesigner : DockContent
    {
        public IBusinessService BusinessService = new BusinessService();

        public DockFormDesigner()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void DockFormDesigner_Load(object sender, EventArgs e)
        {
            Dap2xProvoider.CreateFormEditor(this.Handle);
            Dap2xProvoider.MoveFormEditor(this.Width, this.Height);
        }

        private void DockFormDesigner_Resize(object sender, EventArgs e)
        {
            Dap2xProvoider.MoveFormEditor(this.Width, this.Height);
        }

        private SYS_BUSINESSFORM _currForm;
        public SYS_BUSINESSFORM CurrForm
        {
            get
            {
                return _currForm;
            }
            set
            {
                _currForm = value;
            }
        }
    }
}
