using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner.ControlProperty
{
    public class PropertyRightItem : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            //if (edSvc != null)
            //{
            //    if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
            //    {
            //        ControlRightsFacade controlRightsFacade = new ControlRightsFacade();

            //        string[] ctrlIdItems;
            //        int len = Dap2xProvoider.GetSelectedFormItemsCount();
            //        if (len > 1)
            //        {//设置多个控件的权限
            //            StringBuilder ctrlIdStr = new StringBuilder(len * 5 + 1);
            //            Dap2xProvoider.GetSelectedFormItemsID(ctrlIdStr);
            //            ctrlIdItems = ctrlIdStr.ToString().Split(';');
            //            controlRightsFacade.RightSettingInterface(ctrlIdItems);
            //        }
            //        else
            //        {
            //            if (((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).SelectedControl.formItemID.ToString() != "0")
            //            {
            //                controlRightsFacade.ControlId = ((FormDesignerWorkbenchWindow)WorkbenchSingleton
            //                    .Workbench.ActiveWorkbenchWindow).SelectedControl.formItemID.ToString();
            //                controlRightsFacade.RightSettingInterface(true);
            //            }
            //            else
            //            {
            //                controlRightsFacade.ControlId = string.Empty;
            //                new ControlRightsFacade().RightSettingInterface(false);
            //            }
            //        }
            //    }
            //}
            return value;
        }   
    }
}
