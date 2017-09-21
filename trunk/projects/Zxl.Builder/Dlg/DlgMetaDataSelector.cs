using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zxl.Business.Model;
using DevExpress.XtraTreeList.Nodes;

namespace Zxl.Builder
{
    public partial class DlgMetaDataSelector : Form
    {
        public DlgMetaDataSelector()
        {
            InitializeComponent();
        }

        public List<SYS_METADATA> MetaDatas
        {
            set
            {
                SYS_METADATA obj = new SYS_METADATA();
                obj.ID = -1;
                obj.NAME = "元数据列表";
                TreeListNode root = treeMetaDataList.AppendNode(new object[] { obj.NAME, "" }, obj.ID);
                root.Tag = obj;

                foreach (SYS_METADATA data in value)
                {
                    TreeListNode node = treeMetaDataList.AppendNode(new object[] { data.NAME, data.DESCRIPTION }, root);
                    node.Tag = data;
                }
                treeMetaDataList.ExpandAll();
            }
        }

        public List<SYS_METADATA> SelectedItems { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedItems = new List<SYS_METADATA>();
            foreach (TreeListNode node in treeMetaDataList.Nodes[0].Nodes)
            {
                if(node.CheckState == CheckState.Checked)
                {
                    SelectedItems.Add(node.Tag as SYS_METADATA);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
