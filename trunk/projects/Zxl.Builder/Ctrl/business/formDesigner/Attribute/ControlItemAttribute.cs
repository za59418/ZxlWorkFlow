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
        [CategoryAttribute("Ȩ�ް�"), Description("Ȩ�ް�"),
        EditorAttribute(typeof(PropertyRightItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string RightItem
        {
            get { return _rightItem; }
            set { ; }
        }

        [CategoryAttribute("�¼��ű�"), Description("�¼��ű�"),
        EditorAttribute(typeof(PropertyControlScript), typeof(System.Drawing.Design.UITypeEditor))]
        public string ControlScript
        {
            get { return "..."; }
            set { ; }
        }

        [CategoryAttribute("����"), Description("���ݰ�"),
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
        [CategoryAttribute("����"), Description("�����б�"),
      EditorAttribute(typeof(PropertyDataSource), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        private string _exp = "...";
        [CategoryAttribute("����"), Description("���ݱ��ʽ"),
      EditorAttribute(typeof(PropertyControlExpression), typeof(System.Drawing.Design.UITypeEditor))]
        public string Expression
        {
            get { return _exp; }
            set { _exp = value; }
        }

        [CategoryAttribute("������֤"), Description("������֤"),
      EditorAttribute(typeof(PropertyValidateItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string ValidateItem
        {
            get { return _rightItem; }
            set { ; }
        }

        [CategoryAttribute("���"), Description("�ؼ����"),
     EditorAttribute(typeof(PropertyDesignItem), typeof(System.Drawing.Design.UITypeEditor))]
        public string DesignItem
        {
            get { return _rightItem; }
            set { ; }
        }

        private string _comboBoxEdit = "false";
        [CategoryAttribute("���"), Description("���������ݱ༭"), TypeConverter(typeof(PropertyComboxEditItem))]
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
        [CategoryAttribute("���"), Description("�߿�"), TypeConverter(typeof(PropertyLabelBorderItem))]
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

        [CategoryAttribute("��۲���"), Description("����")]
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
                        MessageBox.Show("�Ѵ��ڴ�����");
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
        [CategoryAttribute("�ؼ�����"), Description("�ؼ�����"), TypeConverter(typeof(PropertyControlTypeItem))]
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

                    //    //�ĺ�
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

        [CategoryAttribute("�ؼ�����"), Description("�ĺ����Ϳؼ���"),
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
        [CategoryAttribute("��۲���"), Description("�Ƿ�ֻ��"), TypeConverter(typeof(PropertyReadOnlyItem))]
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
        [CategoryAttribute("��۲���"), Description("�Ƿ��ӡ"), TypeConverter(typeof(PropertyPrintItem))]
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
        [CategoryAttribute("��۲���"), Description("�Ƿ�鵵��ӡ"), TypeConverter(typeof(PropertyPrintItem))]
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
        [CategoryAttribute("��۲���"), Description("�����ؼ�"),
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
        [CategoryAttribute("��۲���"), Description("�ؼ���ʾ")]
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
                    //        XtraMessageBox.Show("�����Ƿ��ַ�", "ϵͳ��ʾ", MessageBoxButtons.OK);
                    //    }
                    //}
                }
            }
        }
    }
}
