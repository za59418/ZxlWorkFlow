using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FormDesigner.ControlDesign
{
    public partial class PrintSettingDialog : DevExpress.XtraEditors.XtraForm
    {
        public PrintSettingDialog(bool isPrint)
        {
            InitializeComponent();
            _isprint = isPrint;
            if (this._isprint)
            {
                this.radioGroup1.SelectedIndex = 0;
            }
            else
            {
                this.radioGroup1.SelectedIndex = 1;
            }
        }

        private bool _isprint = false;

        public bool Print
        {
            get { return _isprint; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex==0)
            {
                _isprint = true;
            }
            else
            {
                _isprint = false;

            }
            this.DialogResult = DialogResult.OK;
        }
    }
}