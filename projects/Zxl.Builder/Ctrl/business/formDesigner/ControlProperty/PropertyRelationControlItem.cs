using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;

namespace FormDesigner.ControlProperty
{
    public class PropertyRelationControlItem:TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        private List<string> GetItem()
        {
            List<string> lstControls = new List<string>();
            //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
            //{
            //    FormDesignerWorkbenchWindow win = (FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow;
            //    if (win.SelectedControl.formItemID.ToString() != "0"
            //            && win.SelectedControl.formItemID.ToString() != null)
            //    {
            //        lstControls.Add(string.Empty);
            //        foreach (KeyValuePair<int, string> item in FormDesignerWorkbenchWindow.controlsDictionary)
            //        {
            //            lstControls.Add(item.Value);
            //        }
            //    }
            //}
            return lstControls;
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
