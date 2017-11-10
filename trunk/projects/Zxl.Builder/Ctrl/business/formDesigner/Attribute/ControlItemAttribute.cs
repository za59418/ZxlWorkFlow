using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using FormDesigner.Attribute;
using FormDesigner.ControlProperty;
using FormDesigner.Common;
using Zxl.Builder;

namespace FormDesigner.Attribute
{
    public class ControlItemAttribute : GeneralAttribute
    {
        private FormProvoider.FormItemInfo formItemInfo;
        public FormProvoider.FormItemInfo FormItemInfo
        {
            set
            {
                formItemInfo = value;
            }
        }

        private string _rightItem = "...";
        [CategoryAttribute("权限绑定"), Description("权限绑定"),
        EditorAttribute(typeof(PropertyRightItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string RightItem
        {
            get { return _rightItem; }
            set { ; }
        }

        [CategoryAttribute("事件脚本"), Description("事件脚本"),
        EditorAttribute(typeof(PropertyControlScript), typeof(System.Drawing.Design.UITypeEditor))]
        public string ControlScript
        {
            get { return "..."; }
            set { ; }
        }

        [CategoryAttribute("数据"), Description("数据绑定"),
        EditorAttribute(typeof(PropertyDataItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataItem
        {
            get { return BindValue(ControlId); }
            set { ; }
        }

        public string BindValue(string ID)
        {
            string value = string.Empty;
            //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow != null
            //    && WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is FormDesignerWorkbenchWindow)
            //{
            //    FormDataCollection formDataCollection = ((FormDesignerWorkbenchWindow)
            //        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).formDataCollection;
            //    DataBindAttribute dataBindAttribute;
            //    if (formDataCollection.TryGetValue(ID, out dataBindAttribute))
            //    {
            //        if (dataBindAttribute is SingleDataBindAttribute)
            //        {
            //            value = GetBindName(((SingleDataBindAttribute)dataBindAttribute).Value);
            //        }
            //    }
            //}
            return value;
        }

        private string GetBindName(string bindValue)
        {
            string reStr = string.Empty;
            string table = bindValue.Substring(1, bindValue.LastIndexOf('/') - 1);
            string field = bindValue.Substring(bindValue.LastIndexOf('/') + 1);
            //foreach (var item in ((FormDesignerWorkbenchWindow)
            //    WorkbenchSingleton.Workbench.ActiveWorkbenchWindow).dataDefineResource.DataDefine)
            //{
            //    foreach (var citem in item.Propertys)
            //    {
            //        if (citem.Name == field && item.Name == table)
            //        {
            //            reStr = "/" + item.Description + "/" + citem.Column;
            //            break;
            //        }
            //    }

            //}
            return reStr;
        }

        private string _dataSource = "(Collection)";
        [CategoryAttribute("数据"), Description("数据列表"),
      EditorAttribute(typeof(PropertyDataSource), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        private string _exp = "...";
        [CategoryAttribute("数据"), Description("数据表达式"),
      EditorAttribute(typeof(PropertyControlExpression), typeof(System.Drawing.Design.UITypeEditor))]
        public string Expression
        {
            get { return _exp; }
            set { _exp = value; }
        }

        [CategoryAttribute("数据验证"), Description("数据验证"),
      EditorAttribute(typeof(PropertyValidateItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string ValidateItem
        {
            get { return _rightItem; }
            set { ; }
        }

        [CategoryAttribute("设计"), Description("控件设计"),
     EditorAttribute(typeof(PropertyDesignItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string DesignItem
        {
            get { return _rightItem; }
            set { ; }
        }

        private string _comboBoxEdit = "false";
        [CategoryAttribute("设计"), Description("下拉框数据编辑"), TypeConverter(typeof(PropertyComboxEditItem))]
        public string ComboBoxEdit
        {
            get
            {
                if (FormItemType == 2 && ControlId.Length > 1)
                {
                    if (ControlMapping.ComboxEditControls.Contains(ControlId))
                    {
                        _comboBoxEdit = "true";
                    }
                }
                return _comboBoxEdit;
            }
            set
            {
                if (value.Length > 0 && FormItemType == 2)
                {
                    ControlMapping.ComboxEditControls.Remove(ControlId);
                    if (value == "true")
                    {
                        ControlMapping.ComboxEditControls.Add(ControlId);
                    }
                    _comboBoxEdit = value;
                }
            }
        }

        private string borderStyle = "false";
        [CategoryAttribute("设计"), Description("边框"), TypeConverter(typeof(PropertyLabelBorderItem))]
        public string BoarderStyle
        {
            get
            {
                if (FormItemType == 4 && ControlId.Length > 1)
                {
                    borderStyle = Border.ToString().ToLower();//Dap2xProvoider.BorderStyle(formItemInfo).ToString();
                }
                return borderStyle;
            }
            set
            {
                if (value.Length > 0 && FormItemType == 4)
                {
                    FormProvoider.SetFormItemStyle(FormItemId, 0x00800000, bool.Parse(value));
                    borderStyle = value;
                    Border = bool.Parse(value);
                }
            }
        }

        [CategoryAttribute("外观布局"), Description("名称")]
        public string Name
        {
            set
            {
                if (ControlId != "0")
                {
                    if (!DockFormDesigner.controlDictionary.ValueInDictionary(
                        Convert.ToInt32(ControlId), value))
                    {
                        DockFormDesigner.controlDictionary.SetValue(
                            Convert.ToInt32(ControlId), value);
                    }
                    else
                    {
                        MessageBox.Show("已存在此名称");
                        return;
                    }
                }
            }
            get
            {
                if (ControlId != "0")
                {
                    return DockFormDesigner.controlDictionary.GetValue(Convert.ToInt32(ControlId));
                }
                else
                    return null;
            }
        }

        private string controlType = string.Empty;
        [CategoryAttribute("控件类型"), Description("控件类型"), TypeConverter(typeof(PropertyControlTypeItem))]
        public string ControlType
        {
            get { return controlType; }
            set
            {
                if (value.Length > 0)
                {
                    //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is DockFormDesigner)
                    //{
                    //    string extValue = DAP2ControlMapping.GetInstance().GetExtensionTypeId(FormItemType.ToString(), value);
                    //    Dap2xProvoider.SetFormItemExtension(Convert.ToInt32(ControlId), Convert.ToInt16(extValue));
                    //    UInt16 aa = Dap2xProvoider.GetFormItemExtension(Convert.ToInt32(ControlId));
                    //    controlType = value;

                    //    //文号
                    //    if (aa != 4)
                    //    {
                    //        if (DAP2ControlMapping.ControlNumberDefine.ContainsKey(int.Parse(ControlId)))
                    //        {
                    //            DAP2ControlMapping.ControlNumberDefine.Remove(int.Parse(ControlId));
                    //        }
                    //    }
                    //}
                }
            }
        }

        [CategoryAttribute("控件类型"), Description("文号类型控件绑定"),
      EditorAttribute(typeof(PropertyNumberRuleItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string NumberDefine
        {
            get { return _rightItem; }
            set
            {
                ;
            }
        }

        private string readOnly = "false";
        [CategoryAttribute("外观布局"), Description("是否只读"), TypeConverter(typeof(PropertyReadOnlyItem))]
        public string ReadOnly
        {
            get
            {
                if (ControlId.Length > 1)
                {
                    if (ControlMapping.ReadControls.Contains(ControlId))
                    {
                        readOnly = "true";
                    }
                }
                return readOnly;
            }
            set
            {
                if (value.Length > 0)
                {
                    ControlMapping.ReadControls.Remove(ControlId);
                    if (value == "true")
                    {
                        ControlMapping.ReadControls.Add(ControlId);
                    }
                    readOnly = value;
                }
            }
        }

        private string isprint = "true";
        [CategoryAttribute("外观布局"), Description("是否打印"), TypeConverter(typeof(PropertyPrintItem))]
        public string IsPrint
        {
            get
            {
                if (ControlId.Length > 0)
                {
                    if (ControlId == "0")
                    {
                        return PageProperty.IsPrint.ToString();
                    }
                    else
                    {
                        if (ControlMapping.NotPrintControls.Contains(ControlId))
                        {
                            isprint = "false";
                        }
                    }
                }
                return isprint;
            }
            set
            {
                if (value.Length > 0)
                {
                    if (ControlId == "0")
                    {
                        PageProperty.IsPrint = bool.Parse(value);
                    }
                    else
                    {
                        ControlMapping.NotPrintControls.Remove(ControlId);
                        if (value == "false")
                        {
                            ControlMapping.NotPrintControls.Add(ControlId);
                        }
                        isprint = value;
                    }
                }
            }
        }


        /// <summary>
        /// IsPrintWhenArchive
        /// </summary>
        private string _isPrintWhenArchive = "true";
        [CategoryAttribute("外观布局"), Description("是否归档打印"), TypeConverter(typeof(PropertyPrintItem))]
        public string IsPrintWhenArchive
        {
            get
            {
                if (ControlId.Length > 0)
                {
                    int ctlId = Convert.ToInt32(ControlId);
                    if (ControlMapping.PrintWhenArchiveControls.ContainsKey(ctlId))
                    {
                        _isPrintWhenArchive = ControlMapping.PrintWhenArchiveControls[ctlId];
                    }
                }
                return _isPrintWhenArchive;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    int ctlId = Convert.ToInt32(ControlId);
                    ControlMapping.PrintWhenArchiveControls[ctlId] = value;
                    _isPrintWhenArchive = value;
                }
            }
        }

        private string relationControl = string.Empty;
        [CategoryAttribute("外观布局"), Description("关联控件"),
        TypeConverter(typeof(PropertyRelationControlItem))]
        public string RelationControl
        {
            get
            {
                if (ControlMapping.ControlRelation.ContainsKey(
                    Convert.ToInt32(ControlId)))
                {
                    if (!ControlMapping.ControlRelation.TryGetValue(
                        Convert.ToInt32(ControlId), out relationControl))
                    {
                        relationControl = DockFormDesigner.controlDictionary.GetName(
                            Convert.ToInt32(ControlId));
                    }
                    if (!DockFormDesigner.controlDictionary.ContainsValue(relationControl))
                    {
                        relationControl = string.Empty;
                    }
                }
                return relationControl;
            }
            set
            {
                //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is DockFormDesigner)
                //{
                //    DAP2ControlMapping.ControlRelation.Remove(Convert.ToInt32(ControlId));
                //    if (value.Length > 0)
                //    {
                //        DAP2ControlMapping.ControlRelation.Add(Convert.ToInt32(ControlId), value);
                //    }
                //    relationControl = value;
                //}
            }
        }

        private string _tip = string.Empty;
        [CategoryAttribute("外观布局"), Description("控件提示")]
        public string Tip
        {
            get
            {
                if (ControlMapping.ControlTip.ContainsKey(Convert.ToInt32(ControlId)))
                {
                    ControlMapping.ControlTip.TryGetValue(Convert.ToInt32(ControlId) , out _tip);
                }
                return _tip;
            }
            set
            {
                if (value.Length > 0)
                {
                    //if (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow is DockFormDesigner)
                    //{
                    //    if (!HelperClass.InValidateChar(value))
                    //    {
                    //        DAP2ControlMapping.ControlTip.Remove(Convert.ToInt32(ControlId));
                    //        DAP2ControlMapping.ControlTip.Add(Convert.ToInt32(ControlId), value);
                    //        _tip = value;
                    //    }
                    //    else
                    //    {
                    //        XtraMessageBox.Show("包含非法字符", "系统提示", MessageBoxButtons.OK);
                    //    }
                    //}
                }
            }
        }
    }
}
