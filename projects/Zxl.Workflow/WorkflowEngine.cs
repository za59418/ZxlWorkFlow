using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
