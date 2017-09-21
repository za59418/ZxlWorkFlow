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
    public partial class businessDataCtrl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();

        public businessDataCtrl()
        {
            InitializeComponent();
            RefreshBusinessDataTree();
        }

        #region 业务数据点击事件
        private void treeBusinessData_MouseUp(object sender, MouseEventArgs e)
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
            
            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeBusinessData.ContextMenuStrip = null;
                SYS_BUSINESSDATA temp = node.Tag as SYS_BUSINESSDATA;
                if (temp.ID == -1) // 根root
                {
                    tsmiAddBusinessData.Visible = true;
                    tsmiEditBusinessData.Visible = false;
                    tsmiDelBusinessData.Visible = false;
                }
                else
                {
                    tsmiAddBusinessData.Visible = false;
                    tsmiEditBusinessData.Visible = true;
                    tsmiDelBusinessData.Visible = true;
                }
                treeBusinessData.ContextMenuStrip = contextMenuBd;
            }

            // 加载右边的详情树
            if (null != treeBusinessData.FocusedNode && treeBusinessData.FocusedNode.Level != 0) // 点击的是非根节点
            {
                SYS_BUSINESSDATA currBusinessData = treeBusinessData.FocusedNode.Tag as SYS_BUSINESSDATA;
                txtBusinessDataName.Text = currBusinessData.NAME;

                RefreshBusinessDataDetailTree(currBusinessData);
            }
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

        #region 业务数据详情点击事件
        private void treeListDetail_MouseUp(object sender, MouseEventArgs e)
        {
            // 复选框控制
            TreeListHitInfo hitInfo = treeListDetail.CalcHitInfo(new Point(e.X, e.Y));
            TreeListNode node = hitInfo.Node;
            treeListDetail.FocusedNode = node;
            treeListDetail.UncheckAll();
            if (null != node)
                node.CheckState = CheckState.Checked;
            else
                return;

            //右键菜单控制
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeListDetail.ContextMenuStrip = null;
                SYS_BUSINESSDATADETAIL temp = node.Tag as SYS_BUSINESSDATADETAIL;

                if (node.Level == 0) // 根root
                {
                    tsmiAddMetaData.Visible = true;
                    tsmiDelMetaData.Visible = false;
                }
                else if (node.Level == 1) // 元数据
                {
                    tsmiAddMetaData.Visible = true;
                    tsmiDelMetaData.Visible = true;
                }
                else // 业务数据详情或者元数据属性
                {
                    if (null != temp) // 业务数据详情
                    {
                        tsmiAddMetaData.Visible = false;
                        tsmiDelMetaData.Visible = true;
                    }
                    else
                    {
                        contextMenuBdt.Visible = false;
                    }
                }
                treeListDetail.ContextMenuStrip = contextMenuBdt;
            }
        }

        private void tsmiAddMetaData_Click(object sender, EventArgs e)
        {
            //当前选中的业务数据
            SYS_BUSINESSDATA currBusinessData = treeBusinessData.FocusedNode.Tag as SYS_BUSINESSDATA;

            //当前选中的详情
            SYS_BUSINESSDATADETAIL detail = treeListDetail.FocusedNode.Tag as SYS_BUSINESSDATADETAIL;

            DlgMetaDataSelector dlg = new DlgMetaDataSelector();
            dlg.MetaDatas = BusinessServcie.MetaDatas();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                List<SYS_METADATA> list = dlg.SelectedItems;
                foreach(SYS_METADATA data in list)
                {
                    BusinessServcie.AddBusinessDataDetail(currBusinessData.ID, data.ID, detail.ID);
                }
            }
            RefreshBusinessDataDetailTree(currBusinessData);
        }

        private void tsmiDelMetaData_Click(object sender, EventArgs e)
        {
            //当前选中的业务数据
            SYS_BUSINESSDATA currBusinessData = treeBusinessData.FocusedNode.Tag as SYS_BUSINESSDATA;
            //当前选中的业务数据详情
            SYS_BUSINESSDATADETAIL detail = treeListDetail.FocusedNode.Tag as SYS_BUSINESSDATADETAIL;

            BusinessServcie.DelBusinessDataDetail(detail.ID);
            RefreshBusinessDataDetailTree(currBusinessData);
        }

        /// <summary>
        /// 刷新右侧详情树
        /// </summary>
        /// <param name="currBusinessData">选中的业务数据</param>
        void RefreshBusinessDataDetailTree(SYS_BUSINESSDATA currBusinessData)
        {
            treeListDetail.Nodes.Clear();
            // 根节点
            SYS_BUSINESSDATADETAIL obj = new SYS_BUSINESSDATADETAIL();
            obj.ID = 0;
            TreeListNode root = treeListDetail.AppendNode(new object[] { currBusinessData.NAME }, -1);
            root.Tag = obj;

            CascadeAddNode(currBusinessData.ID, 0, root);            
            treeListDetail.ExpandAll();
        }

        /// <summary>
        /// 递归构建树
        /// </summary>
        /// <param name="BusinessDataID">业务数据ID</param>
        /// <param name="ParentID">父业务数据详情ID</param>
        void CascadeAddNode(int BusinessDataID, int ParentID, TreeListNode node)
        {
            List<SYS_BUSINESSDATADETAIL> datas = BusinessServcie.BusinessDataDetails(BusinessDataID, ParentID);
            foreach (SYS_BUSINESSDATADETAIL bDetail in datas)
            {
                // 业务数据
                SYS_METADATA metaData = BusinessServcie.MetaData(bDetail.REF_METADATA_ID);

                TreeListNode metaDataNode = treeListDetail.AppendNode(new object[] { metaData.NAME }, node);
                metaDataNode.Tag = bDetail; // 设置为业务数据详情

                List<SYS_METADATADETAIL> details = BusinessServcie.MetaDataDetails(metaData.ID);
                foreach (SYS_METADATADETAIL detail in details)
                {
                    // 属性
                    TreeListNode detailNode = treeListDetail.AppendNode(new object[] { detail.NAME, detail.DESCRIPTION, detail.DATATYPE, detail.LENGTH, detail.NULLABLE, detail.DEFAULTVAL }, metaDataNode);
                    detailNode.Tag = detail;
                }
                CascadeAddNode(BusinessDataID, bDetail.ID, metaDataNode); // 递归
            }
        }
        #endregion 业务数据详情点击事件

    }
}
