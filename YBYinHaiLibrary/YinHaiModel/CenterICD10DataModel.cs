using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    ///中心ICD10数据下载
    /// </summary>
    public class CenterICD10DataModel: YinHaiModelBase
    {
        public List<CenterICD10DataSub> items;
    }

    public class CenterICD10DataSub
    {
        /// <summary>
        /// YKE120
        /// </summary>
        [YinHai(XmlAttName = "YKE120")]
        public string ICD10编码;

        /// <summary>
        /// YKE223
        /// </summary>
        [YinHai(XmlAttName = "YKE223")]
        public string ICD10副编码;

        /// <summary>
        /// YKE121
        /// </summary>
        [YinHai(XmlAttName = "YKE121")]
        public string ICD10名称;

        /// <summary>
        /// YKA260
        /// </summary>
        [YinHai(XmlAttName = "YKA260")]
        public string 拼音助记码;

        /// <summary>
        /// YKA278
        /// </summary>
        [YinHai(XmlAttName = "YKA278")]
        public string 五笔助记码;

        /// <summary>
        /// AAE013
        /// </summary>
        [YinHai(XmlAttName = "AAE013")]
        public string 备注;

    }
}
