using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Learun.Util;
using Nancy;
using SearchEngine;
using SearchEngine.Models;
using Newtonsoft.Json.Linq;

namespace Learun.Application.WebApi.Modules
{
    /// <summary>
    /// 搜索api
    /// </summary>
    public class SearchEngineApi: BaseApi
    {

        public SearchEngineApi()
            : base("/by/search")
        {
            Post["/ys"] = Search;
            Post["/gs"] = AdvancedSearch;
        }


        /// <summary>
        /// 搜索接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Search(dynamic _)
        {
            String uploaddate = this.GetReqData();
            JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            SearchService searchService = new SearchService();
            string keyword = jo["keyword"].ToString();
            string pagea = jo["page"].ToString();
            string pagesize = jo["pagesize"].ToString();
            List<SearchResult> list = (List<SearchResult>)searchService.search(keyword, pagea, pagesize, out int count);
            var jsonData = new
            {
                rows = list,
                total = count,
                page = pagea
                //records = paginationobj.records
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 高级搜索接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response AdvancedSearch(dynamic _)
        {
            String uploaddate = this.GetReqData();
            JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            SearchService searchService = new SearchService();
            string ssnum = jo["ssnum"].ToString();
            string scn = jo["scn"].ToString();
            string sen = jo["sen"].ToString();
            string sics = jo["sics"].ToString();
            string sccs = jo["sccs"].ToString();
            string sstatus = jo["sstatus"].ToString();
            string sfenlei = jo["sfenlei"].ToString();
            string sisd = jo["sisd"].ToString();
            string sefd = jo["sefd"].ToString();
            string pagea = jo["page"].ToString();
            string pagesize = jo["pagesize"].ToString();
            List<SearchResult> list = (List<SearchResult>)searchService.AdvandceSearch(ssnum,scn,sen,sics,sccs,sstatus,sfenlei,sisd,sefd, pagea, pagesize, out int count);
            var jsonData = new
            {
                rows = list,
                total = count,
                page = pagea
                //records = paginationobj.records
            };
            return Success(jsonData);
        }
        public class Upload {
            string keyword;
            int page;
            int pagesize;
        }


    }
}