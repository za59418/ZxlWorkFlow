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
    public partial class DlgEditBusinessMaterial : Form
    {
        public DlgEditBusinessMaterial()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private SYS_BUSINESSMATERIAL mMaterial;
        public SYS_BUSINESSMATERIAL Material
        {
            get
            {
                mMaterial.MATERIALNAME = tbName.Text;
                mMaterial.CREATETIME = DateTime.Parse(tbCreateTime.Text);
                mMaterial.SORTINDEX = Convert.ToInt32(tbSortIndex.Text);
                return mMaterial;
            }
            set
            {
                mMaterial = value;
                tbName.Text = mMaterial.MATERIALNAME;
                tbCreateTime.Text = mMaterial.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                tbSortIndex.Text = mMaterial.SORTINDEX + "";
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
