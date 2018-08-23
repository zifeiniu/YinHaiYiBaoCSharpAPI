using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// yh_interface_getuncertaintytrade  返回的Model
    /// </summary>
    public class UncertaintytradeModel: YinHaiModelBase
    {
        public List<UncertaintytradeSubModel> Items;

    }

    /// <summary>
    /// 
    /// </summary>
    public class UncertaintytradeSubModel
    {
        /// <summary>
        /// <yke014>交易流水号</yke014>
        /// </summary>
        [YinHai(XmlAttName = "yke014")]
        public string 交易流水号;

        /// <summary>
        /// <yke015>交易编号</yke015>
        /// </summary>
        [YinHai(XmlAttName = "yke015")]
        public string 交易编号;

    }
}
