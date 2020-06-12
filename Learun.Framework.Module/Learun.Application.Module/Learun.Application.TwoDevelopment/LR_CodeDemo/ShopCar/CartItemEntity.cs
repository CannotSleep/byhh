using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-16 09:18
    /// 描 述：购物车
    /// </summary>
    public class CartItemEntity 
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
        /// quantity
        /// </summary>
        /// <returns></returns>
        [Column("QUANTITY")]
        public int? quantity { get; set; }
        /// <summary>
        /// member_id
        /// </summary>
        /// <returns></returns>
        [Column("MEMBER_ID")]
        public string member_id { get; set; }
        /// <summary>
        /// product_id
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCT_ID")]
        public string product_id { get; set; }
        /// <summary>
        /// admin_id
        /// </summary>
        /// <returns></returns>
        [Column("ADMIN_ID")]
        public string admin_id { get; set; }
        /// <summary>
        /// standardId
        /// </summary>
        /// <returns></returns>
        [Column("STANDARDID")]
        public string standardId { get; set; }
        /// <summary>
        /// standardName
        /// </summary>
        /// <returns></returns>
        [Column("STANDARDNAME")]
        public string standardName { get; set; }
        /// <summary>
        /// standardPages
        /// </summary>
        /// <returns></returns>
        [Column("STANDARDPAGES")]
        public string standardPages { get; set; }
        /// <summary>
        /// cartType
        /// </summary>
        /// <returns></returns>
        [Column("CARTTYPE")]
        public string cartType { get; set; }
        /// <summary>
        /// price
        /// </summary>
        /// <returns></returns>
        [Column("PRICE")]
        public decimal? price { get; set; }
        /// <summary>
        /// computer
        /// </summary>
        /// <returns></returns>
        [Column("COMPUTER")]
        public string computer { get; set; }
        /// <summary>
        /// startDate
        /// </summary>
        /// <returns></returns>
        [Column("STARTDATE")]
        public DateTime? startDate { get; set; }
        /// <summary>
        /// endDate
        /// </summary>
        /// <returns></returns>
        [Column("ENDDATE")]
        public DateTime? endDate { get; set; }
        /// <summary>
        /// replaceStandard
        /// </summary>
        /// <returns></returns>
        [Column("REPLACESTANDARD")]
        public string replaceStandard { get; set; }
        /// <summary>
        /// depositeDate
        /// </summary>
        /// <returns></returns>
        [Column("DEPOSITEDATE")]
        public DateTime? depositeDate { get; set; }
        /// <summary>
        /// depositeTime
        /// </summary>
        /// <returns></returns>
        [Column("DEPOSITETIME")]
        public int? depositeTime { get; set; }
        /// <summary>
        /// a825
        /// </summary>
        /// <returns></returns>
        [Column("A825")]
        public string a825 { get; set; }
        /// <summary>
        /// a4754
        /// </summary>
        /// <returns></returns>
        [Column("A4754")]
        public string a4754 { get; set; }
        /// <summary>
        /// a826
        /// </summary>
        /// <returns></returns>
        [Column("A826")]
        public string a826 { get; set; }
        /// <summary>
        /// copr
        /// </summary>
        /// <returns></returns>
        [Column("COPR")]
        public string copr { get; set; }
        /// <summary>
        /// memberCompany
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERCOMPANY")]
        public string memberCompany { get; set; }
        /// <summary>
        /// zba001
        /// </summary>
        /// <returns></returns>
        [Column("ZBA001")]
        public string zba001 { get; set; }
        /// <summary>
        /// zba102
        /// </summary>
        /// <returns></returns>
        [Column("ZBA102")]
        public string zba102 { get; set; }
        /// <summary>
        /// paperPrice
        /// </summary>
        /// <returns></returns>
        [Column("PAPERPRICE")]
        public string paperPrice { get; set; }
        /// <summary>
        /// standorg
        /// </summary>
        /// <returns></returns>
        [Column("STANDORG")]
        public string standorg { get; set; }
        /// <summary>
        /// standorgbiao
        /// </summary>
        /// <returns></returns>
        [Column("STANDORGBIAO")]
        public string standorgbiao { get; set; }
        /// <summary>
        /// qwprice
        /// </summary>
        /// <returns></returns>
        [Column("QWPRICE")]
        public string qwprice { get; set; }
        /// <summary>
        /// downloadtrue
        /// </summary>
        /// <returns></returns>
        [Column("DOWNLOADTRUE")]
        public bool? downloadtrue { get; set; }
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
    }
}

