using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zxl.Workflow
{
    public class StartActivity : BaseActivity
    {
        public StartActivity(int x, int y)
            : base(x, y)
        {
            Description = "开始";
        }
        override protected void DrawIcon(Graphics g)
        {
            if (IsSelected)
                g.DrawImage(Properties.Resources.startSelect, _rect);
            else
                g.DrawImage(Properties.Resources.start, _rect);
        }
    }
}
