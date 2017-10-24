using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.WorkflowDesigner
{
    public abstract class BaseTool : Tool
    {
        public override void AfterActivityCreate()
        {
            Ctrl.CurrentTool = new SelectorTool();
        }

        protected abstract BaseActivity CreateActivity(int x, int y);

        public override void OnMouseDown(int x, int y)
        {
            BaseActivity activity = CreateActivity(x, y);
            Ctrl.Document.ActivityList.Add(activity);
            Ctrl.RedrawAll();
            AfterActivityCreate();
        }
    }
}
