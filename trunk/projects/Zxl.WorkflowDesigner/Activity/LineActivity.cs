using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;

namespace Zxl.WorkflowDesigner
{
    public class LineActivity : Activity
    {
        private BaseActivity _source;
        public BaseActivity Source
        {
            get { return _source; }
            set { _source = value; }
        }
        private BaseActivity _target;
        public BaseActivity Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public LineActivity(BaseActivity source, BaseActivity target)
        {
            _source = source;
            _target = target;
            _description = source.Description + "→" + target.Description;

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

            attr = lineElement.OwnerDocument.CreateAttribute("description");
            attr.Value = _description;
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
            DrawArrow(g, source, target);

            DrawHandle(g);
        }

        void DrawArrow(Graphics g, Point source, Point target)
        {
            double angle = 0;

            double x = (target.X - source.X);
            double y = (target.Y - source.Y);

            int x1 = 0;
            int y1 = 0;

            int halfWfActivityWidthOrHeight = ManualActivity.widthAndHeight / 2;

            if (x == 0 || y == 0)
            {
                // 垂直 x 或 y方向
                // 特殊处理以防止除0
                if (x == 0)
                {
                    if (y > 0)
                    {
                        angle = 90;
                        x1 = target.X;
                        y1 = target.Y - halfWfActivityWidthOrHeight;
                    }
                    else
                    {
                        angle = 270;
                        x1 = target.X;
                        y1 = target.Y + halfWfActivityWidthOrHeight;
                    }
                }
                else if (y == 0)
                {
                    if (x > 0)
                    {
                        angle = 0;
                        x1 = target.X - halfWfActivityWidthOrHeight;
                        y1 = target.Y;
                    }
                    else
                    {
                        angle = 180;
                        x1 = target.X + halfWfActivityWidthOrHeight;
                        y1 = target.Y;
                    }
                }
            }
            else
            {
                double xDIVy = x / y;
                double yDIVx = y / x;
                double c = Math.Atan(xDIVy);
                angle = -(c * 180 / Math.PI);
                angle += 90;
                double c1 = Math.Atan(yDIVx);
                if (xDIVy == 1)
                {
                    if (x > 0)
                    {
                        x1 = target.X - halfWfActivityWidthOrHeight;
                        y1 = target.Y - halfWfActivityWidthOrHeight;
                    }
                    else
                    {
                        angle += 180;
                        x1 = target.X + halfWfActivityWidthOrHeight;
                        y1 = target.Y + halfWfActivityWidthOrHeight;
                    }
                }
                else if (xDIVy == -1)
                {
                    if (x > 0)
                    {
                        angle += 180;
                        x1 = target.X - halfWfActivityWidthOrHeight;
                        y1 = target.Y + halfWfActivityWidthOrHeight;
                    }
                    else
                    {
                        x1 = target.X + halfWfActivityWidthOrHeight;
                        y1 = target.Y - halfWfActivityWidthOrHeight;
                    }
                }
                else if (xDIVy < -1)
                {
                    x1 = halfWfActivityWidthOrHeight;
                    y1 = (int)(x1 / Math.Tan(c));
                    if (x > 0)
                    {
                        angle += 180;
                        x1 = target.X - x1;
                    }
                    else
                    {
                        x1 = target.X + x1;
                    }

                    if (y > 0)
                    {
                        y1 = target.Y + y1;
                    }
                    else
                    {
                        y1 = target.Y - y1;
                    }
                }
                else if (xDIVy > 1)
                {
                    x1 = halfWfActivityWidthOrHeight;
                    y1 = (int)(x1 / Math.Tan(c));
                    if (x > 0)
                    {
                        x1 = target.X - x1;
                    }
                    else
                    {
                        angle += 180;
                        x1 = target.X + x1;
                    }

                    if (y > 0)
                    {
                        y1 = target.Y - y1;
                    }
                    else
                    {
                        y1 = target.Y + y1;
                    }
                }
                else if (xDIVy > -1 && xDIVy < 0)
                {
                    y1 = halfWfActivityWidthOrHeight;
                    x1 = (int)(y1 / Math.Tan(c1));
                    if (x > 0)
                    {
                        angle += 180;
                        x1 = target.X + x1;
                    }
                    else
                    {
                        x1 = target.X - x1;
                    }

                    if (y > 0)
                    {
                        y1 = target.Y - y1;
                    }
                    else
                    {
                        y1 = target.Y + y1;
                    }
                }
                else if (xDIVy < 1 && xDIVy > 0)
                {
                    y1 = halfWfActivityWidthOrHeight;
                    x1 = (int)(y1 / Math.Tan(c1));
                    if (x > 0)
                    {
                        x1 = target.X - x1;
                    }
                    else
                    {
                        angle += 180;
                        x1 = target.X + x1;
                    }

                    if (y > 0)
                    {
                        y1 = target.Y - y1;
                    }
                    else
                    {
                        y1 = target.Y + y1;
                    }
                }
            }
            ImageAttributes imAtt = new ImageAttributes();
            imAtt.SetColorKey(Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255));
            // 画箭头
            Bitmap arrowBitmap = Properties.Resources.arrow;

            int imgWidth = arrowBitmap.Width;
            int imgHeight = arrowBitmap.Height;

            Rectangle rcDest = new Rectangle();
            rcDest.X = -imgWidth / 2;
            rcDest.Y = -imgHeight / 2;
            rcDest.Width = imgWidth;
            rcDest.Height = imgWidth;

            GraphicsState gs = g.Save();

            g.TranslateTransform(x1, y1);
            g.RotateTransform((float)angle);

            g.DrawImage(arrowBitmap, rcDest,
                0, 0,
                imgWidth,
                imgWidth,
                GraphicsUnit.Pixel,
                imAtt);

            imAtt.Dispose();
            arrowBitmap.Dispose();

            g.Restore(gs);

        }

        void DrawHandle(Graphics g)
        {
            Color nodeColor;
            if (IsSelected)
            {
                nodeColor = Color.Red;
            }
            else
            {
                nodeColor = Color.Blue;
            }
            using (Brush brush = new SolidBrush(nodeColor))
            {
                g.FillEllipse(brush, _rect);
            }
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
