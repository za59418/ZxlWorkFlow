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
using FormDesigner;

namespace Zxl.Builder
{
    public partial class DockCurrBusinessData : DockContent
    {
        public IBusinessService BusinessServcie = new BusinessService();
        public DockCurrBusinessData()
        {
            InitializeComponent();
        }

        private SYS_BUSINESSDATA _currBusinessData;
        public SYS_BUSINESSDATA CurrBusinessData
        {
            get
            {
                return _currBusinessData;
            }
            set
            {
                _currBusinessData = value;
                RefreshBusinessDataDetailTree(_currBusinessData);
            }
        }

        //选中的属性字段
        public SYS_METADATADETAIL selectedProperty { get; set; }
        public SYS_METADATA selectedMetadata { get; set; }
        
        private void treeListDetail_Click(object sender, EventArgs e)
        {
            if (treeListDetail.FocusedNode != null)
            {
                if (treeListDetail.FocusedNode.Level >= 2)
                {
                    if (treeListDetail.FocusedNode.Tag is SYS_METADATADETAIL)
                    {
                        selectedProperty = treeListDetail.FocusedNode.Tag as SYS_METADATADETAIL;
                        selectedMetadata = treeListDetail.FocusedNode.ParentNode.Tag as SYS_METADATA;
                        Dap2xProvoider.DoToolBarCmd(60303);
                    }
                }
            }            
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
                    TreeListNode detailNode = treeListDetail.AppendNode(new object[] { detail.NAME }, metaDataNode);
                    detailNode.Tag = detail;
                }
                CascadeAddNode(BusinessDataID, bDetail.ID, metaDataNode); // 递归
            }
        }

    }
}
