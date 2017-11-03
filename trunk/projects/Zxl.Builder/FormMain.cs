using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Zxl.Builder
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public delegate void DelegateLog(string Msg);
        public DelegateLog INFO;
        public DelegateLog WARN;
        public DelegateLog ERROR;

        void info(string Msg)
        {
            dConsole.rtbLog.ForeColor = Color.Green;
            dConsole.rtbLog.AppendText(">> " + Msg + "\r\n");
        }
        void warn(string Msg)
        {
            dConsole.rtbLog.ForeColor = Color.Yellow;
            dConsole.rtbLog.AppendText(">> " + Msg + "\r\n");
        }
        void error(string Msg)
        {
            dConsole.rtbLog.ForeColor = Color.Red;
            dConsole.rtbLog.AppendText(">> " + Msg + "\r\n");
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();
            INFO = new DelegateLog(info);
            WARN = new DelegateLog(warn);
            ERROR = new DelegateLog(error);
        }

        public DockPanel MainDockPanel
        {
            get
            {
                return this.dockPanel1;
            }
        }

        DockMetaData dmd = new DockMetaData();
        DockBusinessData dbd = new DockBusinessData();
        DockBusiness db = new DockBusiness();
        DockOrg dOrg = new DockOrg();
        DockRole dRole = new DockRole();
        DockUser dUser = new DockUser();
        DockConfig dCnfg = new DockConfig();
        DockConsole dConsole = new DockConsole();

        void Init()
        {
            MainDockPanel.DockLeftPortion = 0.15;
            MainDockPanel.DockRightPortion = 0.15;
            MainDockPanel.DockBottomPortion = 0.15;

            dCnfg.TabText = "配置";
            dCnfg.HideOnClose = true;
            dCnfg.Show(MainDockPanel, DockState.DockRight);
            dConsole.TabText = "控制台";
            dConsole.HideOnClose = true;
            dConsole.Show(MainDockPanel, DockState.DockBottom);

            dmd.TabText = "原数据";
            dmd.MainForm = this;
            dmd.HideOnClose = true;
            dmd.Show(MainDockPanel, DockState.DockLeft);

            dbd.TabText = "业务数据";
            dbd.MainForm = this;
            dbd.HideOnClose = true;
            dbd.Show(MainDockPanel, DockState.DockLeft);

            db.TabText = "业务列表";
            db.MainForm = this;
            db.HideOnClose = true;
            db.Show(MainDockPanel, DockState.DockLeft);

            dOrg.TabText = "机构";
            dOrg.MainForm = this;
            dOrg.Show(this.dockPanel1);
            dOrg.HideOnClose = true;
            dOrg.DockTo(MainDockPanel, DockStyle.Left);

            dRole.TabText = "角色";
            dRole.MainForm = this;
            dRole.Show(this.dockPanel1);
            dRole.HideOnClose = true;
            dRole.DockTo(dOrg.Pane, DockStyle.Fill, 1);

            dUser.TabText = "用户";
            dUser.MainForm = this;
            dUser.Show(this.dockPanel1);
            dUser.HideOnClose = true;
            dUser.DockTo(dOrg.Pane, DockStyle.Fill, 2);
        }

        //业务+9
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            db.Visible = true;
            db.Activate();
        }
        //元数据
        private void metaData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dmd.Visible = true;
            dmd.Activate();
        }
        //业务数据
        private void businessData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dbd.Visible = true;
            dbd.Activate();
        }
        //用户
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dUser.Visible = true;
            dUser.Activate();
        }
        //角色
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dRole.Visible = true;
            dRole.Activate();
        }
        //机构
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dOrg.Visible = true;
            dOrg.Activate();
        }
        //配置
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dCnfg.Visible = true;
            dCnfg.Activate();
        }
        //表单
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            emptyCtrl ctrl = new emptyCtrl();
            ctrl.Dock = DockStyle.Fill;
            //AddPage("表单管理", ctrl);
        }
        //材料
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            emptyCtrl ctrl = new emptyCtrl();
            ctrl.Dock = DockStyle.Fill;
            //AddPage("材料管理", ctrl);
        }
    }
}
