using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormDesigner.Common;
using Zxl.Builder;

namespace FormDesigner.ControlDesign
{
    public partial class GridProperty : System.Windows.Forms.Form
    {
        int controlID;
        int indexColumn;
        private List<string> _gridColumns;
        private string _currentColumn;
        GridColumnStyle columnStyle;
        public GridProperty(string ControlID)
        {
            controlID = Convert.ToInt32(ControlID);
            InitializeComponent();
            _gridColumns = new List<string>();
            this.txtContorlName.Text = controlID.ToString();
            columnStyle = ((DockFormDesigner)DockWindowFactory.Instance.CurrDockWindow).ColumnStyle;
            BindValues();
        }

        private void BindValues()
        {
            foreach (KeyValuePair<int, string> kvp in columnStyle.ColumnStyles)
            {
                //this.combStyle.Items.Add(new KeyValueObject(kvp.Key.ToString(),kvp.Value));
            }

            if (FormProvoider.GetGridColumns(controlID) > 0)
            {
                BindColumnInfo(0);
                indexColumn = 0;
            }
            for (int i = 0; i < FormProvoider.GetGridColumns(controlID); i++)
            {
                FormProvoider.GridColumn gridColumnInfo = new FormProvoider.GridColumn();
                FormProvoider.GetGridColumnInfo(controlID, i, out gridColumnInfo);
                _gridColumns.Add(gridColumnInfo.columncaption);
            }
        }

        private FormProvoider.GridColumn GetColumnInfo(int controlID, int indexColumn)
        {
            FormProvoider.GridColumn gridColumnInfo = new FormProvoider.GridColumn();
            FormProvoider.GetGridColumnInfo(controlID, indexColumn, out gridColumnInfo);
            return gridColumnInfo;
        }

        private void BindColumnInfo(int indexColumn)
        {
            FormProvoider.GridColumn gridColumnInfo = GetColumnInfo(controlID, indexColumn);
            this.txtCurColumn.Text = gridColumnInfo.columncaption;
            this.txtColumnWidth.Text = gridColumnInfo.columnWidth.ToString();
            string value;
            columnStyle.ColumnStyles.TryGetValue(gridColumnInfo.columnStyle, out value);
            this.combStyle.SelectedItem = GetItembykey(gridColumnInfo.columnStyle.ToString());
            // new KeyValueObject(gridColumnInfo.columnStyle.ToString(), value);
            this.txtDefaultValue.Text = gridColumnInfo.columndefaultValue;
            if (gridColumnInfo.columnalign == 1)
            { 
                this.rbtReadOnly.Checked = true; 
            }
            else
            { 
                this.rbtNotReadonly.Checked = true; 
            }
            if (gridColumnInfo.sum==1)
            {
                this.chkSum.Checked = true;
            }
            else
            {
                this.chkSum.Checked = false;
            }
            _currentColumn = gridColumnInfo.columncaption;
        }

        private object GetItembykey(string key)
        {
            object item = null;
            foreach (object var in combStyle.Items)
            {
                //if (((KeyValueObject)var).key == key)
                //{
                //    item = var;
                //}
            }
            return item;
        }

