using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using FormDesigner.Common;

namespace FormDesigner.ControlProperty
{
    public class PropertyDataSource : UITypeEditor
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
            //        if (win.SelectedControl.formItemID.ToString() != "0" && win.SelectedControl.formItemID.ToString() != null)
            //        {
            //            DataBindAttribute dataBindAttribute;
            //            if (win.formDataCollection.TryGetValue(win.SelectedControl.formItemID.ToString(), out dataBindAttribute))
            //            {
            //                if (dataBindAttribute is SingleDataBindAttribute)
            //                {
            //                    string key = win.FormParameter.FormId + "_" + win.FormParameter.FormRevisionId + "_" + win.SelectedControl.formItemID.ToString();
            //                    System.Windows.Forms.Form frm = win.dataDefineResource.GetDataSource(key);
            //                    frm.ShowDialog();
            //                    if ((bool)frm.Tag == true)
            //                    {
            //                        if (dataBindAttribute != null)
            //                        {
            //                            ((SingleDataBindAttribute)dataBindAttribute).Datasource = key;
            //                            Dist.Platform.Log.LogEngine.GetLog().WriteLog(Dist.Platform.Log.LogLevel.Info,
            //                                "空间数据源，controlid:"+win.SelectedControl.formItemID,
            //                                DateTime.Now,
            //                                string.Empty,
            //                                "表单");
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("请先绑定数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
