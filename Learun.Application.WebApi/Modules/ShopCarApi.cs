using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class ShopCarApi : BaseApi
    {
        public ShopCarApi()
          : base("/by/shopcar")
        {
            Post["/add"] = AddShopCar;
            Post["/getbyId"] = GetShopCarByUserId;
            Post["/delete"] = DeleteShopCar;
            Post["/deletebyUserId"] = DeleteShopCarByUserId;
            Post["/getcountbyUserId"] = GetDiscountByUserId;
        }

        private ShopCarIBLL shopCar = new ShopCarBLL();
        private StandardCountIBLL standardCountIBLL = new StandardCountBLL();
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response AddShopCar(dynamic _)
        {
            CartItemEntity cartItem = this.GetReqData<CartItemEntity>();
            cartItem.createDate = DateTime.Now;
            cartItem.modifyDate = DateTime.Now;

            shopCar.SaveEntity("",cartItem);
            return Success("添加成功");
        }


        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response DeleteShopCar(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            shopCar.DeleteEntity(req);
            return Success("删除成功");
        }


        /// <summary>
        /// 根据用户ID删除购物车
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response DeleteShopCarByUserId(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            shopCar.DeleteEntity(req);
            return Success("删除成功");
        }


        /// <summary>
        /// 根据用户ID获取购物车商品数量
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetShopCarByUserId(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            List<CartItemEntity> list = (List<CartItemEntity>)shopCar.GetListByUserId(req);
            var jsonData = new
            {
                result = list,
                alen = list.Count
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 根据用户ID获取折扣数据
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetDiscountByUserId(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            List<StandardCountEntity> standardCount = (List<StandardCountEntity>)standardCountIBLL.GetDiscountByUserId(req);
            var jsonData = new
            {
                result = standardCount
            };
            return Success(jsonData);
        }
    }
}