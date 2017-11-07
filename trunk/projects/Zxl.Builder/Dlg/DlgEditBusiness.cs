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
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class DlgEditBusiness : Form
    {
        public IBusinessService BusinessServcie = new BusinessService();
        public DlgEditBusiness()
        {
            InitializeComponent();

            cbBusinessData.Items.Clear();
            cbBusinessData.ValueMember = "ID";
            cbBusinessData.DisplayMember = "NAME";
            List<SYS_BUSINESSDATA> bDatas = BusinessServcie.BusinessDatas();
            foreach (SYS_BUSINESSDATA bData in bDatas)
            {
                cbBusinessData.Items.Add(bData);
            }
            cbBusinessData.DataSource = bDatas;
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
                mBusiness.REF_BUSINESSDATA_ID = null != cbBusinessData.SelectedItem ? (cbBusinessData.SelectedItem as SYS_BUSINESSDATA).ID : 0; //绑定业务数据
                mBusiness.SORTINDEX = Convert.ToInt32(tbSortIndex.Text);
                return mBusiness;
            }
            set
            {
                mBusiness = value;                
                tbName.Text = mBusiness.BUSINESSNAME;
                tbShortName.Text = mBusiness.SHORTNAME;
                tbDescription.Text = mBusiness.DESCRIPTION;
                cbBusinessData.SelectedValue = mBusiness.REF_BUSINESSDATA_ID;
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
