using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    public class LogHelper
    {
        public static void AddErrorMsg(string msg)
        {
            if (LogAction != null)
            {
                LogAction(msg);
            }

        }
        public static void AddLogMsg(string msg)
        {

            if (LogAction != null)
            {
                LogAction(msg);
            }
        }


        public static Action<string> LogAction;


        public static void LogInputXml(string fileName,string xml)
        {
            if (YBYinHaiBLL.NeedLog)
            {
                if (!System.IO.Directory.Exists("log"))
                {
                    System.IO.Directory.CreateDirectory("log");
                }

                StreamWriter sw = File.CreateText("log/" + fileName);
                sw.WriteLine(xml);
                sw.Close();
            }
        }

        /// <summary>
        /// 记录转换错误
        /// </summary>
        /// <param name="msg"></param>
        public static void AddParseMsg(string msg)
        {
            if (LogAction!= null)
            {
                LogAction(msg);
            }
            
             
        }
    }
}
