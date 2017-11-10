using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

//using Dist.Planning.Domain;
using FormDesigner;
using FormDesigner.Attribute;
using Zxl.Builder;

namespace FormDesigner.Common
{
    public class FormXmlParser
    {
        private XmlParser formXmlParser = null;

        DockFormDesigner _dockFormDesigner;

        public FormXmlParser(string xmlFilePath, bool isXmlString)
        {
            formXmlParser = new XmlParser(xmlFilePath, true);
        }

        public FormXmlParser(string xmlFile)
        {
            formXmlParser = new XmlParser(xmlFile);
        }

        public bool GetPrintProperty(string xpath,string property)
        {
            string contorlNode = formXmlParser.GetNodeAttributeValue(xpath, property);
            if (contorlNode.Length > 0)
            {
                if (bool.Parse(contorlNode))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// 获取控件信息集
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public ControlCollection GetControls(DockFormDesigner dockFormDesigner, string xPath, out Dictionary<string, string> panelProperty)
        {
            _dockFormDesigner = dockFormDesigner;
            ControlCollection controlCollection = new ControlCollection();
            XmlNode contorlNodes = formXmlParser.GetNode(xPath);
            panelProperty = new Dictionary<string, string>();
            //textBoxsType = new TextBoxsType();
            panelProperty.Add("width",contorlNodes.Attributes["width"].Value);
            panelProperty.Add("height", contorlNodes.Attributes["height"].Value);
            DockFormDesigner.controlDictionary.Clear();
            foreach (XmlNode xmlnode in contorlNodes)
            {
                GeneralAttribute generalAttribute = new GeneralAttribute();


                Int16 ItemType = 0;   
                //ItemType= Convert.ToInt16(DAP2ControlMapping.GetInstance().GetFormItemType(xmlnode.Name));
                switch(xmlnode.Name)
                {
                    case "Line":
                        ItemType = 255;
                        break;
                    case "Button":
                        ItemType = 15;
                        break;
                    case "Label":
                        ItemType = 4;
                        break;
                    case "TextBox":
                        ItemType = 1;
                        break;
                    case "ComboBox":
                        ItemType = 2;
                        break;
                    case "CheckBox":
                        ItemType = 3;
                        break;
                    case "TabControl":
                        ItemType = 5;
                        break;
                    case "GroupBox":
                        ItemType = 6;
                        break;
                    case "DataGrid":
                        ItemType = 7;
                        break;
                    case "RadioButtonList":
                        ItemType = 20;
                        break;
                }

                switch (ItemType)
                {
                    case 5:
                        #region ItemType=5
                        TableContorlAttribute tableContorlAttribute = new TableContorlAttribute();
                        BindGeneralAttribute(tableContorlAttribute, xmlnode, Convert.ToInt16(ControlMapping.GetInstance().GetFormItemType(xmlnode.Name)));
                        foreach (XmlNode groupNode in xmlnode)
                        {
                            Group group = new Group();
                            group.Name = groupNode.Attributes["name"].Value;
                            foreach (XmlNode childNode in groupNode)
                            {
                                Int16 ItemTypec;
                                //if (childNode.Name == "DateTimePicker")
                                //{
                                //    ItemTypec = 1;
                                //    textBoxsType.AddTextBox(childNode.Attributes["id"].Value);
                                //}
                                //else
                                ItemTypec = Convert.ToInt16(ControlMapping.GetInstance().GetFormItemType(childNode.Name));
                                switch (ItemTypec)
                                {
                                    case 7:
                                        DataGridControlAttribute DataGridControlAttribute = AppendGrid(childNode);
                                        group.AddGroupControl(DataGridControlAttribute.ControlId, DataGridControlAttribute);
                                        break;
                                    case 20:
                                        RadioButtonListAttribute rbtlist = AppendRadioButton(childNode);
                                        group.AddGroupControl(rbtlist.ControlId, rbtlist);
                                        break;
                                    default:

                                        GeneralAttribute childContrlAttribute = new GeneralAttribute();
                                        BindGeneralAttribute(childContrlAttribute, childNode, ItemTypec);
                                        group.AddGroupControl(childContrlAttribute.ControlId, childContrlAttribute);
                                        break;
                                }
                            }
                            tableContorlAttribute.AddGroup(group.Name, group);
                        }
                        generalAttribute = tableContorlAttribute;
                        #endregion
                        break;
                    case 7:
                        generalAttribute = AppendGrid(xmlnode);
                        break;
                    case 20:
                        generalAttribute = AppendRadioButton(xmlnode);
                        break;
                    default:
                        BindGeneralAttribute(generalAttribute, xmlnode, ItemType);
                        break;
                }
                controlCollection.Add(xmlnode.Attributes["id"].Value, generalAttribute);
            }
            return controlCollection;
        }


        /// <summary>
        /// 获取数据定义
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        //public DataDefine GetDataDefine(string xPath)
        //{
        //    DataDefine dataDefine = new DataDefine();
        //    foreach (XmlNode xmlnode in distFormXmlParser.GetNode(xPath))
        //    {
        //        DataDefineClass dataDefineClass = new DataDefineClass();
        //        dataDefineClass.Description = xmlnode.Attributes["description"].Value;
        //        dataDefineClass.Name = xmlnode.Attributes["name"].Value;
        //        foreach (XmlNode cxmlnode in xmlnode.ChildNodes)
        //        {
        //            ClassProperty classProperty=new ClassProperty();
        //            classProperty.Name=cxmlnode.Attributes["name"].Value;
        //            classProperty.Column = cxmlnode.Attributes["column"].Value;
        //            classProperty.Type = cxmlnode.Attributes["type"].Value;
        //            if(cxmlnode.Attributes["length"]!=null)
        //            classProperty.Length = cxmlnode.Attributes["length"].Value;
        //            dataDefineClass.Propertys.Add(classProperty);

        //        }
        //        dataDefine.Add(dataDefineClass);
        //    }
        //    return dataDefine;
           
        //}

        /// <summary>
        /// 获取数据源定义
        /// </summary>
        /// <returns></returns>
        //public DataSourceDefines GetDataSourceDefine(string xPath)
        //{
        //    DataSourceDefines dataSourceDefines = new DataSourceDefines();
        //    XmlNode Nodelist= distFormXmlParser.GetNode(xPath);
        //    foreach (XmlNode node in Nodelist)
        //    {
        //        CustomDataSourceDefine customDataSourceDefine = new CustomDataSourceDefine();
        //        customDataSourceDefine.Id = node.Attributes["id"].Value;
        //        customDataSourceDefine.Refer = node.Attributes["refer"].Value;
        //        List<Dictionary<string, string>> lis = new List<Dictionary<string, string>>();
        //        foreach (XmlNode nodeRow in node.ChildNodes)
        //        {
        //            Dictionary<string, string> dic = new Dictionary<string, string>();
        //            foreach (XmlNode nodeProperty in nodeRow.ChildNodes)
        //            {
        //                dic.Add(nodeProperty.Attributes["name"].Value,nodeProperty.InnerText);
        //            }
        //            lis.Add(dic);
        //        }
        //        dataSourceDefines.Add(customDataSourceDefine.Id, customDataSourceDefine);
        //    }
        //    return dataSourceDefines;
        //}

        /// <summary>
        /// 获取绑定数据集
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        //public FormDataCollection GetFormDataCollection(string xPath)
        //{
        //    FormDataCollection formDataCollection = new FormDataCollection();
        //    foreach (XmlNode xmlnode in distFormXmlParser.GetNode(xPath))
        //    {
        //        if (xmlnode.Name == "SingleItem")
        //        {
        //            SingleDataBindAttribute dataBindAttribute = new SingleDataBindAttribute(xmlnode.Attributes["id"].Value);
        //            dataBindAttribute.Value = xmlnode.Attributes["value"].Value;
        //            dataBindAttribute.Formatter = xmlnode.Attributes["formatter"].Value;
        //            dataBindAttribute.Datasource = xmlnode.Attributes["datasource"].Value;
        //            formDataCollection.Add(xmlnode.Attributes["id"].Value, dataBindAttribute);
        //        }
        //        else if (xmlnode.Name == "GridItem")
        //        {
        //            GridDataBindAttribute dataBindAttribute = new GridDataBindAttribute(xmlnode.Attributes["id"].Value);
        //            dataBindAttribute.Value = xmlnode.Attributes["value"].Value;
        //            foreach (XmlNode childnode in xmlnode.FirstChild)
        //            {
        //                GridColumnAttribute GridColumnAttribute = new GridColumnAttribute();
        //                GridColumnAttribute.Value = childnode.Attributes["value"].Value;
        //                if (childnode.Attributes["valueDescription"] != null)
        //                {
        //                    GridColumnAttribute.Description = childnode.Attributes["valueDescription"].Value;
        //                }
        //                GridColumnAttribute.Datasource = childnode.Attributes["datasource"].Value;
        //                dataBindAttribute.AddColumn(GridColumnAttribute);
        //            }
        //            formDataCollection.Add(xmlnode.Attributes["id"].Value, dataBindAttribute);
        //        }
        //    }
        //    return formDataCollection;
        //}

        /// <summary>
        /// 获取数据验证集
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        //public FormValidatesCollection GetFormValidatesCollection(string xPath)
        //{
        //    FormValidatesCollection formValidatesCollection = new FormValidatesCollection();
        //    foreach (XmlNode xmlnode in distFormXmlParser.GetNode(xPath))
        //    {
        //        ValidatesAttribute dataBindAttribute = new ValidatesAttribute(xmlnode.Attributes["id"].Value,xmlnode.Attributes["val"].Value);
        //        formValidatesCollection.Add(xmlnode.Attributes["id"].Value, dataBindAttribute);
        //    }
        //    return formValidatesCollection;
        //}

        /// <summary>
        /// 获取权限绑定集
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        //public FormRightsCollection GetFormRightsCollection(string xPath)
        //{
        //    FormRightsCollection formRightsCollection = new FormRightsCollection();
        //    foreach (XmlNode xmlnode in distFormXmlParser.GetNode(xPath))
        //    {
        //        StateCategory stateCategory = new StateCategory();
        //        stateCategory.Name = xmlnode.Attributes["name"].Value;
        //        stateCategory.Right = xmlnode.Attributes["right"].Value;
        //        foreach (XmlNode childXmlNode in xmlnode)
        //        {
        //            RightAttribute rightAttribute = new RightAttribute();
        //            rightAttribute.Id=childXmlNode.Attributes["id"].Value;
        //            rightAttribute.Right=childXmlNode.Attributes["right"].Value;
        //            rightAttribute.States = xmlnode.Attributes["name"].Value;
        //            stateCategory.Add(childXmlNode.Attributes["id"].Value, rightAttribute);
        //        }
        //        formRightsCollection.Add(xmlnode.Attributes["name"].Value, stateCategory);
        //    }
        //    return formRightsCollection;
        //}

        /// <summary>
        /// DataGrid 控件解析
        /// </summary>
        /// <param name="xmlnode"></param>
        /// <returns></returns>
        private DataGridControlAttribute AppendGrid(XmlNode xmlnode)
        {
            AddControl(xmlnode);
            DataGridControlAttribute dataGridControlAttribute = new DataGridControlAttribute();
            //dataGridControlAttribute.Left = Convert.ToInt32(xmlnode.Attributes["x"].Value);
            //dataGridControlAttribute.Top = Convert.ToInt32(xmlnode.Attributes["y"].Value);
            //dataGridControlAttribute.Height = Convert.ToInt32(xmlnode.Attributes["height"].Value);
            //dataGridControlAttribute.Width = Convert.ToInt32(xmlnode.Attributes["width"].Value);
            //dataGridControlAttribute.FormItemId = Convert.ToInt32(xmlnode.Attributes["id"].Value);
            //dataGridControlAttribute.FormItemType = Convert.ToInt16(DAP2ControlMapping.GetInstance().GetFormItemType(xmlnode.Name));
            //if (xmlnode.Attributes["extensionType"] != null)
            //{
            //    string enttype = DAP2ControlMapping.GetInstance().GetExtensionTypeId(dataGridControlAttribute.FormItemType.ToString()
            //        , xmlnode.Attributes["extensionType"].Value);
            //    if (!string.IsNullOrEmpty(enttype))
            //        dataGridControlAttribute.ExtensionType = Convert.ToInt16(enttype);
            //}
            //foreach (XmlNode node in xmlnode.ChildNodes)
            //{
            //    if (node.Name=="Columns")
            //    {
            //        foreach (XmlNode ColumnNode in node.ChildNodes)
            //        {
            //            Column Column = new Column();
            //            Column.Text = ColumnNode.Attributes["text"].Value;
            //            Column.Width = ColumnNode.Attributes["width"].Value;
            //            Column.Input = ColumnNode.Attributes["input"].Value;
            //            if (ColumnNode.Attributes["default"] != null)
            //            {
            //                Column.DefaultValue = ColumnNode.Attributes["default"].Value;
            //            }
            //            if (ColumnNode.Attributes["readonly"] != null)
            //            {
            //                Column.ReadOnly = ColumnNode.Attributes["readonly"].Value;
            //            }
            //            if (ColumnNode.Attributes["sum"]!=null)
            //            {
            //                Column.Sum = ColumnNode.Attributes["sum"].Value;
            //            }
            //            dataGridControlAttribute.AddColumn(Column);
            //        }
            //    }
            //    if (node.Name == "Rows")
            //    {
            //        if (_formDesignerWorkbenchWindow.GridRowDefine.ContainsKey(dataGridControlAttribute.FormItemId))
            //        {
            //            _formDesignerWorkbenchWindow.GridRowDefine.Remove(dataGridControlAttribute.FormItemId);
            //        }
            //        _formDesignerWorkbenchWindow.GridRowDefine.Add(dataGridControlAttribute.FormItemId, node);
            //    }
            //}
            
            return dataGridControlAttribute;
        }

        private RadioButtonListAttribute AppendRadioButton(XmlNode xmlNode)
        {
            AddControl(xmlNode);
            RadioButtonListAttribute rbtlist = new RadioButtonListAttribute();
            rbtlist.Left = Convert.ToInt32(xmlNode.Attributes["x"].Value);
            rbtlist.Top = Convert.ToInt32(xmlNode.Attributes["y"].Value);
            rbtlist.Height = Convert.ToInt32(xmlNode.Attributes["height"].Value);
            rbtlist.Width = Convert.ToInt32(xmlNode.Attributes["width"].Value);
            rbtlist.FormItemId = Convert.ToInt32(xmlNode.Attributes["id"].Value);
            rbtlist.FormItemType = 20;// Convert.ToInt16(DAP2ControlMapping.GetInstance().GetFormItemType(xmlNode.Name));
            rbtlist.Rows = Convert.ToInt32(xmlNode.Attributes["rows"].Value);
            rbtlist.Columns = Convert.ToInt32(xmlNode.Attributes["columns"].Value);
            rbtlist.ColumnInterWidth = Convert.ToInt32(xmlNode.Attributes["columnInterWidth"].Value);
            rbtlist.RadioButtonListText = xmlNode.Attributes["RadioButtonListText"].Value;
            return rbtlist;
        } 

        /// <summary>
        /// 控件一般属性解析
        /// </summary>
        /// <param name="ContrlAttribute"></param>
        /// <param name="xmlNode"></param>
        /// <param name="ItemType"></param>
        private void BindGeneralAttribute(GeneralAttribute ContrlAttribute, XmlNode xmlNode, Int16 ItemType)
        {
            AddControl(xmlNode);
            ContrlAttribute.Left = Convert.ToInt32(xmlNode.Attributes["x"].Value);
            ContrlAttribute.Top = Convert.ToInt32(xmlNode.Attributes["y"].Value);
            ContrlAttribute.Height = Convert.ToInt32(xmlNode.Attributes["height"].Value);
            ContrlAttribute.Width = Convert.ToInt32(xmlNode.Attributes["width"].Value);
            ContrlAttribute.FormItemId = Convert.ToInt32(xmlNode.Attributes["id"].Value);
            ContrlAttribute.FormItemType = ItemType;
            if (xmlNode.Attributes["text"] != null)
                ContrlAttribute.Text = xmlNode.Attributes["text"].Value;
            if (xmlNode.Attributes["multiline"] != null)
            {
                ContrlAttribute.Multiline = xmlNode.Attributes["multiline"].Value == "true" ? true : false;
            }
            if (xmlNode.Attributes["font"] != null)
            {
                string[] strFont = xmlNode.Attributes["font"].Value.Split('|');
                ContrlAttribute.WindowTextFont = GeneralAttribute.SetFontStyle(new FontFamily(strFont[0]), Convert.ToInt16(strFont[1]), Convert.ToInt32(strFont[2]));
            }
            if (xmlNode.Attributes["color"] != null)
            {
                ContrlAttribute.WindowTextColor = ColorTranslator.FromOle(Convert.ToInt32(xmlNode.Attributes["color"].Value));
            }
            if (xmlNode.Attributes["readonly"] != null)
            {
                if (xmlNode.Attributes["readonly"].Value == "true")
                {
                    ControlMapping.ReadControls.Add(ContrlAttribute.FormItemId.ToString());
                }
            }
            if (xmlNode.Attributes["isprint"] != null)
            {
                if (xmlNode.Attributes["isprint"].Value == "false")
                {
                    ControlMapping.NotPrintControls.Add(ContrlAttribute.FormItemId.ToString());
                }
            }
            //// 新增解析isprintwhenarchive的代码
            //if (xmlNode.Attributes["isprintwhenarchive"] != null)
            //{
            //    DAP2ControlMapping.PrintWhenArchiveControls.Add(ContrlAttribute.FormItemId,
            //        xmlNode.Attributes["isprintwhenarchive"].Value);
            //}

            //if (xmlNode.Attributes["relationControl"]!=null)
            //{
            //    DAP2ControlMapping.ControlRelation.Add(ContrlAttribute.FormItemId,
            //        xmlNode.Attributes["relationControl"].Value);
            //}
            if (xmlNode.Attributes["extensionType"] != null)
            {
                string enttype = ControlMapping.GetInstance().GetExtensionTypeId(ContrlAttribute.FormItemType.ToString()
                    , xmlNode.Attributes["extensionType"].Value);
                if (!string.IsNullOrEmpty(enttype))
                    ContrlAttribute.ExtensionType = Convert.ToInt16(enttype);
            }
            if (xmlNode.Attributes["tip"] != null)
            {
                ControlMapping.ControlTip.Add(ContrlAttribute.FormItemId, xmlNode.Attributes["tip"].Value);
            }
            //if (xmlNode.Attributes["numberDefine"] != null)
            //{
            //    DAP2ControlMapping.ControlNumberDefine.Add(ContrlAttribute.FormItemId,
            //        xmlNode.Attributes["numberDefine"].Value);
            //}
            if (xmlNode.Attributes["defaultValue"] != null)
            {
                ControlMapping.DefaultValues.Add(ContrlAttribute.FormItemId, xmlNode.Attributes["defaultValue"].Value);
            }
            if (xmlNode.Attributes["expression"] != null)
            {
                ControlMapping.ExpressionControls.Add(ContrlAttribute.FormItemId, xmlNode.Attributes["expression"].Value);
            }
            if (xmlNode.Attributes["border"] != null)
            {
                ContrlAttribute.Border = bool.Parse(xmlNode.Attributes["border"].Value);
            }

            if (ContrlAttribute.FormItemType == 2)
            {
                if (xmlNode.Attributes["comboxEdit"] != null)
                {
                    if (xmlNode.Attributes["comboxEdit"].Value == "true")
                    {
                        ControlMapping.ComboxEditControls.Add(ContrlAttribute.ControlId);
                    }
                }
            }
        }

        private void AddControl(XmlNode xmlnode)
        {
            try
            {
                if (xmlnode.Attributes["name"] != null)
                {
                    if (xmlnode.Attributes["name"].Value.Trim().Length == 0)
                    {
                        MessageBox.Show("表单中ID为" + xmlnode.Attributes["id"].Value + "的字段名称为空", "系统提示", MessageBoxButtons.OK);
                    }
                    DockFormDesigner.controlDictionary.AddValue(Convert.ToInt32(xmlnode.Attributes["id"].Value)
                            , xmlnode.Attributes["name"].Value);
                }
                else
                {
                    DockFormDesigner.controlDictionary.AddValue(Convert.ToInt32(xmlnode.Attributes["id"].Value)
                        , xmlnode.Attributes["id"].Value);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "系统提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// zhanben20100919
        /// 获取表单脚本
        /// </summary>
        /// <param name="xpathString">表单脚本</param>
        /// <returns></returns>
        public string GetFormScriptString(string xpathString)
        {
            XmlNode node = formXmlParser.GetNode(xpathString);
            if (node != null)
            {
                return node.InnerText;
            }

            return String.Empty;
        }

    }
}
