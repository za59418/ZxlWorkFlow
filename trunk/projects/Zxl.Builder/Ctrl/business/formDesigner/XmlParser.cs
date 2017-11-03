using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FormDesigner
{
    /// <summary>
    /// xml配置类
    /// </summary>
    public class XmlParser
    {
        public XmlDocument _doc;
        private string _filepath;

        public XmlDocument xmlDocument
        {
            get { return _doc; }
        }

        public XmlParser(string xmlContent,bool isXml)
        {
            try
            {
                _doc = new XmlDocument();
                _doc.LoadXml(xmlContent);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("xmlContent:{0}'{1}'{0}不是有效的Xml格式字符串.", Environment.NewLine, xmlContent), ex);
            }

        }

        public XmlParser(string xmlContent)
        {
            try
            {
                if (System.IO.File.Exists(xmlContent))
                {
                    _doc = new XmlDocument();
                    _doc.Load(xmlContent);
                    _filepath = xmlContent;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("xmlContent:{0}'{1}'{0}不是有效的Xml格式字符串.", Environment.NewLine, xmlContent), ex);
            }

        }

        public System.Xml.XmlNode GetNode(string xpath)
        {
            System.Xml.XmlNode node = null;
            if (_doc != null)
            {
                node = _doc.DocumentElement.SelectSingleNode(xpath);
            }
            return node;
        }

        public System.Xml.XmlNodeList GetNodes(string xpath)
        {
            System.Xml.XmlNodeList nodes= null;
            if (_doc != null)
            {
                nodes = _doc.DocumentElement.SelectNodes(xpath);
            }
            return nodes;
        }

        public string GetNodeAttributeValue(string xpath, string attrName)
        {
            System.Xml.XmlNode node = GetNode(xpath);
            if (node != null)
            {
                if (node.Attributes[attrName] != null)
                {
                    return node.Attributes[attrName].Value;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return "";
            }
        }

        public static int GetAttributeInt32Value(XmlNode controlNode, string attributeName)
        {
            string attValue = GetAttributeValue(controlNode, attributeName);
            return Convert.ToInt32(attValue);
        }

        public static string GetAttributeValue(XmlNode controlNode, string attributeName)
        {
            string attValue = "";
            try
            {
                attValue = controlNode.Attributes[attributeName].Value;
                return attValue;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteNode(string xpath)
        {
            XmlNodeList xnlst = _doc.DocumentElement.SelectNodes(xpath);
            if (xnlst != null)
            {
                foreach (XmlNode xn in xnlst)
                {
                    xn.RemoveAll();
                    xn.ParentNode.RemoveChild(xn);
                    _doc.Save(_filepath);
                    
                }
            }
        }

        public void AddNode(string xpath ,XmlNode xmlNode)
        {
            XmlNode xnl = _doc.DocumentElement.SelectSingleNode(xpath);
            xnl.AppendChild(xmlNode);
            _doc.Save(_filepath);
        }

        public void DocSave()
        {           
            _doc.Save(_filepath);
        }

    }

}
