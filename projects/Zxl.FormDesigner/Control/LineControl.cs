using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;

namespace Zxl.FormDesigner
{
    public class LineControl : Control
    {
        private BaseControl _source;
        public BaseControl Source
        {
            get { return _source; }
            set { _source = value; }
        }
        private BaseControl _target;
        public BaseControl Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public LineControl(BaseControl source, BaseControl target)
        {
            _source = source;
            _target = target;
            //_description = source.Description + "→" + target.Description;

            _x = _target.X + (_source.X - _target.X) / 2;
            _y = _target.Y + (_source.Y - _target.Y) / 2;
            _rect = new Rectangle(_x - 4, _y - 4, 8, 8);
        }

        private Rectangle _rect;

        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
                _rect = new Rectangle(_x - 4, _y - 4, 8, 8);
            }
        }
        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                _rect = new Rectangle(_x - 4, _y - 4, 8, 8);
            }
        }

        public void CreateXml(XmlElement linesElement)
        {
            XmlElement lineElement = linesElement.OwnerDocument.CreateElement("line");

            XmlAttribute attr = lineElement.OwnerDocument.CreateAttribute("id");
            attr.Value = _id;
            lineElement.Attributes.Append(attr);

            attr = lineElement.OwnerDocument.CreateAttribute("value");
            attr.Value = _value;
            lineElement.Attributes.Append(attr);

            attr = lineElement.OwnerDocument.CreateAttribute("x");
            attr.Value = _x.ToString();
            lineElement.Attributes.Append(attr);

            attr = lineElement.OwnerDocument.CreateAttribute("y");
            attr.Value = _y.ToString();
            lineElement.Attributes.Append(attr);

            //source
            attr = lineElement.OwnerDocument.CreateAttribute("source");
            attr.Value = _source.ID;
            lineElement.Attributes.Append(attr);

            //target
            attr = lineElement.OwnerDocument.CreateAttribute("target");
            attr.Value = _target.ID;
            lineElement.Attributes.Append(attr);

            linesElement.AppendChild(lineElement);
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

        public override void Move(int offX, int offY)
        {
            _x += offX;
            _y += offY;
            _rect = new Rectangle(_x - 4, _y - 4, 8, 8);
        }

        public override void RangeSelect(Rectangle rect)
        {
            if (rect.Contains(_rect))
            {
                IsSelected = true;
            }
        }

        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(Color.Green))
            {
                g.DrawLine(p, Source.X, Source.Y, _x, _y);
                g.DrawLine(p, _x, _y, Target.X, Target.Y);
            }

            Point source = new Point(_x, _y);
            Point target = new Point(Target.X, Target.Y);
        }

        public override void AlignToGrid()
        {
            if (_x < 0)
            {
                _x = 0;
            }
            else if (_x >= 2000)
            {
                _x = 2000;
            }
            else
            {
                _x = AlignToNumber(_x, GridSize);
            }

            if (_y < 0)
            {
                _y = 0;
            }
            else if (_y >= 2000)
            {
                _y = 2000;
            }
            else
            {
                _y = AlignToNumber(_y, GridSize);
            }

            _rect = new Rectangle(_x - 4, _y - 4, 8, 8);
        }
    }
}
