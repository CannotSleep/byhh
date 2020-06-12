using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-03-03 14:36
    /// 描 述：会员管理
    /// </summary>
    public class memberEntity 
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string Id { get; set; }
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
        /// Deposit
        /// </summary>
        /// <returns></returns>
        [Column("DEPOSIT")]
        public decimal? Deposit { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        [Column("EMAIL")]
        public string Email { get; set; }
        /// <summary>
        /// AccountName
        /// </summary>
        /// <returns></returns>
        [Column("ACCOUNTNAME")]
        public string AccountName { get; set; }
        /// <summary>
        /// isAccountEnabled
        /// </summary>
        /// <returns></returns>
        [Column("ISACCOUNTENABLED")]
        public bool? isAccountEnabled { get; set; }
        /// <summary>
        /// isAccountLocked
        /// </summary>
        /// <returns></returns>
        [Column("ISACCOUNTLOCKED")]
        public bool? isAccountLocked { get; set; }
        /// <summary>
        /// isAccountExpired
        /// </summary>
        /// <returns></returns>
        [Column("ISACCOUNTEXPIRED")]
        public bool? isAccountExpired { get; set; }
        /// <summary>
        /// isCredentialsExpired
        /// </summary>
        /// <returns></returns>
        [Column("ISCREDENTIALSEXPIRED")]
        public bool? isCredentialsExpired { get; set; }
        /// <summary>
        /// LockedDate
        /// </summary>
        /// <returns></returns>
        [Column("LOCKEDDATE")]
        public DateTime? LockedDate { get; set; }
        /// <summary>
        /// LastLoginDate
        /// </summary>
        /// <returns></returns>
        [Column("LASTLOGINDATE")]
        public DateTime? LastLoginDate { get; set; }
        /// <summary>
        /// LoginFailureCount
        /// </summary>
        /// <returns></returns>
        [Column("LOGINFAILURECOUNT")]
        public int? LoginFailureCount { get; set; }
        /// <summary>
        /// LastLoginIp
        /// </summary>
        /// <returns></returns>
        [Column("LASTLOGINIP")]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        /// <returns></returns>
        [Column("PASSWORD")]
        public string Password { get; set; }
        /// <summary>
        /// PasswordRecoverKey
        /// </summary>
        /// <returns></returns>
        [Column("PASSWORDRECOVERKEY")]
        public string PasswordRecoverKey { get; set; }
        /// <summary>
        /// RechargeIntegral
        /// </summary>
        /// <returns></returns>
        [Column("RECHARGEINTEGRAL")]
        public int? RechargeIntegral { get; set; }
        /// <summary>
        /// RegisterIp
        /// </summary>
        /// <returns></returns>
        [Column("REGISTERIP")]
        public string RegisterIp { get; set; }
        /// <summary>
        /// SafeAnswer
        /// </summary>
        /// <returns></returns>
        [Column("SAFEANSWER")]
        public string SafeAnswer { get; set; }
        /// <summary>
        /// SafeQuestion
        /// </summary>
        /// <returns></returns>
        [Column("SAFEQUESTION")]
        public string SafeQuestion { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        /// <returns></returns>
        [Column("USERNAME")]
        public string UserName { get; set; }
        /// <summary>
        /// MemberRankId
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERRANKID")]
        public string MemberRankId { get; set; }
        /// <summary>
        /// OuidId
        /// </summary>
        /// <returns></returns>
        [Column("OUIDID")]
        public string OuidId { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>
        /// <returns></returns>
        [Column("PARENTID")]
        public string ParentId { get; set; }
        /// <summary>
        /// MemberTel
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERTEL")]
        public string MemberTel { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        /// <returns></returns>
        [Column("COMPANYNAME")]
        public string CompanyName { get; set; }
        /// <summary>
        /// TatolDeposit
        /// </summary>
        /// <returns></returns>
        [Column("TATOLDEPOSIT")]
        public decimal? TatolDeposit { get; set; }
        /// <summary>
        /// Consume
        /// </summary>
        /// <returns></returns>
        [Column("CONSUME")]
        public decimal? Consume { get; set; }
        /// <summary>
        /// ConsumePoint
        /// </summary>
        /// <returns></returns>
        [Column("CONSUMEPOINT")]
        public int? ConsumePoint { get; set; }
        /// <summary>
        /// TatolPoint
        /// </summary>
        /// <returns></returns>
        [Column("TATOLPOINT")]
        public int? TatolPoint { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        /// <returns></returns>
        [Column("FAX")]
        public string Fax { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        [Column("ADDRESS")]
        public string Address { get; set; }
        /// <summary>
        /// MemberPost
        /// </summary>
        /// <returns></returns>
        [Column("MEMBERPOST")]
        public string MemberPost { get; set; }
        /// <summary>
        /// Tel
        /// </summary>
        /// <returns></returns>
        [Column("TEL")]
        public string Tel { get; set; }
        /// <summary>
        /// Postal
        /// </summary>
        /// <returns></returns>
        [Column("POSTAL")]
        public string Postal { get; set; }
        /// <summary>
        /// Department
        /// </summary>
        /// <returns></returns>
        [Column("DEPARTMENT")]
        public string Department { get; set; }
        /// <summary>
        /// Rank
        /// </summary>
        /// <returns></returns>
        [Column("RANK")]
        public string Rank { get; set; }
        /// <summary>
        /// Ics
        /// </summary>
        /// <returns></returns>
        [Column("ICS")]
        public string Ics { get; set; }
        /// <summary>
        /// Nodes
        /// </summary>
        /// <returns></returns>
        [Column("NODES")]
        public string Nodes { get; set; }
        /// <summary>
        /// ActiveType
        /// </summary>
        /// <returns></returns>
        [Column("ACTIVETYPE")]
        public int? ActiveType { get; set; }
        /// <summary>
        /// ActiveKey
        /// </summary>
        /// <returns></returns>
        [Column("ACTIVEKEY")]
        public string ActiveKey { get; set; }
        /// <summary>
        /// ActiveDate
        /// </summary>
        /// <returns></returns>
        [Column("ACTIVEDATE")]
        public DateTime? ActiveDate { get; set; }
        /// <summary>
        /// IsAdmin
        /// </summary>
        /// <returns></returns>
        [Column("ISADMIN")]
        public bool? IsAdmin { get; set; }
        /// <summary>
        /// Bz
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string Bz { get; set; }
        /// <summary>
        /// Area
        /// </summary>
        /// <returns></returns>
        [Column("AREA")]
        public string Area { get; set; }
        /// <summary>
        /// OrderIIemNum
        /// </summary>
        /// <returns></returns>
        [Column("ORDERIIEMNUM")]
        public int? OrderIIemNum { get; set; }
        /// <summary>
        /// LoginNum
        /// </summary>
        /// <returns></returns>
        [Column("LOGINNUM")]
        public int? LoginNum { get; set; }
        /// <summary>
        /// CompanyIcs
        /// </summary>
        /// <returns></returns>
        [Column("COMPANYICS")]
        public string CompanyIcs { get; set; }
        /// <summary>
        /// Security
        /// </summary>
        /// <returns></returns>
        [Column("SECURITY")]
        public int? Security { get; set; }
        /// <summary>
        /// SpaceSize
        /// </summary>
        /// <returns></returns>
        [Column("SPACESIZE")]
        public string SpaceSize { get; set; }
        /// <summary>
        /// CompanyIcsName
        /// </summary>
        /// <returns></returns>
        [Column("COMPANYICSNAME")]
        public string CompanyIcsName { get; set; }
        /// <summary>
        /// MaxMoney
        /// </summary>
        /// <returns></returns>
        [Column("MAXMONEY")]
        public decimal? MaxMoney { get; set; }
        /// <summary>
        /// IsMaxMoney
        /// </summary>
        /// <returns></returns>
        [Column("ISMAXMONEY")]
        public bool? IsMaxMoney { get; set; }
        /// <summary>
        /// Remarks
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string Remarks { get; set; }
        /// <summary>
        /// Copr
        /// </summary>
        /// <returns></returns>
        [Column("COPR")]
        public bool? Copr { get; set; }
        /// <summary>
        /// SourceType
        /// </summary>
        /// <returns></returns>
        [Column("SOURCETYPE")]
        public string SourceType { get; set; }
        /// <summary>
        /// EnterpriseType
        /// </summary>
        /// <returns></returns>
        [Column("ENTERPRISETYPE")]
        public string EnterpriseType { get; set; }
        /// <summary>
        /// PathStandard
        /// </summary>
        /// <returns></returns>
        [Column("PATHSTANDARD")]
        public string PathStandard { get; set; }
        /// <summary>
        /// QuStandard
        /// </summary>
        /// <returns></returns>
        [Column("QUSTANDARD")]
        public string QuStandard { get; set; }
        /// <summary>
        /// Qyisopen
        /// </summary>
        /// <returns></returns>
        [Column("QYISOPEN")]
        public bool? Qyisopen { get; set; }
        /// <summary>
        /// DownloadNumber
        /// </summary>
        /// <returns></returns>
        [Column("DOWNLOADNUMBER")]
        public int? DownloadNumber { get; set; }
        /// <summary>
        /// Factdescription
        /// </summary>
        /// <returns></returns>
        [Column("FACTDESCRIPTION")]
        public string Factdescription { get; set; }
        /// <summary>
        /// Ischeckip
        /// </summary>
        /// <returns></returns>
        [Column("ISCHECKIP")]
        public bool? Ischeckip { get; set; }
        [NotMapped]
        public string Viplevel { get; set; }
        [NotMapped]
        public string Discount { get; set; }

        [NotMapped]
        public string BRecharge { get; set; }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 登录信息
        /// </summary>
        [NotMapped]
        public string LoginMsg { get; set; }
        /// <summary>
        /// 登录状态
        /// </summary>
        [NotMapped]
        public bool LoginOk { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Id = Guid.NewGuid().ToString();
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

