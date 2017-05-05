using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zxl.Form.Sheet
{
    public class SheetTable
    {
        public List<RowPosition> RowPositionCollection { get; set; }
        public List<ColumnPosition> ColumnPositionCollection { get; set; }
        public List<SheetRow> SheetRows { get; set; }
    }
}
