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
    public partial class DockConfig : DockContent
    {
        public IConfigService ConfigService = new ConfigService();
        public DockConfig()
        {
            InitializeComponent();
            RefreshConfigTree();
        }
        #region 配置树点击事件
        private void treeCnfg_MouseUp(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeConfig.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeConfig.FocusedNode = node;
            treeConfig.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;

            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeConfig.ContextMenuStrip = null;
                SYS_SYSTEMCONFIG temp = node.Tag as SYS_SYSTEMCONFIG;
                if (temp.ID == -1) // 根root
                {
                    tsmiAddConfig.Visible = true;
                    tsmiEditConfig.Visible = false;
                    tsmiDelConfig.Visible = false;
                }
                else
                {
                    tsmiAddConfig.Visible = false;
                    tsmiEditConfig.Visible = true;
                    tsmiDelConfig.Visible = true;
                }
                treeConfig.ContextMenuStrip = contextMenuCnfg;
            }
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeConfig.FocusedNode;

            SYS_SYSTEMCONFIG config = currNode.Tag as SYS_SYSTEMCONFIG;
            ConfigService.DelConfig(config.ID);

            RefreshConfigTree();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            DlgEditConfig dlg = new DlgEditConfig();
            dlg.Config = new SYS_SYSTEMCONFIG();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                ConfigService.SaveConfig(dlg.Config);
                RefreshConfigTree();
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeConfig.FocusedNode;
            SYS_SYSTEMCONFIG config = currNode.Tag as SYS_SYSTEMCONFIG;

            DlgEditConfig dlg = new DlgEditConfig();
            dlg.Config = config;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                ConfigService.SaveConfig(dlg.Config);
                RefreshConfigTree();
            }
        }

        /// <summary>
        /// 刷新配置树
        /// </summary>
        void RefreshConfigTree()
        {
            treeConfig.Nodes.Clear();
            SYS_SYSTEMCONFIG obj = new SYS_SYSTEMCONFIG();
            obj.ID = -1;
            obj.KEY = "系统配置";
            TreeListNode root = treeConfig.AppendNode(new object[] { obj.KEY }, obj.ID);
            root.Tag = obj;

            List<SYS_SYSTEMCONFIG> cnfgs = ConfigService.Configs();
            foreach (SYS_SYSTEMCONFIG cnfg in cnfgs)
            {
                //TreeListNode node = treeConfig.AppendNode(new object[] { (null == cnfg.DESCRIPTION || "" == cnfg.DESCRIPTION) ? cnfg.KEY : cnfg.DESCRIPTION }, root);
                TreeListNode node = treeConfig.AppendNode(new object[] { cnfg.DESCRIPTION + "(" + cnfg.KEY + ")" }, root);
                node.Tag = cnfg;
            }

            treeConfig.ExpandAll();
        }
        #endregion 配置树点击事件
    }
}
