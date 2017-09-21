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
    public partial class DlgEditBusinessData : Form
    {
        public DlgEditBusinessData()
        {
            InitializeComponent();
        }

        public int BusinessId { get; set; }
        public string BusinessName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string BusinessDescription
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
