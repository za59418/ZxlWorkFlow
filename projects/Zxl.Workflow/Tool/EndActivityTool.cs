using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.Workflow
{
    public class EndActivityTool : BaseTool
    {
        protected override BaseActivity CreateActivity(int x, int y)
        {
            return new EndActivity(x, y);
        }
    }
}
