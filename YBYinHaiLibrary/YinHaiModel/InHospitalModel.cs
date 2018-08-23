using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 住院办理
    /// </summary>
    public class InHospitalModel: YinHaiModelBase
    {

        /// <summary>
        /// prm_ykc010
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc010")]
        public string 住院号;

        /// <summary>
        /// prm_akc192
        /// </summary>
        [YinHai(XmlAttName = "prm_akc192")]
        public string 入院日期;

        /// <summary>
        /// prm_akc193
        /// </summary>
        [YinHai(XmlAttName = "prm_akc193")]
        public string 入院诊断名称;

        /// <summary>
        /// prm_yke120
        /// </summary>
        [YinHai(XmlAttName = "prm_yke120")]
        public string 入院诊断ICD编码;

        /// <summary>
        /// prm_ykc012
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc012")]
        public string 入院床位;

        /// <summary>
        /// prm_ykc011
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc011")]
        public string 入院科室;

        /// <summary>
        /// prm_ykc013
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc013")]
        public string 入院经办人编码;

        /// <summary>
        /// prm_ykc141
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc141")]
        public string 入院经办人姓名;

        /// <summary>
        /// prm_ykc014
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc014")]
        public string 入院经办时间;

        /// <summary>
        /// prm_ykc292
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc292")]
        public string 分娩类型;

        /// <summary>
        /// prm_ykc296
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc296")]
        public string 居民普通住院病种;

        /// <summary>
        /// prm_ykc009
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc009")]
        public string 病历号;

        /// <summary>
        /// prm_aae013
        /// </summary>
        [YinHai(XmlAttName = "prm_aae013")]
        public string 备注;

        /// <summary>
        /// prm_hisbh
        /// </summary>
        [YinHai(XmlAttName = "prm_hisbh")]
        public string HIS厂商编号;

    }
}
