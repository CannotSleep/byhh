using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-13 10:05
    /// 描 述：文章分类表
    /// </summary>
    public class ArticleCategoryController : MvcControllerBase
    {
        private ArticleCategoryIBLL articleCategoryIBLL = new ArticleCategoryBLL();

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
        /// 表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
             return View();
        }
        /// <summary>
        /// 添加页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson,string page,string limit)
        {
            //page limit 
            //Pagination paginationobj = pagination.ToObject<Pagination>();
            Pagination paginationobj = new Pagination();
            paginationobj.page = int.Parse(page);
            paginationobj.rows = int.Parse(limit);
            paginationobj.sidx = "createDate";
            paginationobj.sord = "desc";
            var data = articleCategoryIBLL.GetPageList(paginationobj, queryJson);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string queryJson)
        {
            var data = articleCategoryIBLL.GetList(queryJson);
            var jsonData = new
            {
                rows = data
            };
            return Success(jsonData);
        }


        /// <summary>
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var ArticleCategoryData = articleCategoryIBLL.GetArticleCategoryEntity( keyValue );
            var jsonData = new {
                ArticleCategory = ArticleCategoryData,
            };
            return Success(jsonData);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            articleCategoryIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, ArticleCategoryEntity strEntity)
        {
            //ArticleCategoryEntity entity = strEntity.ToObject<ArticleCategoryEntity>();
            articleCategoryIBLL.SaveEntity(keyValue, strEntity);
            return Success("保存成功！");
        }
        #endregion

    }
}
