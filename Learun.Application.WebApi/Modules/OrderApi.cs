using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Nancy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class OrderApi: BaseApi
    {
        public OrderApi()
           : base("/by/order")
        {
            Post["/getByUserId"] = GetOrderByUserId;
            Post["/getById"] = GetOrderById;
            Post["/addOrder"] = AddOrder;
            Post["/getByUidSnum"] = GetOrderByuidSnum;
        }

        private OrderIBLL orderIBLL = new OrderBLL();
        private OrderItemIBLL orderItemIBLL = new OrderItemBLL();
        private ShopCarIBLL ShopCar = new ShopCarBLL();
        private VipMemberIBLL VipMember = new VipMemberBLL();
        /// <summary>
        /// 根据用户ID获取订单列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetOrderByUserId(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据

            String uploaddate = this.GetReqData();
            JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            string pagea = jo["page"].ToString();
            string pagesize = jo["pagesize"].ToString();
            string cateid = jo["memid"].ToString();
            Pagination pagination = new Pagination();
            pagination.page = int.Parse(pagea);
            pagination.rows = int.Parse(pagesize);
            pagination.sidx = "createDate";
            pagination.sord = "desc";

            var data = orderIBLL.GetByUserId(cateid, pagination);
            foreach (var item in data) {
               item.standardName = item.standardName.Replace("<", "").Replace(">", "").Replace("b", "").Replace("r", "").Replace(@"""", "");
                // .Substring(1, item.standardName.Length - 1)
                item.standardId = item.standardId.Replace("<", "").Replace(">", "").Replace("b", "").Replace("r", "").Replace(@"""", "");
            }
            var jsonData = new
            {
                result = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Success(jsonData);
        }


        /// <summary>
        /// 根据订单ID获取订单详细信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetOrderById(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            ordersEntity orders = ((List<ordersEntity>)orderIBLL.GetById(req))[0];
            //获取子项
            var dataitem = (List<OrderItemEntity>)orderItemIBLL.GetItemList(orders.id);
            orders.childList = dataitem;
            var jsonData = new
            {
                result = orders
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 根据用户ID和标准号获取订单
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetOrderByuidSnum(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            JObject jo = Learun.Util.Extensions.ToObject<JObject>(req);
            string uid = jo["uid"].ToString();
            string standnum = jo["standnum"].ToString();

            List <OrderItemEntity> list = ((List<OrderItemEntity>)orderItemIBLL.GetStandardBymid(uid,standnum));
            var jsonData = new
            {
                result = list
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="_"></param>
        /// <returns>todo更新订单状态</returns>
        private Response AddOrder(dynamic _)
        {
            //todo事务
            ordersEntity ordersEntity = this.GetReqData<ordersEntity>();
            // 用户金额判定
            memberEntity member = new memberEntity();
            member = VipMember.GetEntity(ordersEntity.member_id);
            var ye = member.TatolDeposit;
            var xe = ordersEntity.paidAmount;
            if (ye==null) {
                ye = 0;
            }
            if (xe > ye) {
                return Fail("余额不足请充值");
            }
            //购物车订单删除
            ShopCar.DeleteEntityByUserId(ordersEntity.member_id);
            //充足
            ordersEntity.createDate = DateTime.Now;
            ordersEntity.modifyDate = DateTime.Now;
            ordersEntity.memo = "标准购买";
            Random rd = new Random();
            ordersEntity.orderSn = "A"+ rd.Next(100000, 999999);
            ordersEntity.shipMobile = ordersEntity.shipMobile;
            ordersEntity.shipPhone = ordersEntity.shipPhone;
            ordersEntity.shipName = ordersEntity.shipName;
            ordersEntity.shipEmail = ordersEntity.shipEmail;
            ordersEntity.ip = ordersEntity.ip;
            orderIBLL.SaveEntity("", ordersEntity);
            //用户余额减少
            member.TatolDeposit = member.TatolDeposit - xe;
            //积分增加
            member.TatolPoint = (int)((decimal)member.TatolPoint + xe);
            VipMember.SaveEntity(member.Id,member);
            return Success("下单成功");
        }
    }
}