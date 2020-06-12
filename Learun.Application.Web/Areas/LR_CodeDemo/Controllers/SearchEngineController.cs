using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using System.Data;
using System.Web.Mvc;
using SearchEngine;
using System.Collections.Generic;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Search;
using System.IO;
using System.Web.Hosting;
using SearchEngine.Models;
using Lucene.Net.Documents;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-02-11 10:59
    /// 描 述：搜索引擎管理
    /// </summary>
    
    public class SearchEngineController : MvcControllerBase
    {
        private StandardIBLL standardIBLL = new StandardBLL();


        #region 视图功能
        /// <summary>
        /// 主页面
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
             return View();
        }
        /// <summary>
        /// 搜索
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SeaIndex()
        {
            return View();
        }
        /// <summary>
        /// 初始化
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Init()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取标准数据库所有表格
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetAllTable()
        {
            List<string> data = (List<string>)standardIBLL.GetAllTable();
            var jsonData = new
            {
                rows = data
                //records = paginationobj.records
            };
            return Success(jsonData);
        }
        

        /// <summary>
        /// 全部索引初始化异步
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public string EngineInitAll()
        {
            // 更新索引库
            List<Standard> data = (List<Standard>)standardIBLL.GetList("");
            for (int i = 0; i < data.Count; i++)
            {
                IndexTask task = new IndexTask();
                task.TaskId = data[i].Id;
                IndexManager.Instance.AddArticle(task);
            }
            return "更新完毕";
        }


        /// <summary>
        /// 全部索引同步初始化
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult EngineInitAllAsyc()
        {
            // 更新索引库
            List<Standard> data = (List<Standard>)standardIBLL.GetList("");
            for (int i = 0; i < data.Count; i++)
            {
                IndexManager.Instance.AddStandardSync(data[i],i);
            }
            return Success("更新完毕");
        }


        /// <summary>
        /// 索引部份表初始化异步
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public string EngineInit(string tname)
        {
            // 更新索引库
            List<Standard> data = (List<Standard>)standardIBLL.GetListByTableName(tname);
            for (int i = 0; i < data.Count; i++)
            {
                IndexTask task = new IndexTask();
                task.TaskId = data[i].Id;
                IndexManager.Instance.AddArticle(task);
            }
            return "更新完毕";
        }

        /// <summary>
        /// 单个标准同步索引初始化
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult EngineInitItemAsyc(string id)
        {
            // 更新索引库
            List<Standard> data = (List<Standard>)standardIBLL.GetList(id);
            for (int i = 0; i < data.Count; i++)
            {
                IndexManager.Instance.AddStandardSync(data[i], i);
            }
            return Success("更新完毕");
        }


        /// <summary>
        /// 删除全部索引
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public string DeleteEngine()
        {
            IndexManager.Instance.DeleteArticle();
            return "删除完毕";
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult search(string keyword,string pagea,string pagesizea)
        {
            SearchService searchService = new SearchService();
            List<SearchResult> list = (List<SearchResult>)searchService.search(keyword, pagea, pagesizea,out int count);
            var jsonData = new
            {
                rows = list,
                total = count,
                page = pagea
                //records = paginationobj.records
            };
            return Success(jsonData);
        }
        #endregion
    }
}
