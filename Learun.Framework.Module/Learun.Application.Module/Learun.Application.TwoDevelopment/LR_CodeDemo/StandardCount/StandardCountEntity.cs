using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-26 17:30
    /// 描 述：标准费用计算
    /// </summary>
    public class StandardCountEntity 
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
        /// pageSize
        /// </summary>
        /// <returns></returns>
        [Column("PAGESIZE")]
        public int? pageSize { get; set; }
        /// <summary>
        /// unit
        /// </summary>
        /// <returns></returns>
        [Column("UNIT")]
        public decimal? unit { get; set; }
        /// <summary>
        /// basicCost
        /// </summary>
        /// <returns></returns>
        [Column("BASICCOST")]
        public decimal? basicCost { get; set; }
        /// <summary>
        /// overdueCost
        /// </summary>
        /// <returns></returns>
        [Column("OVERDUECOST")]
        public decimal? overdueCost { get; set; }
        /// <summary>
        /// isDefault
        /// </summary>
        /// <returns></returns>
        [Column("ISDEFAULT")]
        public bool? isDefault { get; set; }
        /// <summary>
        /// funit
        /// </summary>
        /// <returns></returns>
        [Column("FUNIT")]
        public decimal? funit { get; set; }
        /// <summary>
        /// memberRank_id
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERRANK_ID")]
        public string memberRank_id { get; set; }
        /// <summary>
        /// fbasicCost
        /// </summary>
        /// <returns></returns>
        [Column("FBASICCOST")]
        public decimal? fbasicCost { get; set; }
        /// <summary>
        /// foverdueCost
        /// </summary>
        /// <returns></returns>
        [Column("FOVERDUECOST")]
        public decimal? foverdueCost { get; set; }
        /// <summary>
        /// depositePrice
        /// </summary>
        /// <returns></returns>
        [Column("DEPOSITEPRICE")]
        public string depositePrice { get; set; }

        /// <summary>
        /// 等级名称
        /// </summary>
        /// <returns></returns>
        [NotMapped]
        public string name { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.id = Guid.NewGuid().ToString();
            this.modifyDate = DateTime.Now;
            this.createDate = DateTime.Now;
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

