using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-13 16:52
    /// 描 述：文章信息
    /// </summary>
    public class ArticleEntity 
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
        /// author
        /// </summary>
        [Column("AUTHOR")]
        public string author { get; set; }
        /// <summary>
        /// hits
        /// </summary>
        [Column("HITS")]
        public int? hits { get; set; }
        /// <summary>
        /// htmlFilePath
        /// </summary>
        [Column("HTMLFILEPATH")]
        public string htmlFilePath { get; set; }
        /// <summary>
        /// isPublication
        /// </summary>
        [Column("ISPUBLICATION")]
        public byte? isPublication { get; set; }
        /// <summary>
        /// isRecommend
        /// </summary>
        [Column("ISRECOMMEND")]
        public byte? isRecommend { get; set; }
        /// <summary>
        /// isTop
        /// </summary>
        [Column("ISTOP")]
        public byte? isTop { get; set; }
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
        /// pageCount
        /// </summary>
        [Column("PAGECOUNT")]
        public int? pageCount { get; set; }
        /// <summary>
        /// title
        /// </summary>
        [Column("TITLE")]
        public string title { get; set; }
        /// <summary>
        /// articleCategory_id
        /// </summary>
        [Column("ARTICLECATEGORY_ID")]
        public string articleCategory_id { get; set; }
        /// <summary>
        /// imagePath
        /// </summary>
        [Column("IMAGEPATH")]
        public string imagePath { get; set; }
        /// <summary>
        /// ouid
        /// </summary>
        [Column("OUID")]
        public string ouid { get; set; }
        /// <summary>
        /// articleDate
        /// </summary>
        [Column("ARTICLEDATE")]
        public DateTime? articleDate { get; set; }
        /// <summary>
        /// content
        /// </summary>
        [Column("CONTENT")]
        public string content { get; set; }
        /// <summary>
        /// imgUrl
        /// </summary>
        [Column("IMGURL")]
        public string imgUrl { get; set; }
        /// <summary>
        /// isImage
        /// </summary>
        [Column("ISIMAGE")]
        public int? isImage { get; set; }
        /// <summary>
        /// isImageNew
        /// </summary>
        [Column("ISIMAGENEW")]
        public int? isImageNew { get; set; }
        /// <summary>
        /// module
        /// </summary>
        [Column("MODULE")]
        public string module { get; set; }
        /// <summary>
        /// releaseDate
        /// </summary>
        [Column("RELEASEDATE")]
        public DateTime? releaseDate { get; set; }
        /// <summary>
        /// isShou
        /// </summary>
        [Column("ISSHOU")]
        public int? isShou { get; set; }
        /// <summary>
        /// isbannerImageNew
        /// </summary>
        [Column("ISBANNERIMAGENEW")]
        public int? isbannerImageNew { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.id = Guid.NewGuid().ToString();
            this.createDate = DateTime.Now;
            this.modifyDate = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.id = keyValue;
            this.modifyDate = DateTime.Now;
        }
        #endregion
        #region 扩展字段
        #endregion
    }
}

