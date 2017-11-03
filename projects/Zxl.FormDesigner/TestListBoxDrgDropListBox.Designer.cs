namespace Zxl.Test
{
    partial class TestListBoxDrgDropListBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseDown);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseMove);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(419, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseDown);
            this.textBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseMove);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Controls_MouseUp);
            // 
            // ListBoxDrgDropListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 357);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "ListBoxDrgDropListBox";
            this.Text = "ListBoxDrgDropListBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;

    }
}