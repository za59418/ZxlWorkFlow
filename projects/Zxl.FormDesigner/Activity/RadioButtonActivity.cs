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
    public class RadioButtonActivity : BaseActivity
    {
        public RadioButtonActivity(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            Value = "RadioButton";

            MyCtrl = new RadioButton();
            MyCtrl.Width = Width;
            MyCtrl.Height = Height;
            MyCtrl.Location = new Point(X, Y);
            MyCtrl.Text = "RadioButton";
        }

        public override void Draw(Graphics g)
        {

        }

        override public void OpenPropertyDialog()
        {

        }

        public override string GetActivityType()
        {
            return "RadioButton";
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
