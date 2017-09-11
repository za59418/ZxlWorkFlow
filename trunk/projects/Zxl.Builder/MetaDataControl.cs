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

namespace Zxl.Builder
{
    public partial class MetaDataControl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();

        public MetaDataControl()
        {
            InitializeComponent();

            treeMetaData.Nodes.Clear();
            SYS_METADATA obj = new SYS_METADATA();
            obj.id = -1;
            obj.NAME = "元数据";
            TreeListNode root = treeMetaData.AppendNode(new object[] { obj.NAME, "" }, obj.id);

            List<SYS_METADATA> datas = GetAllMetaDatas();
            foreach(SYS_METADATA data in datas)
            {
                TreeListNode node = treeMetaData.AppendNode(new object[] { data.NAME, data.DESCRIPTION }, root);
                node.Tag = data;
            }

            treeMetaData.ExpandAll();
        }

        public List<SYS_METADATA> GetAllMetaDatas()
        {
            return BusinessServcie.MetaDatas();
        }
    }
}
