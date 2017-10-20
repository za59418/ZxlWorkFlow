using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zxl.Workflow
{
    public enum ActivityType
    {
        START,
        END,
        MANUAL,
        SELECT,
        LINE
    }
    public class WorkflowEngine
    {
        public WorkflowEngine()
        {
            if (null == document)
                document = new WorkflowDocument();
        }

        private WorkflowDocument document;
        public WorkflowDocument Document
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
                switch(type)
                {
                    case "0":
                        activity = new StartActivity(x, y);
                        break;
                    case "1":
                        activity = new EndActivity(x, y);
                        break;
                    case "2":
                        activity = new ManualActivity(x, y);
                        break;
                    default:
                        break;
                }

                if (activity != null)
                {
                    activity.ID = activityNode.Attributes["id"].Value;
                    activity.Description = activityNode.Attributes["description"].Value;
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
                    activity.Description = lineNode.Attributes["description"].Value;
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
                case ActivityType.START:
                    tool = new StartActivityTool();
                    break;
                case ActivityType.END:
                    tool = new EndActivityTool();
                    break;
                case ActivityType.MANUAL:
                    tool = new ManualActivityTool();
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
