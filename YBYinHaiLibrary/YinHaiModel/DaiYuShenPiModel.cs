using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 待遇审批信息
    /// </summary>
    public class DaiYuShenPiModel: YinHaiModelBase
    {

        /// <summary>
        /// prm_yab003
        /// </summary>
        [YinHai(XmlAttName = "prm_yab003")]
        public string 分中心编码;

        /// <summary>
        /// prm_aac001
        /// </summary>
        [YinHai(XmlAttName = "prm_aac001")]
        public string 个人编码;

        /// <summary>
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 执行社保政策办法;

        /// <summary>
        /// prm_akc192
        /// </summary>
        [YinHai(XmlAttName = "prm_akc192")]
        public string 入院日期;

    }

    /// <summary>
    /// 待遇审批
    /// </summary>
    public class DaiYuShenpiOutModel : YinHaiModelBase
    {
        /// <summary>
        /// <prm_outstr>待遇审批信息</prm_outstr>
        /// </summary>
        [YinHai(XmlAttName = "prm_outstr")]
        public string 待遇审批信息;
    }
}
