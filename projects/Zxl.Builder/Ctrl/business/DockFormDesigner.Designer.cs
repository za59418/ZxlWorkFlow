namespace Zxl.Builder
{
    partial class DockFormDesigner
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
            this.SuspendLayout();
            // 
            // DockFormDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 508);
            this.Name = "DockFormDesigner";
            this.ShowIcon = false;
            this.TabText = "业务表单";
            this.Text = "业务流程";
            this.Load += new System.EventHandler(this.DockFormDesigner_Load);
            this.Resize += new System.EventHandler(this.DockFormDesigner_Resize);
            this.ResumeLayout(false);

        }

        #endregion


    }
}