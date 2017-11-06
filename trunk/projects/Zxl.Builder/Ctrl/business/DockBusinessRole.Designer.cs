namespace Zxl.Builder
{
    partial class DockBusinessRole
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
            this.components = new System.ComponentModel.Container();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tsmiDelUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRoleDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdNullable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdLength = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDataType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bdName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.treeUserRole = new DevExpress.XtraTreeList.TreeList();
            this.bdDefaultVal = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.contextMenuRoleDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeUserRole)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(105, 21);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(242, 20);
            this.txtRoleName.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtRoleName);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(957, 64);
            this.panelControl1.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "当前角色：";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // tsmiDelUser
            // 
            this.tsmiDelUser.Image = global::Zxl.Builder.Properties.Resources.del1;
            this.tsmiDelUser.Name = "tsmiDelUser";
            this.tsmiDelUser.Size = new System.Drawing.Size(124, 22);
            this.tsmiDelUser.Text = "删除用户";
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Image = global::Zxl.Builder.Properties.Resources.add1;
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddUser.Text = "添加用户";
            // 
            // contextMenuRoleDetail
            // 
            this.contextMenuRoleDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddUser,
            this.tsmiDelUser});
            this.contextMenuRoleDetail.Name = "contextMenuBdt";
            this.contextMenuRoleDetail.Size = new System.Drawing.Size(125, 48);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = " ";
            this.treeListColumn1.FieldName = "none";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 6;
            // 
            // bdNullable
            // 
            this.bdNullable.Caption = "邮箱";
            this.bdNullable.FieldName = "邮箱";
            this.bdNullable.Name = "bdNullable";
            this.bdNullable.OptionsColumn.AllowEdit = false;
            this.bdNullable.OptionsColumn.FixedWidth = true;
            this.bdNullable.Visible = true;
            this.bdNullable.VisibleIndex = 4;
            this.bdNullable.Width = 150;
            // 
            // bdLength
            // 
            this.bdLength.Caption = "固定电话";
            this.bdLength.FieldName = "固定电话";
            this.bdLength.Name = "bdLength";
            this.bdLength.OptionsColumn.AllowEdit = false;
            this.bdLength.OptionsColumn.FixedWidth = true;
            this.bdLength.Visible = true;
            this.bdLength.VisibleIndex = 3;
            this.bdLength.Width = 100;
            // 
            // bdDataType
            // 
            this.bdDataType.Caption = "移动电话";
            this.bdDataType.FieldName = "移动电话";
            this.bdDataType.MinWidth = 30;
            this.bdDataType.Name = "bdDataType";
            this.bdDataType.OptionsColumn.AllowEdit = false;
            this.bdDataType.OptionsColumn.FixedWidth = true;
            this.bdDataType.Visible = true;
            this.bdDataType.VisibleIndex = 2;
            this.bdDataType.Width = 100;
            // 
            // bdDescription
            // 
            this.bdDescription.Caption = "昵称";
            this.bdDescription.FieldName = "昵称";
            this.bdDescription.MinWidth = 30;
            this.bdDescription.Name = "bdDescription";
            this.bdDescription.OptionsColumn.AllowEdit = false;
            this.bdDescription.OptionsColumn.FixedWidth = true;
            this.bdDescription.Visible = true;
            this.bdDescription.VisibleIndex = 1;
            this.bdDescription.Width = 80;
            // 
            // bdName
            // 
            this.bdName.Caption = "名称";
            this.bdName.FieldName = "名称";
            this.bdName.MinWidth = 31;
            this.bdName.Name = "bdName";
            this.bdName.OptionsColumn.AllowEdit = false;
            this.bdName.OptionsColumn.FixedWidth = true;
            this.bdName.Visible = true;
            this.bdName.VisibleIndex = 0;
            this.bdName.Width = 200;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.treeUserRole);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(957, 448);
            this.panelControl2.TabIndex = 8;
            // 
            // treeUserRole
            // 
            this.treeUserRole.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.bdName,
            this.bdDescription,
            this.bdDataType,
            this.bdLength,
            this.bdNullable,
            this.bdDefaultVal,
            this.treeListColumn1});
            this.treeUserRole.ContextMenuStrip = this.contextMenuRoleDetail;
            this.treeUserRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUserRole.Location = new System.Drawing.Point(2, 2);
            this.treeUserRole.LookAndFeel.SkinName = "iMaginary";
            this.treeUserRole.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeUserRole.Name = "treeUserRole";
            this.treeUserRole.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeUserRole.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeUserRole.OptionsView.ShowCheckBoxes = true;
            this.treeUserRole.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemCheckEdit1});
            this.treeUserRole.Size = new System.Drawing.Size(953, 444);
            this.treeUserRole.TabIndex = 0;
            // 
            // bdDefaultVal
            // 
            this.bdDefaultVal.Caption = "创建时间";
            this.bdDefaultVal.FieldName = "创建时间";
            this.bdDefaultVal.Name = "bdDefaultVal";
            this.bdDefaultVal.OptionsColumn.AllowEdit = false;
            this.bdDefaultVal.OptionsColumn.FixedWidth = true;
            this.bdDefaultVal.Visible = true;
            this.bdDefaultVal.VisibleIndex = 5;
            this.bdDefaultVal.Width = 150;
            // 
            // DockBusinessRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 448);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "DockBusinessRole";
            this.TabText = "DockRoleDetail";
            this.Text = "业务角色";
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.contextMenuRoleDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeUserRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtRoleName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuRoleDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdNullable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdLength;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDataType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTreeList.TreeList treeUserRole;
        private DevExpress.XtraTreeList.Columns.TreeListColumn bdDefaultVal;

    }
}