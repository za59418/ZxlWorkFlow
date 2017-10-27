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
    public class LabelControl : BaseControl
    {
        public LabelControl(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            Value = "Label";
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            //外框
            Color color = Color.Black;
            Brush brush = new SolidBrush(color);

            //值
            Font font = new Font("宋体", 10);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            g.DrawString(Value, font, brush, Rect.X, Rect.Y + Rect.Height / 2, format);
        }

        override public void OpenPropertyDialog()
        {

        }

        public override string GetControlType()
        {
            return "Label";
        }

        public override void CreateXml(XmlElement activitiesElement)
        {
            XmlElement controlElement = activitiesElement.OwnerDocument.CreateElement("control");

            XmlAttribute attr = controlElement.OwnerDocument.CreateAttribute("id");
            attr.Value = _id;
            controlElement.Attributes.Append(attr);
            attr = controlElement.OwnerDocument.CreateAttribute("value");
            attr.Value = _value;
            controlElement.Attributes.Append(attr);
            attr = controlElement.OwnerDocument.CreateAttribute("x");
            attr.Value = _x.ToString();
            controlElement.Attributes.Append(attr);

            attr = controlElement.OwnerDocument.CreateAttribute("y");
            attr.Value = _y.ToString();
            controlElement.Attributes.Append(attr);
            //type
            attr = controlElement.OwnerDocument.CreateAttribute("type");
            attr.Value = GetControlType();
            controlElement.Attributes.Append(attr);
            activitiesElement.AppendChild(controlElement);
        }
    }
}
