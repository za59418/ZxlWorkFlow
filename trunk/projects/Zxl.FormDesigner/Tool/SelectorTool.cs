using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.FormDesigner
{
    public class SelectorTool : Tool
    {
        enum State
        {
            None,
            Drag,
            Select,
            RangeSelect
        }

        private int startMouseX;
        private int startMouseY;
        private int endMouseX;
        private int endMouseY;
        private void SetEndMousePosition(int x, int y)
        {
            endMouseX = x;
            endMouseY = y;
        }

        State _state = State.None;
        public override void OnMouseDown(int x, int y)
        {
            HitTestResult result = Ctrl.Document.HitTest(x, y);
            if (null == result)
            {
                Ctrl.Document.ResetSelected();
                Ctrl.RedrawAll();
                _state = State.RangeSelect;
            }
            else if (result.state == Activity.HitTestState.Center)
            {
                if (!result.activity.IsSelected)
                {
                    //if (_state != State.Select)
                    //{
                        Ctrl.Document.ResetSelected();
                    //}
                        result.activity.IsSelected = true;
                    Ctrl.RedrawAll();
                }
                _state = State.Select;
            }

            SetEndMousePosition(x, y);
            startMouseX = x;
            startMouseY = y;
        }
        public override void OnMouseMove(int x, int y)
        {
            if (_state == State.Select)
            {
                if (endMouseX != x && endMouseY != y)
                {
                    _state = State.Drag;
                    SetEndMousePosition(x, y);
                }
            }
            if (_state == State.Drag)
            {
                Ctrl.Document.MoveSelected(x - endMouseX, y - endMouseY);
                Ctrl.RedrawAll();
                SetEndMousePosition(x, y);
            }
        }
        public override void OnMouseUp(int x, int y)
        {
            if (_state == State.Drag)
            {
                Ctrl.RedrawAll();
            }
        }
    }
}
