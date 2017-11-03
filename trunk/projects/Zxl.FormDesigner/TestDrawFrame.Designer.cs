namespace Zxl.Test
{
    partial class TestDrawFrame
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
            this.button1 = new System.Windows.Forms.Button();
            this.myControl1 = new Zxl.FormDesigner.MyControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // myControl1
            // 
            this.myControl1.ID = null;
            this.myControl1.IsSelected = false;
            this.myControl1.Location = new System.Drawing.Point(469, 146);
            this.myControl1.Name = "myControl1";
            this.myControl1.Size = new System.Drawing.Size(75, 23);
            this.myControl1.TabIndex = 1;
            this.myControl1.Text = "myControl1";
            this.myControl1.Value = null;
            // 
            // TestDrawFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 375);
            this.Controls.Add(this.myControl1);
            this.Controls.Add(this.button1);
            this.Name = "TestDrawFrame";
            this.Text = "Test";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private FormDesigner.MyControl myControl1;

    }
}