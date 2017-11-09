using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner.ControlProperty
{
    public class PropertyValidateItem : UITypeEditor
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
            //        if (((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).SelectedControl.formItemID.ToString() != "0"
            //            && ((FormDesignerWorkbenchWindow)WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).SelectedControl.formItemID.ToString() != null)
            //        {
            //            ControlValSetting dialog = new ControlValSetting();
            //            dialog.ShowDialog();
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
