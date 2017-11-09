using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner.ControlProperty
{
    public class PropertyControlScript : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            //IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            //if (edSvc != null)
            //{
            //    if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
            //    {
            //         FormDesignerWorkbenchWindow fdww  = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow  as FormDesignerWorkbenchWindow;
            //        if (fdww.SelectedControl.formItemID.ToString() != "0"
            //            && fdww.SelectedControl.formItemID.ToString() != null)
            //        {
            //            string controlName ;
            //            FormDesignerWorkbenchWindow.controlsDictionary.TryGetValue(fdww.SelectedControl.formItemID, out controlName);
            //            ControlScript frm = new ControlScript(fdww.SelectedControl.formItemID.ToString(),controlName,
            //                fdww.FormParameter.FormId.ToString(), fdww.FormParameter.FormRevisionId.ToString());
            //            frm.ShowDialog();
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
