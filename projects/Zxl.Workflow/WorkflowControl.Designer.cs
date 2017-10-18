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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vScrollBar.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 17);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 368);
            this.vScrollBar.TabIndex = 0;
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Location = new System.Drawing.Point(0, 368);
            this.hScrollBar.Margin = new System.Windows.Forms.Padding(0, 0, 17, 0);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(534, 17);
            this.hScrollBar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vScrollBar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(534, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 385);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 17);
            this.panel2.TabIndex = 1;
            // 
            // WorkflowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.panel1);
            this.Name = "WorkflowControl";
            this.Size = new System.Drawing.Size(551, 385);
            this.Load += new System.EventHandler(this.WorkflowControl_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WorkflowControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WorkflowControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WorkflowControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WorkflowControl_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
