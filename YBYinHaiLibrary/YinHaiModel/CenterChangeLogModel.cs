using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 医保中心变更日志
    /// </summary>
    public class CenterChangeLogModel: YinHaiModelBase
    {
        public List<CenterChangeLogSub> Items;
    }

    public class CenterChangeLogSub
    {
        /// <summary>
        /// YKA002
        /// </summary>
        [YinHai(XmlAttName = "YKA002")]
        public string 医保通用项目编码;

        /// <summary>
        /// YKA003
        /// </summary>
        [YinHai(XmlAttName = "YKA003")]
        public string 医保通用项目名称;

        /// <summary>
        /// YAA027
        /// </summary>
        [YinHai(XmlAttName = "YAA027")]
        public string 物价编码;

        /// <summary>
        /// YKE103
        /// </summary>
        [YinHai(XmlAttName = "YKE103")]
        public string 项目说明;

        /// <summary>
        /// YKE100
        /// </summary>
        [YinHai(XmlAttName = "YKE100")]
        public string 项目内涵;

        /// <summary>
        /// YAE375
        /// </summary>
        [YinHai(XmlAttName = "YAE375")]
        public string 目录特项标志;

        /// <summary>
        /// AAE036
        /// </summary>
        [YinHai(XmlAttName = "AAE036")]
        public string 经办时间;

        /// <summary>
        /// AAE100
        /// </summary>
        [YinHai(XmlAttName = "AAE100")]
        public string 有效标志;

        /// <summary>
        /// YKA457
        /// </summary>
        [YinHai(XmlAttName = "YKA457")]
        public string 一级医院限价;

        /// <summary>
        /// YKA458
        /// </summary>
        [YinHai(XmlAttName = "YKA458")]
        public string 二级医院限价;

        /// <summary>
        /// YKA459
        /// </summary>
        [YinHai(XmlAttName = "YKA459")]
        public string 三级医院限价;

        /// <summary>
        /// YKA009
        /// </summary>
        [YinHai(XmlAttName = "YKA009")]
        public string 特级医院限价;

        /// <summary>
        /// YKA096
        /// </summary>
        [YinHai(XmlAttName = "YKA096")]
        public string 自付比例;

        /// <summary>
        /// YKE101
        /// </summary>
        [YinHai(XmlAttName = "YKE101")]
        public string 生效开始日期;

        /// <summary>
        /// YKE102
        /// </summary>
        [YinHai(XmlAttName = "YKE102")]
        public string 生效结束日期;

        /// <summary>
        /// YKA358
        /// </summary>
        [YinHai(XmlAttName = "YKA358")]
        public string 按项目结算特项标志;

        /// <summary>
        /// YKE201
        /// </summary>
        [YinHai(XmlAttName = "YKE201")]
        public string 中药使用方式;

        /// <summary>
        /// YKE011
        /// </summary>
        [YinHai(XmlAttName = "YKE011")]
        public string 限制使用;

        /// <summary>
        /// YKA456
        /// </summary>
        [YinHai(XmlAttName = "YKA456")]
        public string 限门诊使用;

        /// <summary>
        /// AAE013
        /// </summary>
        [YinHai(XmlAttName = "AAE013")]
        public string 备注;

        /// <summary>
        /// YKA339
        /// </summary>
        [YinHai(XmlAttName = "YKA339")]
        public string 目录支付比例人员分类;

        /// <summary>
        /// YAE495
        /// </summary>
        [YinHai(XmlAttName = "YAE495")]
        public string 处理标志;


    }
}
