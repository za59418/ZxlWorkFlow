namespace Zxl.Builder
{
    partial class businessCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeBusiness = new System.Windows.Forms.TreeView();
            this.cmsBusinesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBusiness = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmiEditBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.csmiDelBusiness = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmsRoles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEditRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMaterials = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMaterial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEditMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsForms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsForm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEditForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelForm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiEditProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiDelProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiAddProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBusinesses.SuspendLayout();
            this.cmsBusiness.SuspendLayout();
            this.cmsRoles.SuspendLayout();
            this.cmsRole.SuspendLayout();
            this.cmsMaterials.SuspendLayout();
            this.cmsMaterial.SuspendLayout();
            this.cmsForms.SuspendLayout();
            this.cmsForm.SuspendLayout();
            this.cmsProcess.SuspendLayout();
            this.cmsProcesses.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeBusiness
            // 
            this.treeBusiness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBusiness.Location = new System.Drawing.Point(0, 0);
            this.treeBusiness.Name = "treeBusiness";
            this.treeBusiness.Size = new System.Drawing.Size(289, 516);
            this.treeBusiness.TabIndex = 0;
            this.treeBusiness.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeBusiness_NodeMouseClick);
            this.treeBusiness.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeBusiness_NodeMouseDoubleClick);
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // cmsiDelRole
            // 
            this.cmsiDelRole.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelRole.Name = "cmsiDelRole";
            this.cmsiDelRole.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelRole.Text = "删除角色";
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
            // 
            // cmsiDelMaterial
            // 
            this.cmsiDelMaterial.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelMaterial.Name = "cmsiDelMaterial";
            this.cmsiDelMaterial.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelMaterial.Text = "删除材料";
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
            // 
            // cmsiDelForm
            // 
            this.cmsiDelForm.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelForm.Name = "cmsiDelForm";
            this.cmsiDelForm.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelForm.Text = "删除表单";
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
            // 
            // cmsiDelProcess
            // 
            this.cmsiDelProcess.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.cmsiDelProcess.Name = "cmsiDelProcess";
            this.cmsiDelProcess.Size = new System.Drawing.Size(124, 22);
            this.cmsiDelProcess.Text = "删除流程";
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
            // 
            // businessCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeBusiness);
            this.Name = "businessCtrl";
            this.Size = new System.Drawing.Size(289, 516);
            this.cmsBusinesses.ResumeLayout(false);
            this.cmsBusiness.ResumeLayout(false);
            this.cmsRoles.ResumeLayout(false);
            this.cmsRole.ResumeLayout(false);
            this.cmsMaterials.ResumeLayout(false);
            this.cmsMaterial.ResumeLayout(false);
            this.cmsForms.ResumeLayout(false);
            this.cmsForm.ResumeLayout(false);
            this.cmsProcess.ResumeLayout(false);
            this.cmsProcesses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsBusinesses;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddBusiness;
        private System.Windows.Forms.TreeView treeBusiness;
        private System.Windows.Forms.ContextMenuStrip cmsBusiness;
        private System.Windows.Forms.ToolStripMenuItem csmiEditBusiness;
        private System.Windows.Forms.ToolStripMenuItem csmiDelBusiness;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip cmsRoles;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddRole;
        private System.Windows.Forms.ContextMenuStrip cmsRole;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditRole;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelRole;
        private System.Windows.Forms.ContextMenuStrip cmsMaterials;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddMaterial;
        private System.Windows.Forms.ContextMenuStrip cmsMaterial;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditMaterial;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelMaterial;
        private System.Windows.Forms.ContextMenuStrip cmsForms;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddForm;
        private System.Windows.Forms.ContextMenuStrip cmsForm;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditForm;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelForm;
        private System.Windows.Forms.ContextMenuStrip cmsProcess;
        private System.Windows.Forms.ToolStripMenuItem cmsiEditProcess;
        private System.Windows.Forms.ToolStripMenuItem cmsiDelProcess;
        private System.Windows.Forms.ContextMenuStrip cmsProcesses;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddProcess;
    }
}
