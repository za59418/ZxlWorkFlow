using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zxl.Workflow
{
    public class ManualActivity : BaseActivity
    {
        public ManualActivity(int x, int y)
            : base(x, y)
        {
            Description = "环节";
        }
        override protected void DrawIcon(Graphics g)
        {
            g.DrawImage(Properties.Resources.manual, _rect);
        }
    }
}
