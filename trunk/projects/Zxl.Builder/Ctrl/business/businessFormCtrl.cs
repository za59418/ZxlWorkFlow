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
using System.Xml;

namespace Zxl.Builder
{
    public partial class businessFormCtrl : UserControl
    {

        public IBusinessService BusinessService = new BusinessService();


        private FormControl formControl = null;
        private FormEngine formEngine = null;
        public businessFormCtrl()
        {
            InitializeComponent();

            formControl = new FormControl();
            formControl.Dock = DockStyle.Fill;
            formControl.OnSave += new FormControl.SaveEventHandler(process_Save);
            formControl.OnInit += new FormControl.InitEventHandler(process_Init);
            this.Controls.Add(formControl);

            formEngine = new FormEngine();
            formControl.Document = formEngine.Document;

            formControl.RedrawAll();
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

        private void process_Save(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement layout = doc.CreateElement("processes");
            formControl.Document.CreateXml(layout);

            SYS_BUSINESSFORM form = CurrForm;
            //process.LAYOUTCONTENT = Encoding.Default.GetBytes(layout.OuterXml); //
            //BusinessService.SaveBusinessProcess(process);
        }
        private void process_Init(object sender, EventArgs e)
        {
            /*初使化*/
            SYS_BUSINESSFORM form = CurrForm;
            formControl.Document.CurrForm = CurrForm; // 在人工活动上要用，表单和角色都与它有关

            //if (null != form.la.LAYOUTCONTENT)
            //{
            //    string Layout = Encoding.Default.GetString(process.LAYOUTCONTENT);
            //    XmlDocument doc = new XmlDocument();
            //    doc.LoadXml(Layout);
            //    formEngine.Layout = doc.DocumentElement;
            //    /**/
            //    formEngine.CreateProcess();
            //}
        }

        private void nbiSelector_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.SELECT);
        }

        private void nbiStart_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.LABEL);
        }

        private void nbiEnd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.BUTTON);
        }

        private void nbiManual_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.TEXTBOX);
        }

        private void nbiArrow_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.COMBOBOX);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.RADIOBUTTON);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.CHECKBOX);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            formControl.CurrentTool = formEngine.SetCurrentTool(ControlType.LINE);
        }
    }
}
