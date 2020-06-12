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
    /// 日 期：2020-04-09 16:25
    /// 描 述：订单管理
    /// </summary>
    public class OrderService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public OrderService()
        {
            fieldSql=@"
                t.id,
                t.createDate,
                t.modifyDate,
                t.deliveryFee,
                t.deliveryTypeName,
                t.memo,
                t.orderSn,
                t.orderStatus,
                t.paidAmount,
                t.paymentConfigName,
                t.paymentFee,
                t.paymentStatus,
                t.productTotalPrice,
                t.productTotalQuantity,
                t.productWeight,
                t.productWeightUnit,
                t.shipAddress,
                t.shipArea,
                t.shipAreaPath,
                t.shipMobile,
                t.shipName,
                t.shipPhone,
                t.shipZipCode,
                t.shippingStatus,
                t.totalAmount,
                t.deliveryType_id,
                t.member_id,
                t.paymentConfig_id,
                t.standardId,
                t.standardName,
                t.standardPages,
                t.shipType,
                t.shipEmail,
                t.shipFox,
                t.memberName,
                t.memberId,
                t.orderType,
                t.admin_id,
                t.uploadstatu,
                t.addtoPrice,
                t.ip,
                t.receiver_id,
                t.expressid,
                t.expressname,
                t.deleteType,
                t.filepath,
                t.excelpath,
                t.op,
                t.memberusername,
                t.addtoPricebei
            ";
        }
        #endregion

        OrderItemService OrderItemService = new OrderItemService();

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<ordersEntity> GetList( string queryJson )
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
                strSql.Append(" FROM orders t ");
                return this.BaseRepository("imuStand").FindList<ordersEntity>(strSql.ToString());
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
        public IEnumerable<ordersEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM orders t ");
                return this.BaseRepository("imuStand").FindList<ordersEntity>(strSql.ToString(), pagination);
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
        public ordersEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository("imuStand").FindEntity<ordersEntity>(keyValue);
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
        /// 根据用户ID获取订单
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<ordersEntity> GetByUserId(string orderId, Pagination pagination)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM orders t where member_id = '"+orderId+"'");
                return this.BaseRepository("imuStand").FindList<ordersEntity>(strSql.ToString(), pagination);
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
        /// 根据ID获取订单
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<ordersEntity> GetById(string Id)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM orders t where id = '" + Id + "'");
                return this.BaseRepository("imuStand").FindList<ordersEntity>(strSql.ToString());
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
                this.BaseRepository("imuStand").Delete<ordersEntity>(t=>t.id == keyValue);
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
        public void SaveEntity(string keyValue, ordersEntity entity)
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
                    //插入子项
                    if (entity.childList != null)
                    {
                        List<OrderItemEntity> childList = entity.childList;
                        foreach (var item in childList)
                        {
                            item.memberId = entity.member_id;
                            item.order_id = entity.id;
                            OrderItemService.SaveEntity(item.id, item);
                        }
                    }
                    //this.BaseRepository("imuStand").Insert(entity);
                    var strSql = new StringBuilder();
                    strSql.Append("insert into orders(id,createDate,modifyDate,memo,orderSn,shipMobile,shipPhone,shipName,shipEmail,ip,paidAmount,productTotalPrice,member_id,standardId,standardName,standardPages) ");
                    strSql.Append("values (");
                    strSql.Append("'" + entity.id + "'" + ',');
                    strSql.Append("'" + entity.createDate + "'" + ',');
                    strSql.Append("'" + entity.modifyDate + "'" + ',');
                    strSql.Append("'" + entity.memo + "'" + ',');
                    strSql.Append("'" + entity.orderSn + "'" + ',');
                    strSql.Append("'" + entity.shipMobile + "'" + ',');
                    strSql.Append("'" + entity.shipPhone + "'" + ',');
                    strSql.Append("'" + entity.shipName + "'" + ',');
                    strSql.Append("'" + entity.shipEmail + "'" + ',');
                    strSql.Append("'" + entity.ip + "'" + ','); 
                    strSql.Append("'" + entity.paidAmount + "'" + ',');
                    strSql.Append("'" + entity.productTotalPrice + "'" + ',');
                    strSql.Append("'" + entity.member_id + "'" + ',');
                    strSql.Append("'" + entity.standardId + "'" + ',');
                    strSql.Append("'" + entity.standardName + "'" + ',');
                    strSql.Append("'" + entity.standardPages + "'");
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
