using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Zxl.Business.Model;

namespace Zxl.FormDesigner
{
    public enum ActivityType
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
            XmlNodeList activityNodes = _layout.SelectNodes("process/activities/activity");
            List<BaseActivity> activities = new List<BaseActivity>();
            foreach (XmlNode activityNode in activityNodes)
            {
                BaseActivity activity = null;
                string type = activityNode.Attributes["type"].Value;
                int x = Convert.ToInt32(activityNode.Attributes["x"].Value);
                int y = Convert.ToInt32(activityNode.Attributes["y"].Value);
                decimal time = 0;
                if (null != activityNode.Attributes["time"])
                    time = Convert.ToDecimal(activityNode.Attributes["time"].Value);
                switch (type)
                {
                    //case "0":
                    //    activity = new StartActivity(x, y);
                    //    break;
                    case "1":

                        break;
                    case "2":
                        activity = new TextBoxActivity(x, y, 80, 20);

                        break;
                    default:
                        break;
                }

                if (activity != null)
                {
                    activity.ID = activityNode.Attributes["id"].Value;
                    activity.Value = activityNode.Attributes["value"].Value;
                    activity.X = x;
                    activity.Y = y;
                    document.ActivityList.Add(activity);
                    activities.Add(activity);
                }
            }
            XmlNodeList lineNodes = _layout.SelectNodes("process/lines/line");
            foreach (XmlNode lineNode in lineNodes)
            {
                int x = Convert.ToInt32(lineNode.Attributes["x"].Value);
                int y = Convert.ToInt32(lineNode.Attributes["y"].Value);
                string sourceId = lineNode.Attributes["source"].Value;
                string targetId = lineNode.Attributes["target"].Value;
                BaseActivity source = null;
                BaseActivity target = null;
                foreach (BaseActivity act in activities)
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

                LineActivity activity = new LineActivity(source, target);
                if (activity != null)
                {
                    activity.ID = lineNode.Attributes["id"].Value;
                    activity.Value = lineNode.Attributes["value"].Value;
                    activity.X = x;
                    activity.Y = y;
                    document.Lines.Add(activity);
                    document.ActivityList.Add(activity);
                }
            }
        }

        public Tool SetCurrentTool(ActivityType type)
        {
            Tool tool = null;
            switch (type)
            {
                case ActivityType.LABEL:
                    tool = new LabelActivityTool();
                    break;
                case ActivityType.BUTTON:
                    tool = new ButtonActivityTool();
                    break;
                case ActivityType.COMBOBOX:
                    tool = new ComboBoxActivityTool();
                    break;
                case ActivityType.TEXTBOX:
                    tool = new TextBoxActivityTool();
                    break;
                case ActivityType.DATETIMEPICKER:
                    tool = new DateTimePickerActivityTool();
                    break;
                case ActivityType.CHECKBOX:
                    tool = new CheckBoxActivityTool();
                    break;
                case ActivityType.RADIOBUTTON:
                    tool = new RadioButtonActivityTool();
                    break;
                case ActivityType.SELECT:
                    tool = new SelectorTool();
                    break;
                case ActivityType.LINE:
                    tool = new LineActivityTool();
                    break;
            }
            return tool;
        }
    }
}
