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
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelWorkflow = new WorkflowPanel();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.Location = new System.Drawing.Point(534, 0);
            this.vScrollBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 17);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 378);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(0, 378);
            this.hScrollBar.Margin = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(534, 17);
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(534, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 17);
            this.panel2.TabIndex = 1;
            // 
            // panelWorkflow
            // 
            this.panelWorkflow.BackColor = System.Drawing.Color.White;
            this.panelWorkflow.Location = new System.Drawing.Point(19, 17);
            this.panelWorkflow.Name = "panelWorkflow";
            this.panelWorkflow.Size = new System.Drawing.Size(1920, 1080);
            this.panelWorkflow.TabIndex = 2;
            this.panelWorkflow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelWorkflow_Paint);
            this.panelWorkflow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseDown);
            this.panelWorkflow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseMove);
            this.panelWorkflow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelWorkflow_MouseUp);
            // 
            // WorkflowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.panelWorkflow);
            this.Name = "WorkflowControl";
            this.Size = new System.Drawing.Size(551, 395);
            this.Load += new System.EventHandler(this.WorkflowControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel panel2;
        private WorkflowPanel panelWorkflow;
    }
}
