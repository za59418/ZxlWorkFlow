using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Zxl.Builder;
using FormDesigner.ControlDesign;

namespace FormDesigner.ControlProperty
{
    public class PropertyDesignItem : UITypeEditor
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
                //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
                //{
                    FormProvoider.FormItemInfo formItemInfo = ((DockFormDesigner)DockWindowFactory.Instance.CurrDockWindow).SelectedControl;
                    switch (formItemInfo.formItemType.ToString())
                    {
                        case "1":
                            EditProperty editProperty = new EditProperty(formItemInfo);
                            editProperty.ShowDialog();
                            break;
                        case "5":
                            TableControlProperty frmTable = new TableControlProperty(formItemInfo.formItemID.ToString());
                            frmTable.ShowDialog();
                            break;
                        case "7":
                            GridProperty frmGrid = new GridProperty(formItemInfo.formItemID.ToString());
                            frmGrid.ShowDialog();
                            break;
                        case "20":
                            RadioButtonListSet frm = new RadioButtonListSet(formItemInfo.formItemID.ToString());
                            frm.ShowDialog();
                            break;
                        default:
                            MessageBox.Show("此控件无此项设置！");
                            break;
                    }
                //}
            }
            return value;
        }   
    }
}
