using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zxl.FormDesigner
{
    public class BaseCtrl : Control
    {
        public Rectangle Rect;// = new Rectangle(0, 0, 100, 20);
        public bool Selected { get; set; }

        public BaseCtrl(int x, int y)
        {
            base.Left = x;
            base.Top = y;
            base.Width = 120;
            base.Height = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Selected)
            {
                Graphics g = e.Graphics;
                Pen selectPen = new Pen(Color.RoyalBlue);

                //虚线
                selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawRectangle(selectPen, Rect.X, Rect.Y, Rect.Width - 1, Rect.Height - 1);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Rect.Width = base.Width + 4;
            Rect.Height = base.Height + 4;
            base.Refresh();
        }
    }
}
