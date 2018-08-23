using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 银海 调用Call 封装Model
    /// </summary>
    [Serializable]
    public class DealModel
    {
        #region 构造

        public DealModel() { }

        //public DealModel(string _dealNo) : this(_dealNo, "") { }

        public DealModel(string _dealNo,string inputXml = null)
        {
            this.astr_jybh = _dealNo;
            if (string.IsNullOrEmpty(inputXml))
            {
                this.astr_jysr_xml = XMLHelper.CreateXml();
            }
            else
            {
                this.astr_jysr_xml = inputXml;
            }
        }

        public DealModel(string _dealNo, string Name, string Value)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(Name, Value);

            this.astr_jybh = _dealNo;
            this.astr_jysr_xml = XMLHelper.CreateXml(dic);
        }

        public DealModel(string _dealNo, Dictionary<string, string> dic)
        {
            this.astr_jybh = _dealNo;
            this.astr_jysr_xml = XMLHelper.CreateXml(dic);
        }

        public DealModel(string _dealNo, Dictionary<string, string>[] dic)
        {
            this.astr_jybh = _dealNo;
            this.astr_jysr_xml = XMLHelper.CreateXml(dic);
        }


        /// <summary>
        /// 创建一个交易
        /// </summary>
        /// <param name="_dealNo"></param>
        /// <param name="_InputXml"></param>
        /// <returns></returns>
        public static DealModel CreateDealModelByXMl(string _dealNo, string _InputXml)
        {
            DealModel deal = new DealModel();
            deal.astr_jybh = _dealNo;
            deal.astr_jysr_xml = _InputXml;
            return deal;
        }

        #endregion

        #region 银海接口属性

        /// <summary>
        /// 调用接口名称
        /// </summary>
        public string CallName;

        /// <summary>
        /// 交易编号
        /// </summary>
        public string astr_jybh = string.Empty;

        /// <summary>
        /// 交易输入
        /// </summary>
        public string astr_jysr_xml = string.Empty;

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string astr_jylsh = string.Empty;


        /// <summary>
        /// 交易验证码
        /// </summary>
        public string astr_jyyzm = string.Empty;

        /// <summary>
        ///交易输出
        /// </summary>
        public string astr_jysc_xml = string.Empty;


        /// <summary>
        /// 返回代码，小于0时，返回错误
        /// </summary>
        public int along_appcode = -1;

        #endregion


       /// <summary>
       /// 当前调用名称
       /// </summary>
        public string DealName= string.Empty;

                  /// <summary>
        /// 返回XML时，解析的Xpath 
        /// </summary>
        public string ResultXmlXpath = xPathRows;


        /// <summary>
        /// 输出文件路径
        /// </summary>
        public string OutputFilePath;
        
      

        /// <summary>
        /// 判断银海接口是否返回成功
        /// </summary>
        /// <returns></returns>
        public bool IsYanHaiSuccess 
        {
            get { return along_appcode >= 0; }
        }
         

        /// <summary>
        /// 错误等信息
        /// </summary>
        public string Msg;


        /// <summary>
        ///  获取Json 结果
        /// </summary>
        /// <returns></returns>
        public string GetJsonResult(string className=null)
        {

            ////判断从文件获取还是从返回结果获取
            //if (string.IsNullOrWhiteSpace(OutputFilePath))
            //{
            //    return GetJsonResultFromXML();
            //}
            //else
            //{
            //    return GetJsonResultFromFile();
            //}
            return "";
        }

     

        ///// <summary>
        ///// 从返回的XML里，根据xpath，创建json返回
        ///// </summary>
        ///// <returns></returns>
        //public string GetJsonResultFromXML()
        //{
        //    Dictionary<string,string> dicResult = XMLHelper.GetDicFromXML(this.astr_jysc_xml, ResultXmlXpath);

        //    if (IsSuccess)
        //    {
        //        dicResult.Add("status", "success");
        //    }
        //    else
        //    {

        //    }

        //    return JsonHelper.ConvertDicToJson(dicResult, DealName);

        //}Z
         

        public Dictionary<string, string> GetDicResult()
        {
            return XMLHelper.GetDicFromXML(this.astr_jysc_xml, ResultXmlXpath);
        }

        /// <summary>
        /// 切换Xpaht
        /// </summary>
        public void SetXpathTypeTop()
        {
            ResultXmlXpath = xPathTop;
        }

        /// <summary>
        /// 返回结果常用的 Xpath 
        /// </summary>
        //public const string xPathType1 = "output/sqldata/row/*";
        public const string xPathRows = "output/sqldata/*";
        public const string xPathTop = "output/*";
        public const string xPathSubRow = "output/sqldata/row/*";

        /// <summary>
        /// 是否是多行
        /// </summary>
        public bool IsRows
        {
            get { return ResultXmlXpath == xPathRows; }

        }

        /// <summary>
        /// 最终返回的Model
        /// </summary>
        public YinHaiModelBase ReslutModel;




    }
}
