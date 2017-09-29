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

            treeBusiness.ItemHeight = 20;
            imageList1.Images.Clear();
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.folder);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.folderUser);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.role);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.folderMaterial);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.material);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.folderForm);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.form);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.folderProcess);
            imageList1.Images.Add(global::Zxl.Builder.Properties.Resources.process);
            treeBusiness.ImageList = imageList1;

            RefreshBusinessTree();
        }

        public SYS_BUSINESS CurrBusiness { get; set; }


        #region 业务树事件
        private void cmsiAddBusiness_Click(object sender, EventArgs e)
        {
            DlgEditBusiness dlg = new DlgEditBusiness();
            SYS_BUSINESSGROUP group = treeBusiness.SelectedNode.Tag as SYS_BUSINESSGROUP;
            dlg.Business = new SYS_BUSINESS();
            dlg.Business.REF_GROUP_ID = group.ID;
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
        void RefreshBusinessTree()
        {
            treeBusiness.Nodes.Clear();

            TreeNode root = treeBusiness.Nodes.Add("root", "业务列表");
            root.ImageIndex = 0;
            root.SelectedImageIndex = 0;
            List<SYS_BUSINESSGROUP> groups = BusinessServcie.BusinessGroups();
            foreach (SYS_BUSINESSGROUP group in groups)
            {
                TreeNode groupNode = root.Nodes.Add(group.ID + "", group.GROUPNAME);

                groupNode.ContextMenuStrip = cmsBusinesses;
                groupNode.ImageIndex = 0;
                groupNode.SelectedImageIndex = 0;
                groupNode.Tag = group;

                List<SYS_BUSINESS> businesses = BusinessServcie.Businesses(group.ID);
                foreach (SYS_BUSINESS business in businesses)
                {
                    TreeNode businessNode = groupNode.Nodes.Add(business.ID + "", business.BUSINESSNAME + "(" + business.ID + ")");
                    businessNode.ImageIndex = 0;
                    businessNode.SelectedImageIndex = 0;
                    businessNode.ContextMenuStrip = cmsBusiness;
                    businessNode.Tag = business;

                    TreeNode rolesNode = businessNode.Nodes.Add("material", "角色列表");
                    rolesNode.ImageIndex = 1;
                    rolesNode.SelectedImageIndex = 1;
                    List<SYS_BUSINESSROLE> roles = BusinessServcie.BusinessRoles(business.ID);
                    foreach (SYS_BUSINESSROLE role in roles)
                    {
                        TreeNode roleNode = rolesNode.Nodes.Add(role.ID + "", role.ROLENAME);
                        roleNode.ImageIndex = 2;
                        roleNode.SelectedImageIndex = 2;
                        roleNode.Tag = role;
                    }
                    rolesNode.Expand();

                    TreeNode materialsNode = businessNode.Nodes.Add("material", "材料清单");
                    materialsNode.ImageIndex = 3;
                    materialsNode.SelectedImageIndex = 3;
                    List<SYS_BUSINESSMATERIAL> materials = BusinessServcie.BusinessMaterials(business.ID);
                    foreach (SYS_BUSINESSMATERIAL material in materials)
                    {
                        TreeNode materialNode = materialsNode.Nodes.Add(material.ID + "", material.MATERIALNAME + "(" + material.ID + ")");
                        materialNode.ImageIndex = 4;
                        materialNode.SelectedImageIndex = 4;
                        materialNode.Tag = material;
                    }
                    materialsNode.Expand();

                    TreeNode formsNode = businessNode.Nodes.Add("form", "表单列表");
                    formsNode.ImageIndex = 5;
                    formsNode.SelectedImageIndex = 5;
                    List<SYS_BUSINESSFORM> forms = BusinessServcie.BusinessForms(business.ID);
                    foreach (SYS_BUSINESSFORM form in forms)
                    {
                        TreeNode formNode = formsNode.Nodes.Add(form.ID + "", form.FORMNAME + "(" + form.ID + ")");
                        formNode.ImageIndex = 6;
                        formNode.SelectedImageIndex = 6;
                        formNode.Tag = form;
                    }
                    formsNode.Expand();

                    TreeNode processesNode = businessNode.Nodes.Add("process", "流程");
                    processesNode.ImageIndex = 7;
                    processesNode.SelectedImageIndex = 7;
                    List<SYS_BUSINESSPROCESS> processes = BusinessServcie.BusinessProcesses(business.ID);
                    foreach (SYS_BUSINESSPROCESS process in processes)
                    {
                        TreeNode processNode = processesNode.Nodes.Add(process.ID + "", process.PROCESSNAME + "(" + process.ID + ")");
                        processNode.ImageIndex = 8;
                        processNode.SelectedImageIndex = 8;
                        processNode.Tag = process;
                    }
                    processesNode.Expand();
                }
                groupNode.Expand();
            }
            root.Expand();
        }      

        #endregion 业务树事件
    }
}
