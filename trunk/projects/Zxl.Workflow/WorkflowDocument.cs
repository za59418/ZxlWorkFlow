using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zxl.Workflow
{
    public class HitTestResult
    {
        public Activity.HitTestState state;
        public Activity activity;
    }

    public class WorkflowDocument
    {
        public WorkflowDocument()
        {
            _activities = new List<Activity>();
            _lines = new List<LineActivity>();
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

        private IList<Activity> _activities;
        public IList<Activity> ActivityList
        {
            get
            {
                return _activities;
            }
        }
        private IList<LineActivity> _lines;
        public IList<LineActivity> Lines
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
            if (result != null && result.state == Activity.HitTestState.Center)
            {
                result.activity.OpenPropertyDialog();
            }
            else
            {
            }
        }

        public HitTestResult HitTest(int x, int y)
        {
            foreach (Activity activity in _activities)
            {
                Activity.HitTestState state = activity.HitTest(x, y);
                if (Activity.HitTestState.None != state)
                {
                    HitTestResult result = new HitTestResult();
                    result.state = state;
                    result.activity = activity;
                    return result;
                }
            }
            return null;
        }
        public void ResetSelected()
        {
            foreach (Activity activity in _activities)
            {
                activity.IsSelected = false;
            }
        }

        public IList<Activity> DeleteSelected()
        {
            IList<Activity> result = new List<Activity>();
            foreach (Activity activity in ActivityList)
            {
                if(activity.IsSelected)
                {
                    result.Add(activity);
                }
                else
                {
                    if(activity is LineActivity)
                    {
                        LineActivity line = activity as LineActivity;
                        if (line.Source.IsSelected || line.Target.IsSelected)
                            result.Add(activity);
                    }
                }
            }
            foreach (Activity activity in result)
            {
                ActivityList.Remove(activity);
            }
            return result;
        }

        public void MoveSelected(int offX, int offY)
        {
            foreach (Activity activity in _activities)
            {
                if (activity.IsSelected)
                    activity.Move(offX, offY);
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
            foreach (Activity activity in _activities)
            {
                if (!(activity is LineActivity))
                {
                    BaseActivity act = activity as BaseActivity;
                    act.CreateXml(actsElement);
                }
            }
            XmlElement linesElement = processElement.OwnerDocument.CreateElement("lines");
            processElement.AppendChild(linesElement);
            foreach (Activity activity in _activities)
            {
                if (activity is LineActivity)
                {
                    LineActivity line = activity as LineActivity;
                    line.CreateXml(linesElement);
                }
            }
            xmlElement.AppendChild(processElement);
        }
    }
}
