using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 清算申请查询输出Model
    /// </summary>
    public class QingsuanShenqingQueryOutModel : YinHaiModelBase
    {
        public List<QingsuanShenqingQuerySubModel> Items;

    }

    public class QingsuanShenqingQuerySubModel
    {
        /// <summary>
        /// akb020
        /// </summary>
        [YinHai(XmlAttName = "akb020")]
        public string 医院编号;

        /// <summary>
        /// ykb053
        /// </summary>
        [YinHai(XmlAttName = "ykb053")]
        public string 清算申请流水号;

        /// <summary>
        /// yka316
        /// </summary>
        [YinHai(XmlAttName = "yka316")]
        public string 清算类别;

        /// <summary>
        /// ykb037
        /// </summary>
        [YinHai(XmlAttName = "ykb037")]
        public string 清算分中心;

        /// <summary>
        /// aae030
        /// </summary>
        [YinHai(XmlAttName = "aae030")]
        public string 开始日期;

        /// <summary>
        /// aae031
        /// </summary>
        [YinHai(XmlAttName = "aae031")]
        public string 结束日期;

        /// <summary>
        /// ykb009
        /// </summary>
        [YinHai(XmlAttName = "ykb009")]
        public string 就诊人次;

        /// <summary>
        /// yka441
        /// </summary>
        [YinHai(XmlAttName = "yka441")]
        public string 就诊人数;

        /// <summary>
        /// yka055
        /// </summary>
        [YinHai(XmlAttName = "yka055")]
        public string 医疗费总额;

        /// <summary>
        /// yka065
        /// </summary>
        [YinHai(XmlAttName = "yka065")]
        public string 个人账户支付金额;

        /// <summary>
        /// yka248
        /// </summary>
        [YinHai(XmlAttName = "yka248")]
        public string 统筹支付金额;

        /// <summary>
        /// yka062
        /// </summary>
        [YinHai(XmlAttName = "yka062")]
        public string 大额统筹支付金额;

        /// <summary>
        /// yka108
        /// </summary>
        [YinHai(XmlAttName = "yka108")]
        public string 清算状态;

        /// <summary>
        /// ykc179
        /// </summary>
        [YinHai(XmlAttName = "ykc179")]
        public string 清算申请人姓名;

        /// <summary>
        /// yke150
        /// </summary>
        [YinHai(XmlAttName = "yke150")]
        public string 清算申请时间;

        /// <summary>
        /// ykb065
        /// </summary>
        [YinHai(XmlAttName = "ykb065")]
        public string 执行的社保政策;

        /// <summary>
        /// aka130
        /// </summary>
        [YinHai(XmlAttName = "aka130")]
        public string 支付类别;


        /// <summary>
        /// <yae366>清算期号</>
        /// </summary>
        [YinHai(XmlAttName = "yae366")]
        public string 清算期号;

 
    }
}
