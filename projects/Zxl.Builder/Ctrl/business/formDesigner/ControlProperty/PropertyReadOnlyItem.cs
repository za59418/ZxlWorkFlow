using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Zxl.Builder;

namespace FormDesigner.ControlProperty
{
    public class PropertyReadOnlyItem : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        private List<string> GetItem()
        {
            List<string> lstType = new List<string>();
            if (DockWindowFactory.Instance.CurrDockWindow is DockFormDesigner)
            {
                if (((DockFormDesigner)DockWindowFactory.Instance.CurrDockWindow).SelectedControl.formItemID.ToString() != "0"
                        && ((DockFormDesigner)DockWindowFactory.Instance.CurrDockWindow).SelectedControl.formItemID.ToString() != null)
                {
                    lstType.Add("true");
                    lstType.Add("false");
                }
            }
            return lstType;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        private StandardValuesCollection GetValues()
        {
            return new StandardValuesCollection(GetItem());
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return GetValues();
        }
    }
}
