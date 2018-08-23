using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{


    public static class XMLHelper
    {
        public const string XmlHeader = "<?xml version = \"1.0\" encoding=\"GBK\" standalone=\"yes\"?>";

        /// <summary>
        /// 空的输入XML
        /// </summary>
        public const string EmptyInputXml = "<?xml version = \"1.0\" encoding=\"GBK\" standalone=\"yes\"?><input></input>";

        public const string inputLab = "<input>{0}</input>";

        private const string EmptyLab = "<{0}>{1}</{0}>";


        public static string CreateXml()
        {
            return EmptyInputXml;
        }

        /// <summary>
        /// 创建多个Input的Xml
        /// </summary>
        /// <param name="dicArray"></param>
        /// <returns></returns>
        public static string CreateXml(Dictionary<string, string>[] dicArray)
        {
            StringBuilder sbResult = new StringBuilder();

            for (int i = 0; i < dicArray.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in dicArray[i].Keys)
                {
                    sb.AppendLine(string.Format(EmptyLab, item, dicArray[i][item]));
                }
                sbResult.Append(string.Format(inputLab, sb.ToString()));
            }

            return XmlHeader + sbResult.ToString();
        }

        /// <summary>
        /// Dic 转换为xml
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string DicConvertToXmlNode(Dictionary<string, string> dic)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in dic.Keys)
            {
                sb.AppendLine(string.Format(EmptyLab, item, dic[item]));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 组装固定架构的XML
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string CreateXml(Dictionary<string,string> dic)
        {
            //XML
            //< input>
            // <prm_yab003>分中心编码</prm_yab003>
            // <prm_ykb065>执行的社保政策</prm_ykb065>
            //</input>

            if (dic == null || dic.Count == 0)
            {
                return EmptyInputXml;
            }

            return XmlHeader + string.Format(inputLab, DicConvertToXmlNode(dic)); 

        }

        /// <summary>
        /// 从XML中，根据Xpath转换Dic
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public static Dictionary<string,string> GetDicFromXML(string xmlContent,string xPath )
        {
            Dictionary<string, string> dicAll = new Dictionary<string, string>();

            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(xmlContent);
            var allNodes = xml.SelectNodes(xPath);
            for (int i = 0; i < allNodes.Count; i++)
            {
                string nodeName = allNodes[i].Name.ToLower().Trim();
                if (!dicAll.ContainsKey(nodeName))
                {
                    dicAll.Add(nodeName, allNodes[i].InnerText);
                }
                else
                {
                    LogHelper.AddParseMsg("xml Top 节点内容重复" + nodeName);
                }
            }
            return dicAll;
        }

        /// <summary>
        /// 从XML中的Xpath的多个row中转换多个dic
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public static Dictionary<string, string>[] GetDicArrayFromXML(string xmlContent, string xPath)
        {
            List<Dictionary<string, string>> DicList = new List<Dictionary<string, string>>();

            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(xmlContent);
            var allNodes = xml.SelectNodes(xPath);
            for (int i = 0; i < allNodes.Count; i++)
            {
                if (allNodes[i].Name.ToLower().Trim() == "row")
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    for (int c = 0; c < allNodes[i].ChildNodes.Count; c++)
                    {
                        string nodeName = allNodes[i].ChildNodes[c].Name;
                        if (!dic.ContainsKey(nodeName))
                        {
                            dic.Add(nodeName, allNodes[i].ChildNodes[c].InnerText);
                        }
                        else
                        {
                            LogHelper.AddParseMsg("xml Rows 节点内容重复" + nodeName);
                        }
                    }
                    DicList.Add(dic);
                }
                else
                {
                    LogHelper.AddParseMsg("xml 节点不是row");
                }
            }
            return DicList.ToArray();
        }


        public static string GetStringFromXML(string xmlContent, string xPath)
        {
            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(xmlContent);
            var allNodes = xml.SelectNodes(xPath);
            if (allNodes.Count > 0)
            {
                return allNodes[0].InnerText;
            }

            return "";
        }
    }
}
