using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YBYinHaiLibrary
{
    public class JsonHelper
    {

        /// <summary>
        /// 返回的Json的属性，是否需要中文说明，还是银海原始编码
        /// </summary>
        static bool NeedInfo=false;

        /// <summary>
        /// 转换Dic 到Json
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string ConvertDicToJson(Dictionary<string, string> dic,string typeName)
        {
            JObject json = new JObject();
            foreach (var item in dic.Keys)
            {
                json.Add(item, dic[item]);
            }
            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        /// <summary>
        /// 转换File 文件到Json
        /// </summary>
        /// <returns></returns>
        public static string ConvertFileToJson(string fileName)
        {
            return "";

        }
    }
}
