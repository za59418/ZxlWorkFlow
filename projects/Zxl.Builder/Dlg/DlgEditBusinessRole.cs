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
    public partial class DlgEditBusinessRole : Form
    {
        public DlgEditBusinessRole()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private SYS_BUSINESSROLE mRole;
        public SYS_BUSINESSROLE Role
        {
            get
            {
                mRole.ROLENAME = tbName.Text;
                mRole.CREATETIME = DateTime.Parse(tbCreateTime.Text);
                return mRole;
            }
            set
            {
                mRole = value;
                tbName.Text = mRole.ROLENAME;
                tbCreateTime.Text = mRole.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
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
