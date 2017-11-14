using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormDesigner.ControlDesign
{
    public partial class RadioButtonListSet : System.Windows.Forms.Form
    {
        private int ContorlID;
        public RadioButtonListSet(string ItemID)
        {
            ContorlID =Convert.ToInt32( ItemID);
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            this.nudRows.Value = Convert.ToInt16(FormProvoider.GetRaidoButtonRows(ContorlID));
            this.nudColumns.Value = Convert.ToInt16(FormProvoider.GetRaidoButtonCols(ContorlID));

            //加size，解决报buffer溢出异常的错误 zhangxl 2012-05-30
            int sizeBuffer = FormProvoider.GetRadioButtonCaption(ContorlID, null);
            StringBuilder caption = new StringBuilder(sizeBuffer);

            int bufsize = FormProvoider.GetRadioButtonCaption(ContorlID, caption);
            this.txtContent.Text = caption.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtContent.Text.Trim().Length == 0)
            {
                MessageBox.Show("内容不能为空！");
                return;
            }
            FormProvoider.SetRaidoButtonRows(ContorlID, Convert.ToInt32(this.nudRows.Value));
            FormProvoider.SetRaidoButtonCols(ContorlID, Convert.ToInt32(this.nudColumns.Value));
            FormProvoider.SetRadioButtonCaption(ContorlID, this.txtContent.Text.Trim());
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}