        private void btnInsertColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputDate())
                {
                    if (_gridColumns.Contains(txtCurColumn.Text.Trim()))
                    {
                        MessageBox.Show("已存在此列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _gridColumns.Add(txtCurColumn.Text.Trim());
                    FormProvoider.GridColumn gridColumnInfo = new FormProvoider.GridColumn();
                    gridColumnInfo.columnalign = 1;
                    gridColumnInfo.columnWidth = Convert.ToInt32(this.txtColumnWidth.Text.Trim());
                    gridColumnInfo.columncaption = this.txtCurColumn.Text.Trim();
                    //gridColumnInfo.columnStyle = Convert.ToInt32(((KeyValueObject)combStyle.SelectedItem).key);
                    gridColumnInfo.columndefaultValue = this.txtDefaultValue.Text.Trim();
                    if (rbtReadOnly.Checked == true)
                    { gridColumnInfo.columnalign = 1; }
                    else
                    { gridColumnInfo.columnalign = 2; }
                    if (chkSum.Checked)
                    {
                        gridColumnInfo.sum = 1;
                    }
                    else
                    {
                        gridColumnInfo.sum = 0;
                    }
                    FormProvoider.InsertGridColumn(controlID, FormProvoider.GetGridColumns(controlID), gridColumnInfo);
                    indexColumn = FormProvoider.GetGridColumns(controlID) - 1;
                    _currentColumn = txtCurColumn.Text.Trim();
                    //((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).formDataCollection.Remove(controlID.ToString());
                    MessageBox.Show("添加成功！请绑定数据。");

                }
            }
            catch { }
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除?", "删除确认", MessageBoxButtons.YesNo))
                {
                    FormProvoider.DeleteGridColumn(controlID, indexColumn);
                    _gridColumns.Remove(txtCurColumn.Text.Trim());
                    if (indexColumn > 0)
                    {
                        BindColumnInfo(indexColumn - 1);
                        indexColumn = indexColumn - 1;
                    }
                    else if (FormProvoider.GetGridColumns(controlID) > 0)
                    {
                        BindColumnInfo(0);
                        indexColumn = 0;
                    }
                    else 
                    {
                        txtCurColumn.Text = string.Empty;
                        txtColumnWidth.Text = string.Empty;
                        combStyle.SelectedItem = null;
                        txtDefaultValue.Text = string.Empty;
                        _currentColumn = string.Empty;
                        chkSum.Checked = false;
                    }
                    //((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).formDataCollection.Remove(controlID.ToString());
                    MessageBox.Show("删除成功！请绑定数据。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }        

        private void btnSetColumn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputDate())
                {
                    _gridColumns.Remove(_currentColumn);
                    _gridColumns.Add(txtCurColumn.Text.Trim());
                    FormProvoider.GridColumn gridColumnInfo = new FormProvoider.GridColumn();
                    gridColumnInfo.columnalign = 1;
                    gridColumnInfo.columnWidth = Convert.ToInt32(this.txtColumnWidth.Text.Trim());
                    gridColumnInfo.columncaption = this.txtCurColumn.Text.Trim();
                    //gridColumnInfo.columnStyle = Convert.ToInt32(((KeyValueObject)combStyle.SelectedItem).key);
                    gridColumnInfo.columndefaultValue = this.txtDefaultValue.Text.Trim();                    
                    if (rbtReadOnly.Checked == true)
                    { 
                        gridColumnInfo.columnalign = 1; 
                    }
                    else
                    { 
                        gridColumnInfo.columnalign = 2; 
                    }
                    if (chkSum.Checked)
                    {
                        gridColumnInfo.sum = 1;
                    }
                    else
                    {
                        gridColumnInfo.sum = 0;
                    }
                    FormProvoider.ModifyGridColumn(controlID, indexColumn, gridColumnInfo);
                    MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void btnPreColumn_Click(object sender, EventArgs e)
        {
            if (indexColumn > 0)
            {
                BindColumnInfo(indexColumn - 1);
                indexColumn = indexColumn - 1;
            }
        }

        private void btnNextColumn_Click(object sender, EventArgs e)
        {
            if (FormProvoider.GetGridColumns(controlID) > indexColumn + 1)
            {
                BindColumnInfo(indexColumn + 1);
                indexColumn = indexColumn + 1;
            }
        }

        private bool CheckInputDate()
        {
            bool checkedResult = true;
            if (this.txtCurColumn.Text.Length == 0)
            {
                MessageBox.Show("列名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return checkedResult=false;
            }
            else if (this.txtColumnWidth.Text.Length == 0)
            {
                MessageBox.Show("列长度不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return checkedResult = false;
            }
            else if (this.combStyle.SelectedItem == null)
            {
                MessageBox.Show("列类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return checkedResult = false;
            }
            else
            return checkedResult;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputDate())
                {
                    if (_gridColumns.Contains(txtCurColumn.Text.Trim()))
                    {
                        MessageBox.Show("已存在此列", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _gridColumns.Add(txtCurColumn.Text.Trim());
                    FormProvoider.GridColumn gridColumnInfo = new FormProvoider.GridColumn();
                    gridColumnInfo.columnalign = 1;
                    gridColumnInfo.columnWidth = Convert.ToInt32(this.txtColumnWidth.Text.Trim());
                    gridColumnInfo.columncaption = this.txtCurColumn.Text.Trim();
                    //gridColumnInfo.columnStyle = Convert.ToInt32(((KeyValueObject)combStyle.SelectedItem).key);
                    gridColumnInfo.columndefaultValue = this.txtDefaultValue.Text.Trim();
                    if (rbtReadOnly.Checked == true)
                    { gridColumnInfo.columnalign = 1; }
                    else
                    { gridColumnInfo.columnalign = 2; }
                    if (chkSum.Checked)
                    {
                        gridColumnInfo.sum = 1;
                    }
                    else
                    {
                        gridColumnInfo.sum = 0;
                    }
                    FormProvoider.InsertGridColumn(controlID, indexColumn + 1, gridColumnInfo);
                    indexColumn += 1; 
                    _currentColumn = txtCurColumn.Text.Trim();
                    //((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).formDataCollection.Remove(controlID.ToString());
                    MessageBox.Show("添加成功！请绑定数据。");
                }
            }
            catch { }
        }
    }

    
}