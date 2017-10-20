﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
            if (IsSelected)
                g.DrawImage(Properties.Resources.manualSelect, _rect);
            else
                g.DrawImage(Properties.Resources.manual, _rect);
        }

        override public void OpenPropertyDialog()
        {

            ActivityInfoDlg dlg = new ActivityInfoDlg();
            dlg.Description = Description;
            
            //dlg.WfActivity = this;
            if(DialogResult.OK == dlg.ShowDialog())
            {
                Description = dlg.Description;
            }
            dlg.Dispose();
        }

        public override string GetActivityType()
        {
            return "2";
        }
    }
}
