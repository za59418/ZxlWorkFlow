using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zxl.FormDesigner
{
    public class LineControlTool : Tool
    {
        private BaseControl startControl;
        private int startMouseX;
        private int startMouseY;
        private int endMouseX;
        private int endMouseY;

        private void setEndMousePosition(int x, int y)
        {
            endMouseX = x;
            endMouseY = y;
        }

        public override void OnMouseDown(int x, int y)
        {
            HitTestResult start = Ctrl.Document.HitTest(x, y);

            //if (null == start || !(start.control is BaseControl))
            //{
            //    MessageBox.Show("必须从活动开始！");
            //    Ctrl.CurrentTool = new SelectorTool();
            //}

            //else
            //{
            //    startControl = start.control as BaseControl;
                startMouseX = x;
                startMouseY = y;
                setEndMousePosition(x, y);
            //}
        }

        Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        public override void OnMouseMove(int x, int y)
        {
            if (x == startMouseX || y == startMouseY)
            {
                //在屏幕上画线
                Point scrollOffset = Ctrl.ScrollOffset;
                Point startPoint = Ctrl.PointToScreen(new Point(startMouseX - scrollOffset.X + 20, startMouseY - scrollOffset.Y + 20));
                ControlPaint.DrawReversibleLine(startPoint, Ctrl.PointToScreen(new Point(endMouseX - scrollOffset.X + 20, endMouseY - scrollOffset.Y + 20)), Color.Black);
                Point endPoint = Ctrl.PointToScreen(new Point(x - scrollOffset.X + 20, y - scrollOffset.Y + 20));

                ControlPaint.DrawReversibleLine(startPoint, endPoint, Color.Black);
            }
            else
            {
                //擦除
                ControlPaint.DrawReversibleFrame(theRectangle, Color.Black, FrameStyle.Dashed);

                //在屏幕上画虚线框
                Point scrollOffset = Ctrl.ScrollOffset;
                Point startPoint = Ctrl.PointToScreen(new Point(startMouseX - scrollOffset.X + 20, startMouseY - scrollOffset.Y + 20));
                Point endPoint = Ctrl.PointToScreen(new Point(x - scrollOffset.X + 20, y - scrollOffset.Y + 20));
                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                theRectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);
                ControlPaint.DrawReversibleFrame(theRectangle, Color.Black, FrameStyle.Dashed);
            }

            setEndMousePosition(x, y);
        }

        public override void OnMouseUp(int x, int y)
        {
            Point scrollOffset = Ctrl.ScrollOffset;
            Point startPoint = Ctrl.PointToScreen(new Point(startMouseX - scrollOffset.X + 20, startMouseY - scrollOffset.Y + 20));
            ControlPaint.DrawReversibleLine(startPoint, Ctrl.PointToScreen(new Point(endMouseX - scrollOffset.X + 20, endMouseY - scrollOffset.Y + 20)), Color.Black);

            HitTestResult end = Ctrl.Document.HitTest(x, y);
            //if ((end == null) || (!(end.control is BaseControl)))
            //{
            //    MessageBox.Show("流向没有结束在节点上");
            //}

            //else
            //{
            Point sPoint = new Point(startMouseX - scrollOffset.X, startMouseY - scrollOffset.Y);
            Point ePoint = new Point(endMouseX - scrollOffset.X, endMouseY - scrollOffset.Y);
            LineControl line = new LineControl(sPoint, ePoint);
            line.AlignToGrid();
            this.Ctrl.Document.ControlList.Add(line);
            this.Ctrl.Document.Lines.Add(line);
            //}
            Ctrl.RedrawAll();
            Ctrl.CurrentTool = new SelectorTool();
        }

    }
}
