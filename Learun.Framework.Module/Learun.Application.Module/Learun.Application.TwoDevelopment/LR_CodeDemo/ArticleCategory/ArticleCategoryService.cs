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
    /// 日 期：2020-04-13 10:05
    /// 描 述：文章分类表
    /// </summary>
    public class ArticleCategoryService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ArticleCategoryEntity> GetList(string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.id,
                t.name,
                t.metaDescription,
                t.orderList,
                t.metaKeywords,
                t.createDate,
                t.modifyDate");
                strSql.Append("  FROM ArticleCategory t ");
                strSql.Append("  where 1=1");
               
                return this.BaseRepository("imuStand").FindList<ArticleCategoryEntity>(strSql.ToString());
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ArticleCategoryEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.id,
                t.name,
                t.metaDescription,
                t.orderList,
                t.metaKeywords,
                t.createDate,
                t.modifyDate
                ");
                strSql.Append("  FROM ArticleCategory t ");
                strSql.Append("  where 1=1");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["name"].IsEmpty())
                {
                    dp.Add("name", "%" + queryParam["name"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.name Like @name ");
                }
                return this.BaseRepository("imuStand").FindList<ArticleCategoryEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取ArticleCategory表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ArticleCategoryEntity GetArticleCategoryEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("imuStand").FindEntity<ArticleCategoryEntity>(keyValue);
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
                this.BaseRepository("imuStand").Delete<ArticleCategoryEntity>(t=>t.id == keyValue);
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
        public void SaveEntity(string keyValue, ArticleCategoryEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    entity.modifyDate = DateTime.Now;
                    this.BaseRepository("imuStand").Update(entity);
                }
                else
                {
                    entity.Create();
                    entity.createDate = DateTime.Now;
                    entity.modifyDate = DateTime.Now;
                    this.BaseRepository("imuStand").Insert(entity);
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
