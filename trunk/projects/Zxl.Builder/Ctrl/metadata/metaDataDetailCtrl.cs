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
    public partial class metaDataDetailCtrl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();

        public metaDataDetailCtrl()
        {
            InitializeComponent();
        }
 
        private SYS_METADATA _currMetaData;
        public SYS_METADATA CurrMetaData
        {
            get
            {
                return _currMetaData;
            }
            set
            {
                _currMetaData = value;
                txtMetaDataName.Text = _currMetaData.NAME;
                txtMetaDataDesc.Text = _currMetaData.DESCRIPTION;
                RefreshMetadataDetail(_currMetaData);
            }
        }

        #region 元数据详情
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

                    obj.REF_METADATA_ID = CurrMetaData.ID;
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

        void RefreshMetadataDetail(SYS_METADATA currMetaData)
        {
            treeListProperty.Rows.Clear();
            List<SYS_METADATADETAIL> datas = BusinessServcie.MetaDataDetails(currMetaData.ID);
            foreach (SYS_METADATADETAIL data in datas)
            {
                treeListProperty.Rows.Add(new object[] { data, data.NAME, data.DESCRIPTION, data.DATATYPE, data.LENGTH, data.NULLABLE, data.DEFAULTVAL });
            }
        }
        #endregion 元数据详情
    }
}
