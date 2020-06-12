using Learun.Util;
using System.Data;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-13 16:52
    /// 描 述：文章信息
    /// </summary>
    public class ArticleController : MvcControllerBase
    {
        private ArticleIBLL articleIBLL = new ArticleBLL();

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
        /// 添加表单页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddArticle()
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
        public ActionResult GetPageList(string pagination, string queryJson, string page, string limit,string articlename)
        {
            //Pagination paginationobj = pagination.ToObject<Pagination>();
            Pagination paginationobj = new Pagination();
            paginationobj.page = int.Parse(page);
            paginationobj.rows = int.Parse(limit);
            paginationobj.sidx = "createDate";
            paginationobj.sord = "desc";
            var data = articleIBLL.GetPageList(paginationobj, articlename);
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
        /// 获取表单数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var ArticleData = articleIBLL.GetArticleEntity( keyValue );
            var jsonData = new {
                Article = ArticleData,
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
            articleIBLL.DeleteEntity(keyValue);
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
        [ValidateInput(false)]
        public ActionResult SaveForm(string keyValue, ArticleEntity strEntity)
        {
            strEntity.author = "内蒙古自治区标准化院";
            strEntity.pageCount = 1;
            articleIBLL.SaveEntity(keyValue, strEntity);
            return Success("保存成功！");
        }

        /// <summary>
        /// 上传文章图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyImageFile(HttpPostedFileBase Filedata)
        {
            try
            {
                //Thread.Sleep(500);////延迟500毫秒
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    if (Request.Files.Count > 0)
                    {
                        Filedata = Request.Files[0];
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                string name = Filedata.FileName;
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string standardPath = Config.GetValue("Newspath");

                //新闻文件路径
                string virtualPath = string.Format("/" + standardPath + "/{0}",Guid.NewGuid() + name);
                //新闻文件全路径
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    Filedata.SaveAs(fullFileName);
                }
                return Success(virtualPath);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        /// <summary>
        /// 上传文章附件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyEnclosureFile(HttpPostedFileBase Filedata)
        {
            try
            {
                //Thread.Sleep(500);////延迟500毫秒
                //没有文件上传，直接返回
                if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
                {
                    if (Request.Files.Count > 0)
                    {
                        Filedata = Request.Files[0];
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
                //获取文件完整文件名(包含绝对路径)
                //文件存放路径格式：/Resource/ResourceFile/{userId}{data}/{guid}.{后缀名}
                string name = Filedata.FileName;
                long filesize = Filedata.ContentLength;
                string FileEextension = Path.GetExtension(Filedata.FileName);
                string standardPath = Config.GetValue("Newspath");

                //标准路径
                string virtualPath = string.Format("/" + standardPath + "/{0}", Guid.NewGuid() + name);
                //标准全路径
                string fullFileName = this.Server.MapPath(virtualPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    Filedata.SaveAs(fullFileName);
                }
                return Success(virtualPath);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }




        #endregion

    }
}
