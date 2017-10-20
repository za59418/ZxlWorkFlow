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

namespace Zxl.Workflow
{
    public partial class ActivityInfoDlg : Form
    {
        public ActivityInfoDlg()
        {
            InitializeComponent();
        }

        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public string Time
        {
            get { return nudTime.Text; }
            set { nudTime.Text = value; }
        }

        private List<SYS_BUSINESSROLE> _roles;
        public List<SYS_BUSINESSROLE> Roles
        {
            get {
                foreach (SYS_BUSINESSROLE role in _roles)
                {
                    if (role.ROLENAME == cbRole.SelectedText)
                        role.IsActive = 1;
                    else
                        role.IsActive = 0;
                }
                return _roles; 
            }
            set { 
                _roles = value;
                cbRole.Items.Clear();
                foreach (SYS_BUSINESSROLE role in _roles)
                {
                    cbRole.Items.Add(role.ROLENAME);
                    if (role.IsActive == 1)
                        cbRole.SelectedText = role.ROLENAME;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
