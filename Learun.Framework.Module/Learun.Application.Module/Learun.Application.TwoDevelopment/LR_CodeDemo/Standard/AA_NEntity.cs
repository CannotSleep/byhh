using Learun.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-02-11 10:42
    /// 描 述：功能搜索和添加
    /// </summary>
    public class Standard
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string Id { get; set; }
        /// <summary>
        /// Oid
        /// </summary>
        /// <returns></returns>
        [Column("OID")]
        public int? Oid { get; set; }
        /// <summary>
        /// StandNum
        /// </summary>
        /// <returns></returns>
        [Column("STANDNUM")]
        public string StandNum { get; set; }
        /// <summary>
        /// ReleaseDate
        /// </summary>
        /// <returns></returns>
        [Column("ISD")]
        public string Isd { get; set; }
        /// <summary>
        /// ImplementationDate
        /// </summary>
        /// <returns></returns>
        [Column("EFD")]
        public string Efd { get; set; }
        /// <summary>
        /// AbolitionDate
        /// </summary>
        /// <returns></returns>
        [Column("ABOLITIONDATE")]
        public string AbolitionDate { get; set; }
        /// <summary>
        /// ChineseName
        /// </summary>
        /// <returns></returns>
        [Column("CN")]
        public string Cn { get; set; }
        /// <summary>
        /// EnglishName
        /// </summary>
        /// <returns></returns>
        [Column("EN")]
        public string En { get; set; }
        /// <summary>
        /// Pages
        /// </summary>
        /// <returns></returns>
        [Column("PAGES")]
        public int? Pages { get; set; }
        /// <summary>
        /// SubstituteStandard
        /// </summary>
        /// <returns></returns>
        [Column("SUBSTITUTESTANDARD")]
        public string SubstituteStandard { get; set; }
        /// <summary>
        /// SubstitutedStandard
        /// </summary>
        /// <returns></returns>
        [Column("SUBSTITUTEDSTANDARD")]
        public string SubstitutedStandard { get; set; }
        /// <summary>
        /// AdoptionRelationship
        /// </summary>
        /// <returns></returns>
        [Column("ADOPTIONRELATIONSHIP")]
        public string AdoptionRelationship { get; set; }
        /// <summary>
        /// EnglishSubjectWords
        /// </summary>
        /// <returns></returns>
        [Column("ENGLISHSUBJECTWORDS")]
        public string EnglishSubjectWords { get; set; }
        /// <summary>
        /// BidWinningNo
        /// </summary>
        /// <returns></returns>
        [Column("CCS")]
        public string Ccs { get; set; }
        /// <summary>
        /// GBN
        /// </summary>
        /// <returns></returns>
        [Column("GBN")]
        public string Gbn { get; set; }
        /// <summary>
        /// ICS
        /// </summary>
        /// <returns></returns>
        [Column("ICS")]
        public string Ics { get; set; }
        /// <summary>
        /// LastModifyTime
        /// </summary>
        /// <returns></returns>
        [Column("LASTMODIFYTIME")]
        public String LastModifyTime { get; set; }
        /// <summary>
        /// CollectionMark
        /// </summary>
        /// <returns></returns>
        [Column("COLLECTIONMARK")]
        public string CollectionMark { get; set; }
        /// <summary>
        /// SingleCopy
        /// </summary>
        /// <returns></returns>
        [Column("SINGLECOPY")]
        public string SingleCopy { get; set; }
        /// <summary>
        /// CdRom
        /// </summary>
        /// <returns></returns>
        [Column("CDROM")]
        public string CdRom { get; set; }
        /// <summary>
        /// a903
        /// </summary>
        /// <returns></returns>
        [Column("A903")]
        public string a903 { get; set; }
        /// <summary>
        /// TextAddress
        /// </summary>
        /// <returns></returns>
        [Column("TEXTADDRESS")]
        public string TextAddress { get; set; }
        /// <summary>
        /// Amendment
        /// </summary>
        /// <returns></returns>
        [Column("AMENDMENT")]
        public string Amendment { get; set; }
        /// <summary>
        /// FirstRecordingTime
        /// </summary>
        /// <returns></returns>
        [Column("FIRSTRECORDINGTIME")]
        public string FirstRecordingTime { get; set; }
        /// <summary>
        /// TypesTitles
        /// </summary>
        /// <returns></returns>
        [Column("TYPESTITLES")]
        public string TypesTitles { get; set; }
        /// <summary>
        /// WayAdding
        /// </summary>
        /// <returns></returns>
        [Column("WAYADDING")]
        public string WayAdding { get; set; }
        /// <summary>
        /// OrganizationNumber
        /// </summary>
        /// <returns></returns>
        [Column("ORGANIZATIONNUMBER")]
        public string OrganizationNumber { get; set; }
        /// <summary>
        /// SequenceNumber
        /// </summary>
        /// <returns></returns>
        [Column("SEQUENCENUMBER")]
        public string SequenceNumber { get; set; }
        /// <summary>
        /// AgeNumber
        /// </summary>
        /// <returns></returns>
        [Column("AGENUMBER")]
        public string AgeNumber { get; set; }
        /// <summary>
        /// LastModifiedIP
        /// </summary>
        /// <returns></returns>
        [Column("LASTMODIFIEDIP")]
        public string LastModifiedIP { get; set; }
        /// <summary>
        /// ScopeApplication
        /// </summary>
        /// <returns></returns>
        [Column("SCOPE")]
        public string Scope { get; set; }
        /// <summary>
        /// TableName
        /// </summary>
        /// <returns></returns>
        [Column("TABLENAME")]
        public string TableName { get; set; }
        /// <summary>
        /// Preface
        /// </summary>
        /// <returns></returns>
        [Column("PREFACE")]
        public string Preface { get; set; }
        /// <summary>
        /// Introduction
        /// </summary>
        /// <returns></returns>
        [Column("INTRODUCTION")]
        public string Introduction { get; set; }
        /// <summary>
        /// PublishingUnit
        /// </summary>
        /// <returns></returns>
        [Column("PUBLISHINGUNIT")]
        public string PublishingUnit { get; set; }
        /// <summary>
        /// ApprovedUnit
        /// </summary>
        /// <returns></returns>
        [Column("APPROVEDUNIT")]
        public string ApprovedUnit { get; set; }
        /// <summary>
        /// ConfirmationDate
        /// </summary>
        /// <returns></returns>
        [Column("CONFIRMATIONDATE")]
        public string ConfirmationDate { get; set; }
        /// <summary>
        /// DraftingUnit
        /// </summary>
        /// <returns></returns>
        [Column("DRAFTINGUNIT")]
        public string DraftingUnit { get; set; }
        /// <summary>
        /// RecordNumber
        /// </summary>
        /// <returns></returns>
        [Column("RECORDNUMBER")]
        public string RecordNumber { get; set; }
        /// <summary>
        /// Supplement
        /// </summary>
        /// <returns></returns>
        [Column("SUPPLEMENT")]
        public string Supplement { get; set; }
        /// <summary>
        /// ChineseThemeWords
        /// </summary>
        /// <returns></returns>
        [Column("CHINESETHEMEWORDS")]
        public string ChineseThemeWords { get; set; }
        /// <summary>
        /// StandardType
        /// </summary>
        /// <returns></returns>
        [Column("STANDARDTYPE")]
        public string StandardType { get; set; }
        /// <summary>
        /// ProposedUnit
        /// </summary>
        /// <returns></returns>
        [Column("PROPOSEDUNIT")]
        public string ProposedUnit { get; set; }
        /// <summary>
        /// ClassificationEconomy
        /// </summary>
        /// <returns></returns>
        [Column("CLASSIFICATIONECONOMY")]
        public string ClassificationEconomy { get; set; }
        /// <summary>
        /// OriginalName
        /// </summary>
        /// <returns></returns>
        [Column("ORIGINALNAME")]
        public string OriginalName { get; set; }
        /// <summary>
        /// StandStatus
        /// </summary>
        /// <returns></returns>
        [Column("STANDSTATUS")]
        public string StandStatus { get; set; }
        /// <summary>
        /// SortField
        /// </summary>
        /// <returns></returns>
        [Column("SORTFIELD")]
        public string SortField { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public string CreateTime { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYDATE")]
        public string ModifyDate { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public int? Status { get; set; }
        /// <summary>
        /// SubStandard
        /// </summary>
        /// <returns></returns>
        [Column("SUBSTANDARD")]
        public string SubStandard { get; set; }
        /// <summary>
        /// ElectronicSource
        /// </summary>
        /// <returns></returns>
        [Column("ELECTRONICSOURCE")]
        public string ElectronicSource { get; set; }
        /// <summary>
        /// Languages
        /// </summary>
        /// <returns></returns>
        [Column("LANGUAGES")]
        public string Languages { get; set; }
        /// <summary>
        /// IsTranslation
        /// </summary>
        /// <returns></returns>
        [Column("ISTRANSLATION")]
        public string IsTranslation { get; set; }
        /// <summary>
        /// TechnicalCommittees
        /// </summary>
        /// <returns></returns>
        [Column("TECHNICALCOMMITTEES")]
        public string TechnicalCommittees { get; set; }
        /// <summary>
        /// IsTranslationd
        /// </summary>
        /// <returns></returns>
        [Column("ISTRANSLATIOND")]
        public string IsTranslationd { get; set; }
        /// <summary>
        /// TranslationLanguage
        /// </summary>
        /// <returns></returns>
        [Column("TRANSLATIONLANGUAGE")]
        public string TranslationLanguage { get; set; }
        /// <summary>
        /// AffiliatedCommittee
        /// </summary>
        /// <returns></returns>
        [Column("AFFILIATEDCOMMITTEE")]
        public string AffiliatedCommittee { get; set; }
        /// <summary>
        /// NameTheStandard
        /// </summary>
        /// <returns></returns>
        [Column("NAMETHESTANDARD")]
        public string NameTheStandard { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        /// <returns></returns>
        [Column("ISBN")]
        public string ISBN { get; set; }
        /// <summary>
        /// IsAudited
        /// </summary>
        /// <returns></returns>
        [Column("ISAUDITED")]
        public string IsAudited { get; set; }
        /// <summary>
        /// ConvertCharacters
        /// </summary>
        /// <returns></returns>
        [Column("CONVERTCHARACTERS")]
        public string ConvertCharacters { get; set; }
        /// <summary>
        /// IsArtSort
        /// </summary>
        /// <returns></returns>
        [Column("ISARTSORT")]
        public int? IsArtSort { get; set; }
        /// <summary>
        /// zb_a001
        /// </summary>
        /// <returns></returns>
        [Column("ZB_A001")]
        public string zb_a001 { get; set; }
        /// <summary>
        /// zb_c003
        /// </summary>
        /// <returns></returns>
        [Column("ZB_C003")]
        public string zb_c003 { get; set; }
        /// <summary>
        /// zb_c004
        /// </summary>
        /// <returns></returns>
        [Column("ZB_C004")]
        public string zb_c004 { get; set; }
        /// <summary>
        /// zb_c005
        /// </summary>
        /// <returns></returns>
        [Column("ZB_C005")]
        public string zb_c005 { get; set; }
        /// <summary>
        /// zb_c002
        /// </summary>
        /// <returns></returns>
        [Column("ZB_C002")]
        public string zb_c002 { get; set; }
        /// <summary>
        /// zb_a300
        /// </summary>
        /// <returns></returns>
        [Column("ZB_A300")]
        public string zb_a300 { get; set; }
        /// <summary>
        /// zb_updateTime
        /// </summary>
        /// <returns></returns>
        [Column("ZB_UPDATETIME")]
        public string zb_updateTime { get; set; }
        /// <summary>
        /// zb_updateType
        /// </summary>
        /// <returns></returns>
        [Column("ZB_UPDATETYPE")]
        public string zb_updateType { get; set; }
        /// <summary>
        /// zb_c006
        /// </summary>
        /// <returns></returns>
        [Column("ZB_C006")]
        public string zb_c006 { get; set; }
        /// <summary>
        /// isfree
        /// </summary>
        /// <returns></returns>
        [Column("ISFREE")]
        public string isfree { get; set; }
        public string CategoryCode { get; set; }

        public List<StandardItem> childList { get; set; }


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
        public class StandardStatic{
            public string abt { get; set; }
            public string gbt { get; set; }
            public string dbt { get; set; }

        }
    }
}

