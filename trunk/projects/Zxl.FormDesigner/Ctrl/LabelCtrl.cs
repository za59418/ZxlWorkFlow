using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zxl.FormDesigner
{
    public class LabelCtrl : BaseCtrl
    {
        public LabelCtrl(int x, int y) : base(x, y) { }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            //外框
            Color color = Color.Black;
            Brush brush = new SolidBrush(color);

            //值
            Font font = new Font("宋体", 10);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, font, brush, Rect.X, Rect.Y + Rect.Height / 2, format);
        }
    }
}
