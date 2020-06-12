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
    /// 日 期：2020-03-26 15:54
    /// 描 述：标准子类
    /// </summary>
    public class StandardItemService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public StandardItemService()
        {
            fieldSql=@"
                t.type,
                t.clg_id,
                t.clg_name,
                t.n_docum,
                t.app_id,
                t.app_body,
                t.ref_item,
                t.t_id,
                t.t_cn,
                t.t_en,
                t.t_def,
                t.t_note,
                t.t_exp,
                t.pic,
                t.tech_itid,
                t.tech_itname,
                t.tech_ptbody,
                t.tech_level,
                t.tech_pic,
                t.BId,
                t.Id
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<StandardItem> GetList( string queryJson )
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
                strSql.Append(" FROM AACC_N_W t ");
                return this.BaseRepository("imuStand").FindList<StandardItem>(strSql.ToString());
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
        public IEnumerable<StandardItem> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM AACC_N_W t ");
                return this.BaseRepository("imuStand").FindList<StandardItem>(strSql.ToString(), pagination);
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
        public StandardItem GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("imuStand").FindEntity<StandardItem>(keyValue);
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
        /// 获取子项数据集
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<StandardItem> GetItemEntityList(string keyValue,string tablename)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM "+tablename+" t where Bid = "+"'"+ keyValue+"'");
                return this.BaseRepository("imuStand").FindList<StandardItem>(strSql.ToString());
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
        public void DeleteEntity(string keyValue,string tablename)
        {
            try
            {
                var strSql = new StringBuilder();
                string tablena = tablename + "_W";
                strSql.Append("delete from "+ tablena + " where BId = ");
                strSql.Append("'" + keyValue + "'");
                this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());
                //this.BaseRepository("imuStand").Delete<StandardItem>(t=>t.BId == keyValue);
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
        public void SaveEntity(string keyValue, StandardItem entity)
        {
            try
            {
                //if (!string.IsNullOrEmpty(keyValue))
                //{
                //    //entity.Modify(keyValue);
                //    var strSql = new StringBuilder();
                //    strSql.Append("update " + entity.tableName);
                //    strSql.Append(" SET  type=" + "'" + entity.type + "'" + ",");
                //    strSql.Append("  clg_id=" + "'" + entity.clg_id + "'" + ",");
                //    strSql.Append("  clg_name=" + "'" + entity.clg_name + "'" + ",");
                //    strSql.Append("  n_docum=" + "'" + entity.n_docum + "'" + ",");
                //    strSql.Append("  app_id=" + "'" + entity.app_id + "'" + ",");
                //    strSql.Append("  app_body=" + "'" + entity.app_body + "'" + ",");
                //    strSql.Append("  ref_item=" + "'" + entity.ref_item + "'" + ",");
                //    strSql.Append("  t_id=" + "'" + entity.t_id + "'" + ",");
                //    strSql.Append("  t_cn=" + "'" + entity.t_cn + "'" + ",");
                //    strSql.Append("  t_en=" + "'" + entity.t_en + "'" + ",");
                //    strSql.Append("  t_def=" + "'" + entity.t_def + "'" + ",");
                //    strSql.Append("  t_note=" + "'" + entity.t_note + "'" + ",");
                //    strSql.Append("  t_exp=" + "'" + entity.t_exp + "'" + ",");
                //    strSql.Append("  pic=" + "'" + entity.pic + "'" + ",");
                //    strSql.Append("  tech_itid=" + "'" + entity.tech_itid + "'" + ",");
                //    strSql.Append("  tech_itname=" + "'" + entity.tech_itname + "'" + ",");
                //    strSql.Append("  tech_ptbody=" + "'" + entity.tech_ptbody + "'" + ",");
                //    strSql.Append("  tech_level=" + "'" + entity.tech_level + "'" + ",");
                //    strSql.Append("  tech_pic=" + "'" + entity.tech_pic + "'" + ",");
                //    strSql.Append("  BId=" + "'" + entity.BId + "'" + " ");
                //    strSql.Append(" where Id = " + "'" + entity.Id + "'");
                //    this.BaseRepository("imuStand").ExecuteBySql(strSql.ToString());
                //}
                //else
                //{
                    entity.Create();
                    var strSql = new StringBuilder();
                    strSql.Append("insert into " + entity.tableName + "(type,clg_id,clg_name,n_docum,app_id,app_body,ref_item,t_id,t_cn,t_en,t_def,t_note,t_exp,pic,tech_itid,tech_itname,tech_ptbody,tech_level,tech_pic,BId,Id) ");
                    strSql.Append("values (");
                    strSql.Append("'" + entity.type + "'" + ',');
                    strSql.Append("'" + entity.clg_id + "'" + ',');
                    strSql.Append("'" + entity.clg_name + "'" + ',');
                    strSql.Append("'" + entity.n_docum + "'" + ',');
                    strSql.Append("'" + entity.app_id + "'" + ',');
                    strSql.Append("'" + entity.app_body + "'" + ',');
                    strSql.Append("'" + entity.ref_item + "'" + ',');
                    strSql.Append("'" + entity.t_id + "'" + ',');
                    strSql.Append("'" + entity.t_cn + "'" + ',');
                    strSql.Append("'" + entity.t_en + "'" + ',');
                    strSql.Append("'" + entity.t_def + "'" + ',');
                    strSql.Append("'" + entity.t_note + "'" + ',');
                    strSql.Append("'" + entity.t_exp + "'" + ',');
                    strSql.Append("'" + entity.pic + "'" + ',');
                    strSql.Append("'" + entity.tech_itid + "'" + ',');
                    strSql.Append("'" + entity.tech_itname + "'" + ',');
                    strSql.Append("'" + entity.tech_ptbody + "'" + ',');
                    strSql.Append("'" + entity.tech_level + "'" + ',');
                    strSql.Append("'" + entity.tech_pic + "'" + ',');
                    strSql.Append("'" + entity.BId + "'" + ',');
                    strSql.Append("'" + entity.Id + "'");
                    strSql.Append(")");
                    this.BaseRepository("标准库").ExecuteBySql(strSql.ToString());
                //}
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
