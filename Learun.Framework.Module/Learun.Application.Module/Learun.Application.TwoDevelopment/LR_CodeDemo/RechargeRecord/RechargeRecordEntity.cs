using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-06-08 09:22
    /// 描 述：充值记录
    /// </summary>
    public class RechargeRecordEntity 
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string Id { get; set; }
        /// <summary>
        /// UId
        /// </summary>
        /// <returns></returns>
        [Column("UID")]
        public string UId { get; set; }
        /// <summary>
        /// BRecharge
        /// </summary>
        /// <returns></returns>
        [Column("BRECHARGE")]
        public string BRecharge { get; set; }
        /// <summary>
        /// ARecharge
        /// </summary>
        /// <returns></returns>
        [Column("ARECHARGE")]
        public string ARecharge { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public DateTime? CreateDate { get; set; }
        [NotMapped]
        public string AccountName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.Id = keyValue;
        }
        #endregion
    }
}

