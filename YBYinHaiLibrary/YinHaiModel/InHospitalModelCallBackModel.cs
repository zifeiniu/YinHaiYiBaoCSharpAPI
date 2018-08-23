using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
   /// <summary>
   /// 住院办理回退
   /// </summary>
    public class InHospitalModelCallBackModel: YinHaiModelBase
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
        /// prm_ykb065
        /// </summary>
        [YinHai(XmlAttName = "prm_ykb065")]
        public string 社会保险办法;
    }
}
