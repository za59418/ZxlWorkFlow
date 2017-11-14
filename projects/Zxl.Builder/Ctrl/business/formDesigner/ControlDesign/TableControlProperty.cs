using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormDesigner.ControlDesign
{
    public partial class TableControlProperty : System.Windows.Forms.Form
    {
        Int32 ItemID;
        public TableControlProperty(string Item)
        {
            InitializeComponent();
            ItemID =Convert.ToInt32(Item);
            BindData(Item);
        }

        private void BindData(string ItemName)
        {
            this.txtContorlName.Text = ItemName;
            StringBuilder pageText = new StringBuilder(256);
            FormProvoider.GetTabPageText(ItemID, FormProvoider.GetCurTabPage(ItemID), pageText, pageText.Capacity);
            this.txtCurTabPage.Text = pageText.ToString();
        }

        private void btnInsertTabPage_Click(object sender, EventArgs e)
        {
            if (InputDataCheck())
            {
                FormProvoider.InsertTabPage(Convert.ToInt32(ItemID), this.txtCurTabPage.Text, -1);
            }
        }


        private void btnPrePage_Click(object sender, EventArgs e)
        {
            FormProvoider.SetCurTabPage(ItemID, FormProvoider.GetCurTabPage(ItemID) - 1);
            StringBuilder pageText = new StringBuilder(256);
            FormProvoider.GetTabPageText(ItemID, FormProvoider.GetCurTabPage(ItemID), pageText, pageText.Capacity);
            this.txtCurTabPage.Text = pageText.ToString();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            FormProvoider.SetCurTabPage(ItemID, FormProvoider.GetCurTabPage(ItemID) + 1);
            StringBuilder pageText = new StringBuilder(256);
            FormProvoider.GetTabPageText(ItemID, FormProvoider.GetCurTabPage(ItemID), pageText, pageText.Capacity);
            this.txtCurTabPage.Text = pageText.ToString();
        }

        private void btnDeletePage_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定删除?", "删除确认", MessageBoxButtons.YesNo))
            {
                FormProvoider.DeleteTabPage(ItemID, FormProvoider.GetCurTabPage(ItemID));
                StringBuilder pageText = new StringBuilder(256);
                FormProvoider.GetTabPageText(ItemID, FormProvoider.GetCurTabPage(ItemID), pageText, pageText.Capacity);
                this.txtCurTabPage.Text = pageText.ToString();
            }
        }

        private void btnSetPageText_Click(object sender, EventArgs e)
        {
            if (InputDataCheck())
            {
                FormProvoider.SetTabPageText(ItemID, FormProvoider.GetCurTabPage(ItemID), this.txtCurTabPage.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool InputDataCheck()
        {
            bool check = true;
            if (txtCurTabPage.Text.Trim().Length == 0)
            {
                MessageBox.Show("页名称不能为空！");
                check = false;
            }
            return check;
        }
    }
}