using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.Builder
{
    public partial class DlgEditMetaData : Form
    {
        public DlgEditMetaData()
        {
            InitializeComponent();
            tbName.Focus();
        }

        public int MetaDataId { get; set; }
        public string MetaDataName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string MetaDataDescription
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
