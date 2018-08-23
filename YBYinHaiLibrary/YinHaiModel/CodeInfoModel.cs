using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{

    /// <summary>
    /// 编码对照信息
    /// </summary>
    public class CodeInfoModel: YinHaiModelBase
    {
        public List<CodeInfoSubModel> Items;
       
    }

    public class CodeInfoSubModel
    {
        /// <summary>
        /// aaa100
        /// </summary>
        [YinHai(XmlAttName = "aaa100")]
        public string 代码类别;

        /// <summary>
        /// aaa101
        /// </summary>
        [YinHai(XmlAttName = "aaa101")]
        public string 类别名称;

        /// <summary>
        /// aaa102
        /// </summary>
        [YinHai(XmlAttName = "aaa102")]
        public string 代码值;

        /// <summary>
        /// aaa103
        /// </summary>
        [YinHai(XmlAttName = "aaa103")]
        public string 代码名称;
    }
}
