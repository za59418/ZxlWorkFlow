using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public class CheckBoxActivityTool : BaseTool
    {
        protected override BaseActivity CreateActivity(int x, int y)
        {
            return new CheckBoxActivity(x, y, 80, 20);
        }

    }
}
