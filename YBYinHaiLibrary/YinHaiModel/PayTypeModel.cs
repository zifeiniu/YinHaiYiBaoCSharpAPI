using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    public class PayTypeModel: YinHaiModelBase
    {
        public List<PayTypeSubModel> Items;
    }

    public class PayTypeSubModel
    {
        /// <summary>
        /// Aka130
        /// </summary>
        [YinHai(XmlAttName = "Aka130")]
        public string 支付类别编码;

        /// <summary>
        /// Aaa103
        /// </summary>
        [YinHai(XmlAttName = "Aaa103")]
        public string 支付类别名称;

        /// <summary>
        /// zflx
        /// </summary>
        [YinHai(XmlAttName = "zflx")]
        public string 支付类型;
    }
}
