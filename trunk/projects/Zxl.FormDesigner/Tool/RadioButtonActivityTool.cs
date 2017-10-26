using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public class RadioButtonActivityTool : BaseTool
    {
        protected override BaseActivity CreateActivity(int x, int y)
        {
            return new RadioButtonActivity(x, y, 80, 20);
        }

    }
}
