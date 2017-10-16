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
    public partial class DlgEditBusinessForm : Form
    {
        public DlgEditBusinessForm()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private SYS_BUSINESSFORM mForm;
        public SYS_BUSINESSFORM Form
        {
            get
            {
                mForm.FORMNAME = tbName.Text;
                mForm.CREATETIME = DateTime.Parse(tbCreateTime.Text);
                mForm.SORTINDEX = Convert.ToInt32(tbSortIndex.Text);
                return mForm;
            }
            set
            {
                mForm = value;
                tbName.Text = mForm.FORMNAME;
                tbCreateTime.Text = mForm.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                tbSortIndex.Text = mForm.SORTINDEX + "";
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
