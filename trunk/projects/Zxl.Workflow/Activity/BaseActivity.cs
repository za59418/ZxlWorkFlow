using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;

namespace Zxl.Workflow
{
    public abstract class BaseActivity : Activity
    {
        public const int widthAndHeight = 40;

        public BaseActivity(int x, int y)
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
            _description = "";
            _x = x;
            _y = y;
            _rect = new Rectangle(_x - widthAndHeight / 2, _y - widthAndHeight / 2, widthAndHeight, widthAndHeight);
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
                _rect = new Rectangle(_x - widthAndHeight / 2, _y - widthAndHeight / 2, widthAndHeight, widthAndHeight);
            }
        }
        protected int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                this._y = value;
                _rect = new Rectangle(_x - widthAndHeight / 2, _y - widthAndHeight / 2, widthAndHeight, widthAndHeight);
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

        protected abstract void DrawIcon(Graphics g);
        public override void Draw(Graphics g)
        {
            DrawIcon(g);
            Color color = Color.Black;

            Font font = new Font("新宋体", 9);
            Brush brush = new SolidBrush(color);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Near;
            g.DrawString(_description, font, brush, new PointF(_x, _y + widthAndHeight / 2 + 5), format);
            format.Dispose();
            font.Dispose();
            brush.Dispose();
        }
        public override void Move(int offX, int offY)
        {
            _x += offX;
            _y += offY;
            _rect = new Rectangle(_x - widthAndHeight / 2, _y - widthAndHeight / 2, widthAndHeight, widthAndHeight);
        }

        abstract public String GetActivityType();

        virtual public void CreateXml(XmlElement activitiesElement)
        {
            XmlElement activityElement = activitiesElement.OwnerDocument.CreateElement("activity");

            XmlAttribute attr = activityElement.OwnerDocument.CreateAttribute("id");
            attr.Value = _id;
            activityElement.Attributes.Append(attr);

            attr = activityElement.OwnerDocument.CreateAttribute("description");
            attr.Value = _description;
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
