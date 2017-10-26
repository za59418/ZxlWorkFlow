using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public class ButtonActivityTool : BaseTool
    {
        protected override BaseActivity CreateActivity(int x, int y)
        {
            return new ButtonActivity(x, y, 80, 20);
        }

    }
}
