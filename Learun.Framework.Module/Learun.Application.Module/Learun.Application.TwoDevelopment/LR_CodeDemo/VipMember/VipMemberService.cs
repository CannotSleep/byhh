using Dapper;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-03-03 14:36
    /// 描 述：会员管理
    /// </summary>
    public class VipMemberService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public VipMemberService()
        {
            fieldSql=@"
                t.Id,
                t.CreateDate,
                t.ModifyDate,
                t.Deposit,
                t.Email,
                t.AccountName,
                t.isAccountEnabled,
                t.isAccountLocked,
                t.isAccountExpired,
                t.isCredentialsExpired,
                t.LockedDate,
                t.LastLoginDate,
                t.LoginFailureCount,
                t.LastLoginIp,
                t.Password,
                t.PasswordRecoverKey,
                t.RechargeIntegral,
                t.RegisterIp,
                t.SafeAnswer,
                t.SafeQuestion,
                t.UserName,
                t.MemberRankId,
                t.OuidId,
                t.ParentId,
                t.MemberTel,
                t.CompanyName,
                t.TatolDeposit,
                t.Consume,
                t.ConsumePoint,
                t.TatolPoint,
                t.Fax,
                t.Address,
                t.MemberPost,
                t.Tel,
                t.Postal,
                t.Department,
                t.Rank,
                t.Ics,
                t.Nodes,
                t.ActiveType,
                t.ActiveKey,
                t.ActiveDate,
                t.IsAdmin,
                t.Bz,
                t.Area,
                t.OrderIIemNum,
                t.LoginNum,
                t.CompanyIcs,
                t.Security,
                t.SpaceSize,
                t.CompanyIcsName,
                t.MaxMoney,
                t.IsMaxMoney,
                t.Remarks,
                t.Copr,
                t.SourceType,
                t.EnterpriseType,
                t.PathStandard,
                t.QuStandard,
                t.Qyisopen,
                t.DownloadNumber,
                t.Factdescription,
                t.Ischeckip
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<memberEntity> GetList( string queryJson )
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
                strSql.Append(" FROM member t ");
                return this.BaseRepository("imuStand").FindList<memberEntity>(strSql.ToString());
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
        public IEnumerable<memberEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM member t ");
                if (!string.IsNullOrWhiteSpace(queryJson)) {
                    strSql.Append("where AccountName like '%"+queryJson+"%'");
                }
                return this.BaseRepository("imuStand").FindList<memberEntity>(strSql.ToString(), pagination);
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
        public memberEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("imuStand").FindEntity<memberEntity>(keyValue);
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
        /// 获取实体,通过用户账号
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        public memberEntity GetEntityByAccount(string account)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM member t ");
                strSql.Append(" WHERE t.AccountName = @account AND t.isAccountEnabled = 1 AND t.isAccountLocked = 0 AND t.isAccountExpired = 0 AND t.isCredentialsExpired = 0");
                return this.BaseRepository("imuStand").FindEntity<memberEntity>(strSql.ToString(), new { account = account });
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
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository("imuStand").Delete<memberEntity>(t=>t.Id == keyValue);
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
        public void SaveEntity(string keyValue, memberEntity entity)
        {
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    entity.Create();
                    entity.Password = Md5Helper.Encrypt(DESEncrypt.Encrypt(entity.Password, "").ToLower(), 32).ToLower();
                    this.BaseRepository("imuStand").Insert(entity);
                }
                else
                {
                    entity.Modify(keyValue);
                    entity.PasswordRecoverKey = null;
                    entity.Password = null;
                    this.BaseRepository("imuStand").Update(entity);
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
