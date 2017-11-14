namespace FormDesigner.ControlDesign
{
    partial class TableControlProperty
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurTabPage = new System.Windows.Forms.TextBox();
            this.btnPrePage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnInsertTabPage = new System.Windows.Forms.Button();
            this.btnDeletePage = new System.Windows.Forms.Button();
            this.btnSetPageText = new System.Windows.Forms.Button();
            this.txtContorlName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前页名称";
            // 
            // txtCurTabPage
            // 
            this.txtCurTabPage.Location = new System.Drawing.Point(103, 57);
            this.txtCurTabPage.Name = "txtCurTabPage";
            this.txtCurTabPage.Size = new System.Drawing.Size(283, 21);
            this.txtCurTabPage.TabIndex = 1;
            // 
            // btnPrePage
            // 
            this.btnPrePage.Location = new System.Drawing.Point(13, 110);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(36, 23);
            this.btnPrePage.TabIndex = 2;
            this.btnPrePage.Text = "<<";
            this.btnPrePage.UseVisualStyleBackColor = true;
            this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(55, 110);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(36, 23);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnInsertTabPage
            // 
            this.btnInsertTabPage.Location = new System.Drawing.Point(112, 110);
            this.btnInsertTabPage.Name = "btnInsertTabPage";
            this.btnInsertTabPage.Size = new System.Drawing.Size(75, 23);
            this.btnInsertTabPage.TabIndex = 4;
            this.btnInsertTabPage.Text = "添加页";
            this.btnInsertTabPage.UseVisualStyleBackColor = true;
            this.btnInsertTabPage.Click += new System.EventHandler(this.btnInsertTabPage_Click);
            // 
            // btnDeletePage
            // 
            this.btnDeletePage.Location = new System.Drawing.Point(274, 110);
            this.btnDeletePage.Name = "btnDeletePage";
            this.btnDeletePage.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePage.TabIndex = 5;
            this.btnDeletePage.Text = "删除页";
            this.btnDeletePage.UseVisualStyleBackColor = true;
            this.btnDeletePage.Click += new System.EventHandler(this.btnDeletePage_Click);
            // 
            // btnSetPageText
            // 
            this.btnSetPageText.Location = new System.Drawing.Point(193, 110);
            this.btnSetPageText.Name = "btnSetPageText";
            this.btnSetPageText.Size = new System.Drawing.Size(75, 23);
            this.btnSetPageText.TabIndex = 6;
            this.btnSetPageText.Text = "更新页";
            this.btnSetPageText.UseVisualStyleBackColor = true;
            this.btnSetPageText.Click += new System.EventHandler(this.btnSetPageText_Click);
            // 
            // txtContorlName
            // 
            this.txtContorlName.Location = new System.Drawing.Point(103, 18);
            this.txtContorlName.Name = "txtContorlName";
            this.txtContorlName.ReadOnly = true;
            this.txtContorlName.Size = new System.Drawing.Size(283, 21);
            this.txtContorlName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "控件名称";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContorlName);
            this.groupBox1.Controls.Add(this.txtCurTabPage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 97);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(355, 110);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TableControlProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 141);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeletePage);
            this.Controls.Add(this.btnInsertTabPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnSetPageText);
            this.Controls.Add(this.btnPrePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableControlProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分页框设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurTabPage;
        private System.Windows.Forms.Button btnPrePage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnInsertTabPage;
        private System.Windows.Forms.Button btnDeletePage;
        private System.Windows.Forms.Button btnSetPageText;
        private System.Windows.Forms.TextBox txtContorlName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
    }
}