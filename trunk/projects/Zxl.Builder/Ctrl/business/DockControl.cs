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
using DevExpress.XtraNavBar;
using FormDesigner;

namespace Zxl.Builder
{
    public partial class DockControl : DockContent
    {
        public DockControl()
        {
            InitializeComponent();
            //InitToolBox();
        }

        public void InitToolBox()
        {
            navBarControl1.Groups.Clear();
            navBarControl1.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in DAP2ControlMapping.GetInstance().GetAllCategories())
            {
                NavBarGroup group = new NavBarGroup(kvp.Value);
                group.Expanded = true;
                this.navBarControl1.Groups.Add(group);
                foreach (KeyValuePair<string, string> kvpItem in
                    DAP2ControlMapping.GetInstance().GetControlsByCategory(kvp.Value))
                {
                    NavBarItem item = new NavBarItem(kvpItem.Value);
                    item.SmallImageIndex = Convert.ToInt32(kvpItem.Key) - 60300;
                    item.Name = kvpItem.Key;
                    item.LinkClicked += new NavBarLinkEventHandler(item_LinkClicked);
                    navBarControl1.Items.Add(item);
                    group.ItemLinks.Add(item);
                }
            }
        }

        void item_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (e.Link != null)
            {
                ExecuteToolBarCommand(Convert.ToUInt32(e.Link.ItemName));
            }
        }
        public void ExecuteToolBarCommand(uint nId)
        {
            Dap2xProvoider.DoToolBarCmd(nId);
        }


        private void nbiLabel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dap2xProvoider.DoToolBarCmd(60302);            
        }

        private void nbiButton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dap2xProvoider.DoToolBarCmd(60305);
        }

        private void nbiTextBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dap2xProvoider.DoToolBarCmd(60303);
        }

        private void nbiComboBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dap2xProvoider.DoToolBarCmd(60304);
        }

        private void nbiRadioButton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dap2xProvoider.DoToolBarCmd(60317);
        }

        private void nbiCheckBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Dap2xProvoider.DoToolBarCmd(60318);
        }

        //public WorkflowControl workflowControl { get; set; }
        //public WorkflowEngine workflowEngine { get; set; }



    }
}
