using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.WorkflowDesigner
{
    public class ManualActivityTool : BaseTool
    {
        protected override BaseActivity CreateActivity(int x, int y)
        {
            return new ManualActivity(x, y);
        }

    }
}
