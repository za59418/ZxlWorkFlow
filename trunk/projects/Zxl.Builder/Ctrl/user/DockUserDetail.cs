using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class DockUserDetail : DockContent
    {
        public IBusinessService BusinessServcie = new BusinessService();
        public IUserService UserServcie = new UserService();

        public DockUserDetail()
        {
            InitializeComponent();
        }
        public FormMain MainForm { get; set; }

        private ORUP_USER _CurrUser;
        public ORUP_USER CurrUser
        {
            get
            {
                return _CurrUser;
            }
            set
            {
                _CurrUser = value;
                txtUserName.Text = CurrUser.USERNAME;
                txtPassword.Text = CurrUser.PASSWORD;
                txtNickName.Text = CurrUser.NICKNAME;
                txtMobile.Text = CurrUser.MOBILE;
                txtPhone.Text = CurrUser.PHONE;
                txtEmail.Text = CurrUser.EMAIL;
                txtCreateTime.Text = CurrUser.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
                chbInValid.CheckState = CurrUser.STATE == 1 ? CheckState.Unchecked : CheckState.Unchecked;

                listRoles.Items.Clear();
                List<ORUP_USERROLE> urs = UserServcie.GetUserRolesByUserID(CurrUser.ID);
                foreach (ORUP_USERROLE ur in urs)
                {
                    listRoles.Items.Add(UserServcie.GetRole(ur.RoleID).ROLENAME);
                }

                listOrganizations.Items.Clear();
                List<ORUP_USERORGANIZATION> uos = UserServcie.GetUserOrgsByUserID(CurrUser.ID);
                foreach (ORUP_USERORGANIZATION uo in uos)
                {
                    listOrganizations.Items.Add(UserServcie.GetOrganization(uo.ORGANIZATIONID).ORGNAME);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CurrUser.USERNAME = txtUserName.Text;
            CurrUser.PASSWORD = txtPassword.Text;
            CurrUser.NICKNAME = txtNickName.Text;
            CurrUser.MOBILE = txtMobile.Text;
            CurrUser.PHONE = txtPhone.Text;
            CurrUser.EMAIL = txtEmail.Text;
            CurrUser.CREATETIME = DateTime.Parse(txtCreateTime.Text);
            CurrUser.STATE = chbInValid.Checked ? 0 : 1;

            try
            {
                CurrUser = UserServcie.SaveUser(CurrUser);
                if (null != CurrUser)
                {
                    MainForm.INFO("保存用户成功！");
                }
            }
            catch (Exception ex)
            {
                MainForm.ERROR("保存用户失败！\r\n" + ex.Message);
            }
        }
    }
}
