﻿using System;
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
    public class PropertyControlTypeItem : TypeConverter
    {
        public PropertyControlTypeItem()
        {
        }

        private List<string> GetItem()
        {
            List<string> lstType = new List<string>();
            //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
            //{
            //if (((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).SelectedControl.formItemID.ToString() != "0"
            //        && ((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).SelectedControl.formItemID.ToString() != null)
            //{
            DockFormDesigner win = (DockFormDesigner)DockWindowFactory.Instance.CurrDockWindow;

            foreach (XmlNode item in ControlMapping.GetInstance().GetControlExtention(win.SelectedControl.formItemType.ToString()))
            {
                if (item.Attributes == null) continue;
                if (item.Attributes["name"] != null)
                {
                    lstType.Add(item.Attributes["name"].Value);

                }
            }
            //}
            //}
            return lstType;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
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
