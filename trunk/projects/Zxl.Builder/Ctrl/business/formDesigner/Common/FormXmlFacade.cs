/*----------------------------------------------------------------
// Copyright (C) 2010 上海数慧系统技术有限公司
// 版权所有。 
//
// 文件名：FormXmlFacade.cs
// 功能描述：
//  
// 
// 创建标识：
//
// 修改标识：zhanben20100919
// 修改描述：新增表单脚本功能
//
//----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Zxl.Builder;
using FormDesigner;
using FormDesigner.Attribute;

namespace FormDesigner.Common
{
    /// <summary>
    /// 生成和解析表单文件接口
    /// </summary>
    public interface IFormXmlFacade
    {
        //bool Execute(FormDesignerWorkbenchWindow formDesignerWorkbenchWindow, out string xmlString);
        void ResetXml(DockFormDesigner formDesignerWorkbenchWindow, string fileContent);
        //void ResetXml(FormDesignerWorkbenchWindow formDesignerWorkbenchWindow, string filePath, out TextBoxsType textBoxsType);
    }

    public class FormXmlFacade : IFormXmlFacade
    {
        /// <summary>
        /// 生成表单文件
        /// </summary>
        /// <param name="formDesignerWorkbenchWindow"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        //public bool Execute(FormDesignerWorkbenchWindow formDesignerWorkbenchWindow, out string xmlString)
        //{
        //    bool isCheckerok = true;
        //    xmlString = string.Empty;
        //    try
        //    {               
        //        List<object> list = new List<object>();
        //        list.Add(formDesignerWorkbenchWindow.formValidatesCollection);
        //        //list.Add(formDesignerWorkbenchWindow.dataDefineResource);
        //        list.Add(formDesignerWorkbenchWindow.formDataCollection);
        //        list.Add(formDesignerWorkbenchWindow.formRightsCollection);
        //        BuildRuleChecker.CheckReference(formDesignerWorkbenchWindow);
        //        string message = string.Empty;
        //        if (isCheckerok)
        //        {
        //            xmlString = DistFormXmlBuilder.BuildXml(list,formDesignerWorkbenchWindow,
        //                formDesignerWorkbenchWindow.SheetLayoutXML);
        //        }
        //    }
        //    catch(Exception E)
        //    {
        //        isCheckerok = false;
        //        MessageBox.Show(E.Message);
        //    }
        //    return isCheckerok;
        //}

        /// <summary>
        /// 读取单个表单文件
        /// </summary>
        /// <param name="formDesignerWorkbenchWindow"></param>
        /// <param name="filePath"></param>
        //public void ResetXml(FormDesignerWorkbenchWindow formDesignerWorkbenchWindow, string filePath, out  TextBoxsType textBoxsType)
        public void ResetXml(DockFormDesigner formDesignerWorkbenchWindow, string fileContent)
        {
            #region//控件
            DistFormXmlParser getObjectFromXml = new DistFormXmlParser(fileContent, true);
            PageProperty.IsPrint = getObjectFromXml.GetPrintProperty("/Form", "isprint");

            Dictionary<string,string> dic = new Dictionary<string,string>();
            DAP2ControlsCollection dap2ControlsCollection = getObjectFromXml.GetDap2xControls(formDesignerWorkbenchWindow, "/Form/Control", out dic);

            string width, height;
            dic.TryGetValue("width", out width);
            dic.TryGetValue("height", out height);
            Dap2xProvoider.SetFormViewSize(Convert.ToInt32(width), Convert.ToInt32(height));
            foreach (KeyValuePair<string, object> kvp in dap2ControlsCollection)
            {
                #region FormItemType == 5
                if (((GeneralAttribute)kvp.Value).FormItemType == 5)
                {
                    Dap2xProvoider.Rect rcRect = new Dap2xProvoider.Rect();
                    SetRect(out rcRect, (GeneralAttribute)kvp.Value);
                    Dap2xProvoider.CreateFormItem(Convert.ToInt32(((GeneralAttribute)kvp.Value).FormItemType),
                        rcRect, Convert.ToInt32(kvp.Key), ((GeneralAttribute)kvp.Value).ExtensionType);

                    TableContorlAttribute tableContorlAttribute = (TableContorlAttribute)kvp.Value;
                    int page=0;
                    foreach (KeyValuePair<string,Group> kvpGroup in tableContorlAttribute.Groups)
                    {
                        Dap2xProvoider.InsertTabPage(((GeneralAttribute)kvp.Value).FormItemId, kvpGroup.Value.Name, page);

                        foreach (KeyValuePair<string, GeneralAttribute> kvpChildAttribute in kvpGroup.Value.GroupControls)
                        {
                            Dap2xProvoider.Rect rcRectChild = new Dap2xProvoider.Rect();
                            SetRect(out rcRectChild, (GeneralAttribute)kvpChildAttribute.Value);
                            Dap2xProvoider.CreateChlidFormItem(kvpChildAttribute.Value.FormItemType, rcRectChild, Convert.ToInt32(kvpChildAttribute.Key),
                                Convert.ToInt32(kvp.Key), page, ((GeneralAttribute)kvpChildAttribute.Value).ExtensionType);
                            if (((GeneralAttribute)kvpChildAttribute.Value).Multiline == true && ((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 1)
                                Dap2xProvoider.SetFormItemStyle(Convert.ToInt32(kvpChildAttribute.Key), 0x00010000, true);//0x00010000
                            if (((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 7)  
                            {
                                //SetDataGrid(formDesignerWorkbenchWindow, kvpChildAttribute.Key, kvpChildAttribute.Value);
                            }
                            if (((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 20)
                            {
                                SetRadioButtonList(kvpChildAttribute.Value);
                            }
                            if (((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 4||
                                ((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 15||
                                ((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 3||
                                ((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 6)
                            {
                                Dap2xProvoider.SetStaticText(Convert.ToInt32(kvpChildAttribute.Key), kvpChildAttribute.Value.Text);
                            }
                            if (((GeneralAttribute)kvpChildAttribute.Value).FormItemType == 4)
                            {
                                Dap2xProvoider.FontWnd font = new Dap2xProvoider.FontWnd();
                                font.itemName = ((GeneralAttribute)kvpChildAttribute.Value).WindowTextFont.FontFamily.Name;
                                font.ftSize = Convert.ToInt32(((GeneralAttribute)kvpChildAttribute.Value).WindowTextFont.Size);
                                font.ftStyle = GeneralAttribute.GetFontStyle(((GeneralAttribute)kvpChildAttribute.Value).WindowTextFont);
                                Dap2xProvoider.SetFormItemFont(((GeneralAttribute)kvpChildAttribute.Value).FormItemId, font);
                                Dap2xProvoider.SetFormItemStyle(((GeneralAttribute)kvpChildAttribute.Value).FormItemId, 0x00800000, ((GeneralAttribute)kvpChildAttribute.Value).Border);
                            }
                        }
                        page++;
                    }
                }
                #endregion
                else if (((GeneralAttribute)kvp.Value).FormItemType == 7)
                {
                    Dap2xProvoider.Rect rcRect = new Dap2xProvoider.Rect();
                    SetRect(out rcRect, (GeneralAttribute)kvp.Value);
                    Dap2xProvoider.CreateFormItem(Convert.ToInt32(((GeneralAttribute)kvp.Value).FormItemType),
                        rcRect, Convert.ToInt32(kvp.Key), ((GeneralAttribute)kvp.Value).ExtensionType);
                    //SetDataGrid(formDesignerWorkbenchWindow, kvp.Key, kvp.Value);
                }
                else if (((GeneralAttribute)kvp.Value).FormItemType == 20)
                {
                    Dap2xProvoider.Rect rcRect = new Dap2xProvoider.Rect();
                    SetRect(out rcRect, (GeneralAttribute)kvp.Value);
                    Dap2xProvoider.CreateFormItem(Convert.ToInt32(((GeneralAttribute)kvp.Value).FormItemType),
                        rcRect, Convert.ToInt32(kvp.Key), ((GeneralAttribute)kvp.Value).ExtensionType);
                    SetRadioButtonList(kvp.Value);
                }
                else if (((GeneralAttribute)kvp.Value).FormItemType == 255)//直线
                {
                    Dap2xProvoider.Rect rcRect = new Dap2xProvoider.Rect();
                    SetRect(out rcRect, (GeneralAttribute)kvp.Value);
                    Dap2xProvoider.CreateFormItem(Convert.ToInt32(((GeneralAttribute)kvp.Value).FormItemType),
                        rcRect, Convert.ToInt32(kvp.Key), ((GeneralAttribute)kvp.Value).ExtensionType);
                }
                else
                {
                    Dap2xProvoider.Rect rcRect = new Dap2xProvoider.Rect();
                    SetRect(out rcRect, (GeneralAttribute)kvp.Value);
                    Dap2xProvoider.CreateFormItem(Convert.ToInt32(((GeneralAttribute)kvp.Value).FormItemType),
                        rcRect, Convert.ToInt32(kvp.Key), ((GeneralAttribute)kvp.Value).ExtensionType);
                    if (((GeneralAttribute)kvp.Value).FormItemType == 1)
                    {
                        DockFormDesigner.controlIdItems.Add(kvp.Key);
                    }
                    else
                    {
                        Dap2xProvoider.SetStaticText(Convert.ToInt32(kvp.Key), ((GeneralAttribute)kvp.Value).Text);
                    }
                    //Dap2xProvoider.SetFormItemStyle(((GeneralAttribute)kvp.Value).FormItemId, 0x00800000, false);

                    if (((GeneralAttribute)kvp.Value).FormItemType == 1 && ((GeneralAttribute)kvp.Value).Multiline == true)
                        Dap2xProvoider.SetFormItemStyle(((GeneralAttribute)kvp.Value).FormItemId, 0x00010000, true);
                    else
                    {
                        Dap2xProvoider.SetFormItemStyle(((GeneralAttribute)kvp.Value).FormItemId, 0x00010000, false);
                    }
                    if (((GeneralAttribute)kvp.Value).FormItemType == 4)
                    {
                        Dap2xProvoider.FontWnd font = new Dap2xProvoider.FontWnd();
                        font.itemName = ((GeneralAttribute)kvp.Value).WindowTextFont.FontFamily.Name;
                        font.ftSize = Convert.ToInt32(((GeneralAttribute)kvp.Value).WindowTextFont.Size);
                        font.ftStyle = GeneralAttribute.GetFontStyle(((GeneralAttribute)kvp.Value).WindowTextFont);
                        Dap2xProvoider.SetFormItemFont(((GeneralAttribute)kvp.Value).FormItemId, font);
                        Color color = ((GeneralAttribute)kvp.Value).WindowTextColor;
                        Dap2xProvoider.SetFormItemColor(((GeneralAttribute)kvp.Value).FormItemId, color.B << 16 | color.G << 8 | color.R);
                        //边框
                        Dap2xProvoider.SetFormItemStyle(((GeneralAttribute)kvp.Value).FormItemId, 0x00800000, ((GeneralAttribute)kvp.Value).Border);
                    }
                }
            }
            #endregion

            //formDesignerWorkbenchWindow.formDataCollection = formDesignerWorkbenchWindow.FormParameter.FormDataCollection;
            //formDesignerWorkbenchWindow.formValidatesCollection = getObjectFromXml.GetFormValidatesCollection("/Form/Validation");//formValidatesCollection
            //formDesignerWorkbenchWindow.formRightsCollection = getObjectFromXml.GetFormRightsCollection("/Form/Right");//formRightsCollection
            ////zhanben20100919 新增表单脚本功能
            //formDesignerWorkbenchWindow.FormScriptString = getObjectFromXml.GetFormScriptString("/Form/Script");
        }

        public static void ReLoadDataBinding(DockFormDesigner formDesignerWorkbenchWindow)
        {
            //formDesignerWorkbenchWindow.formDataCollection =formDesignerWorkbenchWindow.FormParameter.FormDataCollection;// DistFormXmlParser.ReGetFormDataCollection(
        }

        /// <summary>
        /// 设置控件元素的形状参数
        /// </summary>
        /// <param name="rcRect"></param>
        /// <param name="GenerAttribute"></param>
        private void SetRect(out Dap2xProvoider.Rect rcRect, GeneralAttribute GenerAttribute)
        {
            rcRect.left = GenerAttribute.Left;
            rcRect.right = GenerAttribute.Left + GenerAttribute.Width;
            rcRect.top = GenerAttribute.Top;
            rcRect.bottom = GenerAttribute.Top + GenerAttribute.Height;
        }

        /// <summary>
        /// 页面生成DataGrid
        /// </summary>
        /// <param name="formDesignerWorkbenchWindow"></param>
        /// <param name="ID"></param>
        /// <param name="Attribute"></param>
        //private void SetDataGrid(FormDesignerWorkbenchWindow formDesignerWorkbenchWindow, string ID, object Attribute)
        //{
        //    DataGridControlAttribute DataGridControlAttribute = (DataGridControlAttribute)Attribute;
        //    int columnIndex = 0;
        //    for (int j = 0; j < DataGridControlAttribute.Columns.Count; j++)
        //    {
        //        Dap2xProvoider.GridColumn gridColumnInfo = new Dap2xProvoider.GridColumn();
        //        gridColumnInfo.columnalign = 1;
        //        gridColumnInfo.columnWidth = Convert.ToInt32(DataGridControlAttribute.Columns[j].Width);
        //        gridColumnInfo.columncaption = DataGridControlAttribute.Columns[j].Text;
        //        gridColumnInfo.columnStyle = formDesignerWorkbenchWindow.ColumnStyle.GetKeyByValue(DataGridControlAttribute.Columns[j].Input);
        //        gridColumnInfo.columndefaultValue = DataGridControlAttribute.Columns[j].DefaultValue;
        //        if (DataGridControlAttribute.Columns[j].ReadOnly == "true")
        //            gridColumnInfo.columnalign = 1;
        //        else if (DataGridControlAttribute.Columns[j].ReadOnly == "false")
        //            gridColumnInfo.columnalign = 0;
        //        if (null != DataGridControlAttribute.Columns[j].Sum)
        //        {
        //            if (DataGridControlAttribute.Columns[j].Sum == "true")
        //                gridColumnInfo.sum = 1;
        //            else if (DataGridControlAttribute.Columns[j].Sum == "false")
        //                gridColumnInfo.sum = 0;
        //        }
        //        Dap2xProvoider.InsertGridColumn(DataGridControlAttribute.FormItemId, columnIndex, gridColumnInfo);
        //        columnIndex++;
        //    }
        //}

        private void SetRadioButtonList(object Attribute)
        {            
            RadioButtonListAttribute radioButtonListAttribute = (RadioButtonListAttribute)Attribute;
            Dap2xProvoider.SetRaidoButtonCols(radioButtonListAttribute.FormItemId, radioButtonListAttribute.Columns);
            Dap2xProvoider.SetRaidoButtonRows(radioButtonListAttribute.FormItemId, radioButtonListAttribute.Rows);
            Dap2xProvoider.SetRadioButtonCaption(radioButtonListAttribute.FormItemId, radioButtonListAttribute.RadioButtonListText);
        }
    }
}
