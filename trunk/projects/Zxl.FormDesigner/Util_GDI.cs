using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zxl.FormDesigner
{
    enum buttonStyle
    {
        /// <summary>
        /// 正常为选中按钮
        /// </summary>
        ButtonNormal,
        /// <summary>
        /// 获得焦点的按钮
        /// </summary>
        ButtonFocuse,
        /// <summary>
        /// 鼠标经过样式
        /// </summary>
        ButtonMouseOver,
        /// <summary>
        /// 获得焦点并鼠标经过
        /// </summary>
        ButtonFocuseAndMouseOver
    }

    class Util_GDI
    {
        /// <summary>
        /// 绘制圆形按钮（用法同矩形按钮）
        /// </summary>
        /// <param name="text"></param>
        /// <param name="g"></param>
        /// <param name="Location"></param>
        /// <param name="r"></param>
        /// <param name="btnStyle"></param>
        public static void DrawCircleButton(string text, Graphics g, Point Location, int r, buttonStyle btnStyle)
        {
            Graphics Gcircle = g;
            Rectangle rect = new Rectangle(Location.X, Location.Y, r, r);
            Pen p = new Pen(new SolidBrush(Color.Black));
            Gcircle.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Gcircle.DrawEllipse(p, rect);
            if (btnStyle == buttonStyle.ButtonFocuse)
            {
                Gcircle.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#338FCC")), rect);
            }
            else if (btnStyle == buttonStyle.ButtonMouseOver)
            {
                Gcircle.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#EAC100")), rect);
            }
            else if (btnStyle == buttonStyle.ButtonFocuseAndMouseOver)
            {
                Gcircle.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#EAC100")), rect);
            }
            
            p.DashStyle = DashStyle.Dash;
            if (btnStyle != buttonStyle.ButtonNormal)
            {
                
                Gcircle.DrawEllipse(p, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4));//虚线框
            }
            Gcircle.FillEllipse(new SolidBrush(Color.WhiteSmoke), new Rectangle(rect.X + 3, rect.Y + 3, rect.Width - 6, rect.Height - 6));
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Gcircle.DrawString(text, new Font(new FontFamily("宋体"), 10), new SolidBrush(Color.Black), rect, sf);
            p.Dispose();
        }
        /// <summary> 
        /// 绘制圆角按钮
        /// </summary> 
        /// <param name="Text">要绘制的文字</param>
        /// <param name="g">Graphics 对象</param> 
        /// <param name="rect">要填充的矩形</param> 
        /// <param name="btnStyle"></param>
        public static void DrawRoundButton(string Text, Graphics g, Rectangle rect,buttonStyle btnStyle)
        {
            //g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;//消除锯齿
            Rectangle rectangle = rect;
            Brush b = b = new SolidBrush(Color.Black); 
            if (btnStyle == buttonStyle.ButtonFocuse)
            {
                b = new SolidBrush(ColorTranslator.FromHtml("#338FCC"));
            }
            else if (btnStyle == buttonStyle.ButtonMouseOver)
            {
                b = new SolidBrush(ColorTranslator.FromHtml("#C6A300"));
            }
            else if (btnStyle == buttonStyle.ButtonFocuseAndMouseOver)
            {
                b = new SolidBrush(ColorTranslator.FromHtml("#C6A300"));
            }
            g.DrawPath(new Pen(b),GetRoundRectangle(rectangle, 2));
            rectangle = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);
            Pen p=new Pen(Color.Black,0.5f);
            p.DashStyle = DashStyle.Dash;
            if (btnStyle == buttonStyle.ButtonFocuse || btnStyle == buttonStyle.ButtonFocuseAndMouseOver)
            {
                g.DrawRectangle(p,rectangle);//虚线框
            }
            g.FillRectangle(new SolidBrush(Color.WhiteSmoke),rectangle);//白色背景
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(Text, new Font("宋体", 10), new SolidBrush(Color.Black), rectangle, sf);
            p.Dispose();
            b.Dispose();
            g.SmoothingMode = SmoothingMode.Default;
        }
 
       /// <summary> 
        /// 根据普通矩形得到圆角矩形的路径 
        /// </summary> 
        /// <param name="rectangle">原始矩形</param> 
        /// <param name="r">半径</param> 
        /// <returns>图形路径</returns> 
        private static GraphicsPath GetRoundRectangle(Rectangle rectangle, int r)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中  
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

            gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
            gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

            gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

            gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
            gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);
            return gp;
        }

    }
}
