using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner.ControlProperty
{
    public class PropertyNumberRuleItem : UITypeEditor
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
            //        FormDesignerWorkbenchWindow win = (FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow;
            //        if (win.SelectedControl.formItemID != 0)
            //        {
            //            UInt16 a = Dap2xProvoider.GetFormItemExtension(Convert.ToInt32(win.SelectedControl.formItemID));
            //            if (win.SelectedControl.formItemType == 1
            //                && a == 4)
            //            {
            //                string numberDefineId = string.Empty;
            //                string newNumberDefineId = string.Empty;
            //                DAP2ControlMapping.ControlNumberDefine.TryGetValue(
            //                    Convert.ToInt32(win.SelectedControl.formItemID), out numberDefineId);
            //                win.FormParameter.BindNumberDefine(win.SelectedControl.formItemID.ToString(), numberDefineId, out newNumberDefineId);
            //                if (newNumberDefineId.Length > 0)
            //                {
            //                    if (numberDefineId != newNumberDefineId)
            //                    {
            //                        DAP2ControlMapping.ControlNumberDefine.Remove(
            //                            Convert.ToInt32(win.SelectedControl.formItemID));
            //                        DAP2ControlMapping.ControlNumberDefine.Add(
            //                            Convert.ToInt32(win.SelectedControl.formItemID), newNumberDefineId);
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("请选择控件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            return value;
        }   
    }
}
