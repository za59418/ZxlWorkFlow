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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using Zxl.Data;

namespace Zxl.Builder
{
    public partial class businessCtrl : UserControl
    {

        public IBusinessService BusinessServcie = new BusinessService();

        public businessCtrl()
        {
            InitializeComponent();
            RefreshBusinessTree();
        }

        public SYS_BUSINESS CurrBusiness { get; set; }


        #region 业务树事件
        //private void contextMenuUser_MouseUp(object sender, MouseEventArgs e)
        //{
        //    // 复选框控制
        //    TreeListHitInfo hitInfo = treeUser.CalcHitInfo(new Point(e.X, e.Y));
        //    TreeListNode node = hitInfo.Node;
        //    treeUser.FocusedNode = node;
        //    treeUser.UncheckAll();
        //    if (null != node)
        //        node.CheckState = CheckState.Checked;
        //    else
        //        return;

        //    //右键菜单控制
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        treeUser.ContextMenuStrip = null;
        //        if (null != treeUser.FocusedNode)
        //        {
        //            if (treeUser.FocusedNode.Level == 0 || treeUser.FocusedNode.Level == 1) // 根root和字母
        //            {
        //                cmsAddUser.Visible = true;
        //                cmsDelUser.Visible = false;
        //            }
        //            else
        //            {
        //                cmsAddUser.Visible = false;
        //                cmsDelUser.Visible = true;
        //            }
        //            treeUser.ContextMenuStrip = contextMenuUser;
        //        }
        //    }

        //    // 加载右边的详情树
        //    if (null != treeUser.FocusedNode && treeUser.FocusedNode.Level != 0 && treeUser.FocusedNode.Tag is ORUP_USER) // 点击的是非根节点
        //    {
        //        CurrUser = treeUser.FocusedNode.Tag as ORUP_USER;
        //        RefreshUserDetail();
        //    }
        //}
        //private void cmsAddUser_Click(object sender, EventArgs e)
        //{
        //    CurrUser = new ORUP_USER();
        //    CurrUser.CREATETIME = DateTime.Now;
        //    txtUserName.Focus();
        //    RefreshUserDetail();
        //}

        //private void cmsDelUser_Click(object sender, EventArgs e)
        //{
        //    TreeListNode currNode = treeUser.FocusedNode;

        //    ORUP_USER user = currNode.Tag as ORUP_USER;
        //    UserServcie.DelUser(user.ID);

        //    RefreshUserTree();
        //}

        void RefreshBusinessTree()
        {
            treeBusiness.Nodes.Clear();

            TreeNode root = treeBusiness.Nodes.Add("root", "业务列表");
            root.ContextMenuStrip = cmsBusinesses;
            List<SYS_BUSINESS> businesses = BusinessServcie.Businesses();
            int i = 0;
            foreach (SYS_BUSINESS business in businesses)
            {
                TreeNode businessNode = root.Nodes.Add(business.ID + "", business.BUSINESSNAME + "(" + business.ID + ")");
                businessNode.ContextMenuStrip = cmsBusiness;
                businessNode.Tag = business;

                TreeNode materialsNode = businessNode.Nodes.Add("material", "材料清单");
                List<SYS_BUSINESSMATERIAL> materials = BusinessServcie.BusinessMaterials(business.ID);
                foreach(SYS_BUSINESSMATERIAL material in materials)
                {
                    TreeNode materialNode = materialsNode.Nodes.Add(material.ID + "", material.MATERIALNAME + "(" + material.ID + ")");
                    materialNode.Tag = material;
                }
                materialsNode.Expand();

                TreeNode formsNode = businessNode.Nodes.Add("form", "表单列表");
                List<SYS_BUSINESSFORM> forms = BusinessServcie.BusinessForms(business.ID);
                foreach (SYS_BUSINESSFORM form in forms)
                {
                    TreeNode formNode = formsNode.Nodes.Add(form.ID + "", form.FORMNAME + "(" + form.ID + ")");
                    formNode.Tag = form;
                }
                formsNode.Expand();

                TreeNode processesNode = businessNode.Nodes.Add("process", "流程列表");
                List<SYS_BUSINESSPROCESS> processes = BusinessServcie.BusinessProcesses(business.ID);
                foreach (SYS_BUSINESSPROCESS process in processes)
                {
                    TreeNode processNode = processesNode.Nodes.Add(process.ID + "", process.PROCESSNAME + "(" + process.ID + ")");
                    processNode.Tag = process;
                }
                processesNode.Expand();

                if (i++ == 0)
                    businessNode.ExpandAll();
            }
            root.Expand();
        }

        

        #endregion 业务树事件

        private void cmsiAddMaterial_Click(object sender, EventArgs e)
        {
            DlgEditBusiness dlg = new DlgEditBusiness();
            dlg.Business = new SYS_BUSINESS();
            dlg.Business.CREATETIME = DateTime.Now;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.SaveBusiness(dlg.Business);
                RefreshBusinessTree();
            }
        }

        private void tsmiEditBusiness_Click(object sender, EventArgs e)
        {
            DlgEditBusiness dlg = new DlgEditBusiness();
            CurrBusiness = treeBusiness.SelectedNode.Tag as SYS_BUSINESS;
            dlg.Business = BusinessServcie.Business(CurrBusiness.ID);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.SaveBusiness(dlg.Business);
                RefreshBusinessTree();
            }
        }

        private void tsmiDelBusiness_Click(object sender, EventArgs e)
        {
            CurrBusiness = treeBusiness.SelectedNode.Tag as SYS_BUSINESS;
            BusinessServcie.DelBusiness(CurrBusiness.ID);
            RefreshBusinessTree();
        }
    }
}
