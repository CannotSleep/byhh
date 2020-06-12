using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class BooksysApi: BaseApi
    {
        public BooksysApi()
          : base("/by/books")
        {
            Post["/getStandardTitleClass"] = GetStandardTitleClass;
            Post["/getStandardTitle"] = GetStandardTitle;
            Post["/getStandardDB"] = GetStandardDB;
        }
        private StandardTitleClassificationIBLL standardTitleClassification = new StandardTitleClassificationBLL();
        private StandardTitleIBLL standardTitle = new StandardTitleBLL();
        private StandardIBLL standard = new StandardBLL();
        /// <summary>
        /// 获取题录组织分类
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetStandardTitleClass(dynamic _)
        {
            var data = standardTitleClassification.GetList("");
            var jsonData = new
            {
                result = data
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取题录组织
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetStandardTitle(dynamic _)
        {
            //string req = this.GetReqData();// 获取模板请求数据
            var data = standardTitle.GetList("");
            var jsonData = new
            {
                result = data
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取地方标准题录信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetStandardDB(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            var data = standardTitle.GetList(req);
            var jsonData = new
            {
                result = data
            };
            return Success(jsonData);
        }
    }
}