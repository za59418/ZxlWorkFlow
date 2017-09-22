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
    public partial class DlgUserSelector : Form
    {
        public DlgUserSelector()
        {
            InitializeComponent();
        }

        public List<ORUP_USER> Users
        {
            set
            {
                ORUP_USER obj = new ORUP_USER();
                obj.ID = -1;
                obj.USERNAME = "用户列表";
                TreeListNode root = treeMetaDataList.AppendNode(new object[] { obj.USERNAME }, obj.ID);
                root.Tag = obj;

                foreach (ORUP_USER user in value)
                {
                    TreeListNode node = treeMetaDataList.AppendNode(new object[] { user.USERNAME, user.NICKNAME }, root);
                    node.Tag = user;
                }
                treeMetaDataList.ExpandAll();
            }
        }

        public List<ORUP_USER> SelectedItems { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedItems = new List<ORUP_USER>();
            foreach (TreeListNode node in treeMetaDataList.Nodes[0].Nodes)
            {
                if(node.CheckState == CheckState.Checked)
                {
                    SelectedItems.Add(node.Tag as ORUP_USER);
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
