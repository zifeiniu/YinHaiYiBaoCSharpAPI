using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using YBYinHaiLibrary;

namespace WebAPIServer.Controller
{
    public class YiBaoController : ApiController
    {
     

        [HttpGet]
        public string InitProcess()
        {
            if (!YBYinHaiBLL.Init(out string msg))
            {
                return msg;
            }
            return "success";

        }

        /// <summary>
        /// 获取医保中心日期
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetYiBaoDate()
        {
            bool result = YBYinHaiBLL.GetYBCenterDate(out DateTime dt, out string msg);

            if (result)
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(new { status = "ture", result = dt.ToLongDateString() });
                
            }
            else
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(new { status = "false", msg= msg });
            }
        }

        /// <summary>
        /// 获取医院开通支付类别
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PayTypeModel GetPayType(string centerCode, string zhengce)
        {
            return YBYinHaiBLL.Get医院开通支付类别(centerCode, zhengce);
        }

        /// <summary>
        /// 获取医院信息
        /// </summary>
        /// <param name="centerCode"></param>
        /// <param name="zhengce"></param>
        /// <returns></returns>
        [HttpGet]
        public HospitalInfoModel GetHospitalInfo()
        {
            return YBYinHaiBLL.Get医院信息();
        }

        /// <summary>
        /// 获取编码对照信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public CodeInfoModel GetCodeInfo()
        {
            return YBYinHaiBLL.Get编码对照信息();
        }


        /// <summary>
        /// 获取医保中心标准目录
        /// </summary>
        /// 
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public YibaoStandCategoryModel GetYibaoStandCategory(string date)
        {
            return YBYinHaiBLL.Get中心医保标准目录(date);
        }


        /// <summary>
        /// 中心目录变更日志
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public CenterChangeLogModel GetCenterChangeLog(string startDate,string endDate)
        {
            return YBYinHaiBLL.Get中心目录变更日志(startDate, endDate);
        }


        /// <summary>
        /// 中心ICD10数据下载
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public CenterICD10DataModel GetCenterICD10Data()
        {
            return YBYinHaiBLL.Get中心ICD10数据下载();
        }

        /// <summary>
        /// §1.9.8.	目录上传
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public YinHaiModelBase SetCategoryUpload(CategoryUploadModel model)
        {
            LogHelper.AddLogMsg("传入Post 目录上传");

            string xmlFileName = (DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()).Replace(':', ' ') + ".json";
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            LogHelper.LogInputXml(xmlFileName, jsonData);

            return YBYinHaiBLL.Set目录上传单个(model);
        }

        /// <summary>
        /// 目录上传多个
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public CategoryUploadOutModel SetCategoryUploadMuit(CategoryUploadModel[] model)
        {
            LogHelper.AddLogMsg("传入Post 目录上传多个");
            string xmlFileName = (DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString()).Replace(':', ' ') + ".json";
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            LogHelper.LogInputXml(xmlFileName, jsonData);
            return YBYinHaiBLL.Set目录上传多个(model);

        }

        
        /// <summary>
        /// 查询上传目录
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [HttpGet]
        public QueryUploadCategoryModel QueryUploadCategory(string dateTime)
        {
            return YBYinHaiBLL.Query查询上传目录(dateTime);
        }

        /// <summary>
        /// 上传目录删除
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        [HttpGet]
        public YinHaiModelBase DeleteUploadCategory(string HosItemCode)
        {
            return YBYinHaiBLL.Delete删除上传目录(HosItemCode);
        }

        /// <summary>
        /// 用户身份识别
        /// </summary>
        /// <param name="HosItemCode"></param>
        /// <returns></returns>
        [HttpGet]
        public UserIdentityModel UserIdentity()
        {
            return YBYinHaiBLL.身份识别();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public YinHaiModelBase ChangePassword()
        {
            return YBYinHaiBLL.修改密码();
        }


        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public MenZhenJieSuanOutModel MenZhenCheckOut(MenZhenJieSuanModel model)
        {
            LogHelper.AddLogMsg("传入Post 门诊结算");
            return YBYinHaiBLL.门诊结算(model);
        }

       
        /// <summary>
        /// 结算申请查询
        /// </summary>
        /// <param name="qingsuanNo">清算期号</param>
        /// <returns></returns>
        [HttpGet]
        public QingsuanShenqingQueryOutModel QingsuanShenqingQuery(string qingsuanNo)
        {
            return YBYinHaiBLL.清算申请查询(qingsuanNo);
        }

        /// <summary>
        /// 入院办理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public InHospitalOutModel CreateInHospital(InHospitalModel model)
        {
           
            return YBYinHaiBLL.入院办理(model);
        }

        
        /// <summary>
        /// 清算回退
        /// </summary>
        /// <param name="qingsuanNo"></param>
        /// <returns></returns>
        [HttpPost]
        public YinHaiModelBase QingsuanShenqingBack(QingSuanBackModel qingsuanNo)
        {
            LogHelper.AddLogMsg("传入Post 清算回退");
            if (qingsuanNo == null)
            {
                return CreateErrorMsgModel();
            }
            return YBYinHaiBLL.清算回退(qingsuanNo);
        }


        [HttpPost]
        public string TestPost(TestModel[] model)
        {
            Console.WriteLine(model);
            return "ok";
        }


        [HttpGet]
        public string TestGet()
        {
            return "success";
        }


        [HttpGet]
        public string IsStart()
        {
            return "success";
        }

        /// <summary>
        /// 确认交易
        /// </summary>
        /// <param name="callno">流水号</param>
        /// <param name="callcode">验证码</param>
        /// <returns></returns>
        [HttpGet]
        public YinHaiModelBase yhConfirm(string callno, string callcode)
        {
            return YBYinHaiBLL.yh_confirm(callno, callcode);
        }

        /// <summary>
        /// 取消交易
        /// </summary>
        /// <param name="callno"></param>
        /// <param name="callcode"></param>
        /// <returns></returns>
        [HttpGet]
        public YinHaiModelBase yhCancel(string callno, string callcode)
        {
            return YBYinHaiBLL.yh_Cancel(callno, callcode);
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callno">交易编号</param>
        /// <returns></returns>
        [HttpGet]
        public UncertaintytradeModel yhGetuncertaintytrade(string callno = "")
        {
            return YBYinHaiBLL.yh_Getuncertaintytrade(callno);
        }

        /// <summary>
        /// 清算单明细打印
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public YinHaiModelBase qingsuanmingxi(QingsuanPrintModel model)
        {
            if (model == null)
            {
                return CreateErrorMsgModel();
            }
            return YBYinHaiBLL.清算单明细打印(model);
        }

        /// <summary>
        /// 清算申请单打印
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public YinHaiModelBase qingsuanshenqingPrint(QingsuanShenQingPrintModel model)
        {
            if (model == null)
            {
                return CreateErrorMsgModel();
            }
            return YBYinHaiBLL.清算申请单打印(model);
        }

        /// <summary>
        /// 清算申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public YinHaiModelBase QingsuanShenqing(QingsuanShenqingModel model)
        {
            LogHelper.AddLogMsg("传入Post 清算申请");
            if (model == null)
            {
                return CreateErrorMsgModel();
            }
            return YBYinHaiBLL.清算申请(model);
        }



        [HttpGet]
        public YinHaiModelBase menzhenteshu(string name)
        {
            return YBYinHaiBLL.门诊特殊病申请(name);
        }

        /// <summary>
        /// 结算_退费信息查询
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        public CheckFeeQueryModel  CheckFeeQuery(string startDate, string endDate)
        {
            return YBYinHaiBLL.结算_退费信息查询(startDate, endDate);
        }

        [HttpPost]
        public YinHaiModelBase JiesuanBack(JieSuanBackModel model)
        {
            LogHelper.AddLogMsg("传入Post 结算回退");
            if (model == null)
            {
                return CreateErrorMsgModel();
            }
            return YBYinHaiBLL.结算回退(model);
        }

        private YinHaiModelBase CreateErrorMsgModel(string _msg = "POST 请求参数转换失败")
        {
            return new YinHaiModelBase() { status = false, msg = _msg };
        }



    }

     

    public class TestModel
    {
        public string id;

    }
}
