using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public class RadioButtonControlTool : BaseTool
    {
        protected override BaseControl CreateControl(int x, int y)
        {
            return new RadioButtonControl(x, y, 80, 20);
        }

    }
}
