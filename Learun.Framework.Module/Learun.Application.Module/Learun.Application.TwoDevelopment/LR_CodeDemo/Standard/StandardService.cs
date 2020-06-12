using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Learun.Application.TwoDevelopment.LR_CodeDemo.Standard;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-02-11 10:42
    /// 描 述：功能搜索和添加
    /// </summary>
    public class StandardService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        StandardItemService standardItemService = new StandardItemService();
        public StandardService()
        {
            fieldSql=@"
                t.Id,
                t.Oid,
                t.StandNum,
                t.isd,
                t.efd,
                t.AbolitionDate,
                t.cn,
                t.en,
                t.Pages,
                t.SubstituteStandard,
                t.SubstitutedStandard,
                t.AdoptionRelationship,
                t.EnglishSubjectWords,
                t.ccs,
                t.gbn,
                t.ics,
                t.LastModifyTime,
                t.CollectionMark,
                t.SingleCopy,
                t.CdRom,
                t.a903,
                t.TextAddress,
                t.Amendment,
                t.FirstRecordingTime,
                t.TypesTitles,
                t.WayAdding,
                t.OrganizationNumber,
                t.SequenceNumber,
                t.AgeNumber,
                t.LastModifiedIP,
                t.scope,
                t.TableName,
                t.preface,
                t.introduction,
                t.PublishingUnit,
                t.ApprovedUnit,
                t.ConfirmationDate,
                t.DraftingUnit,
                t.RecordNumber,
                t.Supplement,
                t.ChineseThemeWords,
                t.StandardType,
                t.ProposedUnit,
                t.ClassificationEconomy,
                t.OriginalName,
                t.StandStatus,
                t.SortField,
                t.CreateTime,
                t.ModifyDate,
                t.Status,
                t.SubStandard,
                t.ElectronicSource,
                t.Languages,
                t.IsTranslation,
                t.TechnicalCommittees,
                t.IsTranslationd,
                t.TranslationLanguage,
                t.AffiliatedCommittee,
                t.NameTheStandard,
                t.ISBN,
                t.IsAudited,
                t.ConvertCharacters,
                t.IsArtSort,
                t.zb_a001,
                t.zb_c003,
                t.zb_c004,
                t.zb_c005,
                t.zb_c002,
                t.zb_a300,
                t.zb_updateTime,
                t.zb_updateType,
                t.zb_c006,
                t.isfree
            ";
        }
        #endregion

        #region 获取数据


        /// <summary>
        /// 获取所有表名称
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllTable()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append("Name");
                strSql.Append(" FROM SysObjects  where XType='U'");
                return this.BaseRepository("标准库").FindList<string>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 根据表名获取表格数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> GetListByTableName(string tname)
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM "+ tname +" t");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(",m.CategoryCode as CategoryCode ");
                strSql.Append(" FROM standard t left join organization m on t.OrganizationNumber = m.OraganizationCode and t.TableName = m.OraganId");
                if (!string.IsNullOrWhiteSpace(queryJson)) {
                    strSql.Append("where Id = "+"'"+queryJson+"'");
                }
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Standard t ");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString(), pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Standard GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("标准库").FindEntity<Standard>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取标准数量接口
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public StandardStatic GetStandardCount()
        {
            try
            {
                //全标准
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append("count(*)  as tt");
                strSql.Append(" FROM Standard");
                //地方标准数量
                var strSql2 = new StringBuilder();
                strSql2.Append("SELECT ");
                strSql2.Append("count(*)  as tt");
                strSql2.Append(" FROM dbstandard  where OrganizationNumber in (select OraganizationCode from organization where CategoryCode ='D')");
                //国标数量
                var strSql3 = new StringBuilder();
                strSql3.Append("SELECT ");
                strSql3.Append("count(*) as tt");
                strSql3.Append(" FROM gbstandard");
                StandardStatic standardStatic = new StandardStatic();
                standardStatic.abt = this.BaseRepository("标准库").FindTable(strSql.ToString()).Rows[0][0].ToString();
                standardStatic.dbt = this.BaseRepository("标准库").FindTable(strSql2.ToString()).Rows[0][0].ToString();
                standardStatic.gbt = this.BaseRepository("标准库").FindTable(strSql3.ToString()).Rows[0][0].ToString();

                return standardStatic;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        /// <summary>
        /// 获取视图实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> GetViewEntity(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Standard t where t.Id = '" + keyValue +"';");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        /// <summary>
        /// 标准追踪
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> TrackStandard(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Standard t where t.StandNum in (" + keyValue + ")");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }



        /// <summary>
        /// 标准模糊追踪
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> TrackMohuStandard(string keyValue)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Standard t where t.StandNum like '%" + keyValue + "%'");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        /// <summary>
        /// 获取近期发布标准
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> GetRecentlyReleased()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT top 7");
                strSql.Append("t.Id,t.StandNum,t.isd,t.cn");
                strSql.Append(" FROM Standard t where t.isd > CONVERT(varchar(10),GETDATE()-120,120) order by t.isd desc");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取即将实施标准
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Standard> GetComingSoon()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT top 7");
                strSql.Append("t.Id,t.StandNum,t.efd,t.cn");
                strSql.Append(" FROM Standard t order by t.efd desc");
                return this.BaseRepository("标准库").FindList<Standard>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue,string tableName)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("delete from " + tableName);
                strSql.Append(" where Id = "+"'"+keyValue+"'");

                var strSq2 = new StringBuilder();
                strSq2.Append("delete from " + tableName+"_W");
                strSq2.Append(" where BId = "+"'"+keyValue+"'");

                this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());
                this.BaseRepository("标准库").ExecuteBySql(strSq2.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, Standard entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //编辑
                    //entity.Modify(keyValue);
                    //更新子项
                    //先删除子项 再插入
                    standardItemService.DeleteEntity(entity.Id,entity.TableName);

                    if (entity.childList != null)
                    {
                        List<StandardItem> childList = entity.childList;
                        foreach (var item in childList)
                        {
                            standardItemService.SaveEntity(item.Id, item);
                        }
                    }
                    var strSql = new StringBuilder();
                    strSql.Append("update " + entity.TableName+" ");
                    strSql.Append("SET  Oid=" +"'"+ entity.Oid+"'"+",");
                    strSql.Append("  StandNum=" + "'"  + entity.StandNum + "'"+ ",");
                    strSql.Append("  isd=" +"'"+entity.Isd + "'" + ",");
                    strSql.Append("  efd=" +"'"+entity.Efd + "'" + ",");
                    strSql.Append("  AbolitionDate=" + "'" + entity.AbolitionDate + "'" + ",");
                    strSql.Append("  cn=" + "'" + entity.Cn + "'" + ",");
                    strSql.Append("  en=" + "'" + entity.En + "'" + ",");
                    strSql.Append("  Pages=" + "'" + entity.Pages + "'" + ",");
                    strSql.Append("  SubstituteStandard=" + "'" + entity.SubstituteStandard + "'" + ",");
                    strSql.Append("  SubstitutedStandard=" + "'" + entity.SubstitutedStandard + "'" + ",");
                    strSql.Append("  AdoptionRelationship=" + "'" + entity.AdoptionRelationship + "'" + ",");
                    strSql.Append("  EnglishSubjectWords=" + "'" + entity.EnglishSubjectWords + "'" + ",");
                    strSql.Append("  ccs=" + "'" + entity.Ccs + "'" + ",");
                    strSql.Append("  ics=" + "'" + entity.Ics + "'" + ",");
                    strSql.Append("  gbn=" + "'" + entity.Gbn + "'" + ",");
                    strSql.Append("  LastModifyTime=" + "'" + entity.LastModifyTime + "'" + ",");
                    strSql.Append("  CollectionMark=" + "'" + entity.CollectionMark + "'" + ",");
                    strSql.Append("  SingleCopy=" + "'" + entity.SingleCopy + "'" + ",");
                    strSql.Append("  CdRom=" + "'" + entity.CdRom + "'" + ",");
                    strSql.Append("  a903=" + "'" + entity.a903 + "'" + ",");
                    strSql.Append("  TextAddress=" + "'" + entity.TextAddress + "'" + ",");
                    strSql.Append("  Amendment=" + "'" + entity.Amendment + "'" + ",");
                    strSql.Append("  FirstRecordingTime=" + "'" + entity.FirstRecordingTime + "'" + ",");
                    strSql.Append("  TypesTitles=" + "'" + entity.TypesTitles + "'" + ",");
                    strSql.Append("  WayAdding=" + "'" + entity.WayAdding + "'" + ",");
                    strSql.Append("  OrganizationNumber=" + "'" + entity.OrganizationNumber + "'" + ",");
                    strSql.Append("  SequenceNumber=" + "'" + entity.SequenceNumber + "'" + ",");
                    strSql.Append("  AgeNumber=" + "'" + entity.AgeNumber + "'" + ",");
                    strSql.Append("  LastModifiedIP=" + "'" + entity.LastModifiedIP + "'" + ",");
                    strSql.Append("  scope=" + "'" + entity.Scope + "'" + ",");
                    strSql.Append("  TableName=" + "'" + entity.TableName + "'" + ",");
                    strSql.Append("  preface=" + "'" + entity.Preface + "'" + ",");
                    strSql.Append("  introduction=" + "'" + entity.Introduction + "'" + ",");
                    strSql.Append("  PublishingUnit=" + "'" + entity.PublishingUnit + "'" + ",");
                    strSql.Append("  ApprovedUnit=" + "'" + entity.ApprovedUnit + "'" + ",");
                    strSql.Append("  ConfirmationDate=" + "'" + entity.ConfirmationDate + "'" + ",");
                    strSql.Append("  DraftingUnit=" + "'" + entity.DraftingUnit + "'" + ",");
                    strSql.Append("  RecordNumber=" + "'" + entity.RecordNumber + "'" + ",");
                    strSql.Append("  Supplement=" + "'" + entity.Supplement + "'" + ",");
                    strSql.Append("  ChineseThemeWords=" + "'" + entity.ChineseThemeWords + "'" + ",");
                    strSql.Append("  StandardType=" + "'" + entity.StandardType + "'" + ",");
                    strSql.Append("  ProposedUnit=" + "'" + entity.ProposedUnit + "'" + ",");
                    strSql.Append("  ClassificationEconomy=" + "'" + entity.ClassificationEconomy + "'" + ",");
                    strSql.Append("  OriginalName=" + "'" + entity.OriginalName + "'" + ",");
                    strSql.Append("  StandStatus=" + "'" + entity.StandStatus + "'" + ",");
                    strSql.Append("  SortField=" + "'" + entity.SortField + "'" + ",");
                    strSql.Append("  CreateTime=" + "'" + entity.CreateTime + "'" + ",");
                    strSql.Append("  ModifyDate=" + "'" + entity.ModifyDate + "'" + ",");
                    strSql.Append("  Status=" + "'" + entity.Status + "'" + ",");
                    strSql.Append("  SubStandard=" + "'" + entity.SubStandard + "'" + ",");
                    if (!string.IsNullOrWhiteSpace(entity.ElectronicSource)) {
                        strSql.Append("  ElectronicSource=" + "'" + entity.ElectronicSource + "'" + ",");
                    }
                    strSql.Append("  Languages=" + "'" + entity.Languages + "'" + ",");
                    strSql.Append("  IsTranslation=" + "'" + entity.IsTranslation + "'" + ",");
                    strSql.Append("  TechnicalCommittees=" + "'" + entity.TechnicalCommittees + "'" + ",");
                    strSql.Append("  IsTranslationd=" + "'" + entity.IsTranslationd + "'" + ",");
                    strSql.Append("  TranslationLanguage=" + "'" + entity.TranslationLanguage + "'" + ",");
                    strSql.Append("  AffiliatedCommittee=" + "'" + entity.AffiliatedCommittee + "'" + ",");
                    strSql.Append("  NameTheStandard=" + "'" + entity.NameTheStandard + "'" + ",");
                    strSql.Append("  ISBN=" + "'" + entity.ISBN + "'" + ",");
                    strSql.Append("  IsAudited=" + "'" + entity.IsAudited + "'" + ",");
                    strSql.Append("  ConvertCharacters=" + "'" + entity.ConvertCharacters + "'" + ",");
                    strSql.Append("  IsArtSort=" + "'" + entity.IsArtSort + "'" + ",");
                    strSql.Append("  zb_a001=" + "'" + entity.zb_a001 + "'" + ",");
                    strSql.Append("  zb_c003=" + "'" + entity.zb_c003 + "'" + ",");
                    strSql.Append("  zb_c004=" + "'" + entity.zb_c004 + "'" + ",");
                    strSql.Append("  zb_c005=" + "'" + entity.zb_c005 + "'" + ",");
                    strSql.Append("  zb_a300=" + "'" + entity.zb_a300 + "'" + ",");
                    strSql.Append("  zb_updateTime=" + "'" + entity.zb_updateTime + "'" + ",");
                    strSql.Append("  zb_updateType=" + "'" + entity.zb_updateType + "'" + ",");
                    strSql.Append("  zb_c006=" + "'" + entity.zb_c006 + "'" + ",");
                    strSql.Append("  isfree=" + "'" + entity.isfree + "'"); 
                    strSql.Append(" where Id = "+"'"+entity.Id+"'");
                    this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());
                }
                else
                {
                    //entity.Create();
                    //插入子项
                    if (entity.childList!=null) {
                        List<StandardItem> childList = entity.childList;
                        foreach (var item in childList)
                        {
                            standardItemService.SaveEntity("", item);
                        }
                    }
                    var strSql = new StringBuilder();
                    strSql.Append("insert into "+entity.TableName+ "(Id,Oid,StandNum,isd,efd,AbolitionDate,cn,en,Pages,SubstituteStandard, SubstitutedStandard,AdoptionRelationship,EnglishSubjectWords,ccs,ics,gbn,LastModifyTime, CollectionMark,SingleCopy,CdRom,a903,TextAddress,Amendment,FirstRecordingTime,TypesTitles, WayAdding,OrganizationNumber,SequenceNumber,AgeNumber,LastModifiedIP,scope,TableName, preface,introduction,PublishingUnit,ApprovedUnit,ConfirmationDate,DraftingUnit,RecordNumber, Supplement,ChineseThemeWords,StandardType,ProposedUnit,ClassificationEconomy,OriginalName, StandStatus,SortField,CreateTime,ModifyDate,Status,SubStandard,ElectronicSource,Languages, IsTranslation,TechnicalCommittees,IsTranslationd,TranslationLanguage,AffiliatedCommittee, NameTheStandard,ISBN,IsAudited,ConvertCharacters,IsArtSort,zb_a001,zb_c003,zb_c004,zb_c005,zb_c002, zb_a300,zb_updateTime,zb_updateType,zb_c006,isfree) ");
                    strSql.Append("values (");
                    strSql.Append("'" + entity.Id + "'" + ',');
                    strSql.Append("'" + entity.Oid + "'" + ',');
                    strSql.Append("'" + entity.StandNum + "'" + ',');
                    strSql.Append("'" + entity.Isd + "'" + ',');
                    strSql.Append("'" + entity.Efd + "'" + ',');
                    strSql.Append("'" + entity.AbolitionDate + "'" + ',');
                    strSql.Append("'" + entity.Cn + "'" + ',');
                    strSql.Append("'" + entity.En + "'" + ',');
                    strSql.Append("'" + entity.Pages + "'" + ',');
                    strSql.Append("'" + entity.SubstituteStandard + "'" + ',');
                    strSql.Append("'" + entity.SubstitutedStandard + "'" + ',');
                    strSql.Append("'" + entity.AdoptionRelationship + "'" + ',');
                    strSql.Append("'" + entity.EnglishSubjectWords + "'" + ',');
                    strSql.Append("'" + entity.Ccs + "'" + ',');
                    strSql.Append("'" + entity.Ics + "'" + ',');
                    strSql.Append("'" + entity.Gbn + "'" + ',');
                    strSql.Append("'" + entity.LastModifyTime + "'" + ',');
                    strSql.Append("'" + entity.CollectionMark + "'" + ',');
                    strSql.Append("'" + entity.SingleCopy + "'" + ',');
                    strSql.Append("'" + entity.CdRom + "'" + ',');
                    strSql.Append("'" + entity.a903 + "'" + ',');
                    strSql.Append("'" + entity.TextAddress + "'" + ',');
                    strSql.Append("'" + entity.Amendment + "'" + ',');
                    strSql.Append("'" + entity.FirstRecordingTime + "'" + ',');
                    strSql.Append("'" + entity.TypesTitles + "'" + ',');
                    strSql.Append("'" + entity.WayAdding + "'" + ',');
                    strSql.Append("'" + entity.OrganizationNumber + "'" + ',');
                    strSql.Append("'" + entity.SequenceNumber + "'" + ',');
                    strSql.Append("'" + entity.AgeNumber + "'" + ',');
                    strSql.Append("'" + entity.LastModifiedIP + "'" + ',');
                    strSql.Append("'" + entity.Scope + "'" + ',');
                    strSql.Append("'" + entity.TableName + "'" + ',');
                    strSql.Append("'" + entity.Preface + "'" + ',');
                    strSql.Append("'" + entity.Introduction + "'" + ',');
                    strSql.Append("'" + entity.PublishingUnit + "'" + ',');
                    strSql.Append("'" + entity.ApprovedUnit + "'" + ',');
                    strSql.Append("'" + entity.ConfirmationDate + "'" + ',');
                    strSql.Append("'" + entity.DraftingUnit + "'" + ',');
                    strSql.Append("'" + entity.RecordNumber + "'" + ',');
                    strSql.Append("'" + entity.Supplement + "'" + ',');
                    strSql.Append("'" + entity.ChineseThemeWords + "'" + ',');
                    strSql.Append("'" + entity.StandardType + "'" + ',');
                    strSql.Append("'" + entity.ProposedUnit + "'" + ',');
                    strSql.Append("'" + entity.ClassificationEconomy + "'" + ',');
                    strSql.Append("'" + entity.OriginalName + "'" + ',');
                    strSql.Append("'" + entity.StandStatus + "'" + ',');
                    strSql.Append("'" + entity.SortField + "'" + ',');
                    strSql.Append("'" + entity.CreateTime + "'" + ',');
                    strSql.Append("'" + entity.ModifyDate + "'" + ',');
                    strSql.Append("'" + entity.Status + "'" + ',');
                    strSql.Append("'" + entity.SubStandard + "'" + ',');
                    strSql.Append("'" + entity.ElectronicSource + "'" + ',');
                    strSql.Append("'" + entity.Languages + "'" + ',');
                    strSql.Append("'" + entity.IsTranslation + "'" + ',');
                    strSql.Append("'" + entity.TechnicalCommittees + "'" + ',');
                    strSql.Append("'" + entity.IsTranslationd + "'" + ',');
                    strSql.Append("'" + entity.TranslationLanguage + "'" + ',');
                    strSql.Append("'" + entity.AffiliatedCommittee + "'" + ',');
                    strSql.Append("'" + entity.NameTheStandard + "'" + ',');
                    strSql.Append("'" + entity.ISBN + "'" + ',');
                    strSql.Append("'" + entity.IsAudited + "'" + ',');
                    strSql.Append("'" + entity.ConvertCharacters + "'" + ',');
                    strSql.Append("'" + entity.IsArtSort + "'" + ',');
                    strSql.Append("'" + entity.zb_a001 + "'" + ',');
                    strSql.Append("'" + entity.zb_c003 + "'" + ',');
                    strSql.Append("'" + entity.zb_c004 + "'" + ',');
                    strSql.Append("'" + entity.zb_c005 + "'" + ',');
                    strSql.Append("'" + entity.zb_c002 + "'" + ',');
                    strSql.Append("'" + entity.zb_a300 + "'" + ',');
                    strSql.Append("'" + entity.zb_updateTime + "'" + ',');
                    strSql.Append("'" + entity.zb_updateType + "'" + ',');
                    strSql.Append("'" + entity.zb_c006 + "'" + ',');
                    strSql.Append("'" + entity.isfree + "'");
                    strSql.Append(")");
                    this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
