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
    public class ComboBoxControl : BaseControl
    {
        public ComboBoxControl(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            Value = "ComboBox";
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            //外框
            Color color = Color.Gray;
            Brush brush = new SolidBrush(color);
            Pen p = new Pen(brush, 1);
            g.DrawRectangle(p, Rect);

            g.DrawImage(Properties.Resources.combo, Rect.X + Rect.Width - Properties.Resources.combo.Width, Y + (Rect.Height - Properties.Resources.combo.Height) / 2);
        }

        override public void OpenPropertyDialog()
        {

        }

        public override string GetControlType()
        {
            return "ComboBox";
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
