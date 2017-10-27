using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public abstract class BaseTool : Tool
    {
        public override void AfterControlCreate()
        {
            Ctrl.CurrentTool = new SelectorTool();
        }

        protected abstract BaseControl CreateControl(int x, int y);

        public override void OnMouseDown(int x, int y)
        {
            BaseControl control = CreateControl(x, y);
            Ctrl.Document.ControlList.Add(control);
            Ctrl.RedrawAll();
            AfterControlCreate();
        }
    }
}
