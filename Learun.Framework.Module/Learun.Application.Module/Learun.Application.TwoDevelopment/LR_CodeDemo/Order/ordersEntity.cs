using Learun.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-09 16:25
    /// 描 述：订单管理
    /// </summary>
    public class ordersEntity 
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
        /// deliveryFee
        /// </summary>
        /// <returns></returns>
        [Column("DELIVERYFEE")]
        public decimal? deliveryFee { get; set; }
        /// <summary>
        /// deliveryTypeName
        /// </summary>
        /// <returns></returns>
        [Column("DELIVERYTYPENAME")]
        public string deliveryTypeName { get; set; }
        /// <summary>
        /// memo
        /// </summary>
        /// <returns></returns>
        [Column("MEMO")]
        public string memo { get; set; }
        /// <summary>
        /// orderSn
        /// </summary>
        /// <returns></returns>
        [Column("ORDERSN")]
        public string orderSn { get; set; }
        /// <summary>
        /// orderStatus
        /// </summary>
        /// <returns></returns>
        [Column("ORDERSTATUS")]
        public string orderStatus { get; set; }
        /// <summary>
        /// paidAmount
        /// </summary>
        /// <returns></returns>
        [Column("PAIDAMOUNT")]
        public decimal? paidAmount { get; set; }
        /// <summary>
        /// paymentConfigName
        /// </summary>
        /// <returns></returns>
        [Column("PAYMENTCONFIGNAME")]
        public string paymentConfigName { get; set; }
        /// <summary>
        /// paymentFee
        /// </summary>
        /// <returns></returns>
        [Column("PAYMENTFEE")]
        public decimal? paymentFee { get; set; }
        /// <summary>
        /// paymentStatus
        /// </summary>
        /// <returns></returns>
        [Column("PAYMENTSTATUS")]
        public string paymentStatus { get; set; }
        /// <summary>
        /// productTotalPrice
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTTOTALPRICE")]
        public decimal? productTotalPrice { get; set; }
        /// <summary>
        /// productTotalQuantity
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTTOTALQUANTITY")]
        public int? productTotalQuantity { get; set; }
        /// <summary>
        /// productWeight
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTWEIGHT")]
        public decimal? productWeight { get; set; }
        /// <summary>
        /// productWeightUnit
        /// </summary>
        /// <returns></returns>
        [Column("PRODUCTWEIGHTUNIT")]
        public string productWeightUnit { get; set; }
        /// <summary>
        /// shipAddress
        /// </summary>
        /// <returns></returns>
        [Column("SHIPADDRESS")]
        public string shipAddress { get; set; }
        /// <summary>
        /// shipArea
        /// </summary>
        /// <returns></returns>
        [Column("SHIPAREA")]
        public string shipArea { get; set; }
        /// <summary>
        /// shipAreaPath
        /// </summary>
        /// <returns></returns>
        [Column("SHIPAREAPATH")]
        public string shipAreaPath { get; set; }
        /// <summary>
        /// shipMobile
        /// </summary>
        /// <returns></returns>
        [Column("SHIPMOBILE")]
        public string shipMobile { get; set; }
        /// <summary>
        /// shipName
        /// </summary>
        /// <returns></returns>
        [Column("SHIPNAME")]
        public string shipName { get; set; }
        /// <summary>
        /// shipPhone
        /// </summary>
        /// <returns></returns>
        [Column("SHIPPHONE")]
        public string shipPhone { get; set; }
        /// <summary>
        /// shipZipCode
        /// </summary>
        /// <returns></returns>
        [Column("SHIPZIPCODE")]
        public string shipZipCode { get; set; }
        /// <summary>
        /// shippingStatus
        /// </summary>
        /// <returns></returns>
        [Column("SHIPPINGSTATUS")]
        public string shippingStatus { get; set; }
        /// <summary>
        /// totalAmount
        /// </summary>
        /// <returns></returns>
        [Column("TOTALAMOUNT")]
        public decimal? totalAmount { get; set; }
        /// <summary>
        /// deliveryType_id
        /// </summary>
        /// <returns></returns>
        [Column("DELIVERYTYPE_ID")]
        public string deliveryType_id { get; set; }
        /// <summary>
        /// member_id
        /// </summary>
        /// <returns></returns>
        [Column("MEMBER_ID")]
        public string member_id { get; set; }
        /// <summary>
        /// paymentConfig_id
        /// </summary>
        /// <returns></returns>
        [Column("PAYMENTCONFIG_ID")]
        public string paymentConfig_id { get; set; }
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
        public int? standardPages { get; set; }
        /// <summary>
        /// shipType
        /// </summary>
        /// <returns></returns>
        [Column("SHIPTYPE")]
        public string shipType { get; set; }
        /// <summary>
        /// shipEmail
        /// </summary>
        /// <returns></returns>
        [Column("SHIPEMAIL")]
        public string shipEmail { get; set; }
        /// <summary>
        /// shipFox
        /// </summary>
        /// <returns></returns>
        [Column("SHIPFOX")]
        public string shipFox { get; set; }
        /// <summary>
        /// memberName
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERNAME")]
        public string memberName { get; set; }
        /// <summary>
        /// memberId
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERID")]
        public string memberId { get; set; }
        /// <summary>
        /// orderType
        /// </summary>
        /// <returns></returns>
        [Column("ORDERTYPE")]
        public string orderType { get; set; }
        /// <summary>
        /// admin_id
        /// </summary>
        /// <returns></returns>
        [Column("ADMIN_ID")]
        public string admin_id { get; set; }
        /// <summary>
        /// uploadstatu
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADSTATU")]
        public int? uploadstatu { get; set; }
        /// <summary>
        /// addtoPrice
        /// </summary>
        /// <returns></returns>
        [Column("ADDTOPRICE")]
        public decimal? addtoPrice { get; set; }
        /// <summary>
        /// ip
        /// </summary>
        /// <returns></returns>
        [Column("IP")]
        public string ip { get; set; }
        /// <summary>
        /// receiver_id
        /// </summary>
        /// <returns></returns>
        [Column("RECEIVER_ID")]
        public string receiver_id { get; set; }
        /// <summary>
        /// expressid
        /// </summary>
        /// <returns></returns>
        [Column("EXPRESSID")]
        public string expressid { get; set; }
        /// <summary>
        /// expressname
        /// </summary>
        /// <returns></returns>
        [Column("EXPRESSNAME")]
        public string expressname { get; set; }
        /// <summary>
        /// deleteType
        /// </summary>
        /// <returns></returns>
        [Column("DELETETYPE")]
        public string deleteType { get; set; }
        /// <summary>
        /// filepath
        /// </summary>
        /// <returns></returns>
        [Column("FILEPATH")]
        public string filepath { get; set; }
        /// <summary>
        /// excelpath
        /// </summary>
        /// <returns></returns>
        [Column("EXCELPATH")]
        public string excelpath { get; set; }
        /// <summary>
        /// op
        /// </summary>
        /// <returns></returns>
        [Column("OP")]
        public string op { get; set; }
        /// <summary>
        /// memberusername
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERUSERNAME")]
        public string memberusername { get; set; }
        /// <summary>
        /// addtoPricebei
        /// </summary>
        /// <returns></returns>
        [Column("ADDTOPRICEBEI")]
        public decimal? addtoPricebei { get; set; }

        /// <summary>
        /// 子项集合
        /// </summary>
        /// <returns></returns>
        public List<OrderItemEntity> childList { get; set; }
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

