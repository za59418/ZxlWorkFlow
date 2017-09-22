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
    public partial class DlgEditOrg : Form
    {
        public DlgEditOrg()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private ORUP_ORGANIZATION mOrg;
        public ORUP_ORGANIZATION Organization
        {
            get
            {
                mOrg.ORGNAME = tbName.Text;
                mOrg.DESCRIPTION = tbDescription.Text;
                mOrg.ORGTYPE = cbType.Text == "主机构" ? 0 : 1;
                mOrg.CREATETIME = DateTime.Parse(tbCreateTime.Text);
                mOrg.STATE = cbValid.Checked ? 1 : 0;
                return mOrg;
            }
            set
            {
                mOrg = value;
                tbName.Text = mOrg.ORGNAME;
                tbDescription.Text = mOrg.DESCRIPTION;
                cbType.Text = mOrg.ORGTYPE == 0 ? "主机构" : "";
                tbCreateTime.Text = mOrg.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                cbValid.CheckState = mOrg.STATE == 0 ? CheckState.Unchecked : CheckState.Checked;
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
