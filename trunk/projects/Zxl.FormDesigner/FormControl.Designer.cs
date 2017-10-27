namespace Zxl.FormDesigner
{
    partial class FormControl
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
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmsProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.panelForm = new Zxl.FormDesigner.FormPanel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cmsProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vScrollBar.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 17);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 364);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar.Margin = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(526, 17);
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(526, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 17);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hScrollBar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 17);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.vScrollBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(526, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(17, 364);
            this.panel3.TabIndex = 4;
            // 
            // cmsProcess
            // 
            this.cmsProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiSave,
            this.cmsiArrange});
            this.cmsProcess.Name = "cmsProcess";
            this.cmsProcess.Size = new System.Drawing.Size(101, 48);
            // 
            // cmsiSave
            // 
            this.cmsiSave.Name = "cmsiSave";
            this.cmsiSave.Size = new System.Drawing.Size(100, 22);
            this.cmsiSave.Text = "保存";
            this.cmsiSave.Click += new System.EventHandler(this.cmsiSave_Click);
            // 
            // cmsiArrange
            // 
            this.cmsiArrange.Name = "cmsiArrange";
            this.cmsiArrange.Size = new System.Drawing.Size(100, 22);
            this.cmsiArrange.Text = "整理";
            this.cmsiArrange.Click += new System.EventHandler(this.cmsiArrange_Click);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.ContextMenuStrip = this.cmsProcess;
            this.panelForm.Location = new System.Drawing.Point(19, 17);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(768, 1024);
            this.panelForm.TabIndex = 2;
            this.panelForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForm_Paint);
            this.panelForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panelForm_KeyDown);
            this.panelForm.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseDoubleClick);
            this.panelForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseDown);
            this.panelForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseMove);
            this.panelForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseUp);
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelForm);
            this.Name = "FormControl";
            this.Size = new System.Drawing.Size(543, 381);
            this.Load += new System.EventHandler(this.FormControl_Load);
            this.Resize += new System.EventHandler(this.FormControl_Resize);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.cmsProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel panel2;
        private FormPanel panelForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ContextMenuStrip cmsProcess;
        private System.Windows.Forms.ToolStripMenuItem cmsiSave;
        private System.Windows.Forms.ToolStripMenuItem cmsiArrange;
    }
}
