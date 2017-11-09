using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner.ControlProperty
{
    public class PropertyControlExpression : UITypeEditor
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
            //        FormDesignerWorkbenchWindow fdww = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow as FormDesignerWorkbenchWindow;
            //        if (fdww.SelectedControl.formItemID.ToString() != "0"
            //            && fdww.SelectedControl.formItemID.ToString() != null)
            //        {
            //            string controlName;
            //            FormDesignerWorkbenchWindow.controlsDictionary.TryGetValue(fdww.SelectedControl.formItemID, out controlName);
            //            string expression=string.Empty;
            //            DAP2ControlMapping.ExpressionControls.TryGetValue(fdww.SelectedControl.formItemID, out expression);
            //            ExpressionDialog frm = new ExpressionDialog(FormDesignerWorkbenchWindow.controlsDictionary, expression);
            //            frm.StartPosition = FormStartPosition.CenterParent;
            //            if (DialogResult.OK == frm.ShowDialog())
            //            {
            //                expression = frm.Expression;
            //                DAP2ControlMapping.ExpressionControls.Remove(fdww.SelectedControl.formItemID);
            //                DAP2ControlMapping.ExpressionControls.Add(fdww.SelectedControl.formItemID,expression);

            //                Dist.Platform.Log.LogEngine.GetLog().WriteLog(Dist.Platform.Log.LogLevel.Info,
            //                    "控件表达式,id:" + fdww.SelectedControl.formItemID + ",Expression:" + expression,
            //                    DateTime.Now,
            //                    string.Empty,
            //                    "表单");
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
