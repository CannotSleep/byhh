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
    public class NewsApi: BaseApi
    {
        public NewsApi()
           : base("/by/news")
        {
            Post["/getlist"] = GetNewsList;
            Post["/getitem"] = GetNews;
        }

        private ArticleIBLL article = new ArticleBLL();

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetNewsList(dynamic _)
        {
            String uploaddate = this.GetReqData();
            JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            string pagea = jo["page"].ToString();
            string pagesize = jo["pagesize"].ToString();
            string cateid = jo["cateid"].ToString();
            Pagination pagination = new Pagination();
            pagination.page = int.Parse(pagea);
            pagination.rows = int.Parse(pagesize);
            pagination.sidx = "createDate";
            pagination.sord = "desc";
            string queryjson = "";
            if (!string.IsNullOrWhiteSpace(cateid))
            {
                queryjson = cateid;
            }
            var data = article.GetPageListApi(pagination,queryjson);
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
        /// 获取新闻详情
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetNews(dynamic _)
        {
            string req = this.GetReqData();// 获取模板请求数据
            ArticleEntity articleEntity = article.GetArticleEntity(req);
            var jsonData = new
            {
                result = articleEntity
            };
            return Success(jsonData);
        }
    }
}