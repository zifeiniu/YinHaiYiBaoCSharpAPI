using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;

namespace SaasHelper
{
    public static class AutoStart
    {
        public const string url = "http://47.92.126.161:8080/yibao/setup.exe";

        static AutoStart() 
        {
            //SetUp 程序目录
            string DirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal, Environment.SpecialFolderOption.DoNotVerify) + "\\";
            string processName = "yibaosetup.exe";
            SetupPath = DirPath + processName;
        }

        private static string SetupPath;

        /// <summary>
        /// 设置Setup为自启动
        /// </summary>
        public static void SetAutorunSetup() 
        {
            if (!System.IO.File.Exists(SetupPath))
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileAsync(new Uri(url), SetupPath);
                    wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                }
                catch (Exception ex)
                {
                   // Logger.Log.AddErrorLog(ex, "下载Setup 出错");    
                }
            }
            else
            {
                SetProcessAutorun(SetupPath);
            }


        }

        static void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                SetProcessAutorun(SetupPath);
            }
            catch (Exception ex)
            {
                
                
            }
        }


        public static void SetCosomt() 
        {
            string processName = Process.GetCurrentProcess().ProcessName + ".exe";
            string ProcessDir = Environment.CurrentDirectory + "\\";
            string path = ProcessDir + processName;

            RegeditAdd("yizhu",path,null);
        }

        /// <summary>
        /// 设置自己为自启动
        /// </summary>
        public static void SetAutorunSelfStart() 
        {
            string processName= Process.GetCurrentProcess().ProcessName + ".exe";
            string ProcessDir = Environment.CurrentDirectory + "\\";
            string path = ProcessDir + processName;
            SetProcessAutorun(path);
        }

        private static void SetProcessAutorun(string path) 
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey SubKey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            object pathO = SubKey.GetValue("yibaoHelper");
            if (pathO == null)
            {
                SetAutoSetup(path);
                return;
            }

            string pathNew = pathO.ToString();
            if (pathNew != path)
            {
                DeleteAutoSetup();
                SetAutoSetup(path);
            }
        
        }

        private static void SetAutoSetup(string path) 
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey SubKey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true);
            SubKey.SetValue("yibaoHelper", path, RegistryValueKind.String);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckAutostart() 
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey SubKey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            object pathO = SubKey.GetValue("yibaoHelper");
            if (pathO == null)
            {
                return false;
            }
            if (pathO.ToString() != SetupPath)
            {
                return false;
            }
            return true;
            
        }

        public static void DeleteAutoSetup()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey SubKey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                SubKey.DeleteValue("yibaoHelper");
            }
            catch (Exception)
            {

                
            }
        }


      /// <summary>
      /// 添加自定义协议
      /// </summary>
      /// <param name="Root_Key"></param>
      /// <param name="file_application_path"></param>
      /// <param name="file_application_ico"></param>
      /// <returns></returns>
        public static bool RegeditAdd(string Root_Key, string file_application_path, string file_application_ico)
        {
            RegistryKey reg_CurrentUser = Registry.CurrentUser;
            try
            {
                //获取注册表CurrentUser/SOFTWARE/Classes项
                RegistryKey reg_Classes = reg_CurrentUser.OpenSubKey("SOFTWARE", true).OpenSubKey("Classes", true);
                RegistryKey reg_key = reg_Classes.OpenSubKey(Root_Key, true);
                if (reg_key == null)
                {
                    RegistryKey reg_sjbs = reg_Classes.CreateSubKey(Root_Key);
                    //添加默认项
                    reg_sjbs.SetValue("", "URL: " + Root_Key + " Protocol Handler");
                    //协议别名
                    reg_sjbs.SetValue("URL Protocol", file_application_path);
                    RegistryKey reg_DefaultIcon = reg_sjbs.CreateSubKey("DefaultIcon");
                    if (!String.IsNullOrEmpty(file_application_ico) || file_application_ico == "")
                    {
                        //设置自定义图标
                        reg_DefaultIcon.SetValue("", file_application_ico);
                    }
                    else
                    {
                        //设置系统定义图标
                        reg_DefaultIcon.SetValue("", file_application_path + ",1");
                    }
                    //呼出处理程序
                    RegistryKey reg_command = reg_sjbs.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command");
                    //%1 表示传递的参数，再次%1表示调用处显示链接文本
                    reg_command.SetValue("", "\"" + file_application_path + "\" \"%1\"");
                }
                return true;
            }
            catch { return false; }
            finally { reg_CurrentUser.Close(); }
        }
    }
}
