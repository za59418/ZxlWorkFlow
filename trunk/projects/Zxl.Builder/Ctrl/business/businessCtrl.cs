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


        public FormMain MainForm { get; set; }

        public SYS_BUSINESSGROUP CurrBusinessGroup { get; set; }
        private SYS_BUSINESS CurrBusiness;
        private SYS_BUSINESSROLE CurrRole;
        private SYS_BUSINESSMATERIAL CurrMaterial;
        private SYS_BUSINESSFORM CurrForm;
        private SYS_BUSINESSPROCESS CurrProcess;

        #region 业务树事件
        private void treeBusiness_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag is SYS_BUSINESSROLE)
            {
                CurrRole = e.Node.Tag as SYS_BUSINESSROLE;
            }
            else if (e.Node.Tag is SYS_BUSINESSMATERIAL)
            {
                CurrMaterial = e.Node.Tag as SYS_BUSINESSMATERIAL;
            }
            else if (e.Node.Tag is SYS_BUSINESSFORM)
            {
                CurrForm = e.Node.Tag as SYS_BUSINESSFORM;
            }
            else if (e.Node.Tag is SYS_BUSINESSPROCESS)
            {
                CurrProcess = e.Node.Tag as SYS_BUSINESSPROCESS;
            }
            else if (e.Node.Tag is SYS_BUSINESS)
            {
                CurrBusiness = e.Node.Tag as SYS_BUSINESS;
            }
            else if (e.Node.Tag is SYS_BUSINESSGROUP)
            {
                CurrBusinessGroup = e.Node.Tag as SYS_BUSINESSGROUP;
            }
            else{ // 角色，材料，表单，流程文件夹
                if(e.Node.Parent.Tag is SYS_BUSINESS)
                {
                    CurrBusiness = e.Node.Parent.Tag as SYS_BUSINESS;
                    CurrBusinessGroup = e.Node.Parent.Parent.Tag as SYS_BUSINESSGROUP;
                }
            }
        }

        private void treeBusiness_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Tag is SYS_BUSINESSROLE)
            {
                businessRoleCtrl ctrl = new businessRoleCtrl();
                ctrl.Dock = DockStyle.Fill;
                ctrl.CurrRole = e.Node.Tag as SYS_BUSINESSROLE;
                MainForm.AddTab(ctrl.CurrRole.ROLENAME, ctrl);
            }
            else if (e.Node.Tag is SYS_BUSINESSFORM)
            {

            }
            else if (e.Node.Tag is SYS_BUSINESSPROCESS)
            {
                businessProcessCtrl ctrl = new businessProcessCtrl();
                ctrl.Dock = DockStyle.Fill;
                ctrl.CurrProcess = e.Node.Tag as SYS_BUSINESSPROCESS;
                MainForm.AddTab(ctrl.CurrProcess.PROCESSNAME, ctrl);
            }
        }

        #region business
        private void cmsiAddBusiness_Click(object sender, EventArgs e)
        {
            DlgEditBusiness dlg = new DlgEditBusiness();

            //SYS_BUSINESSGROUP group = treeBusiness.SelectedNode.Tag as SYS_BUSINESSGROUP;

            dlg.Business = new SYS_BUSINESS();
            dlg.Business.REF_GROUP_ID = CurrBusinessGroup.ID;
            dlg.Business.CREATETIME = DateTime.Now;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.SaveBusiness(dlg.Business);
                RefreshBusinessTree();
            }
        }

        private void csmiEditBusiness_Click(object sender, EventArgs e)
        {
            DlgEditBusiness dlg = new DlgEditBusiness();
            //CurrBusiness = treeBusiness.SelectedNode.Tag as SYS_BUSINESS;
            dlg.Business = BusinessServcie.Business(CurrBusiness.ID);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BusinessServcie.SaveBusiness(dlg.Business);
                RefreshBusinessTree();
            }
        }

        private void csmiDelBusiness_Click(object sender, EventArgs e)
        {
            //CurrBusiness = treeBusiness.SelectedNode.Tag as SYS_BUSINESS;
            BusinessServcie.DelBusiness(CurrBusiness.ID);
            RefreshBusinessTree();
        }
        #endregion business
        #region businessrole
        private void cmsiAddRole_Click(object sender, EventArgs e)
        {
            SYS_BUSINESSROLE newRole = new SYS_BUSINESSROLE();
            newRole.CREATETIME = DateTime.Now;
            newRole.REF_BUSINESS_ID = CurrBusiness.ID;
            DlgEditBusinessRole dlg = new DlgEditBusinessRole();
            dlg.Role = newRole;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessRole(dlg.Role);
                    RefreshBusinessTree();
                    MainForm.INFO("添加业务角色成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("添加业务角色失败！" + ex.Message);
                }
            }
        }

        private void cmsiEditRole_Click(object sender, EventArgs e)
        {
            DlgEditBusinessRole dlg = new DlgEditBusinessRole();
            dlg.Role = BusinessServcie.GetBusinessRole(CurrRole.ID);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessRole(dlg.Role);
                    RefreshBusinessTree();
                    MainForm.INFO("编辑业务角色成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("编辑业务角色失败！" + ex.Message);
                }
            }
        }

        private void cmsiDelRole_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessServcie.DelBusinessRole(CurrRole.ID);
                RefreshBusinessTree();
                MainForm.INFO("删除业务角色成功！");
            }
            catch (Exception ex)
            {
                MainForm.ERROR("删除业务角色失败！" + ex.Message);
            }
        }

        #endregion businessrole
        #region material
        private void cmsiAddMaterial_Click(object sender, EventArgs e)
        {
            SYS_BUSINESSMATERIAL newMaterial = new SYS_BUSINESSMATERIAL();
            newMaterial.CREATETIME = DateTime.Now;
            newMaterial.REF_BUSINESS_ID = CurrBusiness.ID;
            DlgEditBusinessMaterial dlg = new DlgEditBusinessMaterial();
            dlg.Material = newMaterial;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessMaterial(dlg.Material);
                    RefreshBusinessTree();
                    MainForm.INFO("添加业务材料成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("添加业务材料失败！" + ex.Message);
                }
            }
        }

        private void cmsiEditMaterial_Click(object sender, EventArgs e)
        {
            DlgEditBusinessMaterial dlg = new DlgEditBusinessMaterial();
            dlg.Material = BusinessServcie.GetBusinessMaterial(CurrMaterial.ID);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessMaterial(dlg.Material);
                    RefreshBusinessTree();
                    MainForm.INFO("编辑业务材料成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("编辑业务材料失败！" + ex.Message);
                }
            }
        }

        private void cmsiDelMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessServcie.DelBusinessMaterial(CurrMaterial.ID);
                RefreshBusinessTree();
                MainForm.INFO("删除业务材料成功！");
            }
            catch (Exception ex)
            {
                MainForm.ERROR("删除业务材料失败！" + ex.Message);
            }
        }
        #endregion material
        #region form
        private void cmsiAddForm_Click(object sender, EventArgs e)
        {
            SYS_BUSINESSFORM newForm = new SYS_BUSINESSFORM();
            newForm.CREATETIME = DateTime.Now;
            newForm.REF_BUSINESS_ID = CurrBusiness.ID;
            DlgEditBusinessForm dlg = new DlgEditBusinessForm();
            dlg.Form = newForm;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessForm(dlg.Form);
                    RefreshBusinessTree();
                    MainForm.INFO("添加业务表单成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("添加业务表单失败！" + ex.Message);
                }
            }
        }
        private void cmsiEditForm_Click(object sender, EventArgs e)
        {
            DlgEditBusinessForm dlg = new DlgEditBusinessForm();
            dlg.Form = BusinessServcie.GetBusinessForm(CurrForm.ID);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessForm(dlg.Form);
                    RefreshBusinessTree();
                    MainForm.INFO("编辑业务表单成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("编辑业务表单失败！" + ex.Message);
                }
            }
        }
        private void cmsiDelForm_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessServcie.DelBusinessForm(CurrForm.ID);
                RefreshBusinessTree();
                MainForm.INFO("删除业务表单成功！");
            }
            catch (Exception ex)
            {
                MainForm.ERROR("删除业务表单失败！" + ex.Message);
            }
        }
        #endregion form
        #region process
        private void cmsiAddProcess_Click(object sender, EventArgs e)
        {
            SYS_BUSINESSPROCESS newProcess = new SYS_BUSINESSPROCESS();
            newProcess.CREATETIME = DateTime.Now;
            newProcess.REF_BUSINESS_ID = CurrBusiness.ID;
            DlgEditBusinessProcess dlg = new DlgEditBusinessProcess();
            dlg.Process = newProcess;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessProcess(dlg.Process);
                    RefreshBusinessTree();
                    MainForm.INFO("添加业务流程成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("添加业务流程失败！" + ex.Message);
                }
            }
        }

        private void cmsiEditProcess_Click(object sender, EventArgs e)
        {
            DlgEditBusinessProcess dlg = new DlgEditBusinessProcess();
            dlg.Process = BusinessServcie.GetBusinessProcess(CurrProcess.ID);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    BusinessServcie.SaveBusinessProcess(dlg.Process);
                    RefreshBusinessTree();
                    MainForm.INFO("编辑业务流程成功！");
                }
                catch (Exception ex)
                {
                    MainForm.ERROR("编辑业务流程失败！" + ex.Message);
                }
            }
        }

        private void cmsiDelProcess_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessServcie.DelBusinessProcess(CurrProcess.ID);
                RefreshBusinessTree();
                MainForm.INFO("删除业务流程成功！");
            }
            catch (Exception ex)
            {
                MainForm.ERROR("删除业务流程失败！" + ex.Message);
            }
        }
        #endregion process

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
                    rolesNode.ContextMenuStrip = cmsRoles;
                    List<SYS_BUSINESSROLE> roles = BusinessServcie.BusinessRoles(business.ID);
                    foreach (SYS_BUSINESSROLE role in roles)
                    {
                        TreeNode roleNode = rolesNode.Nodes.Add(role.ID + "", role.ROLENAME);
                        roleNode.ImageIndex = 2;
                        roleNode.SelectedImageIndex = 2;
                        roleNode.ContextMenuStrip = cmsRole;
                        roleNode.Tag = role;
                    }
                    rolesNode.Expand();

                    TreeNode materialsNode = businessNode.Nodes.Add("material", "材料清单");
                    materialsNode.ImageIndex = 3;
                    materialsNode.SelectedImageIndex = 3;
                    materialsNode.ContextMenuStrip = cmsMaterials;
                    List<SYS_BUSINESSMATERIAL> materials = BusinessServcie.BusinessMaterials(business.ID);
                    foreach (SYS_BUSINESSMATERIAL material in materials)
                    {
                        TreeNode materialNode = materialsNode.Nodes.Add(material.ID + "", material.MATERIALNAME + "(" + material.ID + ")");
                        materialNode.ImageIndex = 4;
                        materialNode.SelectedImageIndex = 4;
                        materialNode.ContextMenuStrip = cmsMaterial;
                        materialNode.Tag = material;
                    }
                    materialsNode.Expand();

                    TreeNode formsNode = businessNode.Nodes.Add("form", "表单列表");
                    formsNode.ImageIndex = 5;
                    formsNode.SelectedImageIndex = 5;
                    formsNode.ContextMenuStrip = cmsForms;
                    List<SYS_BUSINESSFORM> forms = BusinessServcie.BusinessForms(business.ID);
                    foreach (SYS_BUSINESSFORM form in forms)
                    {
                        TreeNode formNode = formsNode.Nodes.Add(form.ID + "", form.FORMNAME + "(" + form.ID + ")");
                        formNode.ImageIndex = 6;
                        formNode.SelectedImageIndex = 6;
                        formNode.ContextMenuStrip = cmsForm;
                        formNode.Tag = form;
                    }
                    formsNode.Expand();

                    TreeNode processesNode = businessNode.Nodes.Add("process", "流程");
                    processesNode.ImageIndex = 7;
                    processesNode.SelectedImageIndex = 7;
                    processesNode.ContextMenuStrip = cmsProcesses;
                    List<SYS_BUSINESSPROCESS> processes = BusinessServcie.BusinessProcesses(business.ID);
                    foreach (SYS_BUSINESSPROCESS process in processes)
                    {
                        TreeNode processNode = processesNode.Nodes.Add(process.ID + "", process.PROCESSNAME + "(" + process.ID + ")");
                        processNode.ImageIndex = 8;
                        processNode.SelectedImageIndex = 8;
                        processNode.ContextMenuStrip = cmsProcess;
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
