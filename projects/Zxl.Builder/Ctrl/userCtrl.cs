﻿using System;
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

        public SYS_USER CurrUser { get; set; }


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
                    if (treeUser.FocusedNode.Level == 0 || treeUser.FocusedNode.Level == 1) // 根root和字母
                    {
                        cmsAddUser.Visible = true;
                        cmsDelUser.Visible = false;
                    }
                    else
                    {
                        cmsAddUser.Visible = false;
                        cmsDelUser.Visible = true;
                    }
                    treeUser.ContextMenuStrip = contextMenuUser;
                }
            }

            // 加载右边的详情树
            if (null != treeUser.FocusedNode && treeUser.FocusedNode.Level != 0 && treeUser.FocusedNode.Tag is SYS_USER) // 点击的是非根节点
            {
                CurrUser = treeUser.FocusedNode.Tag as SYS_USER;
                RefreshUserDetail();
            }
        }
        private void cmsAddUser_Click(object sender, EventArgs e)
        {
            CurrUser = new SYS_USER();
            CurrUser.CREATETIME = DateTime.Now;
            txtUserName.Focus();
            RefreshUserDetail();
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

            //按字母分组排序
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            List<SYS_USER> users = UserServcie.Users();
            users.Sort((a, b) => a.USERNAME.CompareTo(b.USERNAME));
            foreach(string letter in letters)
            {
                TreeListNode lNode = treeUser.AppendNode(new object[] { letter }, root);
                lNode.Tag = letter;

                int userCount = 0;
                foreach (SYS_USER user in users)
                {
                    if (ValueOperator.GetSpellCode(user.USERNAME.Substring(0, 1)) == letter)
                    {
                        TreeListNode node = treeUser.AppendNode(new object[] { user.USERNAME }, lNode);
                        node.Tag = user;
                        userCount++;
                    }
                }
                if (0 == userCount)
                    treeUser.DeleteNode(lNode);
            }

            treeUser.ExpandAll();
        }

        void RefreshUserDetail()
        {
            txtUserName.Text = CurrUser.USERNAME;
            txtPassword.Text = CurrUser.PASSWORD;
            txtNickName.Text = CurrUser.NICKNAME;
            txtMobile.Text = CurrUser.MOBILE;
            txtPhone.Text = CurrUser.PHONE;
            txtEmail.Text = CurrUser.EMAIL;
            txtCreateTime.Text = CurrUser.CREATETIME.ToString("yyyy-MM-dd HH:mm:ss");
            chbInValid.CheckState = CurrUser.STATE == 1 ? CheckState.Unchecked : CheckState.Unchecked;
        }

        #endregion 用户列表事件

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
                    MessageBox.Show("保存成功！");
                    RefreshUserTree();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存失败！\r\n" + ex.Message);
            }
        }
    }
}
