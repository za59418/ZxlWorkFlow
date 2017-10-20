namespace Zxl.Workflow
{
    partial class WorkflowControl
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
            this.panelWorkflow = new Zxl.Workflow.WorkflowPanel();
            this.cmsiArrange = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmsProcess.Size = new System.Drawing.Size(153, 70);
            // 
            // cmsiSave
            // 
            this.cmsiSave.Name = "cmsiSave";
            this.cmsiSave.Size = new System.Drawing.Size(152, 22);
            this.cmsiSave.Text = "保存";
            this.cmsiSave.Click += new System.EventHandler(this.cmsiSave_Click);
            // 
            // panelWorkflow
            // 
            this.panelWorkflow.BackColor = System.Drawing.Color.White;
            this.panelWorkflow.ContextMenuStrip = this.cmsProcess;
            this.panelWorkflow.Location = new System.Drawing.Point(19, 17);
            this.panelWorkflow.Name = "panelWorkflow";
            this.panelWorkflow.Size = new System.Drawing.Size(1920, 1080);
            this.panelWorkflow.TabIndex = 2;
            this.panelWorkflow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelWorkflow_Paint);
            this.panelWorkflow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panelWorkflow_KeyDown);
            this.panelWorkflow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseDoubleClick);
            this.panelWorkflow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseDown);
            this.panelWorkflow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseMove);
            this.panelWorkflow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseUp);
            // 
            // cmsiArrange
            // 
            this.cmsiArrange.Name = "cmsiArrange";
            this.cmsiArrange.Size = new System.Drawing.Size(152, 22);
            this.cmsiArrange.Text = "整理";
            this.cmsiArrange.Click += new System.EventHandler(this.cmsiArrange_Click);
            // 
            // WorkflowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelWorkflow);
            this.Name = "WorkflowControl";
            this.Size = new System.Drawing.Size(543, 381);
            this.Load += new System.EventHandler(this.WorkflowControl_Load);
            this.Resize += new System.EventHandler(this.WorkflowControl_Resize);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.cmsProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel panel2;
        private WorkflowPanel panelWorkflow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ContextMenuStrip cmsProcess;
        private System.Windows.Forms.ToolStripMenuItem cmsiSave;
        private System.Windows.Forms.ToolStripMenuItem cmsiArrange;
    }
}
