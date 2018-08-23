using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;


namespace YBYinHaiLibrary
{
    internal static class YinHaiCOM
    {
        /// <summary>
        /// DLL 目录
        /// </summary>
        //private static string DLLDirName = "yinhai";
        private const string DLLSystemDirPath32 = @"C:\Windows\System32\";
        private const string DLLSystemDirPath64 = @"C:\Windows\SysWOW64\";

        private static string[] DllNameArray = new string[] { "yh_interface.dll", "yh_local.dll","autodownloadCOM.dll","yh_interfaceproxy.dll", "winsockhc.dll" };


        /// <summary>
        /// 注册Dll
        /// </summary>
        public static bool  RegYinHaiDll(out string msg)
        {
            msg = "";
            bool reslut = true;
            for (int i = 0; i < DllNameArray.Length; i++)
            {
                try
                {
                    
                    string dllPath32 = DLLSystemDirPath32 + DllNameArray[i];
                    string dllPath64 = DLLSystemDirPath64 + DllNameArray[i];

                    if (File.Exists(dllPath32))
                    {
                        RegDll(dllPath32);
                    }
                    else if (File.Exists(dllPath64))
                    {
                        RegDll(dllPath64);
                    }
                    else
                    {
                        reslut = false;
                        msg += "未找到文件" + DllNameArray[i] + ";";
                    }
                }
                catch (Exception)
                {
                    reslut = false;
                }
            }
            return reslut;
        }


