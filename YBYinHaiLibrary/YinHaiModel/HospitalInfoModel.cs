using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 医院信息
    /// </summary>
    public class HospitalInfoModel : YinHaiModelBase
    {


        /// <summary>
        /// prm_akb021
        /// </summary>
        [YinHai(XmlAttName = "prm_akb021")]
        public string 服务机构名称;

        /// <summary>
        /// prm_yke362
        /// </summary>
        [YinHai(XmlAttName = "prm_yke362")]
        public string 医院类别;

        /// <summary>
        /// prm_aka101
        /// </summary>
        [YinHai(XmlAttName = "prm_aka101")]
        public string 医疗等级;

        /// <summary>
        /// prm_akb023
        /// </summary>
        [YinHai(XmlAttName = "prm_akb023")]
        public string 医疗机构类别;

        /// <summary>
        /// prm_akb022
        /// </summary>
        [YinHai(XmlAttName = "prm_akb022")]
        public string 服务机构类型;

        /// <summary>
        /// prm_aae004
        /// </summary>
        [YinHai(XmlAttName = "prm_aae004")]
        public string 联系人姓名;

        /// <summary>
        /// prm_aae005
        /// </summary>
        [YinHai(XmlAttName = "prm_aae005")]
        public string 联系人电话;

        /// <summary>
        /// prm_aae006
        /// </summary>
        [YinHai(XmlAttName = "prm_aae006")]
        public string 地址;

        /// <summary>
        /// prm_aae007
        /// </summary>
        [YinHai(XmlAttName = "prm_aae007")]
        public string 邮编;

        /// <summary>
        /// prm_zykt
        /// </summary>
        [YinHai(XmlAttName = "prm_zykt")]
        public string 是否开通住院;

        /// <summary>
        /// prm_aka130
        /// </summary>
        [YinHai(XmlAttName = "prm_aka130")]
        public string 门诊特检;

        /// <summary>
        /// prm_mztc
        /// </summary>
        [YinHai(XmlAttName = "prm_mztc")]
        public string 居民门诊统筹;

        /// <summary>
        /// prm_dxsmztc
        /// </summary>
        [YinHai(XmlAttName = "prm_dxsmztc")]
        public string 大学生门诊统筹;

        /// <summary>
        /// prm_ptmz
        /// </summary>
        [YinHai(XmlAttName = "prm_ptmz")]
        public string 普通门诊;

    }
}