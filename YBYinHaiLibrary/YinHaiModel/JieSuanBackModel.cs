using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
   /// <summary>
   /// 
   /// </summary>
    public class JieSuanBackModel : YinHaiModelBase
    {  /// <summary>
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
        /// prm_aka130
        /// </summary>
        [YinHai(XmlAttName = "prm_aka130")]
        public string 支付类别;

        /// <summary>
        /// prm_yka103
        /// </summary>
        [YinHai(XmlAttName = "prm_yka103")]
        public string 结算编号;

        /// <summary>
        /// prm_aae011
        /// </summary>
        [YinHai(XmlAttName = "prm_aae011")]
        public string 经办人;

        /// <summary>
        /// prm_ykc141
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc141")]
        public string 经办人姓名;

        /// <summary>
        /// prm_aae036
        /// </summary>
        [YinHai(XmlAttName = "prm_aae036")]
        public string 经办时间;

        /// <summary>
        /// prm_aae013
        /// </summary>
        [YinHai(XmlAttName = "prm_aae013")]
        public string 退费原因;

        /// <summary>
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 社会保险办法;
    }
}
