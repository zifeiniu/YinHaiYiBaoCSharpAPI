using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 银海操作类封装
    /// </summary>
    public static class YBYinHaiBLL
    {
        /// <summary>
        /// 是否是模拟数据
        /// </summary>
        public static bool IsMock =false;

        /// <summary>
        /// 是否记录日志
        /// </summary>
        public static bool NeedLog = false;

        /// <summary>
        /// 医保目录储存地址
        /// </summary>
        public static string YiBaoPath = null;

        #region 通用


        /// <summary>
        /// 注册DLL
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RegYinHaiDll(out string msg)
        {
            return YinHaiCOM.RegYinHaiDll(out msg);
        }

        /// <summary>
        /// 初始化Dll
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Init(out string msg)
        {
            return YinHaiCOM.Init(out msg);
        }

        /// <summary>
        /// 同步医保中心时间为本机时间
        /// </summary>
        /// <returns></returns>
        public static bool SyncDate()
        {
            if (GetYBCenterDate(out DateTime dateTime, out string msg))
            {
                return DateHelper.SyncTime(dateTime);
            }
            return false;
        }

        /// <summary>
        /// 获取医保中心日期
        /// </summary>
        /// <returns></returns>
        public static bool GetYBCenterDate(out DateTime dateTime, out string msg)
        {
            dateTime = DateTime.MinValue;

            DealModel deal = new DealModel("52");

            deal.CallName = "获取医保中心时间";

            deal.CallDeal();

            msg = deal.Msg;

            if (deal.IsYanHaiSuccess)
            {
                Dictionary<string, string> dicAll = XMLHelper.GetDicFromXML(deal.astr_jysc_xml, DealModel.xPathSubRow);
                if (dicAll.TryGetValue("prm_sysdate", out string value))
                {
                    if (DateTime.TryParse(value, out dateTime))
                    {
                        return true;
                    }
                    else
                    {
                        msg = "格式转换失败";
                    }
                }
            }

            return false;

        }

        public static void TestDealModelCall(DealModel dealModel)
        {
            dealModel.CallDeal();
        }


        public static HospitalInfoModel Get医院信息()
        {
            DealModel deal = new DealModel("04");
            deal.CallName = "获取医院信息";
            deal.CallDeal();
            deal.SetXpathTypeTop();
            deal.CreateResultModel(new HospitalInfoModel());
            return (HospitalInfoModel)deal.ReslutModel;
        }

        /// <summary>
        /// Get医院开通支付类别
        /// </summary>
        /// <returns></returns>
        public static PayTypeModel Get医院开通支付类别(string centerCode, string zhengce)
        {
            //< prm_yab003 > 分中心编码 </ prm_yab003 >
            //< prm_ykb065 > 执行的社保政策 </ prm_ykb065 >
            Dictionary<string, string> dic = GetDic("prm_yab003", centerCode, "prm_ykb065", zhengce);

            DealModel deal = new DealModel("05a", dic);
            deal.CallName = "获取医院开通支付类别";
            deal.CallDeal();
            deal.CreateResultModel(new PayTypeModel());
            return (PayTypeModel)deal.ReslutModel;
        }
        #endregion


        #region 中心目录等


        /// <summary>
        /// §1.9.4.	编码对照信息获取
        /// </summary>
        /// <returns></returns>
        public static CodeInfoModel Get编码对照信息()
        {
            DealModel deal = new DealModel("57");
            deal.CallName = "获取编码对照信息";
            deal.CallDeal();
            deal.CreateResultModel(new CodeInfoModel());
            return (CodeInfoModel)deal.ReslutModel;
        }

        /// <summary>
        /// §1.9.5.	获取中心医保标准目录
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static YibaoStandCategoryModel Get中心医保标准目录(string date)
        {
            //< prm_yae036 > 变更时间 </ prm_yae036 >
            //< prm_outputfile > 输出文件绝对路径和文件名 </ prm_outputfile >

            string filePath = FileHelper.GetRandomFilePath("医保中心标准目录");

            Dictionary<string, string> dic = GetDic("prm_yae036", date, "prm_outputfile", filePath);

            DealModel deal = new DealModel("91", dic);

            deal.OutputFilePath = filePath;
            deal.CallName = "获取中心医保标准目录";
            deal.CallDeal();

            deal.CreateResultModel(new YibaoStandCategoryModel());
            return (YibaoStandCategoryModel)deal.ReslutModel;
        }

        /// <summary>
        /// §1.9.37.	结算、退费信息查询（含门诊和住院）(
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static CheckFeeQueryModel 结算_退费信息查询(string startDate,string endDate)
        {
            //< prm_begindate > 开始日期 </ prm_begindate >
            //< prm_enddate > 结束日期 </ prm_enddate >
            //< prm_outputfile > 输出文件绝对路径和文件名 </ prm_outputfile >

            string filePath = FileHelper.GetRandomFilePath("结算_退费信息查询");
             

            Dictionary<string, string> dic =  new Dictionary<string, string> ();
            dic.Add("prm_begindate", startDate);
            dic.Add("prm_enddate", endDate);
            dic.Add("prm_outputfile", filePath);

            DealModel deal = new DealModel("46A", dic);

            deal.OutputFilePath = filePath;
            deal.CallName = "结算_退费信息查询";
            deal.CallDeal();

            deal.CreateResultModel(new CheckFeeQueryModel());
            return (CheckFeeQueryModel)deal.ReslutModel;
        }

        

        /// <summary>
        /// §1.9.6.	获取中心目录变更日志
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static CenterChangeLogModel Get中心目录变更日志(string startDate, string endDate)
        {
            string filePath = FileHelper.GetRandomFilePath("中心目录变更日志");

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("prm_begindate", startDate);
            dic.Add("prm_enddate", endDate);
            dic.Add("prm_outputfile", filePath);

            DealModel deal = new DealModel("RZ01", dic);
            deal.CallName = "获取中心目录变更日志";
            deal.OutputFilePath = filePath;
            deal.CallDeal();
            deal.CreateResultModel(new CenterChangeLogModel());
            return (CenterChangeLogModel)deal.ReslutModel;
        }

        /// <summary>
        /// §1.9.7.	中心ICD10数据下载
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static CenterICD10DataModel Get中心ICD10数据下载()
        {
            string filePath = FileHelper.GetRandomFilePath("中心ICD10数据下载");

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("prm_outputfile", filePath);
            DealModel deal = new DealModel("61", dic);
            deal.CallName = "中心ICD10数据下载";
            deal.OutputFilePath = filePath;

            deal.CallDeal();

            deal.CreateResultModel(new CenterICD10DataModel());
            return (CenterICD10DataModel)deal.ReslutModel;
        }

        /// <summary>
        /// 1.9.8 目录上传
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CategoryUploadOutModel Set目录上传多个(CategoryUploadModel[] model)
        {
            CategoryUploadOutModel result = new CategoryUploadOutModel();
            result.resultItems = new List<StatusModel>();
            result.status = true;
            for (int i = 0; i < model.Length; i++)
            {
                try
                {
                    YinHaiModelBase r = Set目录上传单个(model[i]);
                    if (r.status)
                    {
                        result.resultItems.Add(new StatusModel() { status = true, code = model[i].医院项目编码 });
                    }
                    else
                    {
                        result.resultItems.Add(new StatusModel() { status = false, code = model[i].医院项目编码, msg = r.msg });
                        result.status = false;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.AddErrorMsg("多个目录上传多个报错" + ex.Message);
                }
            }
            return result;


        }

        public static YinHaiModelBase Set目录上传单个(CategoryUploadModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);

            DealModel deal = new DealModel("T01", dicArray);

            deal.CallDeal();
            deal.CallName = "目录上传";

            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }


        /// <summary>
        /// §1.9.9.	查询上传目录
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static QueryUploadCategoryModel Query查询上传目录(string dateTime)
        {
            string filePath = FileHelper.GetRandomFilePath("查询上传目录");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("prm_outputfile", filePath);
            dic.Add("prm_sqsj", dateTime);
            DealModel deal = new DealModel("T02", dic);

            deal.OutputFilePath = filePath;

            deal.CallDeal();
            deal.CallName = "查询上传目录";
            deal.CreateResultModel(new QueryUploadCategoryModel());
            return (QueryUploadCategoryModel)deal.ReslutModel;
        }

        /// <summary>
        /// §1.9.10.	删除上传目录
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static YinHaiModelBase Delete删除上传目录(string HosItemCode)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("prm_xmbm", HosItemCode);
            DealModel deal = new DealModel("T04", dic);

            deal.CallDeal();
            deal.CallName = "删除上传目录";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }
        #endregion

        #region 个人信息
        /// <summary>
        /// 1.9.11 身份识别
        /// </summary>
        /// <returns></returns>
        public static UserIdentityModel 身份识别()
        {
            DealModel deal = new DealModel("03");

            deal.CallDeal();
            deal.CallName = "身份识别";
            deal.SetXpathTypeTop();

            deal.CreateResultModel(new UserIdentityModel());
            return (UserIdentityModel)deal.ReslutModel;
        }

        /// <summary>
        /// 1.9.12 修改密码
        /// </summary>
        /// <param name="HosItemCode"></param>
        /// <returns></returns>
        public static YinHaiModelBase 修改密码()
        {
            DealModel deal = new DealModel("02");

            deal.CallDeal();
            deal.CallName = "修改密码";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }

        #endregion

        #region 门诊结算


        /// <summary>
        /// 1.9.13 门诊结算
        /// </summary>
        /// <param name="HosItemCode"></param>
        /// <returns></returns>
        public static MenZhenJieSuanOutModel 门诊结算(MenZhenJieSuanModel model)
        {
            StringBuilder SbxmlConten = new StringBuilder();
            SbxmlConten.Append(XMLHelper.XmlHeader);

            SbxmlConten.Append("<input>");

            SbxmlConten.Append(XMLHelper.DicConvertToXmlNode(YinHaiHelper.ConvertModelToDic(model)));

            SbxmlConten.Append("<dataset>");

            for (int i = 0; i < model.Items.Count; i++)
            {
                SbxmlConten.Append("<row>");
                SbxmlConten.Append(XMLHelper.DicConvertToXmlNode(YinHaiHelper.ConvertModelToDic(model.Items[i])));
                SbxmlConten.Append("</row>");

            }

            SbxmlConten.Append("</dataset>");
            SbxmlConten.Append("</input>");


            DealModel deal = new DealModel("48", SbxmlConten.ToString());
            deal.CallName = "门诊结算";
            deal.CallDeal();
            deal.SetXpathTypeTop();
            deal.CreateResultModel(new MenZhenJieSuanOutModel());
            return (MenZhenJieSuanOutModel)deal.ReslutModel;
        }
        #endregion


        #region 清算
        /// <summary>
        ///  清算申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static YinHaiModelBase 清算申请(QingsuanShenqingModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);

            DealModel deal = new DealModel("71", dicArray);

            deal.CallDeal();
            deal.SetXpathTypeTop();
            deal.CallName = "申请结算";
            deal.CreateResultModel(new QingsuanShenqingOutModel());
            return (QingsuanShenqingOutModel)deal.ReslutModel;
        }

        /// <summary>
        /// 清算申请查询
        /// </summary>
        /// <param name="qingsuanNo"></param>
        /// <returns></returns>
        public static QingsuanShenqingQueryOutModel 清算申请查询(string qingsuanNo)
        {

            DealModel deal = new DealModel("74a", "prm_yae366", qingsuanNo);

            deal.CallDeal();
            deal.CallName = "清算申请查询";
            deal.CreateResultModel(new QingsuanShenqingQueryOutModel());
            return (QingsuanShenqingQueryOutModel)deal.ReslutModel;
        }

        /// <summary>
        /// 清算回退
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static YinHaiModelBase 清算回退(QingSuanBackModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);
            DealModel deal = new DealModel("73", dicArray);

            deal.CallDeal();
            deal.CallName = "清算回退";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }

        /// <summary>
        /// 结算回退
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static YinHaiModelBase 结算回退(JieSuanBackModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);
            DealModel deal = new DealModel("42", dicArray);

            deal.CallDeal();
            deal.CallName = "结算回退";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }

        #endregion


        #region 住院

        /// <summary>
        /// 入院办理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static InHospitalOutModel 入院办理(InHospitalModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);
            //Prm_ykc292和Prm_ykc296且不能同时存在

            RemoveDicNull(dicArray, "prm_ykc292");
            RemoveDicNull(dicArray, "prm_ykc296");
            if (dicArray.ContainsKey("prm_ykc292") || dicArray.ContainsKey("prm_ykc296"))
            {
                return new InHospitalOutModel() { status = false, msg = "系统要求 居民普通住院病种（prm_ykc296）  和 分娩类型（prm_ykc292） 不能同时存在" };
            }


            DealModel deal = new DealModel("21", dicArray);

            deal.CallDeal();
            deal.CallName = "入院办理";
            deal.CreateResultModel(new InHospitalOutModel());
            return (InHospitalOutModel)deal.ReslutModel;
        }


       /// <summary>
       /// 待遇审批信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public static DaiYuShenpiOutModel 待遇审批信息(DaiYuShenPiModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);
           
            DealModel deal = new DealModel("51", dicArray);

            deal.CallDeal();
            deal.CallName = "待遇审批信息";
            deal.CreateResultModel(new DaiYuShenpiOutModel());
            return (DaiYuShenpiOutModel)deal.ReslutModel;
             
        }

        /// <summary>
        /// 入院办理信息修改
        /// </summary>
        public static YinHaiModelBase 入院办理信息修改(ChargeUserInfo model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);

            DealModel deal = new DealModel("23", dicArray);

            deal.CallDeal();
            deal.CallName = "入院办理信息修改";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;

        }

        /// <summary>
        /// 入院办理回退
        /// </summary>
        public static YinHaiModelBase 入院办理回退(InHospitalModelCallBackModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);

            DealModel deal = new DealModel("22", dicArray);

            deal.CallDeal();
            deal.CallName = "入院办理回退";
            deal.CreateResultModel(new YinHaiModelBase());

            return (YinHaiModelBase)deal.ReslutModel;
        }


        /// <summary>
        /// 入院办理回退？？未完成
        /// </summary>
        public static YinHaiModelBase 住院费用明细写入(InHospitalInfoModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);

            DealModel deal = new DealModel("31", dicArray);

            deal.CallDeal();
            deal.CallName = "入院办理回退";
            deal.CreateResultModel(new YinHaiModelBase());

            return (YinHaiModelBase)deal.ReslutModel;
        }





        #endregion

        #region 私有方法


        /// <summary>
        /// 删除Dic 字典里某个为空的Key
        /// </summary>
        /// <param name="dicArray"></param>
        /// <param name="key"></param>
        private static void RemoveDicNull(Dictionary<string, string> dicArray, string key)
        {
            if (dicArray.TryGetValue(key, out string value))
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    dicArray.Remove(key);
                }
            }
        }


        private static Dictionary<string, string> GetDic(string key1, string value1, string key2, string value2)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(key1, value1);
            dic.Add(key2, value2);
            return dic;

        }
        private static Dictionary<string, string> GetDic(string key, string value)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(key, value);
            return dic;
        }

        #endregion

        #region 打印

        /// <summary>
        /// §1.9.40.	清算单明细打印
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static YinHaiModelBase 清算单明细打印(QingsuanPrintModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);
             
            DealModel deal = new DealModel("72b", dicArray);

            deal.CallDeal();
            deal.CallName = "清算单明细打印";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }

        /// <summary>
        /// §1.9.42.	清算申请单打印
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static YinHaiModelBase 清算申请单打印(QingsuanShenQingPrintModel model)
        {
            Dictionary<string, string> dicArray = YinHaiHelper.ConvertModelToDic(model);

            DealModel deal = new DealModel("75", dicArray);

            deal.CallDeal();
            deal.CallName = "清算申请单打印";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }

        /// <summary>
        /// 门诊特殊病申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static YinHaiModelBase 门诊特殊病申请(string name)
        {
             //< prm_ykc141 > 经办人姓名 </ prm_ykc141 >
            Dictionary<string, string> dicArray = new Dictionary<string, string> ();
            dicArray.Add("prm_ykc141", name);
            DealModel deal = new DealModel("58", dicArray);

            deal.CallDeal();
            deal.CallName = "门诊特殊病申请";
            deal.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)deal.ReslutModel;
        }


        #endregion

        #region 银海其他接口

        /// <summary>
        /// 调用银海确认信息
        /// </summary>
        /// <param name="callno"></param>
        /// <param name="callcode"></param>
        /// <returns></returns>
        public static YinHaiModelBase yh_confirm(string callno, string callcode)
        {
            DealModel dealModel = new DealModel();
            dealModel.astr_jylsh = callno;
            dealModel.astr_jyyzm = callcode;
            dealModel.ConfirmDeal();
            dealModel.CallName = "yh_confirm";
            dealModel.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)dealModel.ReslutModel;
        }

        /// <summary>
        /// 银海接口，取消交易
        /// </summary>
        /// <param name="callno"></param>
        /// <param name="callcode"></param>
        /// <returns></returns>
        public static YinHaiModelBase yh_Cancel(string callno, string callcode)
        {
            DealModel dealModel = new DealModel();
            dealModel.astr_jylsh = callno;
            dealModel.astr_jyyzm = callcode;
            dealModel.CancelDeal();
            dealModel.CallName = "yh_Cancel";
            dealModel.CreateResultModel(new YinHaiModelBase());
            return (YinHaiModelBase)dealModel.ReslutModel;


        }

        public static UncertaintytradeModel yh_Getuncertaintytrade(string callno)
        {
            DealModel dealModel = new DealModel();
            dealModel.astr_jybh = callno;
            dealModel.Getuncertaintytrade();
            dealModel.CallName = "yh_Getuncertaintytrade";
            dealModel.CreateResultModel(new UncertaintytradeModel());
            return (UncertaintytradeModel)dealModel.ReslutModel;

        }

        public static bool Destroy()
        {
            return YinHaiCOM.Destroy();
        }
        #endregion




        #region 通用封装  输入字符串获取字符串，输入Dic获取Dic，输入可为空


        public static bool GetCommonString(string _dealNo, out string result, out string msg)
        {
            return GetCommonString(_dealNo,null,out result, out msg);
        }

        public static bool GetCommonString(string _dealNo,Dictionary<string,string> inputDic ,out string result, out string msg)
        {
            result = "";
            DealModel deal = new DealModel(_dealNo, inputDic);
            deal.CallDeal();
            msg = deal.Msg;

            if (deal.IsYanHaiSuccess)
            {
                result = deal.GetJsonResult();
                return true;
            }

            return false;
        }
 
        
        #endregion
    }
}
