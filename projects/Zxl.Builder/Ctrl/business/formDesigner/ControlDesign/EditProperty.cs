using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormDesigner.ControlDesign
{
    public partial class EditProperty : System.Windows.Forms.Form
    {
        private FormProvoider.FormItemInfo _formItemInfo;

        public EditProperty(FormProvoider.FormItemInfo formItemInfo)
        {
            _formItemInfo = formItemInfo;
            InitializeComponent();
            this.txtControlID.Text = formItemInfo.formItemID.ToString();
            SetRbt();
            
        }

        private void SetRbt()
        {
            if (FormProvoider.GetFormItemStyle(_formItemInfo.formItemID) != 0)
            {
                this.rbtMultiRow.Checked = true;
            }
            else
            {
                this.rbtMultiRow.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtMultiRow.Checked == true)
                {
                    FormProvoider.SetFormItemStyle(Convert.ToInt32(_formItemInfo.formItemID), 0x00010000, true);
                }
                else
                {
                    FormProvoider.SetFormItemStyle(Convert.ToInt32(_formItemInfo.formItemID), 0x00010000, false);
                }
                MessageBox.Show("设置成功！");

                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString(), "设置错误");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}