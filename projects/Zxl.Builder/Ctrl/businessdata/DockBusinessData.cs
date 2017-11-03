using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using WeifenLuo.WinFormsUI.Docking;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class DockBusinessData : DockContent
    {
        public IBusinessService BusinessServcie = new BusinessService();

        public FormMain MainForm { get; set; }

        private SYS_BUSINESSDATA CurrBusinessData;

        public DockBusinessData()
        {
            InitializeComponent();
            RefreshBusinessDataTree();
        }
        #region 业务数据点击事件
        private void treeBusinessData_MouseClick(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeBusinessData.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeBusinessData.FocusedNode = node;
            treeBusinessData.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;

            treeBusinessData.ContextMenuStrip = cmsBusinessDatas;
            // 加载右边的详情树
            if (null != treeBusinessData.FocusedNode && treeBusinessData.FocusedNode.Level != 0) // 点击的是非根节点
            {
                CurrBusinessData = treeBusinessData.FocusedNode.Tag as SYS_BUSINESSDATA;
                treeBusinessData.ContextMenuStrip = cmsBusinessData;
            }
        }

        private void treeBusinessData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DockBusinessDataDetail dbdd = new DockBusinessDataDetail();
            dbdd.CurrBusinessData = CurrBusinessData;
            dbdd.TabText = CurrBusinessData.NAME;
            dbdd.Show(MainForm.MainDockPanel);
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            //treeBusinessData
            TreeListNode currNode = treeBusinessData.FocusedNode;

            SYS_BUSINESSDATA bData = currNode.Tag as SYS_BUSINESSDATA;
            BusinessServcie.DelBusinessData(bData.ID);

            RefreshBusinessDataTree();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            DlgEditBusinessData dlg = new DlgEditBusinessData();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.AddBusinessData(dlg.BusinessName, dlg.BusinessDescription);
                RefreshBusinessDataTree();
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeBusinessData.FocusedNode;
            SYS_BUSINESSDATA bData = currNode.Tag as SYS_BUSINESSDATA;

            DlgEditBusinessData dlg = new DlgEditBusinessData();
            dlg.BusinessId = bData.ID;
            dlg.BusinessName = bData.NAME;
            dlg.BusinessDescription = bData.DESCRIPTION;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.EditBusinessData(bData.ID, dlg.BusinessName, dlg.BusinessDescription);
                RefreshBusinessDataTree();
            }
        }

        /// <summary>
        /// 刷新业务数据树
        /// </summary>
        void RefreshBusinessDataTree()
        {
            treeBusinessData.Nodes.Clear();
            SYS_BUSINESSDATA obj = new SYS_BUSINESSDATA();
            obj.ID = -1;
            obj.NAME = "业务数据";
            TreeListNode root = treeBusinessData.AppendNode(new object[] { obj.NAME, "" }, obj.ID);
            root.Tag = obj;

            List<SYS_BUSINESSDATA> datas = BusinessServcie.BusinessDatas();
            foreach (SYS_BUSINESSDATA data in datas)
            {
                TreeListNode node = treeBusinessData.AppendNode(new object[] { data.NAME, data.DESCRIPTION }, root);
                node.Tag = data;
            }

            treeBusinessData.ExpandAll();
        }
        #endregion 业务数据点击事件
    }
}
