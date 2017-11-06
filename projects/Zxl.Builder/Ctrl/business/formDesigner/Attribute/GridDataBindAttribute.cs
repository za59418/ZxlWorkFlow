using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class GridDataBindAttribute : DataBindAttribute
    {
        #region Variables
        //private string id;
        private string CtrlValue;
        private List<GridColumnAttribute> columnList=new List<GridColumnAttribute>();
        #endregion

        #region Constructors
        public GridDataBindAttribute(string controlId)
        {
            id = controlId;
        }
        #endregion

        #region Properties
        public string Value
        {
            get
            { return CtrlValue; }
            set
            { CtrlValue = value; }
        }

        public string Id
        {
            get { return id; }
        }

        

        public List<GridColumnAttribute> ColumnList
        {
            get
            {
                return columnList;
            }
        }
        #endregion

        #region Methods
        public void AddColumn(GridColumnAttribute column)
        {
            if (columnList.IndexOf(column) == -1)
            {
                columnList.Add(column);
            }
        }

        public void RemoveColumn(GridColumnAttribute column)
        {
            if (columnList.IndexOf(column) > -1)
            {
                columnList.Remove(column);
            }
        }

        public void RemoveAllColumn()
        {
            columnList.Clear();
        }

        private string _value;
        public GridColumnAttribute FindGridColumnAttribute(string value)
        {
            _value = value;
            return columnList.Find(GridColumnItem);
        }

        private bool GridColumnItem(GridColumnAttribute gridColumnAttribute)
        {            
            if (gridColumnAttribute.Value == _value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
