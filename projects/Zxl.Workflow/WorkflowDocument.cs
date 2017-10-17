using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zxl.Workflow
{
    public class WorkflowDocument
    {
        public WorkflowDocument()
        {
            _activitids = new List<Activity>();
            //_lines = new List<LineActivity>();
        }

        private IList<Activity> _activitids;
        public IList<Activity> ActivityList
        {
            get
            {
                return _activitids;
            }
        }

    }
}
