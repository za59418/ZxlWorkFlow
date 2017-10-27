using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace Zxl.FormDesigner
{
    public abstract class BaseControl : Control
    {
        public BaseControl(int x, int y, int width, int height)
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
            _value = "";
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _rect = new Rectangle(_x, _y, _width, _height);
        }

        protected Rectangle _rect;
        public Rectangle Rect
        {
            get { return _rect; }
            set { this._rect = value; }
        }
        protected int _x;
        public int X
        {
            get { return _x; }
            set
            {
                this._x = value;
                _rect = new Rectangle(_x, _y, _width, _height);
            }
        }
        protected int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                this._y = value;
                _rect = new Rectangle(_x, _y, _width, _height);
            }
        }

        protected int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                this._width = value;
                _rect = new Rectangle(_x, _y, _width, _height);
            }
        }

        protected int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                this._height = value;
                _rect = new Rectangle(_x, _y, _width, _height);
            }
        }


        public override HitTestState HitTest(int x, int y)
        {
            if (_rect.Contains(x, y))
            {
                return HitTestState.Center;
            }
            else
            {
                return HitTestState.None;
            }
        }

        public override Rectangle GetRange()
        {
            return _rect;
        }

        public override void Draw(Graphics g)
        {
            if (IsSelected)
            {
                Pen selectPen = new Pen(Color.SlateGray);
                selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawRectangle(selectPen, Rect.X - 1, Rect.Y - 1, Rect.Width + 2, Rect.Height + 2);
                g.DrawRectangle(selectPen, Rect.X - 2, Rect.Y - 2, Rect.Width + 4, Rect.Height + 4);

                selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                g.DrawRectangle(selectPen, Rect.X - 4, Rect.Y - 4, 4, 4);
                g.DrawRectangle(selectPen, Rect.X + Rect.Width, Rect.Y - 4, 4, 4);
                g.DrawRectangle(selectPen, Rect.X - 4, Rect.Y + Rect.Height, 4, 4);
                g.DrawRectangle(selectPen, Rect.X + Rect.Width, Rect.Y + Rect.Height, 4, 4);

                g.DrawRectangle(selectPen, Rect.X + Rect.Width / 2 - 2, Rect.Y - 4, 4, 4);
                g.DrawRectangle(selectPen, Rect.X + Rect.Width / 2 - 2, Rect.Y + Rect.Height, 4, 4);
                g.DrawRectangle(selectPen, Rect.X - 4, Rect.Y + Rect.Height / 2 - 2, 4, 4);
                g.DrawRectangle(selectPen, Rect.X + Rect.Width, Rect.Y + Rect.Height / 2 - 2, 4, 4);
            }
        }

        public override void Move(int offX, int offY)
        {
            _x += offX;
            _y += offY;
            _rect = new Rectangle(_x, _y, _width, _height);
        }

        abstract public String GetControlType();

        virtual public void CreateXml(XmlElement activitiesElement)
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
