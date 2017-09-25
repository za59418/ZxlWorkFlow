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
    public partial class DlgEditConfig : Form
    {
        public DlgEditConfig()
        {
            InitializeComponent();
            tbKey.Focus();
        }

        private SYS_SYSTEMCONFIG mConfig;
        public SYS_SYSTEMCONFIG Config
        {
            get
            {
                mConfig.KEY = tbKey.Text;
                mConfig.VALUE = tbValue.Text;
                mConfig.DESCRIPTION = tbDescription.Text;
                return mConfig;
            }
            set
            {
                mConfig = value;
                tbKey.Text = mConfig.KEY;
                tbValue.Text = mConfig.VALUE;
                tbDescription.Text = mConfig.DESCRIPTION;
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
