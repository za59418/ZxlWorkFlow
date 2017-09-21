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
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class metaDataCtrl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();

        public metaDataCtrl()
        {
            InitializeComponent();

            treeMetaData.Nodes.Clear();
            SYS_METADATA obj = new SYS_METADATA();
            obj.ID = -1;
            obj.NAME = "元数据";
            TreeListNode root = treeMetaData.AppendNode(new object[] { obj.NAME, "" }, obj.ID);

            List<SYS_METADATA> datas = BusinessServcie.MetaDatas();
            foreach (SYS_METADATA data in datas)
            {
                TreeListNode node = treeMetaData.AppendNode(new object[] { data.NAME, data.DESCRIPTION }, root);
                node.Tag = data;
            }

            treeMetaData.ExpandAll();
        }

        private void treeMetaData_Click(object sender, EventArgs e)
        {
            if (null != treeMetaData.FocusedNode && treeMetaData.FocusedNode.Level == 1)
            {
                btnAddRow.Enabled = false;
                btnDelRow.Enabled = false;
                btnSave.Enabled = false;
                btnCommit.Enabled = false;
                btnRollback.Enabled = false;
                treeListProperty.Enabled = false;
                btnLock.CheckState = CheckState.Unchecked;

                treeListProperty.Rows.Clear();
                SYS_METADATA currMetaData = treeMetaData.FocusedNode.Tag as SYS_METADATA;
                txtMetaDataName.Text = currMetaData.NAME;
                txtMetaDataDesc.Text = currMetaData.DESCRIPTION;

                List<SYS_METADATADETAIL> datas = BusinessServcie.MetaDataDetails(currMetaData.ID);
                foreach (SYS_METADATADETAIL data in datas)
                {
                    treeListProperty.Rows.Add(new object[] { data, data.NAME, data.DESCRIPTION, data.DATATYPE, data.LENGTH, data.NULLABLE, data.DEFAULTVAL });
                }
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            btnAddRow.Enabled = !btnAddRow.Enabled;
            btnDelRow.Enabled = !btnDelRow.Enabled;
            btnSave.Enabled = !btnSave.Enabled;
            btnCommit.Enabled = !btnCommit.Enabled;
            btnRollback.Enabled = !btnRollback.Enabled;

            treeListProperty.Enabled = !treeListProperty.Enabled;

            if (btnLock.CheckState == CheckState.Checked)
                btnLock.CheckState = CheckState.Unchecked;
            else
                btnLock.CheckState = CheckState.Checked;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            SYS_METADATADETAIL data = new SYS_METADATADETAIL();
            treeListProperty.Rows.Add(new object[] { data, data.NAME, data.DESCRIPTION, data.DATATYPE, data.LENGTH, data.NULLABLE, data.DEFAULTVAL });

            int rowIndex = treeListProperty.Rows.Count - 2;
            //treeListProperty.Rows[0].Selected = false;
            //treeListProperty.Rows[rowIndex].Selected = true;
            treeListProperty.Focus();
            treeListProperty.CurrentCell = treeListProperty.Rows[rowIndex].Cells[1];

        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in treeListProperty.SelectedRows)
            {
                SYS_METADATADETAIL temp = row.Cells[0].Value as SYS_METADATADETAIL;
                BusinessServcie.DelMetaDataDetail(temp.ID);
                treeListProperty.Rows.Remove(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAddRow.Enabled = false;
            btnDelRow.Enabled = false;
            btnSave.Enabled = false;
            btnCommit.Enabled = true;
            btnRollback.Enabled = true;

            foreach (DataGridViewRow row in treeListProperty.Rows)
            {
                SYS_METADATADETAIL obj = null;
                if (null == row.Cells[0].Value && null != row.Cells[1].Value) // 新增的行
                {
                    obj = new SYS_METADATADETAIL();
                    obj.ID = ValueOperator.CreatePk("SYS_METADATADETAIL");

                    SYS_METADATA currMetaData = treeMetaData.FocusedNode.Tag as SYS_METADATA;
                    obj.REF_METADATA_ID = currMetaData.ID;
                }
                else // 旧行
                {
                    obj = row.Cells[0].Value as SYS_METADATADETAIL;
                }
                if (null != obj)
                {
                    if (null != row.Cells[1].Value)
                        obj.NAME = row.Cells[1].Value.ToString();
                    if (null != row.Cells[2].Value)
                        obj.DESCRIPTION = row.Cells[2].Value.ToString();
                    if (null != row.Cells[3].Value)
                        obj.DATATYPE = row.Cells[3].Value.ToString();
                    if (null != row.Cells[4].Value)
                        obj.LENGTH = Convert.ToInt32(row.Cells[4].Value.ToString());

                    obj.NULLABLE = 1;
                    if (null != row.Cells[5].Value && false == Convert.ToBoolean(row.Cells[5].Value))
                        obj.NULLABLE = 0;

                    if (null != row.Cells[6].Value)
                        obj.DEFAULTVAL = row.Cells[6].Value.ToString();

                    BusinessServcie.SaveMetaDataDetail(obj);
                }
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            btnCommit.Enabled = false;
            btnRollback.Enabled = false;
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            btnCommit.Enabled = false;
            btnRollback.Enabled = false;
        }
    }
}
