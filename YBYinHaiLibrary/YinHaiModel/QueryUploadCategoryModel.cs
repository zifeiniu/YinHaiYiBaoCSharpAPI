using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{
    /// <summary>
    /// 查询上传目录
    /// </summary>
    public class QueryUploadCategoryModel: YinHaiModelBase
    {
        public List<QueryUploadCategorySubModel> Items; 
    }

    public class QueryUploadCategorySubModel
    {
        /// <summary>
        /// prm_yae099
        /// </summary>
        [YinHai(XmlAttName = "prm_yae099")]
        public string 申请流水号;

        /// <summary>
        /// prm_name
        /// </summary>
        [YinHai(XmlAttName = "prm_name")]
        public string 申请人;

        /// <summary>
        /// prm_sbxmbm
        /// </summary>
        [YinHai(XmlAttName = "prm_sbxmbm")]
        public string 医保通用项目编码;

        /// <summary>
        /// prm_xmbm
        /// </summary>
        [YinHai(XmlAttName = "prm_xmbm")]
        public string 医院项目流水号;

        /// <summary>
        /// prm_xmmc
        /// </summary>
        [YinHai(XmlAttName = "prm_xmmc")]
        public string 医院项目通用名称;

        /// <summary>
        /// prm__xmsp
        /// </summary>
        [YinHai(XmlAttName = "prm_xmsp")]
        public string 医院项目商品名称;

        /// <summary>
        /// prm_xmgg
        /// </summary>
        [YinHai(XmlAttName = "prm_xmgg")]
        public string 医院使用规格;

        /// <summary>
        /// prm_jx
        /// </summary>
        [YinHai(XmlAttName = "prm_jx")]
        public string 医院使用剂型;

        /// <summary>
        /// prm_xmdw
        /// </summary>
        [YinHai(XmlAttName = "prm_xmdw")]
        public string 医院使用的计价单位;

        /// <summary>
        /// prm_xmrj
        /// </summary>
        [YinHai(XmlAttName = "prm_xmrj")]
        public string 热键_药品的五笔编码或汉字拼音编码_;

        /// <summary>
        /// prm_xmjg
        /// </summary>
        [YinHai(XmlAttName = "prm_xmjg")]
        public string 价格;

        /// <summary>
        /// prm_aae036
        /// </summary>
        [YinHai(XmlAttName = "prm_aae036")]
        public string 审核时间;

        /// <summary>
        /// Prm_aae011
        /// </summary>
        [YinHai(XmlAttName = "Prm_aae011")]
        public string 审核人;

        /// <summary>
        /// Prm_shbz
        /// </summary>
        [YinHai(XmlAttName = "Prm_shbz")]
        public string 审核标志;

        /// <summary>
        /// Prm_shyy
        /// </summary>
        [YinHai(XmlAttName = "Prm_shyy")]
        public string 审核原因;

        /// <summary>
        /// prm_sccj
        /// </summary>
        [YinHai(XmlAttName = "prm_sccj")]
        public string 生产厂家;

        /// <summary>
        /// prm_flag
        /// </summary>
        [YinHai(XmlAttName = "prm_flag")]
        public string 进出口标志;

        /// <summary>
        /// prm_bz
        /// </summary>
        [YinHai(XmlAttName = "prm_bz")]
        public string 备注;

    }
}
