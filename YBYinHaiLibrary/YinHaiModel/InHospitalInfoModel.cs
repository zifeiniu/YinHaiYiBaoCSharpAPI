using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    ///住院费用明细写入
    /// </summary>
    public class InHospitalInfoModel: YinHaiModelBase
    {

        /// <summary>
        /// akc190
        /// </summary>
        [YinHai(XmlAttName = "akc190")]
        public string 就诊编号;

        /// <summary>
        /// aka130
        /// </summary>
        [YinHai(XmlAttName = "aka130")]
        public string 支付类别;

        /// <summary>
        /// yab003
        /// </summary>
        [YinHai(XmlAttName = "yab003")]
        public string 分中心编号;

        /// <summary>
        /// ykb065
        /// </summary>
        [YinHai(XmlAttName = "ykb065")]
        public string 社会保险办法;

        /// <summary>
        /// yka105
        /// </summary>
        [YinHai(XmlAttName = "yka105")]
        public string 记账流水号;

        /// <summary>
        /// ykd125
        /// </summary>
        [YinHai(XmlAttName = "ykd125")]
        public string 医院项目编码;

        /// <summary>
        /// ykd126
        /// </summary>
        [YinHai(XmlAttName = "ykd126")]
        public string 医院项目名称;

        /// <summary>
        /// yka002
        /// </summary>
        [YinHai(XmlAttName = "yka002")]
        public string 医保通用项目编码;

        /// <summary>
        /// YKA200
        /// </summary>
        [YinHai(XmlAttName = "YKA200")]
        public string 注册信息序列号;

        /// <summary>
        /// akc226
        /// </summary>
        [YinHai(XmlAttName = "akc226")]
        public string 数量;

        /// <summary>
        /// akc225
        /// </summary>
        [YinHai(XmlAttName = "akc225")]
        public string 单价;

        /// <summary>
        /// yka315
        /// </summary>
        [YinHai(XmlAttName = "yka315")]
        public string 明细项目费用总额;

        /// <summary>
        /// yka097
        /// </summary>
        [YinHai(XmlAttName = "yka097")]
        public string 开单科室编码;

        /// <summary>
        /// yka098
        /// </summary>
        [YinHai(XmlAttName = "yka098")]
        public string 开单科室名称;

        /// <summary>
        /// ykd102
        /// </summary>
        [YinHai(XmlAttName = "ykd102")]
        public string 开单医生编码;

        /// <summary>
        /// yka099
        /// </summary>
        [YinHai(XmlAttName = "yka099")]
        public string 开单医生姓名;

        /// <summary>
        /// yka100
        /// </summary>
        [YinHai(XmlAttName = "yka100")]
        public string 受单科室编码;

        /// <summary>
        /// yka101
        /// </summary>
        [YinHai(XmlAttName = "yka101")]
        public string 受单科室名称;

        /// <summary>
        /// ykd106
        /// </summary>
        [YinHai(XmlAttName = "ykd106")]
        public string 受单医生编码;

        /// <summary>
        /// yka102
        /// </summary>
        [YinHai(XmlAttName = "yka102")]
        public string 受单医生姓名;

        /// <summary>
        /// yke123
        /// </summary>
        [YinHai(XmlAttName = "yke123")]
        public string 明细发生时间;

        /// <summary>
        /// ykc141
        /// </summary>
        [YinHai(XmlAttName = "ykc141")]
        public string 经办人姓名;

        /// <summary>
        /// aae036
        /// </summary>
        [YinHai(XmlAttName = "aae036")]
        public string 经办时间;

        /// <summary>
        /// aae013
        /// </summary>
        [YinHai(XmlAttName = "aae013")]
        public string 备注;

        /// <summary>
        /// yke201
        /// </summary>
        [YinHai(XmlAttName = "yke201")]
        public string 中药使用方式;

        /// <summary>
        /// yka295
        /// </summary>
        [YinHai(XmlAttName = "yka295")]
        public string 最小计价单位;

        /// <summary>
        /// aka074
        /// </summary>
        [YinHai(XmlAttName = "aka074")]
        public string 规格;

        /// <summary>
        /// aka070
        /// </summary>
        [YinHai(XmlAttName = "aka070")]
        public string 剂型;

        /// <summary>
        /// yae374
        /// </summary>
        [YinHai(XmlAttName = "yae374")]
        public string 剂型名称;

        /// <summary>
        /// yke009
        /// </summary>
        [YinHai(XmlAttName = "yke009")]
        public string 是否医院制剂;

        /// <summary>
        /// yek301
        /// </summary>
        [YinHai(XmlAttName = "yek301")]
        public string 对应中心目录编码;

        /// <summary>
        /// yek302
        /// </summary>
        [YinHai(XmlAttName = "yek302")]
        public string 套编号;
    }
}
