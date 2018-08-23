using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
   /// <summary>
   /// 清算申请
   /// </summary>
    public class QingsuanShenqingModel: YinHaiModelBase
    {
        /// <summary>
        /// prm_yae366
        /// </summary>
        [YinHai(XmlAttName = "prm_yae366")]
        public string 清算期号;

        /// <summary>
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 执行社会保险办法;

        /// <summary>
        /// prm_yka316
        /// </summary>
        [YinHai(XmlAttName = "prm_yka316")]
        public string 清算类别;

        /// <summary>
        /// prm_ykb037
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb037")]
        public string 清算分中心;

        /// <summary>
        /// prm_yka055
        /// </summary>
        [YinHai(XmlAttName = "prm_yka055")]
        public string 费用总额;

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
        /// prm_yka063
        /// </summary>
        [YinHai(XmlAttName = "prm_yka063")]
        public string 公务员统筹支付金额;

        /// <summary>
        /// prm_yke031
        /// </summary>
        [YinHai(XmlAttName = "prm_yka064")]
        public string 大额商保支付金额;

        /// <summary>
        /// prm_yka065
        /// </summary>
        [YinHai(XmlAttName = "prm_yka065")]
        public string 个人帐户支付金额;

        /// <summary>
        /// prm_ykc179
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc179")]
        public string 清算申请人;

        /// <summary>
        /// prm_yke150
        /// </summary>
        [YinHai(XmlAttName = "prm_yke150")]
        public string 清算申请人时间;

        /// <summary>
        /// prm_write
        /// </summary>
        [YinHai(XmlAttName = "prm_write")]
        public string 检查标志="1";

        /// <summary>
        /// prm_yke239
        /// </summary>
        [YinHai(XmlAttName = "prm_yke239")]
        public string 清算类型 = "1";
    }

    /// <summary>
    /// 清算申请输出
    /// </summary>
    public class QingsuanShenqingOutModel : YinHaiModelBase
    {
        /// <summary>
        /// prm_ykb053
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb053")]
        public string 清算申请流水号 = "1";

    }

    ///// <summary>
    ///// 清算申请查询
    ///// </summary>
    //public class QingsuanShenqingQueryModel : YinHaiModelBase
    //{
    //    /// <summary>
    //    /// Prm_yae366
    //    /// </summary>
    //    [YinHai(XmlAttName = "Prm_yae366")]
    //    public string 清算期号;

    //}
}
