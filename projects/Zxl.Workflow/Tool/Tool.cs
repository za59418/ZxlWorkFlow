using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.Workflow
{
    public abstract class Tool
    {
        virtual public void OnMouseDown(int x, int y) { }
        virtual public void OnMouseUp(int x, int y) { }
        virtual public void OnMouseMove(int x, int y) { }
        virtual public void AfterActivityCreate() { }

        private WorkflowControl _ctrl;
        public WorkflowControl Ctrl
        {
            get { return _ctrl; }
            set { _ctrl = value; }
        }
    }
}
