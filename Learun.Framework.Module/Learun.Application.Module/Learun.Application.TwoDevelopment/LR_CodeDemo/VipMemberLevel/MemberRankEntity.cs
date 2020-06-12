using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-26 16:25
    /// 描 述：会员等级
    /// </summary>
    public class MemberRankEntity 
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string id { get; set; }
        /// <summary>
        /// createDate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public DateTime? createDate { get; set; }
        /// <summary>
        /// modifyDate
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYDATE")]
        public DateTime? modifyDate { get; set; }
        /// <summary>
        /// isDefault
        /// </summary>
        /// <returns></returns>
        [Column("ISDEFAULT")]
        public int isDefault { get; set; }
        /// <summary>
        /// name
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string name { get; set; }
        /// <summary>
        /// point
        /// </summary>
        /// <returns></returns>
        [Column("POINT")]
        public int? point { get; set; }
        /// <summary>
        /// preferentialScale
        /// </summary>
        /// <returns></returns>
        [Column("PREFERENTIALSCALE")]
        public decimal? preferentialScale { get; set; }
        /// <summary>
        /// ouid_id
        /// </summary>
        /// <returns></returns>
        [Column("OUID_ID")]
        public string ouid_id { get; set; }
        /// <summary>
        /// organname
        /// </summary>
        /// <returns></returns>
        [Column("ORGANNAME")]
        public string organname { get; set; }
        /// <summary>
        /// parent_id
        /// </summary>
        /// <returns></returns>
        [Column("PARENT_ID")]
        public string parent_id { get; set; }
        /// <summary>
        /// uploadSpacepaceSize
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADSPACEPACESIZE")]
        public string uploadSpacepaceSize { get; set; }
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
    }
}

