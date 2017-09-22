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
    public partial class orgCtrl : UserControl
    {

        public IUserService UserService = new UserService();

        public orgCtrl()
        {
            InitializeComponent();
            RefreshOrgTree();
        }

        #region 机构树点击事件
        private void treeOrg_MouseUp(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeOrg.CalcHitInfo(new Point(e.X, e.Y)); 
            TreeListNode node = hitInfo.Node;
            treeOrg.FocusedNode = node;
            treeOrg.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;
            
            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeOrg.ContextMenuStrip = null;
                ORUP_ORGANIZATION temp = node.Tag as ORUP_ORGANIZATION;
                if (temp.ID == -1) // 根root
                {
                    tsmiAddOrg.Visible = true;
                    tsmiEditOrg.Visible = false;
                    tsmiDelOrg.Visible = false;
                }
                else
                {
                    tsmiAddOrg.Visible = false;
                    tsmiEditOrg.Visible = true;
                    tsmiDelOrg.Visible = true;
                }
                treeOrg.ContextMenuStrip = contextMenuRole;
            }

            // 加载右边的详情树
            if (null != treeOrg.FocusedNode && treeOrg.FocusedNode.Level != 0) // 点击的是非根节点
            {
                ORUP_ORGANIZATION currOrg = treeOrg.FocusedNode.Tag as ORUP_ORGANIZATION;
                txtOrgName.Text = currOrg.ORGNAME;

                RefreshUserOrgTree(currOrg);
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            //treeBusinessData
            TreeListNode currNode = treeOrg.FocusedNode;

            ORUP_ORGANIZATION org = currNode.Tag as ORUP_ORGANIZATION;
            UserService.DelOrg(org.ID);

            RefreshOrgTree();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            ORUP_ORGANIZATION newOrg = new ORUP_ORGANIZATION();
            newOrg.CREATETIME = DateTime.Now;
            DlgEditOrg dlg = new DlgEditOrg();
            dlg.Organization = newOrg;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                UserService.SaveOrg(dlg.Organization);
                RefreshOrgTree();
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            DlgEditOrg dlg = new DlgEditOrg();
            dlg.Organization= treeOrg.FocusedNode.Tag as ORUP_ORGANIZATION;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                UserService.SaveOrg(dlg.Organization);
                RefreshOrgTree();
            }
        }

        /// <summary>
        /// 刷新机构树
        /// </summary>
        void RefreshOrgTree()
        {
            treeOrg.Nodes.Clear();
            ORUP_ORGANIZATION obj = new ORUP_ORGANIZATION();
            obj.ID = -1;
            obj.ORGNAME = "机构列表";
            TreeListNode root = treeOrg.AppendNode(new object[] { obj.ORGNAME }, obj.ID);
            root.Tag = obj;

            List<ORUP_ORGANIZATION> orgs = UserService.Orgs();
            foreach (ORUP_ORGANIZATION org in orgs)
            {
                TreeListNode node = treeOrg.AppendNode(new object[] { org.ORGNAME, org.DESCRIPTION }, root);
                node.Tag = org;
            }

            treeOrg.ExpandAll();
        }
        #endregion 机构树点击事件

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
            //当前选中的角色
            ORUP_ORGANIZATION currOrg = treeOrg.FocusedNode.Tag as ORUP_ORGANIZATION;

            DlgUserSelector dlg = new DlgUserSelector();
            dlg.Users = UserService.Users();

            if (DialogResult.OK == dlg.ShowDialog())
            {
                List<ORUP_USER> list = dlg.SelectedItems;
                foreach (ORUP_USER user in list)
                {
                    UserService.SaveUserOrg(user.ID, currOrg.ID);
                }
            }
            RefreshUserOrgTree(currOrg);
        }

        private void cmsDelUser_Click(object sender, EventArgs e)
        {
            //当前选中的角色
            ORUP_ORGANIZATION currOrg = treeOrg.FocusedNode.Tag as ORUP_ORGANIZATION;
            //当前选中的用户
            ORUP_USERORGANIZATION uo = treeUserOrg.FocusedNode.Tag as ORUP_USERORGANIZATION;
            UserService.DelUserOrg(uo.ID);
            RefreshUserOrgTree(currOrg);
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
            List<ORUP_USERORGANIZATION> userOrgs = UserService.UserOrgs(currOrg.ID);
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
