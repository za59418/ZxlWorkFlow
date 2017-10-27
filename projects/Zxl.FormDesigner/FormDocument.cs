using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zxl.Business.Model;

namespace Zxl.FormDesigner
{
    public class HitTestResult
    {
        public Control.HitTestState state;
        public Control control;
    }

    public enum FormDirection
    {
        HORIZONTAL,
        VERTICAL
    }

    public class FormDocument
    {
        public FormDocument()
        {
            _controls = new List<Control>();
            _lines = new List<LineControl>();
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private FormDirection _direction;
        public FormDirection Direction
        {
            get {
                if (null == _direction)
                    _direction = FormDirection.VERTICAL;
                return _direction; 
            }
            set { _direction = value; }
        }

        public SYS_BUSINESSFORM CurrForm { get; set; }

        private IList<Control> _controls;
        public IList<Control> ControlList
        {
            get
            {
                return _controls;
            }
        }
        private IList<LineControl> _lines;
        public IList<LineControl> Lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
            }
        }

        public void OpenPropertyDialogAtPoint(int x, int y)
        {
            HitTestResult result = HitTest(x, y);
            if (result != null && result.state == Control.HitTestState.Center)
            {
                //result.control.CurrProcess = CurrProcess; // 在人工活动上要用，表单和角色都与它有关
                result.control.OpenPropertyDialog();
            }
            else
            {
            }
        }

        public HitTestResult HitTest(int x, int y)
        {
            foreach (Control control in _controls)
            {
                Control.HitTestState state = control.HitTest(x, y);
                if (Control.HitTestState.None != state)
                {
                    HitTestResult result = new HitTestResult();
                    result.state = state;
                    result.control = control;
                    return result;
                }
            }
            return null;
        }
        public void ResetSelected()
        {
            foreach (Control control in _controls)
            {
                control.IsSelected = false;
            }
        }

        public IList<Control> DeleteSelected()
        {
            IList<Control> result = new List<Control>();
            foreach (Control control in ControlList)
            {
                if (control.IsSelected)
                {
                    result.Add(control);
                }
                else
                {
                    if (control is LineControl)
                    {
                        LineControl line = control as LineControl;
                        //if (line.Source.IsSelected || line.Target.IsSelected)
                        //    result.Add(control);
                    }
                }
            }
            foreach (Control control in result)
            {
                ControlList.Remove(control);
            }
            return result;
        }

        public void MoveSelected(int offX, int offY)
        {
            foreach (Control control in _controls)
            {
                if (control.IsSelected)
                    control.Move(offX, offY);
            }
        }

        public void CreateXml(XmlElement xmlElement)
        {
            XmlElement processElement = xmlElement.OwnerDocument.CreateElement("process");

            XmlAttribute attr = xmlElement.OwnerDocument.CreateAttribute("id");
            attr.Value = _id;
            processElement.Attributes.Append(attr);

            attr = xmlElement.OwnerDocument.CreateAttribute("description");
            attr.Value = _description;
            processElement.Attributes.Append(attr);

            XmlElement actsElement = processElement.OwnerDocument.CreateElement("activities");
            processElement.AppendChild(actsElement);
            foreach (Control control in _controls)
            {
                if (!(control is LineControl))
                {
                    BaseControl act = control as BaseControl;
                    act.CreateXml(actsElement);
                }
            }
            XmlElement linesElement = processElement.OwnerDocument.CreateElement("lines");
            processElement.AppendChild(linesElement);
            foreach (Control control in _controls)
            {
                if (control is LineControl)
                {
                    LineControl line = control as LineControl;
                    line.CreateXml(linesElement);
                }
            }
            xmlElement.AppendChild(processElement);
        }
    }
}
