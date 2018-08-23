using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 清算回退 Input Model
    /// </summary>
    public class QingSuanBackModel : YinHaiModelBase
    {
        /// <summary>
        /// prm_ykb037
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb037")]
        public string 清算分中心;

        /// <summary>
        /// prm_ykb053
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb053")]
        public string 清算申请流水号;

        /// <summary>
        /// prm_ykc179
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc179")]
        public string 回退人员姓名;

        /// <summary>
        /// prm_yke150
        /// </summary>
        [YinHai(XmlAttName = "prm_yke150")]
        public string 回退时间;

        /// <summary>
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 执行社会保险办法;




    }
}
