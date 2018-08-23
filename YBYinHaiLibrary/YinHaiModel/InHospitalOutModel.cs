using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 入院办理的输出Model
    /// </summary>
    public class InHospitalOutModel : YinHaiModelBase
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
        /// prm_aka130
        /// </summary>
        [YinHai(XmlAttName = "prm_aka130")]
        public string 支付类别;

        /// <summary>
        /// prm_aac001
        /// </summary>
        [YinHai(XmlAttName = "prm_aac001")]
        public string 个人编号;

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
        public string 身份号码;

        /// <summary>
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 执行社会保险办法;

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
        /// prm_akc023
        /// </summary>
        [YinHai(XmlAttName = "prm_akc023")]
        public string 实足年龄;

        /// <summary>
        /// prm_akc021
        /// </summary>
        [YinHai(XmlAttName = "prm_akc021")]
        public string 医疗人员类别;
    }
}
