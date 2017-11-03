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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class DockUser : DockContent
    {
        public IBusinessService BusinessServcie = new BusinessService();
        public IUserService UserServcie = new UserService();

        public DockUser()
        {
            InitializeComponent();
            RefreshUserTree();
        }

        public FormMain MainForm { get; set; }
        private ORUP_USER CurrUser;


        #region 用户列表事件
        private void treeUser_MouseClick(object sender, MouseEventArgs e)
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

            treeUser.ContextMenuStrip = cmsUsers;
            // 加载右边的详情树
            if (null != treeUser.FocusedNode && treeUser.FocusedNode.Level != 0 && treeUser.FocusedNode.Tag is ORUP_USER) // 点击的是非根节点
            {
                CurrUser = treeUser.FocusedNode.Tag as ORUP_USER;
                treeUser.ContextMenuStrip = cmsUser;
            }
        }

        private void treeUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DockUserDetail dud = new DockUserDetail();
            dud.MainForm = MainForm;
            dud.CurrUser = CurrUser;
            dud.TabText = CurrUser.USERNAME;
            dud.Show(MainForm.MainDockPanel);
        }

        private void cmsAddUser_Click(object sender, EventArgs e)
        {
            CurrUser = new ORUP_USER();
            CurrUser.CREATETIME = DateTime.Now;
        }

        private void cmsDelUser_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeUser.FocusedNode;

            ORUP_USER user = currNode.Tag as ORUP_USER;
            UserServcie.DelUser(user.ID);

            RefreshUserTree();
        }

        void RefreshUserTree()
        {
            treeUser.Nodes.Clear();
            ORUP_USER obj = new ORUP_USER();
            obj.ID = 0;
            obj.USERNAME = "用户列表";
            TreeListNode root = treeUser.AppendNode(new object[] { obj.USERNAME }, -1);

            //按字母分组排序
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            List<ORUP_USER> users = UserServcie.Users();
            users.Sort((a, b) => a.USERNAME.CompareTo(b.USERNAME));
            foreach (string letter in letters)
            {
                TreeListNode lNode = treeUser.AppendNode(new object[] { letter }, root);
                lNode.Tag = letter;

                int userCount = 0;
                foreach (ORUP_USER user in users)
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
        #endregion 用户列表事件
    }
}
