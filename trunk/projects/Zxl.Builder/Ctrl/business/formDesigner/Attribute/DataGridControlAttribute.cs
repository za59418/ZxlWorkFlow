using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class DataGridControlAttribute : GeneralAttribute
    {
        private List<Column> columns = new List<Column>();
        public List<Column> Columns
        {
            get { return columns; }
        }

        public void AddColumn(Column column)
        {
            if (columns.IndexOf(column) == -1)
            {
                columns.Add(column);
            }
        }
    }

    public class Column
    {
        private string sum;
        public string Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string width;

        public string Width
        {
            get { return width; }
            set { width = value; }
        }

        private string input;

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        private string Default;

        public string DefaultValue
        {
            get { return Default; }
            set { Default = value; }
        }

        private string readOnly;

        public string ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }
    }
}
