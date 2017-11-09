using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner.ControlProperty
{
    public class PropertyDataItem : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
            //    if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
            //    {
            //        FormDesignerWorkbenchWindow wind = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow as FormDesignerWorkbenchWindow;
            //        if (wind.SelectedControl.formItemID.ToString() != "0"
            //            && (wind.SelectedControl.formItemID.ToString() != null))
            //        {
            //            if (wind.SelectedControl.formItemType.ToString() == "7")
            //            {
            //                GridDataBind frm = new GridDataBind();
            //                frm.ShowDialog();
            //                Dist.Platform.Log.LogEngine.GetLog().WriteLog(Dist.Platform.Log.LogLevel.Info,
            //                    "Grid控件数据绑定,controlid:" + wind.SelectedControl.formItemID,
            //                    DateTime.Now,
            //                    string.Empty,
            //                    "表单");
            //            }
            //            else
            //            {
            //                DataBinding dialog = new DataBinding();
            //                dialog.ShowDialog();
            //                Dist.Platform.Log.LogEngine.GetLog().WriteLog(Dist.Platform.Log.LogLevel.Info,
            //                    "一般控件数据绑定,controlid:" + wind.SelectedControl.formItemID,
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
            }
            return value;
        }
    }
}
