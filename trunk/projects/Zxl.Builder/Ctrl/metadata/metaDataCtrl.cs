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
    public partial class metaDataCtrl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();

        public metaDataCtrl()
        {
            InitializeComponent();
            RefreshMetaDataTree();
        }

        private SYS_METADATA CurrMetaData;
        public FormMain MainForm { get; set; }

        #region 元数据树事件
        private void treeMetaData_MouseClick(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeMetaData.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeMetaData.FocusedNode = node;
            treeMetaData.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;
            treeMetaData.ContextMenuStrip = cmsMetadatas;
            // 加载右边的详情树
            if (null != treeMetaData.FocusedNode && treeMetaData.FocusedNode.Level != 0) // 点击的是非根节点
            {
               CurrMetaData = treeMetaData.FocusedNode.Tag as SYS_METADATA;
               treeMetaData.ContextMenuStrip = cmsMetadata;
            }
        }

        private void treeMetaData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            metaDataDetailCtrl ctrl = new metaDataDetailCtrl();
            ctrl.Dock = DockStyle.Fill;
            ctrl.CurrMetaData = CurrMetaData;
            MainForm.AddTab(ctrl.CurrMetaData.NAME, ctrl);
        }

        private void cmsAddMetaData_Click(object sender, EventArgs e)
        {
            DlgEditMetaData dlg = new DlgEditMetaData();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.AddMetaData(dlg.MetaDataName, dlg.MetaDataDescription);
                RefreshMetaDataTree();
            }
        }

        private void cmsEditMetaData_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeMetaData.FocusedNode;
            SYS_METADATA bData = currNode.Tag as SYS_METADATA;

            DlgEditMetaData dlg = new DlgEditMetaData();
            dlg.MetaDataId = bData.ID;
            dlg.MetaDataName = bData.NAME;
            dlg.MetaDataDescription = bData.DESCRIPTION;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.EditMetaData(bData.ID, dlg.MetaDataName, dlg.MetaDataDescription);
                RefreshMetaDataTree();
            }
        }

        private void cmsDelMetaData_Click(object sender, EventArgs e)
        {
            TreeListNode currNode = treeMetaData.FocusedNode;

            SYS_METADATA bData = currNode.Tag as SYS_METADATA;
            BusinessServcie.DelMetaData(bData.ID);

            RefreshMetaDataTree();
        }

        void RefreshMetaDataTree()
        {
            treeMetaData.Nodes.Clear();
            SYS_METADATA obj = new SYS_METADATA();
            obj.ID = 0;
            obj.NAME = "元数据";
            TreeListNode root = treeMetaData.AppendNode(new object[] {obj.NAME }, -1);

            List<SYS_METADATA> datas = BusinessServcie.MetaDatas();
            foreach (SYS_METADATA data in datas)
            {
                TreeListNode node = treeMetaData.AppendNode(new object[] { data.NAME, data.DESCRIPTION }, root);
                node.Tag = data;
            }
            treeMetaData.ExpandAll();
        }

        #endregion 元数据树事件


    }
}
