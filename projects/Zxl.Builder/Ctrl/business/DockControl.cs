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
        }

        public void ExecuteToolBarCommand(uint nId)
        {
            FormProvoider.DoToolBarCmd(nId);
        }

        #region 控件
        private void nbiLabel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60302);            
        }

        private void nbiButton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60305);
        }

        private void nbiTextBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60303);
        }

        private void nbiComboBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60304);
        }

        private void nbiRadioButton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60317);
        }

        private void nbiCheckBox_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60318);
        }

        private void nbiSelector_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(0);
        }
        #endregion

        #region 控件命令
        private void nbiLeft_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60319"));
        }

        private void nbiRight_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60320"));
        }

        private void nbiTop_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60321"));
        }

        private void nbiBottom_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60322"));
        }

        private void nbiWidth_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60323"));
        }

        private void nbiHeight_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60324"));
        }

        private void nbiHorizontal_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60326"));
        }

        private void nbiVertical_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ExecuteToolBarCommand(uint.Parse("60327"));
        }
        #endregion

        #region 表格命令
        private void nbiSelectGrid_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60003);
        }

        private void nbiGrid_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60001);
        }

        private void nbiEraser_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60002);
        }

        private void nbiMerge_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60004);
        }

        private void nbiSplit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60005);
        }

        private void nbiRowHeight_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60006);
        }

        private void nbiCelWidth_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60007);
        }
        private void nbiPrintSetting_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60015);
        }

        private void nbiPrintPreview_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60033);
        }

        private void nbiProperty_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60029);
        }

        private void nbiBgImg_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60027);
        }

        private void nbiAddPage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60023);
        }

        private void nbiDelPage_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FormProvoider.DoToolBarCmd(60024);
        }        
        #endregion

        //public WorkflowControl workflowControl { get; set; }
        //public WorkflowEngine workflowEngine { get; set; }
    }
}
