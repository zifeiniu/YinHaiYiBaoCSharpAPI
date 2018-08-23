using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// §1.9.37.	结算、退费信息查询（含门诊和住院）(
    /// </summary>
    public class CheckFeeQueryModel: YinHaiModelBase
    {
      public List<CheckFeeQuerySubModel> items;
    }

    public class CheckFeeQuerySubModel
    {

        /// <summary>
        /// akc190
        /// </summary>
        [YinHai(XmlAttName = "akc190")]
        public string 就诊编号;


        /// <summary>
        /// yka103
        /// </summary>
        [YinHai(XmlAttName = "yka103")]
        public string 结算编号;


        /// <summary>
        /// aka130
        /// </summary>
        [YinHai(XmlAttName = "aka130")]
        public string 支付类别;

        /// <summary>
        /// aac001
        /// </summary>
        [YinHai(XmlAttName = "aac001")]
        public string 个人编号;

        /// <summary>
        /// yka065
        /// </summary>
        [YinHai(XmlAttName = "yka065")]
        public string 个人账户支付部分;

        /// <summary>
        /// yka055
        /// </summary>
        [YinHai(XmlAttName = "yka055")]
        public string 费用总额;

        /// <summary>
        /// yka056
        /// </summary>
        [YinHai(XmlAttName = "yka056")]
        public string 全自费部分;

        /// <summary>
        /// yka057
        /// </summary>
        [YinHai(XmlAttName = "yka057")]
        public string 先行自付;

        /// <summary>
        /// yka111
        /// </summary>
        [YinHai(XmlAttName = "yka111")]
        public string 符合范围;

        /// <summary>
        /// yka058
        /// </summary>
        [YinHai(XmlAttName = "yka058")]
        public string 本次起付线;

        /// <summary>
        /// yka248
        /// </summary>
        [YinHai(XmlAttName = "yka248")]
        public string 本次基本医疗报销金额;

        /// <summary>
        /// yka062
        /// </summary>
        [YinHai(XmlAttName = "yka062")]
        public string 本次大病医疗报销金额;

        /// <summary>
        /// yke030
        /// </summary>
        [YinHai(XmlAttName = "yke030")]
        public string 本次公务员报销金额;

        /// <summary>
        /// ykc177
        /// </summary>
        [YinHai(XmlAttName = "ykc177")]
        public string 本次个人账户支付后帐户余额;

        /// <summary>
        /// yka410
        /// </summary>
        [YinHai(XmlAttName = "yka410")]
        public string 特检特治项目费用;

        /// <summary>
        /// yka373
        /// </summary>
        [YinHai(XmlAttName = "yka373")]
        public string 离休奖励备用金支付金额;

        /// <summary>
        /// yka372
        /// </summary>
        [YinHai(XmlAttName = "yka372")]
        public string 离休奖励备用金支付后的余额;

        /// <summary>
        /// yke398
        /// </summary>
        [YinHai(XmlAttName = "yke398")]
        public string _15日内同病种住院标识;

        /// <summary>
        /// ykc365
        /// </summary>
        [YinHai(XmlAttName = "ykc365")]
        public string 医院申报清算限额定额数量;

        /// <summary>
        /// ykb037
        /// </summary>
        [YinHai(XmlAttName = "ykb037")]
        public string 清算分中心;

        /// <summary>
        /// yka316
        /// </summary>
        [YinHai(XmlAttName = "yka316")]
        public string 清算类别;

        /// <summary>
        /// yka054
        /// </summary>
        [YinHai(XmlAttName = "yka054")]
        public string 清算方式;

        /// <summary>
        /// yae366
        /// </summary>
        [YinHai(XmlAttName = "yae366")]
        public string 清算期号;

        /// <summary>
        /// akc021
        /// </summary>
        [YinHai(XmlAttName = "akc021")]
        public string 医疗人员类别;

        /// <summary>
        /// ykc121
        /// </summary>
        [YinHai(XmlAttName = "ykc121")]
        public string 就诊结算方式;

        /// <summary>
        /// ykc280
        /// </summary>
        [YinHai(XmlAttName = "ykc280")]
        public string 居保人员类别;

        /// <summary>
        /// ykc281
        /// </summary>
        [YinHai(XmlAttName = "ykc281")]
        public string 居保人员身份;

        /// <summary>
        /// aae036
        /// </summary>
        [YinHai(XmlAttName = "aae036")]
        public string 经办时间;

        /// <summary>
        /// AAE100
        /// </summary>
        [YinHai(XmlAttName = "AAE100")]
        public string 刷卡标识;

        /// <summary>
        /// yka064
        /// </summary>
        [YinHai(XmlAttName = "yka064")]
        public string 大额商保支付金额;

        /// <summary>
        /// Ykb065
        /// </summary>
        [YinHai(XmlAttName = "Ykb065")]
        public string 执行社会保险办法;

        /// <summary>
        /// aac003
        /// </summary>
        [YinHai(XmlAttName = "aac003")]
        public string 姓名;

        /// <summary>
        /// yka430
        /// </summary>
        [YinHai(XmlAttName = "yka430")]
        public string 特检特治项5_5目费用;

    }
}
