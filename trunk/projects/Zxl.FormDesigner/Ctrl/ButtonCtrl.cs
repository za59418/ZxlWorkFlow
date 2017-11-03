using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zxl.FormDesigner
{
    public class ButtonCtrl : BaseCtrl
    {
        public ButtonCtrl(int x, int y) : base(x, y) { }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            //外框
            Color color = Color.Gray;
            Brush brush = new SolidBrush(color);
            Pen p = new Pen(brush, 1);
            g.DrawRectangle(p, Rect.X, Rect.Y, Rect.Width - 1, Rect.Height - 1);

            //背景
            Color color2 = Color.LightGray;
            Brush brush2 = new SolidBrush(color2);
            g.FillRectangle(brush2, Rect.X + 1, Rect.Y + 1, Rect.Width - 2, Rect.Height - 2);

            //值
            Font font = new Font("宋体", 10);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, font, brush, Rect.X + Rect.Width / 2, Rect.Y + Rect.Height / 2, format);
        }
    }
}
