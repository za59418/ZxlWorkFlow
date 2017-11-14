using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormDesigner.ControlDesign
{
    public partial class FormLogDlg : Form
    {
        private FormLogDlg()
        {
            InitializeComponent();
        }

        private static FormLogDlg _instance = new FormLogDlg();
        public static FormLogDlg Instance
        {
            get
            {
                if(null==_instance)
                    _instance = new FormLogDlg();
                return _instance;
            }
        }

        public void Log(string msg,FormLogType type)
        {
            if (this.Visible == false) this.Visible = true;
            if (type == FormLogType.LOG)
            {
                txtMsg.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-------Log:   " + msg);
            }
            else if (type == FormLogType.ERROR)
            {
                txtMsg.AppendText("\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----Error:   " + msg);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMsg.Text = "";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMsg.Text);
        }

        private void FormLogDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }

    public enum FormLogType
    {
        LOG,ERROR
    }
}
