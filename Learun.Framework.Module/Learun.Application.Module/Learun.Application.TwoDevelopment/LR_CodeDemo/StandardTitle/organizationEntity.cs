using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-01-16 16:23
    /// 描 述：标准题录
    /// </summary>
    public class organizationEntity 
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public Guid ID { get; set; }
        /// <summary>
        /// OraganId
        /// </summary>
        /// <returns></returns>
        [Column("ORAGANID")]
        public string OraganId { get; set; }
        /// <summary>
        /// OraganizationCode
        /// </summary>
        /// <returns></returns>
        [Column("ORAGANIZATIONCODE")]
        public string OraganizationCode { get; set; }
        /// <summary>
        /// OraganizationName
        /// </summary>
        /// <returns></returns>
        [Column("ORAGANIZATIONNAME")]
        public string OraganizationName { get; set; }
        /// <summary>
        /// CategoryCode
        /// </summary>
        /// <returns></returns>
        [Column("CATEGORYCODE")]
        public string CategoryCode { get; set; }
        /// <summary>
        /// Bz
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public int? Bz { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYDATE")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// OraganizationOrder
        /// </summary>
        /// <returns></returns>
        [Column("ORAGANIZATIONORDER")]
        public string OraganizationOrder { get; set; }
        /// <summary>
        /// Copr
        /// </summary>
        /// <returns></returns>
        [Column("COPR")]
        public int? Copr { get; set; }
        /// <summary>
        /// Synchronous
        /// </summary>
        /// <returns></returns>
        [Column("SYNCHRONOUS")]
        public int? Synchronous { get; set; }
        /// <summary>
        /// Discount
        /// </summary>
        /// <returns></returns>
        [Column("DISCOUNT")]
        public decimal? Discount { get; set; }
        /// <summary>
        /// 1启用0禁用
        /// </summary>
        /// <returns></returns>
        [Column("ISUSED")]
        public int? IsUsed { get; set; }
        /// <summary>
        /// OrderCode
        /// </summary>
        /// <returns></returns>
        [Column("ORDERCODE")]
        public int? OrderCode { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.ID = Guid.NewGuid();
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.ModifyDate = DateTime.Now;
            this.ID = new Guid(keyValue);
        }
        #endregion
    }
}

