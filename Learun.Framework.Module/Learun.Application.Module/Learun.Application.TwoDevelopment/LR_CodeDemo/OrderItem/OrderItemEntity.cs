using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-15 11:32
    /// 描 述：订单子项
    /// </summary>
    public class OrderItemEntity 
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
        /// deliveryQuantity
        /// </summary>
        /// <returns></returns>
        [Column("DELIVERYQUANTITY")]
        public int? deliveryQuantity { get; set; }
        /// <summary>
        /// productHtmlFilePath
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTHTMLFILEPATH")]
        public string productHtmlFilePath { get; set; }
        /// <summary>
        /// productName
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTNAME")]
        public string productName { get; set; }
        /// <summary>
        /// productPrice
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTPRICE")]
        public string productPrice { get; set; }
        public string price { get; set; }
        /// <summary>
        /// productQuantity
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTQUANTITY")]
        public int? productQuantity { get; set; }
        /// <summary>
        /// productSn
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTSN")]
        public string productSn { get; set; }
        /// <summary>
        /// totalDeliveryQuantity
        /// </summary>
        /// <returns></returns>
        [Column("TOTALDELIVERYQUANTITY")]
        public int? totalDeliveryQuantity { get; set; }
        /// <summary>
        /// order_id
        /// </summary>
        /// <returns></returns>
        [Column("ORDER_ID")]
        public string order_id { get; set; }
        /// <summary>
        /// standard_id
        /// </summary>
        /// <returns></returns>
        [Column("STANDARD_ID")]
        public string standard_id { get; set; }
        /// <summary>
        /// memberId
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERID")]
        public string memberId { get; set; }
        /// <summary>
        /// orderId
        /// </summary>
        /// <returns></returns>
        [Column("ORDERID")]
        public string orderId { get; set; }
        /// <summary>
        /// standardId
        /// </summary>
        /// <returns></returns>
        [Column("STANDARDID")]
        public string standardId { get; set; }
        public string standardName { get; set; }
        /// <summary>
        /// orderSn
        /// </summary>
        /// <returns></returns>
        [Column("ORDERSN")]
        public string orderSn { get; set; }
        /// <summary>
        /// product_id
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCT_ID")]
        public string product_id { get; set; }
        /// <summary>
        /// orderItemType
        /// </summary>
        /// <returns></returns>
        [Column("ORDERITEMTYPE")]
        public string orderItemType { get; set; }
        /// <summary>
        /// emailAttachStatus
        /// </summary>
        /// <returns></returns>
        [Column("EMAILATTACHSTATUS")]
        public string emailAttachStatus { get; set; }
        /// <summary>
        /// deleteType
        /// </summary>
        /// <returns></returns>
        [Column("DELETETYPE")]
        public string deleteType { get; set; }
        /// <summary>
        /// addtoPrice
        /// </summary>
        /// <returns></returns>
        [Column("ADDTOPRICE")]
        public decimal? addtoPrice { get; set; }
        /// <summary>
        /// identify
        /// </summary>
        /// <returns></returns>
        [Column("IDENTIFY")]
        public string identify { get; set; }
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
        /// isSuoQu
        /// </summary>
        /// <returns></returns>
        [Column("ISSUOQU")]
        public int? isSuoQu { get; set; }
        /// <summary>
        /// memberCompany
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERCOMPANY")]
        public string memberCompany { get; set; }
        /// <summary>
        /// memberName
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERNAME")]
        public string memberName { get; set; }
        /// <summary>
        /// memberusername
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERUSERNAME")]
        public string memberusername { get; set; }
        /// <summary>
        /// orderNum
        /// </summary>
        /// <returns></returns>
        [Column("ORDERNUM")]
        public string orderNum { get; set; }
        /// <summary>
        /// password
        /// </summary>
        /// <returns></returns>
        [Column("PASSWORD")]
        public string password { get; set; }
        /// <summary>
        /// zba001
        /// </summary>
        /// <returns></returns>
        [Column("ZBA001")]
        public string zba001 { get; set; }
        /// <summary>
        /// zba002
        /// </summary>
        /// <returns></returns>
        [Column("ZBA002")]
        public string zba002 { get; set; }
        /// <summary>
        /// zba102
        /// </summary>
        /// <returns></returns>
        [Column("ZBA102")]
        public string zba102 { get; set; }
        /// <summary>
        /// qwisopen
        /// </summary>
        /// <returns></returns>
        [Column("QWISOPEN")]
        public bool? qwisopen { get; set; }
        /// <summary>
        /// a827
        /// </summary>
        /// <returns></returns>
        [Column("A827")]
        public string a827 { get; set; }
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

