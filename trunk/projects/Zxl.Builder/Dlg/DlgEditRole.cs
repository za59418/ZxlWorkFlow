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
    public partial class DlgEditRole : Form
    {
        public DlgEditRole()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private ORUP_ROLE mRole;
        public ORUP_ROLE Role
        {
            get
            {
                mRole.ROLENAME = tbName.Text;
                mRole.DESCRIPTION = tbDescription.Text;
                mRole.ROLETYPE = cbType.Text == "基本角色" ? 0 : 1;
                mRole.CREATETIME = DateTime.Parse(tbCreateTime.Text);
                mRole.STATE = cbValid.Checked ? 1 : 0;
                return mRole;
            }
            set
            {
                mRole = value;
                tbName.Text = mRole.ROLENAME;
                tbDescription.Text = mRole.DESCRIPTION;
                cbType.Text = mRole.ROLETYPE == 0 ? "基本角色" : "";
                tbCreateTime.Text = mRole.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                cbValid.CheckState = mRole.STATE == 0 ? CheckState.Unchecked : CheckState.Checked;
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
