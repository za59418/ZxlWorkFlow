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

            List<SYS_METADATA> datas = BusinessServcie.MetaDatas();
            foreach(SYS_METADATA data in datas)
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

            treeListProperty.ClearSelection();
            treeListProperty.BeginEdit(false);
            treeListProperty.Rows[rowIndex].Cells[0].Selected = true;
            treeListProperty.RefreshEdit();
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in treeListProperty.SelectedRows)
                treeListProperty.Rows.Remove(row);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnAddRow.Enabled = false;
            btnDelRow.Enabled = false;
            btnSave.Enabled = false;
            btnCommit.Enabled = true;
            btnRollback.Enabled = true;

            foreach(DataGridViewRow row in treeListProperty.Rows)
            {
                SYS_METADATADETAIL obj = row.Cells[0].Value as SYS_METADATADETAIL;

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
