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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Zxl.Data;
using Zxl.FormDesigner;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;

namespace Zxl.Builder
{
    public partial class businessFormCtrl2 : UserControl
    {

        public IBusinessService BusinessService = new BusinessService();
        public Controls formControls = new Controls();
        public Forms formForms = new Forms();


        public businessFormCtrl2()
        {
            InitializeComponent();
            formControls.Show(this.dockPanel1, DockState.DockRight);
            formForms.Show(this.dockPanel1);
        }


        private SYS_BUSINESSFORM _currForm;
        public SYS_BUSINESSFORM CurrForm
        {
            get
            {
                return _currForm;
            }
            set
            {
                _currForm = value;
            }
        }

        private void nbiSelector_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void nbiStart_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void nbiEnd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void nbiManual_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void nbiArrow_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
        }

    }
}
