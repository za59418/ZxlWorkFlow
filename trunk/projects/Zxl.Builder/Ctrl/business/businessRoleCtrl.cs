using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class businessRoleCtrl : UserControl
    {

        public IUserService UserService = new UserService();

        public businessRoleCtrl()
        {
            InitializeComponent();
        }

        private SYS_BUSINESSROLE _currRole;
        public SYS_BUSINESSROLE CurrRole
        {
            get
            {
                return _currRole;
            }
            set
            {
                _currRole = value;
                txtRoleName.Text = _currRole.ROLENAME;
                RefreshUserRoleTree(_currRole);
            }
        }

        #region 角色树点击事件

        //private void tsmiDel_Click(object sender, EventArgs e)
        //{
        //    TreeListNode currNode = treeRole.FocusedNode;

        //    ORUP_ROLE role = currNode.Tag as ORUP_ROLE;
        //    UserService.DelRole(role.ID);

        //    RefreshRoleTree();
        //}

        //private void tsmiAdd_Click(object sender, EventArgs e)
        //{
        //    ORUP_ROLE newRole = new ORUP_ROLE();
        //    newRole.CREATETIME = DateTime.Now;
        //    DlgEditRole dlg = new DlgEditRole();
        //    dlg.Role = newRole;
        //    if (DialogResult.OK == dlg.ShowDialog())
        //    {
        //        UserService.SaveRole(dlg.Role);
        //        RefreshRoleTree();
        //    }
        //}

        //private void tsmiEdit_Click(object sender, EventArgs e)
        //{
        //    DlgEditRole dlg = new DlgEditRole();
        //    dlg.Role = treeRole.FocusedNode.Tag as ORUP_ROLE;
        //    if (DialogResult.OK == dlg.ShowDialog())
        //    {
        //        UserService.SaveRole(dlg.Role);
        //        RefreshRoleTree();
        //    }
        //}

        /// <summary>
        /// 刷新角色树
        /// </summary>
        //void RefreshRoleTree()
        //{
        //    treeRole.Nodes.Clear();
        //    ORUP_ROLE obj = new ORUP_ROLE();
        //    obj.ID = -1;
        //    obj.ROLENAME = "角色列表";
        //    TreeListNode root = treeRole.AppendNode(new object[] { obj.ROLENAME }, obj.ID);
        //    root.Tag = obj;

        //    List<ORUP_ROLE> roles = UserService.Roles();
        //    foreach (ORUP_ROLE role in roles)
        //    {
        //        TreeListNode node = treeRole.AppendNode(new object[] { role.ROLENAME, role.DESCRIPTION }, root);
        //        node.Tag = role;
        //    }

        //    treeRole.ExpandAll();
        //}
        #endregion 角色树点击事件

        #region 详情树点击事件
        private void treeUserRole_MouseUp(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeUserRole.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeUserRole.FocusedNode = node;
            treeUserRole.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;

            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeUserRole.ContextMenuStrip = null;
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
                treeUserRole.ContextMenuStrip = contextMenuRoleDetail;
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
                    UserService.SaveUserRole(user.ID, _currRole.ID);
                }
            }
            RefreshUserRoleTree(_currRole);
        }

        private void cmsDelUser_Click(object sender, EventArgs e)
        {
            //当前选中的用户
            ORUP_USERROLE ur = treeUserRole.FocusedNode.Tag as ORUP_USERROLE;
            UserService.DelUserRole(ur.ID);
            RefreshUserRoleTree(_currRole);
        }

        /// <summary>
        /// 刷新右侧详情树
        /// </summary>
        /// <param name="currBusinessData">选中的业务数据</param>
        void RefreshUserRoleTree(SYS_BUSINESSROLE currRole)
        {
            treeUserRole.Nodes.Clear();
            // 根节点
            TreeListNode root = treeUserRole.AppendNode(new object[] { currRole.ROLENAME }, -1);
            root.Tag = currRole;
            List<ORUP_USERROLE> userRoles = UserService.GetUserRolesByRoleID(currRole.ID);
            foreach (ORUP_USERROLE ur in userRoles)
            {
                ORUP_USER user = UserService.GetUser(ur.UserID);
                TreeListNode node = treeUserRole.AppendNode(new object[] { user.USERNAME, user.NICKNAME, user.MOBILE, user.PHONE, user.EMAIL, user.CREATETIME }, root);
                node.Tag = ur;
            }

            treeUserRole.ExpandAll();
        }

        #endregion 详情树点击事件
    }
}
