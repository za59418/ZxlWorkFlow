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

        public FormMain MainForm { get; set; }

        private ORUP_ORGANIZATION CurrOrg;


        #region 机构树点击事件


        private void treeOrg_MouseClick(object sender, MouseEventArgs e)
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

            treeOrg.ContextMenuStrip = cmsOrgs;
            // 加载右边的详情树
            if (null != treeOrg.FocusedNode && treeOrg.FocusedNode.Level != 0) // 点击的是非根节点
            {
                CurrOrg = treeOrg.FocusedNode.Tag as ORUP_ORGANIZATION;
                treeOrg.ContextMenuStrip = cmsOrg;
            }
        }

        private void treeOrg_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            orgDetailCtrl ctrl = new orgDetailCtrl();
            ctrl.Dock = DockStyle.Fill;
            ctrl.CurrOrg = CurrOrg;
            MainForm.AddTab(ctrl.CurrOrg.ORGNAME, ctrl);
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
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
    }
}
