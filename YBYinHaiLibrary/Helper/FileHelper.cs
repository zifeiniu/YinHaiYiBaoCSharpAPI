using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    public static class FileHelper
    {

        /// <summary>
        /// 默认文件后缀
        /// </summary>
        const string DefaultFileSuffix = ".txt";

        /// <summary>
        /// TAP 文件分隔符
        /// </summary>
        static char[] FileTabChar = new char[] { '\r', ' ' };


        /// <summary>
        /// 获取临时文件输出目录
        /// </summary>
        /// <returns></returns>
        private static string GetOutputFileDir()
        {

            if (YBYinHaiBLL.IsMock)
            {
                return Environment.CurrentDirectory + "\\" + "YinHaiOutFile";
            }
            else
            {

                return string.IsNullOrWhiteSpace(YBYinHaiBLL.YiBaoPath) ? System.Environment.GetEnvironmentVariable("TEMP") : YBYinHaiBLL.YiBaoPath;

                //string Path = Environment.GetFolderPath(Environment.SpecialFolder.Templates, Environment.SpecialFolderOption.DoNotVerify);

            }


        }

        /// <summary>
        /// 在临时文件夹里创建一个随机文件地址
        /// </summary>
        /// <returns></returns>
        public static string GetRandomFilePath(string fileName = "")
        {
            string FileDir = GetOutputFileDir();


            if (!YBYinHaiBLL.IsMock)
            {
            
                fileName += GetDtFileName();
            }
            return FileDir + "\\" + fileName + DefaultFileSuffix;
        }

        public static string GetDtFileName() {
            DateTime dt = DateTime.Now;

            string[] array = new string[]
            {
                dt.Year.ToString(),
                dt.Month.ToString(),
                dt.Day.ToString(),
                dt.Hour.ToString(),
                dt.Minute.ToString(),
                dt.Second.ToString(),
                dt.Millisecond.ToString()
            };
            return string.Join("-", array);
        }





        /// <summary>
        /// 解析文件格式为TAB分割的文本
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ConverTapFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] allLine = File.ReadAllLines(filePath);
                if (allLine.Length > 0)
                {
                    string[] allTittle = allLine[0].Split(FileTabChar);

                    JObject jObject = new JObject();
                    for (int i = 1; i < allLine.Length; i++)
                    {

                    }

                }

            }

            return "";
        }

        static Random r = new Random();
        public static string GetDatetimeFileName()
        {
            return (DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()).Replace(':', ' ') + "-" + r.Next(1,10000);
        }

        static string DebugDirName = "DebugJson";

        public static void SaveDealModeltoJsonFile(DealModel model)
        {
            try
            {
                if (YBYinHaiBLL.NeedLog)
                {
                    if (!Directory.Exists(DebugDirName))
                    {
                        Directory.CreateDirectory(DebugDirName);
                    }
                    string fileName = model.CallName + model.astr_jybh + "-" + GetDatetimeFileName() + ".json";

                    string jsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    StreamWriter sw = File.CreateText(DebugDirName + "\\" + fileName);
                    sw.WriteLine(jsonValue);
                    sw.Close();
                }
                     
            }
            catch (Exception)
            {

                
            }
        }

        public static DealModel ReadjsonFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return (DealModel)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData,typeof(DealModel));
            }
            return null;

        }
    }
}
