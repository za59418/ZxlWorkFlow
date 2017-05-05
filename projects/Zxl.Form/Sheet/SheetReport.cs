using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zxl.Form.Sheet
{
    public class SheetReport
    {
        public string Orientation { get; set; }
        public string PaperWidthWithTwipsUnit { get; set; }
        public string PaperHeightWithTwipsUnit { get; set; }
        public string BottomMargin { get; set; }
        public string LeftMargin { get; set; }
        public string RightMargin { get; set; }
        public string TopMargin { get; set; }
        public List<SheetPage> SheetPages { get; set; }
    }
}
