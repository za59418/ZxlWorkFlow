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
                    tsmiDelBusinessData.Visible = false;
                    tsmiAddBusinessData.Visible = true;
                }
                else
                {
                    tsmiDelBusinessData.Visible = true;
                    tsmiAddBusinessData.Visible = false;
                }
                treeBusinessData.ContextMenuStrip = contextMenuBd;
            }

            // 加载右边的详情树
            if (null != treeBusinessData.FocusedNode && treeBusinessData.FocusedNode.Level == 1)
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
                SYS_BUSINESSDATA temp = node.Tag as SYS_BUSINESSDATA;

                contextMenuBdt.Visible = true;
                if (node.Level == 0) // 根root或者一级节点
                {
                    tsmiAddMetaData.Visible = true;
                    tsmiDelMetaData.Visible = false;
                }
                else if (node.Level == 1)
                {
                    tsmiAddMetaData.Visible = true;
                    tsmiDelMetaData.Visible = true;
                }
                else // 属性或者字段
                {
                    if (null != temp)
                    {
                        tsmiAddMetaData.Visible = false;
                        tsmiDelMetaData.Visible = true;
                    }
                    else
                    {
                        tsmiAddMetaData.Visible = false;
                        tsmiDelMetaData.Visible = false;
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
            SYS_METADATA metaData = treeListDetail.FocusedNode.Tag as SYS_METADATA;

            //List<SYS_BUSINESSDATADETAIL> details = BusinessServcie.BusinessDataDetails(currBusinessData.ID);

            DlgMetaDataSelector dlg = new DlgMetaDataSelector();
            dlg.MetaDatas = BusinessServcie.MetaDatas();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                List<SYS_METADATA> list = dlg.SelectedItems;
                foreach(SYS_METADATA data in list)
                {
                    BusinessServcie.AddBusinessDataDetail(currBusinessData.ID, data.ID, metaData.ID);
                    //SYS_BUSINESSDATADETAIL detail = new SYS_BUSINESSDATADETAIL();
                    //detail.ID = ValueOperator.CreatePk("SYS_BUSINESSDATADETAIL");
                    //detail.REF_BUSINESSDATA_ID = currBusinessData.ID;
                    //detail.REF_METADATA_ID = data.ID;
                }
            }
            RefreshBusinessDataDetailTree(currBusinessData);
        }

        private void tsmiDelMetaData_Click(object sender, EventArgs e)
        {
            //当前选中的业务数据
            SYS_BUSINESSDATA currBusinessData = treeBusinessData.FocusedNode.Tag as SYS_BUSINESSDATA;
            //当前选中的详情
            SYS_METADATA metaData = treeListDetail.FocusedNode.Tag as SYS_METADATA;

            SYS_BUSINESSDATADETAIL detail = BusinessServcie.BusinessDataDetail(currBusinessData.ID, metaData.ID);
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
            SYS_METADATA obj = new SYS_METADATA();
            obj.ID = 0;
            obj.NAME = currBusinessData.NAME;
            TreeListNode root = treeListDetail.AppendNode(new object[] { obj.NAME }, -1);
            root.Tag = obj;

            CascadeAddNode(currBusinessData.ID, 0, root);
            
            //List<SYS_BUSINESSDATADETAIL> datas = BusinessServcie.BusinessDataDetails(currBusinessData.ID);
            //foreach (SYS_BUSINESSDATADETAIL data in datas)
            //{
            //    // 二级节点
            //    SYS_METADATA metaData = BusinessServcie.MetaData(data.REF_METADATA_ID);
            //    TreeListNode metaDataNode = treeListDetail.AppendNode(new object[] { metaData.NAME }, 0);
            //    metaDataNode.Tag = metaData;

            //    List<SYS_METADATADETAIL> details = BusinessServcie.MetaDataDetails(metaData.ID);
            //    foreach (SYS_METADATADETAIL detail in details)
            //    {
            //        //三级节点
            //        TreeListNode detailNode = treeListDetail.AppendNode(new object[] { detail.NAME, detail.DESCRIPTION, detail.DATATYPE, detail.LENGTH, detail.NULLABLE, detail.DEFAULTVAL }, metaDataNode);
            //        detailNode.Tag = detail;
            //    }
            //}
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
            foreach (SYS_BUSINESSDATADETAIL data in datas)
            {
                // 业务数据
                SYS_METADATA metaData = BusinessServcie.MetaData(data.REF_METADATA_ID);

                TreeListNode metaDataNode = treeListDetail.AppendNode(new object[] { metaData.NAME }, node);
                metaDataNode.Tag = metaData;

                List<SYS_METADATADETAIL> details = BusinessServcie.MetaDataDetails(metaData.ID);
                foreach (SYS_METADATADETAIL detail in details)
                {
                    // 属性
                    TreeListNode detailNode = treeListDetail.AppendNode(new object[] { detail.NAME, detail.DESCRIPTION, detail.DATATYPE, detail.LENGTH, detail.NULLABLE, detail.DEFAULTVAL }, metaDataNode);
                    detailNode.Tag = detail;
                }
                CascadeAddNode(BusinessDataID, data.ID, metaDataNode); // 递归
            }
        }
        #endregion 业务数据详情点击事件

    }
}
