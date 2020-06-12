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
    /// 日 期：2020-04-13 16:52
    /// 描 述：文章信息
    /// </summary>
    public class ArticleService : RepositoryFactory
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ArticleEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.id,
                t.articleCategory_id,
                t.title,
                t.author,
                t.metaDescription,
                t.imagePath,
                t.createDate,
                t.hits,
                t.metaKeywords,
                t.isTop,
                t.isRecommend,
                t.isPublication,
                t.content
                ");
                strSql.Append("  FROM Article t ");
                if (!string.IsNullOrWhiteSpace(queryJson))
                {
                    strSql.Append(" where t.title like '%" + queryJson + "%'");
                }
                return this.BaseRepository("imuStand").FindList<ArticleEntity>(strSql.ToString(), pagination);
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
        public IEnumerable<ArticleEntity> GetPageListApi(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.id,
                t.articleCategory_id,
                t.title,
                t.author,
                t.metaDescription,
                t.imagePath,
                t.createDate,
                t.hits,
                t.metaKeywords,
                t.isTop,
                t.isRecommend,
                t.isPublication,
                t.content
                ");
                strSql.Append("  FROM Article t ");
                if (!string.IsNullOrWhiteSpace(queryJson))
                {
                    strSql.Append(" where t.articleCategory_id = '" + queryJson + "'");
                }
                return this.BaseRepository("imuStand").FindList<ArticleEntity>(strSql.ToString(), pagination);
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
        /// 获取Article表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ArticleEntity GetArticleEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("imuStand").FindEntity<ArticleEntity>(keyValue);
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
                this.BaseRepository("imuStand").Delete<ArticleEntity>(t=>t.id == keyValue);
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
        public void SaveEntity(string keyValue, ArticleEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("imuStand").Update(entity);
                }
                else
                {
                    entity.Create();
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
