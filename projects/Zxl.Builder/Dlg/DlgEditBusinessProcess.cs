using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zxl.Business.Model;

namespace Zxl.Builder
{
    public partial class DlgEditBusinessProcess : Form
    {
        public DlgEditBusinessProcess()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private SYS_BUSINESSPROCESS mProcess;
        public SYS_BUSINESSPROCESS Process
        {
            get
            {
                mProcess.PROCESSNAME = tbName.Text;
                mProcess.CREATETIME = DateTime.Parse(tbCreateTime.Text);
                return mProcess;
            }
            set
            {
                mProcess = value;
                tbName.Text = mProcess.PROCESSNAME;
                tbCreateTime.Text = mProcess.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
