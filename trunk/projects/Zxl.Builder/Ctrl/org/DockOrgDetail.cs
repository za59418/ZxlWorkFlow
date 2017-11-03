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
    public partial class DockOrgDetail : DockContent
    {
        public IUserService UserService = new UserService();
        public DockOrgDetail()
        {
            InitializeComponent();
        }
        private ORUP_ORGANIZATION _currOrg;
        public ORUP_ORGANIZATION CurrOrg
        {
            get
            {
                return _currOrg;
            }
            set
            {
                _currOrg = value;
                txtOrgName.Text = _currOrg.ORGNAME;
                RefreshUserOrgTree(_currOrg);
            }
        }

        #region 详情树点击事件
        private void treeUserOrg_MouseUp(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeUserOrg.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeUserOrg.FocusedNode = node;
            treeUserOrg.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;

            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeUserOrg.ContextMenuStrip = null;
                ORUP_USER temp = node.Tag as ORUP_USER;

                if (node.Level == 0) // 根root
                {
                    tsmiAddUser.Visible = true;
                    tsmiDelUser.Visible = false;
                }
                else
                {
                    tsmiAddUser.Visible = false;
                    tsmiDelUser.Visible = true;
                }
                treeUserOrg.ContextMenuStrip = contextMenuRoleDetail;
            }
        }

        private void cmsAddUser_Click(object sender, EventArgs e)
        {
            DlgUserSelector dlg = new DlgUserSelector();
            dlg.Users = UserService.Users();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                List<ORUP_USER> list = dlg.SelectedItems;
                foreach (ORUP_USER user in list)
                {
                    UserService.SaveUserOrg(user.ID, CurrOrg.ID);
                }
            }
            RefreshUserOrgTree(CurrOrg);
        }

        private void cmsDelUser_Click(object sender, EventArgs e)
        {
            //当前选中的用户
            ORUP_USERORGANIZATION uo = treeUserOrg.FocusedNode.Tag as ORUP_USERORGANIZATION;
            UserService.DelUserOrg(uo.ID);
            RefreshUserOrgTree(CurrOrg);
        }

        /// <summary>
        /// 刷新右侧详情树
        /// </summary>
        /// <param name="currBusinessData">选中的业务数据</param>
        void RefreshUserOrgTree(ORUP_ORGANIZATION currOrg)
        {
            treeUserOrg.Nodes.Clear();
            // 根节点
            TreeListNode root = treeUserOrg.AppendNode(new object[] { currOrg.ORGNAME }, -1);
            root.Tag = currOrg;
            List<ORUP_USERORGANIZATION> userOrgs = UserService.GetUserOrgsByOrgID(currOrg.ID);
            foreach (ORUP_USERORGANIZATION uo in userOrgs)
            {
                ORUP_USER user = UserService.GetUser(uo.USERID);
                TreeListNode node = treeUserOrg.AppendNode(new object[] { user.USERNAME, user.NICKNAME, user.MOBILE, user.PHONE, user.EMAIL, user.CREATETIME }, root);
                node.Tag = uo;
            }

            treeUserOrg.ExpandAll();
        }

        #endregion 详情树点击事件
    }
}
