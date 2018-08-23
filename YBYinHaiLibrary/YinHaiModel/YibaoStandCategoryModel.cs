using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 医保标准目录
    /// </summary>
    public class YibaoStandCategoryModel : YinHaiModelBase
    {

        public List<YibaoStandCategorySubModel> Items;
    }

    public class YibaoStandCategorySubModel
    {

        /// <summary>
        /// yka002
        /// </summary>
        [YinHai(XmlAttName = "yka002")]
        public string 医保通用项目编码;

        /// <summary>
        /// yka003
        /// </summary>
        [YinHai(XmlAttName = "yka003")]
        public string 医保通用项目名称;

        /// <summary>
        /// yka004
        /// </summary>
        [YinHai(XmlAttName = "yka004")]
        public string 药品注册名称;

        /// <summary>
        /// yka202
        /// </summary>
        [YinHai(XmlAttName = "yka202")]
        public string 商品名;

        /// <summary>
        /// YKA005
        /// </summary>
        [YinHai(XmlAttName = "YKA005")]
        public string 西药药品代码;

        /// <summary>
        /// YKA006
        /// </summary>
        [YinHai(XmlAttName = "YKA006")]
        public string 药监局药品编码;

        /// <summary>
        /// YKA200
        /// </summary>
        [YinHai(XmlAttName = "YKA200")]
        public string 注册信息序列号;

        /// <summary>
        /// yae036
        /// </summary>
        [YinHai(XmlAttName = "yae036")]
        public string 变更时间;

        /// <summary>
        /// yka001
        /// </summary>
        [YinHai(XmlAttName = "yka001")]
        public string 大类编码;

        /// <summary>
        /// ykd110
        /// </summary>
        [YinHai(XmlAttName = "ykd110")]
        public string 统计类型;

        /// <summary>
        /// yka389
        /// </summary>
        [YinHai(XmlAttName = "yka389")]
        public string 拼音助记码;

        /// <summary>
        /// yka401
        /// </summary>
        [YinHai(XmlAttName = "yka401")]
        public string 五笔助记码;

        /// <summary>
        /// Yka295
        /// </summary>
        [YinHai(XmlAttName = "Yka295")]
        public string 最小计价单位;

        /// <summary>
        /// aka074
        /// </summary>
        [YinHai(XmlAttName = "aka074")]
        public string 注册规格;

        /// <summary>
        /// aka070
        /// </summary>
        [YinHai(XmlAttName = "aka070")]
        public string 剂型;

        /// <summary>
        /// AKA075
        /// </summary>
        [YinHai(XmlAttName = "AKA075")]
        public string 注册剂型;

        /// <summary>
        /// AKA076
        /// </summary>
        [YinHai(XmlAttName = "AKA076")]
        public string 生产单位;

        /// <summary>
        /// yka007
        /// </summary>
        [YinHai(XmlAttName = "yka007")]
        public string 批准文号;

        /// <summary>
        /// YKA201
        /// </summary>
        [YinHai(XmlAttName = "YKA201")]
        public string 批准文号备注;

        /// <summary>
        /// Yka284
        /// </summary>
        [YinHai(XmlAttName = "Yka284")]
        public string 通用项目英文名称;

        /// <summary>
        /// Yka096
        /// </summary>
        [YinHai(XmlAttName = "Yka096")]
        public string 自付比例;

        /// <summary>
        /// xj
        /// </summary>
        [YinHai(XmlAttName = "xj")]
        public string 限价;

        /// <summary>
        /// Yae375
        /// </summary>
        [YinHai(XmlAttName = "Yae375")]
        public string 目录特项使用标志;

        /// <summary>
        /// YKA203
        /// </summary>
        [YinHai(XmlAttName = "YKA203")]
        public string 新版目录备注;

        /// <summary>
        /// YKA210
        /// </summary>
        [YinHai(XmlAttName = "YKA210")]
        public string 酸根;

        /// <summary>
        /// YKA211
        /// </summary>
        [YinHai(XmlAttName = "YKA211")]
        public string 盐基;
    }
}
