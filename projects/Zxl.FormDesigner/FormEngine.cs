using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zxl.Business.Model;

namespace Zxl.FormDesigner
{
    public enum ControlType
    {
        LABEL,
        BUTTON,
        COMBOBOX,
        TEXTBOX,
        DATETIMEPICKER,
        CHECKBOX,
        RADIOBUTTON,
        SELECT,
        LINE
    }
    public class FormEngine
    {
        public FormEngine()
        {
            if (null == document)
                document = new FormDocument();
        }

        private FormDocument document;
        public FormDocument Document
        {
            get
            {
                return document;
            }
            set
            {
                document = value;
            }
        }

        private XmlElement _layout;
        public XmlElement Layout
        {
            get { return _layout; }
            set { _layout = value; }
        }

        public void CreateProcess()
        {
            XmlNodeList controlNodes = _layout.SelectNodes("process/controls/control");
            List<BaseControl> controls = new List<BaseControl>();
            foreach (XmlNode controlNode in controlNodes)
            {
                BaseControl control = null;
                string type = controlNode.Attributes["type"].Value;
                int x = Convert.ToInt32(controlNode.Attributes["x"].Value);
                int y = Convert.ToInt32(controlNode.Attributes["y"].Value);
                decimal time = 0;
                if (null != controlNode.Attributes["time"])
                    time = Convert.ToDecimal(controlNode.Attributes["time"].Value);
                switch (type)
                {

                    case "1":

                        break;
                    case "2":
                        control = new TextBoxControl(x, y, 80, 20);

                        break;
                    default:
                        break;
                }

                if (control != null)
                {
                    control.ID = controlNode.Attributes["id"].Value;
                    control.Value = controlNode.Attributes["value"].Value;
                    control.X = x;
                    control.Y = y;
                    document.ControlList.Add(control);
                    controls.Add(control);
                }
            }
            XmlNodeList lineNodes = _layout.SelectNodes("process/lines/line");
            foreach (XmlNode lineNode in lineNodes)
            {
                int x = Convert.ToInt32(lineNode.Attributes["x"].Value);
                int y = Convert.ToInt32(lineNode.Attributes["y"].Value);
                string sourceId = lineNode.Attributes["source"].Value;
                string targetId = lineNode.Attributes["target"].Value;
                BaseControl source = null;
                BaseControl target = null;
                foreach (BaseControl act in controls)
                {
                    if (act.ID == sourceId)
                    {
                        source = act;
                        continue;
                    }
                    if (act.ID == targetId)
                    {
                        target = act;
                        continue;
                    }
                }

                //LineControl control = new LineControl(source, target);
                //if (control != null)
                //{
                //    control.ID = lineNode.Attributes["id"].Value;
                //    control.Value = lineNode.Attributes["value"].Value;
                //    control.X = x;
                //    control.Y = y;
                //    document.Lines.Add(control);
                //    document.ControlList.Add(control);
                //}
            }
        }

        public Tool SetCurrentTool(ControlType type)
        {
            Tool tool = null;
            switch (type)
            {
                case ControlType.LABEL:
                    tool = new LabelControlTool();
                    break;
                case ControlType.BUTTON:
                    tool = new ButtonControlTool();
                    break;
                case ControlType.COMBOBOX:
                    tool = new ComboBoxControlTool();
                    break;
                case ControlType.TEXTBOX:
                    tool = new TextBoxControlTool();
                    break;
                case ControlType.CHECKBOX:
                    tool = new CheckBoxControlTool();
                    break;
                case ControlType.RADIOBUTTON:
                    tool = new RadioButtonControlTool();
                    break;
                case ControlType.SELECT:
                    tool = new SelectorTool();
                    break;
                case ControlType.LINE:
                    tool = new LineControlTool();
                    break;
            }
            return tool;
        }
    }
}
