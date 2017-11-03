namespace Zxl.Builder
{
    partial class DockBusiness
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeBusiness = new System.Windows.Forms.TreeView();
            this.cmsProcesses = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiAddProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRole = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiEditRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBusinesses = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiAddBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProcess = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiEditProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMaterial = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiEditMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMaterials = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiAddMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.cmsBusiness = new System.Windows.Forms.ContextMenuStrip();
            this.csmiEditBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.csmiDelBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRoles = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiAddRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsForm = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiEditForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsForms = new System.Windows.Forms.ContextMenuStrip();
            this.cmsiAddForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProcesses.SuspendLayout();
            this.cmsRole.SuspendLayout();
            this.cmsBusinesses.SuspendLayout();
            this.cmsProcess.SuspendLayout();
            this.cmsMaterial.SuspendLayout();
            this.cmsMaterials.SuspendLayout();
            this.cmsBusiness.SuspendLayout();
            this.cmsRoles.SuspendLayout();
            this.cmsForm.SuspendLayout();
            this.cmsForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeBusiness
            // 
            this.treeBusiness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBusiness.Location = new System.Drawing.Point(0, 0);
            this.treeBusiness.Name = "treeBusiness";
            this.treeBusiness.Size = new System.Drawing.Size(284, 505);
            this.treeBusiness.TabIndex = 1;
            this.treeBusiness.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeBusiness_NodeMouseClick);
            this.treeBusiness.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeBusiness_NodeMouseDoubleClick);
            // 
            // cmsProcesses
            // 
            this.cmsProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddProcess});
            this.cmsProcesses.Name = "contextMenuBd";
            this.cmsProcesses.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsiAddProcess
            // 
            this.cmsiAddProcess.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsiAddProcess.Name = "cmsiAddProcess";
            this.cmsiAddProcess.Size = new System.Drawing.Size(124, 22);
            this.cmsiAddProcess.Text = "添加流程";
            this.cmsiAddProcess.Click += new System.EventHandler(this.cmsiAddProcess_Click);
            // 
            // cmsRole
            // 
            this.cmsRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEditRole,
            this.cmsiDelRole});
            this.cmsRole.Name = "contextMenuBd";
            this.cmsRole.Size = new System.Drawing.Size(125, 48);
            // 
            // cmsiEditRole
            // 
            this.cmsiEditRole.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEditRole.Name = "cmsiEditRole";
            this.cmsiEditRole.Size = new System.Drawing.Size(124, 22);
            this.cmsiEditRole.Text = "编辑角色";
            this.cmsiEditRole.Click += new System.EventHandler(this.cmsiEditRole_Click);
            // 
            // cmsiDelRole
            // 
            this.cmsiDelRole.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelRole.Name = "cmsiDelRole";
            this.cmsiDelRole.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelRole.Text = "删除角色";
            this.cmsiDelRole.Click += new System.EventHandler(this.cmsiDelRole_Click);
            // 
            // cmsBusinesses
            // 
            this.cmsBusinesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddBusiness});
            this.cmsBusinesses.Name = "contextMenuBd";
            this.cmsBusinesses.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsiAddBusiness
            // 
            this.cmsiAddBusiness.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsiAddBusiness.Name = "cmsiAddBusiness";
            this.cmsiAddBusiness.Size = new System.Drawing.Size(124, 22);
            this.cmsiAddBusiness.Text = "添加业务";
            this.cmsiAddBusiness.Click += new System.EventHandler(this.cmsiAddBusiness_Click);
            // 
            // cmsProcess
            // 
            this.cmsProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEditProcess,
            this.cmsiDelProcess});
            this.cmsProcess.Name = "contextMenuBd";
            this.cmsProcess.Size = new System.Drawing.Size(125, 48);
            // 
            // cmsiEditProcess
            // 
            this.cmsiEditProcess.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEditProcess.Name = "cmsiEditProcess";
            this.cmsiEditProcess.Size = new System.Drawing.Size(124, 22);
            this.cmsiEditProcess.Text = "编辑流程";
            this.cmsiEditProcess.Click += new System.EventHandler(this.cmsiEditProcess_Click);
            // 
            // cmsiDelProcess
            // 
            this.cmsiDelProcess.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelProcess.Name = "cmsiDelProcess";
            this.cmsiDelProcess.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelProcess.Text = "删除流程";
            this.cmsiDelProcess.Click += new System.EventHandler(this.cmsiDelProcess_Click);
            // 
            // cmsMaterial
            // 
            this.cmsMaterial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEditMaterial,
            this.cmsiDelMaterial});
            this.cmsMaterial.Name = "contextMenuBd";
            this.cmsMaterial.Size = new System.Drawing.Size(125, 48);
            // 
            // cmsiEditMaterial
            // 
            this.cmsiEditMaterial.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEditMaterial.Name = "cmsiEditMaterial";
            this.cmsiEditMaterial.Size = new System.Drawing.Size(124, 22);
            this.cmsiEditMaterial.Text = "编辑材料";
            this.cmsiEditMaterial.Click += new System.EventHandler(this.cmsiEditMaterial_Click);
            // 
            // cmsiDelMaterial
            // 
            this.cmsiDelMaterial.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelMaterial.Name = "cmsiDelMaterial";
            this.cmsiDelMaterial.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelMaterial.Text = "删除材料";
            this.cmsiDelMaterial.Click += new System.EventHandler(this.cmsiDelMaterial_Click);
            // 
            // cmsMaterials
            // 
            this.cmsMaterials.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddMaterial});
            this.cmsMaterials.Name = "contextMenuBd";
            this.cmsMaterials.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsiAddMaterial
            // 
            this.cmsiAddMaterial.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsiAddMaterial.Name = "cmsiAddMaterial";
            this.cmsiAddMaterial.Size = new System.Drawing.Size(124, 22);
            this.cmsiAddMaterial.Text = "添加材料";
            this.cmsiAddMaterial.Click += new System.EventHandler(this.cmsiAddMaterial_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmsBusiness
            // 
            this.cmsBusiness.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csmiEditBusiness,
            this.csmiDelBusiness});
            this.cmsBusiness.Name = "contextMenuBd";
            this.cmsBusiness.Size = new System.Drawing.Size(125, 48);
            // 
            // csmiEditBusiness
            // 
            this.csmiEditBusiness.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.csmiEditBusiness.Name = "csmiEditBusiness";
            this.csmiEditBusiness.Size = new System.Drawing.Size(124, 22);
            this.csmiEditBusiness.Text = "编辑业务";
            this.csmiEditBusiness.Click += new System.EventHandler(this.csmiEditBusiness_Click);
            // 
            // csmiDelBusiness
            // 
            this.csmiDelBusiness.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.csmiDelBusiness.Name = "csmiDelBusiness";
            this.csmiDelBusiness.Size = new System.Drawing.Size(124, 22);
            this.csmiDelBusiness.Text = "删除业务";
            this.csmiDelBusiness.Click += new System.EventHandler(this.csmiDelBusiness_Click);
            // 
            // cmsRoles
            // 
            this.cmsRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddRole});
            this.cmsRoles.Name = "contextMenuBd";
            this.cmsRoles.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsiAddRole
            // 
            this.cmsiAddRole.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsiAddRole.Name = "cmsiAddRole";
            this.cmsiAddRole.Size = new System.Drawing.Size(124, 22);
            this.cmsiAddRole.Text = "添加角色";
            this.cmsiAddRole.Click += new System.EventHandler(this.cmsiAddRole_Click);
            // 
            // cmsForm
            // 
            this.cmsForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiEditForm,
            this.cmsiDelForm});
            this.cmsForm.Name = "contextMenuBd";
            this.cmsForm.Size = new System.Drawing.Size(125, 48);
            // 
            // cmsiEditForm
            // 
            this.cmsiEditForm.Image = global::Zxl.Builder.Properties.Resources.edit1;
            this.cmsiEditForm.Name = "cmsiEditForm";
            this.cmsiEditForm.Size = new System.Drawing.Size(124, 22);
            this.cmsiEditForm.Text = "编辑表单";
            this.cmsiEditForm.Click += new System.EventHandler(this.cmsiEditForm_Click);
            // 
            // cmsiDelForm
            // 
            this.cmsiDelForm.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelForm.Name = "cmsiDelForm";
            this.cmsiDelForm.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelForm.Text = "删除表单";
            this.cmsiDelForm.Click += new System.EventHandler(this.cmsiDelForm_Click);
            // 
            // cmsForms
            // 
            this.cmsForms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiAddForm});
            this.cmsForms.Name = "contextMenuBd";
            this.cmsForms.Size = new System.Drawing.Size(125, 26);
            // 
            // cmsiAddForm
            // 
            this.cmsiAddForm.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.cmsiAddForm.Name = "cmsiAddForm";
            this.cmsiAddForm.Size = new System.Drawing.Size(124, 22);
            this.cmsiAddForm.Text = "添加表单";
            this.cmsiAddForm.Click += new System.EventHandler(this.cmsiAddForm_Click);
            // 
            // DockBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 505);
            this.Controls.Add(this.treeBusiness);
            this.Name = "DockBusiness";
            this.ShowIcon = false;
            this.TabText = "BusinessForm";
            this.Text = "业务列表";
            this.cmsProcesses.ResumeLayout(false);
            this.cmsRole.ResumeLayout(false);
            this.cmsBusinesses.ResumeLayout(false);
            this.cmsProcess.ResumeLayout(false);
            this.cmsMaterial.ResumeLayout(false);
            this.cmsMaterials.ResumeLayout(false);
            this.cmsBusiness.ResumeLayout(false);
            this.cmsRoles.ResumeLayout(false);
            this.cmsForm.ResumeLayout(false);
            this.cmsForms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeBusiness;
        private System.Windows.Forms.ContextMenuStrip cmsProcesses;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddProcess;
        private System.Windows.Forms.ContextMenuStrip cmsRole;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditRole;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelRole;
        private System.Windows.Forms.ContextMenuStrip cmsBusinesses;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddBusiness;
        private System.Windows.Forms.ContextMenuStrip cmsProcess;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditProcess;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelProcess;
        private System.Windows.Forms.ContextMenuStrip cmsMaterial;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditMaterial;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelMaterial;
        private System.Windows.Forms.ContextMenuStrip cmsMaterials;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddMaterial;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmsBusiness;
        private System.Windows.Forms.ToolStripMenuItem csmiEditBusiness;
        private System.Windows.Forms.ToolStripMenuItem csmiDelBusiness;
        private System.Windows.Forms.ContextMenuStrip cmsRoles;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddRole;
        private System.Windows.Forms.ContextMenuStrip cmsForm;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditForm;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelForm;
        private System.Windows.Forms.ContextMenuStrip cmsForms;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddForm;
    }
}