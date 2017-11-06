using System;
using System.Collections.Generic;
using System.Text;

namespace FormDesigner.Attribute
{
    public class RadioButtonListAttribute : GeneralAttribute
    {
        private int _rows ;
        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        private int _columns ;
        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        private int _columnInterWidth;
        public int ColumnInterWidth
        {
            get { return _columnInterWidth; }
            set { _columnInterWidth = value; }
        }

        private string _text;
        public string RadioButtonListText
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }
    }
}
