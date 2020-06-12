using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-13 10:05
    /// 描 述：文章分类表
    /// </summary>
    public class ArticleCategoryEntity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        [Column("ID")]
        public string id { get; set; }
        /// <summary>
        /// createDate
        /// </summary>
        [Column("CREATEDATE")]
        public DateTime? createDate { get; set; }
        /// <summary>
        /// modifyDate
        /// </summary>
        [Column("MODIFYDATE")]
        public DateTime? modifyDate { get; set; }
        /// <summary>
        /// metaDescription
        /// </summary>
        [Column("METADESCRIPTION")]
        public string metaDescription { get; set; }
        /// <summary>
        /// metaKeywords
        /// </summary>
        [Column("METAKEYWORDS")]
        public string metaKeywords { get; set; }
        /// <summary>
        /// name
        /// </summary>
        [Column("NAME")]
        public string name { get; set; }
        /// <summary>
        /// orderList
        /// </summary>
        [Column("ORDERLIST")]
        public int? orderList { get; set; }
        /// <summary>
        /// path
        /// </summary>
        [Column("PATH")]
        public string path { get; set; }
        /// <summary>
        /// parent_id
        /// </summary>
        [Column("PARENT_ID")]
        public string parent_id { get; set; }
        /// <summary>
        /// sign
        /// </summary>
        [Column("SIGN")]
        public string sign { get; set; }
        /// <summary>
        /// ouid
        /// </summary>
        [Column("OUID")]
        public string ouid { get; set; }
        /// <summary>
        /// isImageNews
        /// </summary>
        [Column("ISIMAGENEWS")]
        public int? isImageNews { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.id = keyValue;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

