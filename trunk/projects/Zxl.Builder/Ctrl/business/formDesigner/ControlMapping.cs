using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using FormDesigner.Common;

namespace FormDesigner
{
    public class ControlMapping
    {
        private XmlParser _xmlparser;

        private ControlMapping()
        {
            _xmlparser = new XmlParser(AppDomain.CurrentDomain.BaseDirectory + @"configuration//control.xml");
        }

        private static ControlMapping _instance;
        public static ControlMapping GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ControlMapping();
            }
            return _instance;
        }

        
        public static ArrayList ReadControls = new ArrayList();
        public static ArrayList NotPrintControls = new ArrayList();
        public static ArrayList ComboxEditControls = new ArrayList();
        public static Dictionary<int,string> ControlRelation = new Dictionary<int,string>();
        public static Dictionary<int, string> ControlTip = new Dictionary<int, string>();
        public static Dictionary<int, string> ControlNumberDefine = new Dictionary<int, string>();
        public static Dictionary<int, string> DefaultValues = new Dictionary<int, string>();
        public static Dictionary<int, string> ExpressionControls = new Dictionary<int, string>();
        /// <summary>
        /// add IsPrintWhenArchive属性控件列表
        /// </summary>
        public static Dictionary<int, string> PrintWhenArchiveControls = new Dictionary<int, string>();

        public XmlNode GetControlExtention(string formItemType)
        {
            string xpath = string.Format("/Config/ControlExtention/control[@formItemType='{0}']", formItemType);
            return _xmlparser.GetNode(xpath);
        }

        public string GetExtensionTypeId(string formItemType,string name)
        {
            string xpath = string.Format("/Config/ControlExtention/control[@formItemType='{0}']/Item[@name='{1}']",
                        formItemType, name);
            return _xmlparser.GetNodeAttributeValue(xpath,"id");
        }

        public string GetExtensionTypeName(string formItemType, string id)
        {
            string xpath = string.Format("/Config/ControlExtention/control[@formItemType='{0}']/Item[@id='{1}']",
                        formItemType, id);
            return _xmlparser.GetNodeAttributeValue(xpath, "name");
        }

        public string GetDistControl(string formItemType)
        {
            string xpath = string.Format("/Config/Mapping/Item[@formItemType='{0}']", formItemType);
            return _xmlparser.GetNodeAttributeValue(xpath, "dist");
        }

        public string GetFormItemType(string distName)
        {
            string xpath = string.Format("/Config/Mapping/Item[@distname='{0}']", distName);
            return _xmlparser.GetNodeAttributeValue(xpath, "formItemType");
        }

        public string GetDistname(string formItemType)
        {
            string xpath = string.Format("/Config/Mapping/Item[@formItemType='{0}']", formItemType);
            return _xmlparser.GetNodeAttributeValue(xpath, "distname");
        }

        public Dictionary<string,string> GetAllControls()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (XmlNode node in _xmlparser.GetNode(string.Format("/Config/Mapping")))
            {
                dic.Add(node.Attributes["id"].Value, node.Attributes["name"].Value);
            }
            return dic;
        }

        public Dictionary<string, string> GetAllCategories()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (XmlNode node in _xmlparser.GetNode(string.Format("/Config/Mapping")))
            {
                if (!dic.ContainsValue(node.Attributes["Category"].Value))
                {
                    dic.Add(Guid.NewGuid().ToString(), node.Attributes["Category"].Value);
                }
            }
            return dic;
        }

        public Dictionary<string, string> GetControlsByCategory(string category)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (XmlNode node in _xmlparser.GetNodes(string.Format("/Config/Mapping/Item[@Category='{0}']", category)))
            {
                dic.Add(node.Attributes["id"].Value, node.Attributes["name"].Value);
            }
            return dic;
        }

        public string GetDataProvider()
        {
            string xpath = string.Format("/Config/DataProvider/Item[@key='{0}']", "DesignDataProvider");
            return _xmlparser.GetNodeAttributeValue(xpath, "assembly");
        }
    }
}
