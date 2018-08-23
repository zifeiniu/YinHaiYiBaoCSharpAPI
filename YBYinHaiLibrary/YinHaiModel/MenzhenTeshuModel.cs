using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{

    /// <summary>
    /// 门诊特殊病申请
    /// </summary>
    public class MenzhenTeshuModel: YinHaiModelBase
    {
        /// <summary>
        /// <prm_ykc141>经办人姓名</prm_ykc141>
        /// </summary>
        [YinHai(XmlAttName = "prm_ykc141")]
        public string 经办人姓名;
    }
}
