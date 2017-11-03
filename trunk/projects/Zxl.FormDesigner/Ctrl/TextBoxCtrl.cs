using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zxl.FormDesigner
{
    public class TextBoxCtrl : BaseCtrl
    {
        public TextBoxCtrl(int x, int y) : base(x, y) { }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            //外框
            Color color = Color.Gray;
            Brush brush = new SolidBrush(color);
            Pen p = new Pen(brush, 1);
            g.DrawRectangle(p, Rect.X, Rect.Y, Rect.Width - 1, Rect.Height - 1);

            //值
            Font font = new Font("宋体", 10);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, font, brush, Rect.X, Rect.Y + Rect.Height / 2, format);

        }
    }
}
