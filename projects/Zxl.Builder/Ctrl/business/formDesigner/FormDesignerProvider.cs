using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace FormDesigner
{
    /// <summary>
    /// 表单设计器提供者
    /// weixq20100915
    /// </summary>
    public class FormDesignerProvider
    {
        public IFormDesigner GetFormDesigner()
        {
            // weixq20100916 新增根据配置切换表单设计器的功能

            String designerStyle = GetFormDesignerStyle();

            if (designerStyle.Equals("word", StringComparison.InvariantCultureIgnoreCase))
            {
                return new WordStyleFormDesigner();
            }

            return new OriginalStyleFormDesigner();
        }

        /// <summary>
        /// 获取配置的表单设计器风格
        /// weixq20100916
        /// </summary>
        /// <returns></returns>
        public static String GetFormDesignerStyle()
        {
            String configFile = AppDomain.CurrentDomain.BaseDirectory + @"Form//DistFormDesigner.Config";

            if (File.Exists(configFile))
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(configFile);
                    XmlNode node = doc.SelectSingleNode("Config/Designer");
                    if (node != null)
                    {
                        XmlAttribute styleAttribute = node.Attributes["style"];
                        if (styleAttribute != null)
                        {
                            return styleAttribute.Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }

            return "normal";
        }
    }
}
