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
    public partial class DlgEditBusiness : Form
    {
        public DlgEditBusiness()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private SYS_BUSINESS mBusiness;
        public SYS_BUSINESS Business
        {
            get
            {
                mBusiness.BUSINESSNAME = tbName.Text;
                mBusiness.SHORTNAME = tbShortName.Text;
                mBusiness.DESCRIPTION = tbDescription.Text;
                mBusiness.SORTINDEX = Convert.ToInt32(tbSortIndex.Text);
                return mBusiness;
            }
            set
            {
                mBusiness = value;                
                tbName.Text = mBusiness.BUSINESSNAME;
                tbShortName.Text = mBusiness.SHORTNAME;
                tbDescription.Text = mBusiness.DESCRIPTION;
                tbSortIndex.Text = mBusiness.SORTINDEX + "";
            }
        }

        public int BusinessSortIndex
        {
            get { return Convert.ToInt32(tbSortIndex.Text + ""); }
            set { tbSortIndex.Text = value + ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (null == tbSortIndex.Text || "" == tbSortIndex.Text)
            {
                MessageBox.Show("排序不能为空，且必须是数字！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
