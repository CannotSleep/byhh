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
    /// 日 期：2020-04-15 11:32
    /// 描 述：订单子项
    /// </summary>
    public class OrderItemService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public OrderItemService()
        {
            fieldSql=@"
                t.id,
                t.createDate,
                t.modifyDate,
                t.deliveryQuantity,
                t.productHtmlFilePath,
                t.productName,
                t.productPrice,
                t.productQuantity,
                t.productSn,
                t.totalDeliveryQuantity,
                t.order_id,
                t.standard_id,
                t.memberId,
                t.orderId,
                t.standardId,
                t.orderSn,
                t.product_id,
                t.orderItemType,
                t.emailAttachStatus,
                t.deleteType,
                t.addtoPrice,
                t.identify,
                t.a825,
                t.a4754,
                t.a826,
                t.isSuoQu,
                t.memberCompany,
                t.memberName,
                t.memberusername,
                t.orderNum,
                t.password,
                t.zba001,
                t.zba002,
                t.zba102,
                t.qwisopen,
                t.a827
            ";
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<OrderItemEntity> GetList( string queryJson )
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
                strSql.Append(" FROM OrderItem t ");
                return this.BaseRepository("imuStand").FindList<OrderItemEntity>(strSql.ToString());
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
        public IEnumerable<OrderItemEntity> GetItemList(string queryJson)
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
                strSql.Append(" FROM OrderItem t where order_id="+"'"+queryJson+"'" );
                return this.BaseRepository("imuStand").FindList<OrderItemEntity>(strSql.ToString());
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
        public IEnumerable<OrderItemEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM OrderItem t ");
                return this.BaseRepository("imuStand").FindList<OrderItemEntity>(strSql.ToString(), pagination);
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
        public OrderItemEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("imuStand").FindEntity<OrderItemEntity>(keyValue);
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
        /// 根据用户ID和标准号查询是否购买标准
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<OrderItemEntity> GetStandardBymid(string uid, string standardNum)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM OrderItem t where memberId = '" + uid+ "' and productSn='"+ standardNum + "'");
                return this.BaseRepository("imuStand").FindList<OrderItemEntity>(strSql.ToString());
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
                this.BaseRepository("imuStand").Delete<OrderItemEntity>(t=>t.id == keyValue);
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
        public void SaveEntity(string keyValue, OrderItemEntity entity)
        {
            try
            {
                //if (!string.IsNullOrEmpty(keyValue))
                //{
                //    entity.Modify(keyValue);
                //    this.BaseRepository("imuStand").Update(entity);
                //}
                //else
                //{
                    entity.Create();
                   // this.BaseRepository("imuStand").Insert(entity);
                var strSql = new StringBuilder();
                strSql.Append("insert into OrderItem(id,createDate,modifyDate,order_id,standardId,productName,productPrice,product_id,productSn,memberId) ");
                strSql.Append("values (");
                strSql.Append("'" + entity.id + "'" + ',');
                strSql.Append("'" + entity.createDate + "'" + ',');
                strSql.Append("'" + entity.modifyDate + "'" + ',');
                strSql.Append("'" + entity.order_id + "'" + ',');
                strSql.Append("'" + entity.standardId + "'" + ',');
                strSql.Append("'" + entity.standardName + "'" + ',');
                strSql.Append("'" + entity.price + "'" + ',');
                strSql.Append("'" + entity.product_id + "'" + ',');
                strSql.Append("'" + entity.standardId + "'" + ',');
                strSql.Append("'" + entity.memberId + "'");
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
