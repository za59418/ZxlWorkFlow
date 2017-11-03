using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zxl.FormDesigner
{
    public partial class MyControl : Control
    {
        public MyControl()
        {
            InitializeComponent();
            Rect = new Rectangle(0, 0, 100, 20);
        }

        Rectangle Rect;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = this.CreateGraphics();
            //Rect = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);


            //外框
            Color color = Color.Gray;
            Brush brush = new SolidBrush(color);
            Pen p = new Pen(brush, 1);
            g.DrawRectangle(p, Rect);

            //背景
            Color color2 = Color.LightGray;
            Brush brush2 = new SolidBrush(color2);
            g.FillRectangle(brush2, Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

            //值
            Font font = new Font("宋体", 10);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, font, brush, Rect.X + Rect.Width / 2, Rect.Y + Rect.Height / 2, format);

        }
    }
}
