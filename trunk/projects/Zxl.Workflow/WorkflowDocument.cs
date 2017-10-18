using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.Workflow
{
    public class HitTestResult
    {
        public Activity.HitTestState state;
        public Activity result;
    }

    public class WorkflowDocument
    {
        public WorkflowDocument()
        {
            _activities = new List<Activity>();
            _lines = new List<LineActivity>();
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

        public HitTestResult HitTest(int x, int y)
        {
            foreach (Activity activity in _activities)
            {
                Activity.HitTestState state = activity.HitTest(x, y);
                if (Activity.HitTestState.None != state)
                {
                    HitTestResult result = new HitTestResult();
                    result.state = state;
                    result.result = activity;
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
                if (activity is LineActivity)
                {
                    LineActivity line = activity as LineActivity;
                    if (line.Source.IsSelected || line.Target.IsSelected || line.IsSelected)
                    {
                        ActivityList.Remove(line);
                        Lines.Remove(line);
                        result.Add(line);
                        break;
                    }
                }
            }
            foreach (Activity activity in ActivityList)
            {
                if (!(activity is LineActivity))
                {
                    BaseActivity item = activity as BaseActivity;
                    if (item.IsSelected)
                    {
                        ActivityList.Remove(item);
                        result.Add(item);
                        break;
                    }
                }
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

    }
}
