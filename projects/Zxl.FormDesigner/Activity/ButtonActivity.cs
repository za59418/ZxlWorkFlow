using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Zxl.Business.Model;
using Zxl.Business.Interface;
using Zxl.Business.Impl;

namespace Zxl.FormDesigner
{
    public class ButtonActivity : BaseActivity
    {
        public ButtonActivity(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            Value = "Button";
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            //外框
            Color color = Color.Black;
            Brush brush = new SolidBrush(color);
            Pen p = new Pen(brush, 1);
            g.DrawRectangle(p, Rect);

            //背景
            Color color2 = Color.LightGray;
            Brush brush2 = new SolidBrush(color2);
            g.FillRectangle(brush2, Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);

            //值
            Font font = new Font("黑体", 10);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(Value, font, brush, Rect.X + Rect.Width/2, Rect.Y+Rect.Height/2, format);
        }

        override public void OpenPropertyDialog()
        {

        }

        public override string GetActivityType()
        {
            return "Button";
        }

        public override void CreateXml(XmlElement activitiesElement)
        {
            XmlElement activityElement = activitiesElement.OwnerDocument.CreateElement("activity");

            XmlAttribute attr = activityElement.OwnerDocument.CreateAttribute("id");
            attr.Value = _id;
            activityElement.Attributes.Append(attr);
            attr = activityElement.OwnerDocument.CreateAttribute("value");
            attr.Value = _value;
            activityElement.Attributes.Append(attr);
            attr = activityElement.OwnerDocument.CreateAttribute("x");
            attr.Value = _x.ToString();
            activityElement.Attributes.Append(attr);

            attr = activityElement.OwnerDocument.CreateAttribute("y");
            attr.Value = _y.ToString();
            activityElement.Attributes.Append(attr);
            //type
            attr = activityElement.OwnerDocument.CreateAttribute("type");
            attr.Value = GetActivityType();
            activityElement.Attributes.Append(attr);
            activitiesElement.AppendChild(activityElement);
        }
    }
}
