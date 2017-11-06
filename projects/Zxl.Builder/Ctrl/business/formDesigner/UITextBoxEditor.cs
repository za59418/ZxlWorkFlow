using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormDesigner
{
    public class UITextBoxEditor : UITypeEditor
    {
       
        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown; 
        }

        #region Edit Value
        public override object EditValue(ITypeDescriptorContext context,
                                         IServiceProvider provider,
                                         object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(
                typeof(IWindowsFormsEditorService)) as
                IWindowsFormsEditorService;

            if (wfes == null) { return value; }

            TextBox control = new TextBox();
            control.Name = "textbox1";
            control.ScrollBars= ScrollBars.Vertical;
            control.Height = 300;
            control.Width = 500;
            control.WordWrap = true;
            control.Multiline = true;  
            control.AcceptsReturn = true;
            control.AcceptsTab = true;
         
            if (value != null)
            {
              control.Text = (string)value;
            }
         

            wfes.DropDownControl(control);
        
            value = control.Text;

            Dap2xProvoider.FormItemInfo formItemInfo;
            Dap2xProvoider.GetActiveFormItem(out formItemInfo);
            Dap2xProvoider.SetStaticText(formItemInfo.formItemID, control.Text);

            return value;
        }
        #endregion
        
    }
}
