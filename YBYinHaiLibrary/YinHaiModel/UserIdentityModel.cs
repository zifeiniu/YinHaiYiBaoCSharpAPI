using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    public class UserIdentityModel: YinHaiModelBase
    {
        /// <summary>
        /// prm_aac001
        /// </summary>
        [YinHai(XmlAttName = "prm_aac001")]
        public string 个人编号;

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
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 执行社会保险办法;

        /// <summary>
        /// prm_ykc150
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc150")]
        public string 异地安置标志;

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
        public string 身份证;

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
        /// prm_aac031
        /// </summary>
        [YinHai(XmlAttName = "prm_aac031")]
        public string 个人参保状态;

        /// <summary>
        /// prm_akc087
        /// </summary>
        [YinHai(XmlAttName = "prm_akc087")]
        public string 个人账户余额;

        /// <summary>
        /// prm_yab003
        /// </summary>
        [YinHai(XmlAttName = "prm_yab003")]
        public string 分中心编号;

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
    }
}
