using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zxl.Workflow
{
    public class EndActivity : BaseActivity
    {
        public EndActivity(int x, int y)
            : base(x, y)
        {
            Description = "结束";
        }
        override protected void DrawIcon(Graphics g)
        {
            if (IsSelected)
                g.DrawImage(Properties.Resources.endSelect, _rect);
            else
                g.DrawImage(Properties.Resources.end, _rect);
        }
    }
}
