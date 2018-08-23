using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 门诊结算输出
    /// </summary>
    public class MenZhenJieSuanOutModel : YinHaiModelBase
    {

        /// <summary>
        /// prm_akc190
        /// </summary>
        [YinHai(XmlAttName = "prm_akc190")]
        public string 就诊编号;

        /// <summary>
        /// prm_yab003
        /// </summary>
        [YinHai(XmlAttName = "prm_yab003")]
        public string 分中心编号;

        /// <summary>
        /// prm_yka103
        /// </summary>
        [YinHai(XmlAttName = "prm_yka103")]
        public string 结算编号;

        /// <summary>
        /// prm_aac001
        /// </summary>
        [YinHai(XmlAttName = "prm_aac001")]
        public string 个人编号;

        /// <summary>
        /// prm_yka065
        /// </summary>
        [YinHai(XmlAttName = "prm_yka065")]
        public string 个人帐户支付金额;

        /// <summary>
        /// prm_aae036
        /// </summary>
        [YinHai(XmlAttName = "prm_aae036")]
        public string 经办时间;

        /// <summary>
        /// prm_yka055
        /// </summary>
        [YinHai(XmlAttName = "prm_yka055")]
        public string 医疗费总额;

        /// <summary>
        /// prm_yka056
        /// </summary>
        [YinHai(XmlAttName = "prm_yka056")]
        public string 全自费金额;

        /// <summary>
        /// prm_yka057
        /// </summary>
        [YinHai(XmlAttName = "prm_yka057")]
        public string 挂钩自付金额;

        /// <summary>
        /// prm_yka111
        /// </summary>
        [YinHai(XmlAttName = "prm_yka111")]
        public string 符合范围金额;

        /// <summary>
        /// prm_yka058
        /// </summary>
        [YinHai(XmlAttName = "prm_yka058")]
        public string 进入起付线金额;

        /// <summary>
        /// prm_yka248
        /// </summary>
        [YinHai(XmlAttName = "prm_yka248")]
        public string 基本医疗统筹支付金额;

        /// <summary>
        /// prm_yka062
        /// </summary>
        [YinHai(XmlAttName = "prm_yka062")]
        public string 大额医疗支付金额;

        /// <summary>
        /// prm_yke030
        /// </summary>
        [YinHai(XmlAttName = "prm_yke030")]
        public string 公务员补助报销金额;

        /// <summary>
        /// prm_yke031
        /// </summary>
        [YinHai(XmlAttName = "prm_yke031")]
        public string 大额商保支付金额;

        /// <summary>
        /// prm_akc087
        /// </summary>
        [YinHai(XmlAttName = "prm_akc087")]
        public string 本次个人账户支付后帐户余额;

        /// <summary>
        /// prm_ykb037
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb037")]
        public string 清算分中心;

        /// <summary>
        /// prm_yka316
        /// </summary>
        [YinHai(XmlAttName = "prm_yka316")]
        public string 清算类别;

        /// <summary>
        /// prm_akc021
        /// </summary>
        [YinHai(XmlAttName = "prm_akc021")]
        public string 医疗人员类别;

        /// <summary>
        /// prm_ykc120
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc120")]
        public string 医疗照顾人员类别;

        /// <summary>
        /// prm_yab139
        /// </summary>
        [YinHai(XmlAttName = "prm_yab139")]
        public string 参保所属分中心;

        /// <summary>
        /// prm_aac003
        /// </summary>
        [YinHai(XmlAttName = "prm_aac003")]
        public string 姓名;

        /// <summary>
        /// prm_aac004
        /// </summary>
        [YinHai(XmlAttName = "prm_aac004")]
        public string 性别;

        /// <summary>
        /// prm_aac002
        /// </summary>
        [YinHai(XmlAttName = "prm_aac002")]
        public string 公民身份号码;

        /// <summary>
        /// prm_aac006
        /// </summary>
        [YinHai(XmlAttName = "prm_aac006")]
        public string 出生日期;

        /// <summary>
        /// prm_akc023
        /// </summary>
        [YinHai(XmlAttName = "prm_akc023")]
        public string 实足年龄;

        /// <summary>
        /// prm_aab001
        /// </summary>
        [YinHai(XmlAttName = "prm_aab001")]
        public string 单位编号;

        /// <summary>
        /// prm_aab004
        /// </summary>
        [YinHai(XmlAttName = "prm_aab004")]
        public string 单位名称;

        /// <summary>
        /// prm_ykc280
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc280")]
        public string 居民医疗人员类别;

        /// <summary>
        /// prm_ykc281
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc281")]
        public string 居民医疗人员身份;

        /// <summary>
        /// prm_yka054
        /// </summary>
        [YinHai(XmlAttName = "prm_yka054")]
        public string 清算方式;

        /// <summary>
        /// prm_yae366
        /// </summary>
        [YinHai(XmlAttName = "prm_yae366")]
        public string 清算期号;

        /// <summary>
        /// prm_yka373
        /// </summary>
        [YinHai(XmlAttName = "prm_yka373")]
        public string 其中离休奖励备用金支付金额;

        /// <summary>
        /// prm_yka372
        /// </summary>
        [YinHai(XmlAttName = "prm_yka372")]
        public string 其中离休奖励备用金支付后的余额;

        /// <summary>
        /// prm_yka410
        /// </summary>
        [YinHai(XmlAttName = "prm_yka410")]
        public string 特检特治项目费用;

        /// <summary>
        /// prm_yka420
        /// </summary>
        [YinHai(XmlAttName = "prm_yka420")]
        public string 特殊耗材费用_3_7_;

        /// <summary>
        /// prm_yka430
        /// </summary>
        [YinHai(XmlAttName = "prm_yka430")]
        public string 特检特治项目_5_5_费用;
    }
}
