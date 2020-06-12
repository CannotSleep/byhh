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
    /// 日 期：2020-02-10 19:00
    /// 描 述：搜索统计
    /// </summary>
    public class SearchLogStaticService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public SearchLogStaticService()
        {
            fieldSql=@"
                t.Word,
                t.SearchCount
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<SearchLogStasticsEntity> GetList( string queryJson )
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
                strSql.Append(" FROM SearchLogStastics t ");
                return this.BaseRepository("标准库").FindList<SearchLogStasticsEntity>(strSql.ToString());
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
        public IEnumerable<SearchLogStasticsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM SearchLogStastics t ");
                return this.BaseRepository("标准库").FindList<SearchLogStasticsEntity>(strSql.ToString(), pagination);
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
        public SearchLogStasticsEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("标准库").FindEntity<SearchLogStasticsEntity>(keyValue);
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
                this.BaseRepository("标准库").Delete<SearchLogStasticsEntity>(t=>t.Word == keyValue);
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
        public void SaveEntity(string keyValue, SearchLogStasticsEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository("标准库").Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository("标准库").Insert(entity);
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

        //搜索引擎合并方法
        public int Delete()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("DELETE FROM SearchLogStastics;");
                return this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());
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

        //搜索热词统计
        public List<string> Stastic(int n,int m)
        {
            try
            {
                // todo 不删除查询是否有？删除？
                var strSql = new StringBuilder();
                this.BaseRepository("标准库").BeginTrans();
                // 1.先插入不存在的关键字
                strSql.Append("insert into SearchLogStastics (Word) select b.Word from SearchLogs as b where b.Word not in (select Word from SearchLogStastics) group by Word");
                this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());

                // 2.得到所有关键字列表
                var strSq2 = new StringBuilder();
                strSq2.Append("select word, count(*) as totl from SearchLogs group by word");
                DataTable table = this.BaseRepository("标准库").FindTable(strSq2.ToString());
                foreach (DataRow dr2 in table.Rows)
                {
                    // 3.插入搜索数量
                    string keyword = dr2["word"].ToString();
                    string kcount = dr2["totl"].ToString();
                    var strSq3 = new StringBuilder();
                    strSq3.Append("update SearchLogStastics set SearchCount = "+ kcount + " where Word = '"+ keyword + "'");
                    this.BaseRepository("标准库").ExecuteBySql(strSq3.ToString());
                }
                var strSq4 = new StringBuilder();
                strSq4.Append("select top "+n+" word,count(*) as cad from SearchLogs where word not in(select top "+m+" word from SearchLogs ) group by word order by cad desc");
                List<string> list = (List<string>)this.BaseRepository("标准库").FindList<string>(strSq4.ToString());

                this.BaseRepository("标准库").Commit();
                // where SearchDate >= DateAdd(day, -7, getdate())
                //strSql.Append("insert into SearchLogStastics(Word,SearchCount) select word, count(*) from SearchLogs group by word;");
                return list;
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

    }
}
