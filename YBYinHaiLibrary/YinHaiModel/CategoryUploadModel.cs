using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBYinHaiLibrary
{

    //public class CategoryUploadInputModel
    //{
    //    public List<CategoryUploadModel> items;
    //}

    /// <summary>
    /// 目录上传
    /// </summary>
    public class CategoryUploadModel: YinHaiModelBase
    {
        
            /// <summary>
            /// prm_name
            /// </summary>
            [YinHai(XmlAttName = "prm_name")]
            public string 申请人;

            /// <summary>
            /// prm_xmbm
            /// </summary>
            [YinHai(XmlAttName = "prm_xmbm")]
            public string 医院项目编码;

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
            /// prm_sbxmbm
            /// </summary>
            [YinHai(XmlAttName = "prm_sbxmbm")]
            public string 医保通用项目编码;

            /// <summary>
            /// yka003
            /// </summary>
            [YinHai(XmlAttName = "prm_yka003")]
            public string 医保通用项目名称;

            /// <summary>
            /// yka004
            /// </summary>
            [YinHai(XmlAttName = "prm_yka004")]
            public string 药品注册名称;

            /// <summary>
            /// yka202
            /// </summary>
            [YinHai(XmlAttName = "prm_yka202")]
            public string 商品名;

            /// <summary>
            /// YKA005
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA005")]
            public string 西药药品代码;

            /// <summary>
            /// YKA006
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA006")]
            public string 药监局药品编码;

            /// <summary>
            /// YKA200
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA200")]
            public string 注册信息序列号;

            /// <summary>
            /// aka074
            /// </summary>
            [YinHai(XmlAttName = "prm_aka074")]
            public string 注册规格;

            /// <summary>
            /// aka070
            /// </summary>
            [YinHai(XmlAttName = "prm_aka070")]
            public string 剂型;

            /// <summary>
            /// AKA075
            /// </summary>
            [YinHai(XmlAttName = "prm_AKA075")]
            public string 注册剂型;

            /// <summary>
            /// AKA076
            /// </summary>
            [YinHai(XmlAttName = "prm_AKA076")]
            public string 生产单位;

            /// <summary>
            /// yka007
            /// </summary>
            [YinHai(XmlAttName = "prm_yka007")]
            public string 批准文号;

            /// <summary>
            /// YKA201
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA201")]
            public string 批准文号备注;

            /// <summary>
            /// Yka284
            /// </summary>
            [YinHai(XmlAttName = "prm_Yka284")]
            public string 通用项目英文名称;

            /// <summary>
            /// YKA203
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA203")]
            public string 新版目录备注;

            /// <summary>
            /// YKA210
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA210")]
            public string 酸根;

            /// <summary>
            /// YKA211
            /// </summary>
            [YinHai(XmlAttName = "prm_YKA211")]
            public string 盐基;

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
            public string 热键_药品的五笔编码或汉字拼音编码;

            /// <summary>
            /// prm_xmjg
            /// </summary>
            [YinHai(XmlAttName = "prm_xmjg")]
            public string 价格;

            /// <summary>
            /// prm_bz
            /// </summary>
            [YinHai(XmlAttName = "prm_bz")]
            public string 备注;

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


    }

    /// <summary>
    /// 上传多个目录时，返回的状态类
    /// </summary>
    public class CategoryUploadOutModel : YinHaiModelBase
    {
        public List<StatusModel> resultItems = new List<StatusModel>();

    }

    public class StatusModel
    {
        public string code;

        public bool status;

        public string msg;

    }
}
