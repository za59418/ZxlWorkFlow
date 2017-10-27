using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public class TextBoxControlTool : BaseTool
    {
        protected override BaseControl CreateControl(int x, int y)
        {
            return new TextBoxControl(x, y, 80, 20);
        }

    }
}
