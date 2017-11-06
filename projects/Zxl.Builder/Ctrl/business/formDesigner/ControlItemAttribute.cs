using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using FormDesigner.Attribute;

namespace FormDesigner
{
    public class ControlItemAttribute : GeneralAttribute
    {
        private Dap2xProvoider.FormItemInfo formItemInfo;
        public Dap2xProvoider.FormItemInfo FormItemInfo
        {
            set
            {
                formItemInfo = value;
            }
        }



    }
}
