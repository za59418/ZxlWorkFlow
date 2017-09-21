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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class userCtrl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();
        public IUserService UserServcie = new UserService();

        public userCtrl()
        {
            InitializeComponent();
            RefreshUserTree();
        }


        #region 用户列表事件
        private void contextMenuUser_MouseUp(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeUser.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeUser.FocusedNode = node;
            treeUser.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;

            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeUser.ContextMenuStrip = null;
                if (null != treeUser.FocusedNode)
                {
                    if (treeUser.FocusedNode.Level == 0) // 根root
                    {
                        cmsAddUser.Visible = true;
                        cmsEditUser.Visible = false;
                        cmsDelUser.Visible = false;
                    }
                    else
                    {
                        cmsAddUser.Visible = false;
                        cmsEditUser.Visible = true;
                        cmsDelUser.Visible = true;
                    }
                    treeUser.ContextMenuStrip = contextMenuUser;
                }
            }

            // 加载右边的详情树
            if (null != treeUser.FocusedNode && treeUser.FocusedNode.Level != 0) // 点击的是非根节点
            {
                SYS_USER currUser = treeUser.FocusedNode.Tag as SYS_USER;
                RefreshUserDetail(currUser);
            }
        }
        private void cmsAddUser_Click(object sender, EventArgs e)
        {
            DlgEditMetaData dlg = new DlgEditMetaData();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.AddMetaData(dlg.MetaDataName, dlg.MetaDataDescription);
                RefreshUserTree();
            }
        }

        private void cmsEditUser_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeUser.FocusedNode;
            SYS_METADATA bData = currNode.Tag as SYS_METADATA;

            DlgEditMetaData dlg = new DlgEditMetaData();
            dlg.MetaDataId = bData.ID;
            dlg.MetaDataName = bData.NAME;
            dlg.MetaDataDescription = bData.DESCRIPTION;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.EditMetaData(bData.ID, dlg.MetaDataName, dlg.MetaDataDescription);
                RefreshUserTree();
            }
        }

        private void cmsDelUser_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeUser.FocusedNode;

            SYS_USER user = currNode.Tag as SYS_USER;
            UserServcie.DelUser(user.ID);

            RefreshUserTree();
        }

        void RefreshUserTree()
        {
            treeUser.Nodes.Clear();
            SYS_USER obj = new SYS_USER();
            obj.ID = 0;
            obj.USERNAME = "用户列表";
            TreeListNode root = treeUser.AppendNode(new object[] { obj.USERNAME }, -1);

            List<SYS_USER> datas = UserServcie.Users();
            foreach (SYS_USER data in datas)
            {
                TreeListNode node = treeUser.AppendNode(new object[] { data.USERNAME }, root);
                node.Tag = data;
            }
            treeUser.ExpandAll();
        }

        void RefreshUserDetail(SYS_USER currUser)
        {
            txtUserName.Text = currUser.USERNAME;
            txtMobile.Text = currUser.MOBILE;
            txtEmail.Text = currUser.EMAIL;
        }

        #endregion 用户列表事件


    }
}