        /// <summary>
        /// 注册DLL
        /// </summary>
        /// <returns></returns>
        private static void RegDll(string DllPath)
        {

            Process p = new Process();

            p.StartInfo.FileName = "Regsvr32.exe";

            p.StartInfo.Arguments = "/s \"" + DllPath + "\"";

            p.Start();

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Init(out string msg)
        {

          int  Appcode = -1;
            msg = string.Empty;
            object[] args = new object[] { Appcode, msg };
            yhObject = System.Activator.CreateInstance(yh);
            ParameterModifier pm = new ParameterModifier(2);
            pm[0] = true;
            pm[1] = true;
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_init", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);

            string o1 = args[0].ToString();
            string o2 = args[1].ToString();

            if (Convert.ToInt32(o1) < 0)
            {
                msg = o2;
                return false;
            }

            return true; 
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public static bool Destroy()
        {
           return yh_interface_destroy();
        }




        /// <summary>
        /// 交易主函数，完成所有医疗业务的实际处理（可能存在用户交互界面）
        /// </summary>
        /// <param name="dealModel"></param>
        public static void CallDeal(this DealModel dealModel)
        {

            string xmlFileName = FileHelper.GetDatetimeFileName() + ".xml";
            LogHelper.AddLogMsg( "交易编号" + dealModel.astr_jybh + " :  交易输入XML文件" + xmlFileName);
            LogHelper.LogInputXml(xmlFileName, dealModel.astr_jysr_xml);

            if (!YBYinHaiBLL.IsMock)
            {
                 
                try
                {
                    yh_interface_call(dealModel.astr_jybh, dealModel.astr_jysr_xml, ref dealModel.astr_jylsh, ref dealModel.astr_jyyzm, ref dealModel.astr_jysc_xml, ref dealModel.along_appcode, ref dealModel.Msg);
                }
                catch (Exception ex)
                {
                    dealModel.along_appcode = -1;
                    dealModel.Msg = "YinHaiCall Exception :" + ex.Message;
                }

            }
            else
            {
                dealModel .astr_jysc_xml = TestHelper.GetTestFile(dealModel.astr_jybh);
                dealModel.along_appcode = 1;
            }
            FileHelper.SaveDealModeltoJsonFile(dealModel);

        }



        /// <summary>
        /// 确认交易(只需要传入流水号，和交易码来确认交易)
        /// </summary>
        /// <param name="dealModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void ConfirmDeal(this DealModel dealModel)
        {
            yh_interface_confirm(dealModel.astr_jylsh, dealModel.astr_jyyzm, ref dealModel.along_appcode, ref dealModel.Msg);   
        }

        /// <summary>
        /// 取消交易（只需要传入交易流水号）
        /// </summary>
        /// <param name="dealModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void CancelDeal(this DealModel dealModel)
        {
            yh_interface_cancel(dealModel.astr_jylsh, ref dealModel.along_appcode, ref dealModel.Msg);
        }

        /// <summary>
        /// 查询不确定的交易
        /// </summary>
        /// <param name="dealModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void Getuncertaintytrade(this DealModel dealModel)
        {
            yh_interface_getuncertaintytrade(dealModel.astr_jybh, ref dealModel.astr_jysc_xml, ref dealModel.along_appcode, ref dealModel.Msg);
        }



        /// <summary>
        /// yh_interface_init(ref long along_appcode,ref string astr_appmsg)
        /// 初始化函数，HIS应用启动时调用，进行医保交易处理初始化，本交易调用成功后才能进行其他交易处理。
        /// </summary>
        /// <param name="along_appcode">along_appcode >= 0 ，初始化成功；</param>
        /// <param name="astr_appmsg">along_appcode 小于 0 ，初始化失败，astr_appmsg 错误信息</param>
        //[DllImport("yh_interface.dll",EntryPoint = "yh_interface_init")]
        //private static extern void yh_interface_init(ref long along_appcode, out string astr_appmsg);
        static System.Type yh = Type.GetTypeFromProgID("yinhai.xian.interface");

       static  Object yhObject;



        /// <summary>
        /// 资源释放函数，在HIS应用退出时调用
        /// /// </summary>
        //[DllImport("yh_interface.dll")]
        //private static extern void yh_interface_destroy();
        private static bool yh_interface_destroy()
        {
            try
            {
                yh.InvokeMember("yh_interface_destroy", BindingFlags.InvokeMethod, null,
                         yhObject, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }



        //        参数名称 参数含义    参数类型 参数类别    参数说明
        //astr_jybh   交易编号 String  入口参数 具体的交易代码见〖交易列表〗

        //astr_jysr_xml 交易输入    String 入口参数    xml方式，组织方式见业务说明，字符串最大长度65534字符
        //astr_jylsh  交易流水号 String  出口参数 唯一标识一次交易，VARCHAR(20)
        //astr_jyyzm 交易验证码   String 出口参数    处理类交易返回，确认交易时传入
        //VARCHAR(15)
        //astr_jysc_xml 交易输出    String 出口参数    xml方式，组织方式见业务说明
        //along_appcode   交易标志 long 出口参数    小于0均为失败。此值数据类型是整数，范围为-2147483648 to +2147483647
        //astr_appmsg 交易信息    String 出口参数    错误信息描述。along_appcode小于0时存放错误描述，其他along_appcode>=0时不用关心该参数内容。
        //[DllImport("yh_interface.dll")]
        //private static extern void yh_interface_call(string astr_jybh,string astr_jysr_xml,ref string astr_jylsh,ref string astr_jyyzm,ref string astr_jysc_xml,ref long along_appcode,ref string astr_appmsg);

        private static void yh_interface_call(string astr_jybh, string astr_jysr_xml, ref string astr_jylsh, ref string astr_jyyzm, ref string astr_jysc_xml, ref int along_appcode, ref string astr_appmsg)
        {
            
            object[] args = new object[] {astr_jybh,astr_jysr_xml,
                        astr_jylsh,astr_jyyzm,astr_jysc_xml, along_appcode, astr_appmsg };

            ParameterModifier pm = new ParameterModifier(7);
            pm[0] = false;
            pm[1] = false;
            pm[2] = true;
            pm[3] = true;
            pm[4] = true;
            pm[5] = true;
            pm[6] = true;
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_call", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            object o1 = args[1].ToString();

            astr_jylsh = args[2].ToString();
            astr_jyyzm = args[3].ToString();
            astr_jysc_xml = args[4].ToString();
            along_appcode = Convert.ToInt32(args[5].ToString());
            astr_appmsg = args[6].ToString();
 

        }


        //[DllImport("yh_interface.dll")]
        //private static extern void yh_interface_confirm(string astr_jylsh, string astr_jyyzm, ref int along_appcode, ref string astr_appmsg);
        private static  void yh_interface_confirm(string astr_jylsh, string astr_jyyzm, ref int along_appcode, ref string astr_appmsg)
        {

            object[] args = new object[] {astr_jylsh,astr_jyyzm,
                        along_appcode,astr_appmsg };

            ParameterModifier pm = new ParameterModifier(4);
            pm[0] = false;
            pm[1] = false;
            pm[2] = true;
            pm[3] = true;
        
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_confirm", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            object o1 = args[1].ToString(); 

            along_appcode = Convert.ToInt32(args[2].ToString());
            astr_appmsg = args[3].ToString();


        }



        //[DllImport("yh_interface.dll")]
        //private static extern void yh_interface_cancel(string astr_jylsh, ref int along_appcode, ref string astr_appmsg);
        private static void yh_interface_cancel(string astr_jylsh, ref int along_appcode, ref string astr_appmsg)
        {
            object[] args = new object[] {astr_jylsh,along_appcode,astr_appmsg };

            ParameterModifier pm = new ParameterModifier(3);
            pm[0] = false;
            pm[1] = true;
            pm[2] = true; 

            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_cancel", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
           
            along_appcode = Convert.ToInt32(args[1].ToString());
            astr_appmsg = args[2].ToString();
        }


        //[DllImport("yh_interface.dll")]
        //private static extern void yh_interface_getuncertaintytrade(string astr_jybh, ref string astr_jgxml, ref int along_appcode, ref string astr_appmsg);
        private static void yh_interface_getuncertaintytrade(string astr_jybh, ref string astr_jgxml, ref int along_appcode, ref string astr_appmsg)
        {
            object[] args = new object[] { astr_jybh, astr_jgxml, along_appcode, astr_appmsg };

            ParameterModifier pm = new ParameterModifier(4);
            pm[0] = false; 
            pm[1] = true;
            pm[2] = true;
            pm[3] = true;
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_getuncertaintytrade", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            astr_jgxml = args[1].ToString();
            along_appcode = Convert.ToInt32(args[2].ToString());
            astr_appmsg = args[3].ToString();
        }


        private static void teset()
        {
            string Businesssequence = null;
            string Businessvalidate = null;
            string Outputxml = null;
            string Appcode = null;
            string Appmsg = null;
            
            string BusinessID = "91";
            string Dataxml = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\" ?>"
                + "<input>"
                + "<prm_yae036>2000-01-01</prm_yae036>"
                + "<prm_outputfile>C:\\Items.TXT</prm_outputfile>"
                + "</input>";
            object[] args = new object[] {BusinessID,Dataxml,
                        Businesssequence,Businessvalidate,Outputxml, Appcode, Appmsg };

            ParameterModifier pm = new ParameterModifier(7);
            pm[0] = false;
            pm[1] = false;
            pm[2] = true;
            pm[3] = true;
            pm[4] = true;
            pm[5] = true;
            pm[6] = true;
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_call", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            object o1 = args[1].ToString();
            object o2 = args[2].ToString();
            object o3 = args[3].ToString();
            object o4 = args[4].ToString();
            object o5 = args[5].ToString();
            object o6 = args[6].ToString();

        }

    }
}
