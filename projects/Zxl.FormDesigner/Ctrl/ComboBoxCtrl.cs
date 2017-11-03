using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zxl.FormDesigner
{
    public class ComboBoxCtrl : BaseCtrl
    {
        public ComboBoxCtrl(int x, int y) : base(x, y) { }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            //外框
            Color color = Color.Gray;
            Brush brush = new SolidBrush(color);
            Pen p = new Pen(brush, 1);
            g.DrawRectangle(p, Rect.X, Rect.Y, Rect.Width - 1, Rect.Height - 1);

            g.DrawImage(Properties.Resources.combo, Rect.X + Rect.Width - Properties.Resources.combo.Width - 2, Rect.Y + (Rect.Height - Properties.Resources.combo.Height) / 2);
        }
    }
}
