namespace FormDesigner.ControlDesign
{
    partial class EditProperty
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtMultiRow = new System.Windows.Forms.RadioButton();
            this.rbtSingleRow = new System.Windows.Forms.RadioButton();
            this.txtControlID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(63, 65);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtMultiRow);
            this.groupBox1.Controls.Add(this.rbtSingleRow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "风格";
            // 
            // rbtMultiRow
            // 
            this.rbtMultiRow.AutoSize = true;
            this.rbtMultiRow.Location = new System.Drawing.Point(167, 20);
            this.rbtMultiRow.Name = "rbtMultiRow";
            this.rbtMultiRow.Size = new System.Drawing.Size(47, 16);
            this.rbtMultiRow.TabIndex = 9;
            this.rbtMultiRow.TabStop = true;
            this.rbtMultiRow.Text = "多行";
            this.rbtMultiRow.UseVisualStyleBackColor = true;
            // 
            // rbtSingleRow
            // 
            this.rbtSingleRow.AutoSize = true;
            this.rbtSingleRow.Checked = true;
            this.rbtSingleRow.Location = new System.Drawing.Point(50, 20);
            this.rbtSingleRow.Name = "rbtSingleRow";
            this.rbtSingleRow.Size = new System.Drawing.Size(47, 16);
            this.rbtSingleRow.TabIndex = 8;
            this.rbtSingleRow.TabStop = true;
            this.rbtSingleRow.Text = "单行";
            this.rbtSingleRow.UseVisualStyleBackColor = true;
            // 
            // txtControlID
            // 
            this.txtControlID.Location = new System.Drawing.Point(99, 12);
            this.txtControlID.Name = "txtControlID";
            this.txtControlID.ReadOnly = true;
            this.txtControlID.Size = new System.Drawing.Size(154, 21);
            this.txtControlID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "控件名称";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtControlID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 43);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(298, 98);
            this.panel2.TabIndex = 12;
            // 
            // EditProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 141);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文本框属性";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtControlID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtMultiRow;
        private System.Windows.Forms.RadioButton rbtSingleRow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}