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
        public decimal Time
        {
            get { return null == nudTime.Text ? 0 : Convert.ToDecimal(nudTime.Text); }
            set { nudTime.Text = value.ToString(); }
        }

        private List<SYS_BUSINESSROLE> _roles;
        public List<SYS_BUSINESSROLE> Roles
        {
            get {
                foreach (SYS_BUSINESSROLE role in _roles)
                {
                    if (role.ROLENAME == cbRole.Text)
                        role.Selected = 1;
                    else
                        role.Selected = 0;
                }
                return _roles; 
            }
            set { 
                _roles = value;
                cbRole.Items.Clear();
                foreach (SYS_BUSINESSROLE role in _roles)
                {
                    cbRole.Items.Add(role.ROLENAME);
                    if (role.Selected == 1)
                        cbRole.Text = role.ROLENAME;
                }
            }
        }

        private List<SYS_BUSINESSFORM> _forms;
        public List<SYS_BUSINESSFORM> Forms
        {
            get
            {
                for (int i = 0; i < _forms.Count; i++)
                {
                    if (lvForm.GetItemChecked(i))
                        _forms[i].Checked = 1;
                    else
                        _forms[i].Checked = 0;
                }
                return _forms;
            }
            set
            {
                _forms = value;
                lvForm.Items.Clear();
                for (int i = 0; i < _forms.Count; i++)
                {
                    lvForm.Items.Add(_forms[i].FORMNAME);
                    if (_forms[i].Checked == 1)
                        lvForm.SetItemChecked(i, true);
                    else
                        lvForm.SetItemChecked(i, false);
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
