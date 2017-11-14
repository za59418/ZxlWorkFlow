namespace FormDesigner.ControlDesign
{
    partial class GridProperty
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtContorlName = new System.Windows.Forms.TextBox();
            this.btnSetColumn = new System.Windows.Forms.Button();
            this.btnDeleteColumn = new System.Windows.Forms.Button();
            this.btnInsertColumn = new System.Windows.Forms.Button();
            this.btnNextColumn = new System.Windows.Forms.Button();
            this.btnPreColumn = new System.Windows.Forms.Button();
            this.txtCurColumn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtColumnWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.combStyle = new System.Windows.Forms.ComboBox();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtNotReadonly = new System.Windows.Forms.RadioButton();
            this.rbtReadOnly = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.chkSum = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "控件名称";
            // 
            // txtContorlName
            // 
            this.txtContorlName.Location = new System.Drawing.Point(179, 21);
            this.txtContorlName.Name = "txtContorlName";
            this.txtContorlName.ReadOnly = true;
            this.txtContorlName.Size = new System.Drawing.Size(265, 21);
            this.txtContorlName.TabIndex = 9;
            // 
            // btnSetColumn
            // 
            this.btnSetColumn.Location = new System.Drawing.Point(270, 288);
            this.btnSetColumn.Name = "btnSetColumn";
            this.btnSetColumn.Size = new System.Drawing.Size(75, 23);
            this.btnSetColumn.TabIndex = 3;
            this.btnSetColumn.Text = "更新列";
            this.btnSetColumn.UseVisualStyleBackColor = true;
            this.btnSetColumn.Click += new System.EventHandler(this.btnSetColumn_Click);
            // 
            // btnDeleteColumn
            // 
            this.btnDeleteColumn.Location = new System.Drawing.Point(351, 288);
            this.btnDeleteColumn.Name = "btnDeleteColumn";
            this.btnDeleteColumn.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteColumn.TabIndex = 4;
            this.btnDeleteColumn.Text = "删除列";
            this.btnDeleteColumn.UseVisualStyleBackColor = true;
            this.btnDeleteColumn.Click += new System.EventHandler(this.btnDeleteColumn_Click);
            // 
            // btnInsertColumn
            // 
            this.btnInsertColumn.Location = new System.Drawing.Point(108, 288);
            this.btnInsertColumn.Name = "btnInsertColumn";
            this.btnInsertColumn.Size = new System.Drawing.Size(75, 23);
            this.btnInsertColumn.TabIndex = 2;
            this.btnInsertColumn.Text = "添加列";
            this.btnInsertColumn.UseVisualStyleBackColor = true;
            this.btnInsertColumn.Click += new System.EventHandler(this.btnInsertColumn_Click);
            // 
            // btnNextColumn
            // 
            this.btnNextColumn.Location = new System.Drawing.Point(57, 288);
            this.btnNextColumn.Name = "btnNextColumn";
            this.btnNextColumn.Size = new System.Drawing.Size(36, 23);
            this.btnNextColumn.TabIndex = 1;
            this.btnNextColumn.Text = ">>";
            this.btnNextColumn.UseVisualStyleBackColor = true;
            this.btnNextColumn.Click += new System.EventHandler(this.btnNextColumn_Click);
            // 
            // btnPreColumn
            // 
            this.btnPreColumn.Location = new System.Drawing.Point(15, 288);
            this.btnPreColumn.Name = "btnPreColumn";
            this.btnPreColumn.Size = new System.Drawing.Size(36, 23);
            this.btnPreColumn.TabIndex = 0;
            this.btnPreColumn.Text = "<<";
            this.btnPreColumn.UseVisualStyleBackColor = true;
            this.btnPreColumn.Click += new System.EventHandler(this.btnPreColumn_Click);
            // 
            // txtCurColumn
            // 
            this.txtCurColumn.Location = new System.Drawing.Point(179, 61);
            this.txtCurColumn.Name = "txtCurColumn";
            this.txtCurColumn.Size = new System.Drawing.Size(265, 21);
            this.txtCurColumn.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "当前列名称";
            // 
            // txtColumnWidth
            // 
            this.txtColumnWidth.Location = new System.Drawing.Point(179, 101);
            this.txtColumnWidth.Name = "txtColumnWidth";
            this.txtColumnWidth.Size = new System.Drawing.Size(265, 21);
            this.txtColumnWidth.TabIndex = 1;
            this.txtColumnWidth.Text = "120";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "当前列宽度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "当前列类型";
            // 
            // combStyle
            // 
            this.combStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combStyle.FormattingEnabled = true;
            this.combStyle.Location = new System.Drawing.Point(179, 141);
            this.combStyle.Name = "combStyle";
            this.combStyle.Size = new System.Drawing.Size(265, 20);
            this.combStyle.TabIndex = 2;
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(179, 180);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(265, 21);
            this.txtDefaultValue.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "默认值";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSum);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.combStyle);
            this.groupBox1.Controls.Add(this.txtDefaultValue);
            this.groupBox1.Controls.Add(this.txtContorlName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCurColumn);
            this.groupBox1.Controls.Add(this.txtColumnWidth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 282);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtNotReadonly);
            this.panel1.Controls.Add(this.rbtReadOnly);
            this.panel1.Location = new System.Drawing.Point(179, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 32);
            this.panel1.TabIndex = 28;
            // 
            // rbtNotReadonly
            // 
            this.rbtNotReadonly.AutoSize = true;
            this.rbtNotReadonly.Location = new System.Drawing.Point(3, 8);
            this.rbtNotReadonly.Name = "rbtNotReadonly";
            this.rbtNotReadonly.Size = new System.Drawing.Size(71, 16);
            this.rbtNotReadonly.TabIndex = 0;
            this.rbtNotReadonly.Text = "列可输入";
            this.rbtNotReadonly.UseVisualStyleBackColor = true;
            // 
            // rbtReadOnly
            // 
            this.rbtReadOnly.AutoSize = true;
            this.rbtReadOnly.Location = new System.Drawing.Point(91, 8);
            this.rbtReadOnly.Name = "rbtReadOnly";
            this.rbtReadOnly.Size = new System.Drawing.Size(59, 16);
            this.rbtReadOnly.TabIndex = 1;
            this.rbtReadOnly.Text = "列只读";
            this.rbtReadOnly.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(432, 288);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(189, 288);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "插入列";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // chkSum
            // 
            this.chkSum.AutoSize = true;
            this.chkSum.Location = new System.Drawing.Point(179, 250);
            this.chkSum.Name = "chkSum";
            this.chkSum.Size = new System.Drawing.Size(60, 16);
            this.chkSum.TabIndex = 29;
            this.chkSum.Text = "列求和";
            this.chkSum.UseVisualStyleBackColor = true;
            // 
            // GridProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 323);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeleteColumn);
            this.Controls.Add(this.btnInsertColumn);
            this.Controls.Add(this.btnNextColumn);
            this.Controls.Add(this.btnPreColumn);
            this.Controls.Add(this.btnSetColumn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据网格控件属性";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContorlName;
        private System.Windows.Forms.Button btnSetColumn;
        private System.Windows.Forms.Button btnDeleteColumn;
        private System.Windows.Forms.Button btnInsertColumn;
        private System.Windows.Forms.Button btnNextColumn;
        private System.Windows.Forms.Button btnPreColumn;
        private System.Windows.Forms.TextBox txtCurColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColumnWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combStyle;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtNotReadonly;
        private System.Windows.Forms.RadioButton rbtReadOnly;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.CheckBox chkSum;
    }
}