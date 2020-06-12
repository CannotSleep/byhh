using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-20 10:39
    /// 描 述：合作机构
    /// </summary>
    public class CooperativeOrganizationController : MvcControllerBase
    {
        private CooperativeOrganizationIBLL cooperativeOrganizationIBLL = new CooperativeOrganizationBLL();

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
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList( string queryJson )
        {
            var data = cooperativeOrganizationIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = cooperativeOrganizationIBLL.GetPageList(paginationobj, queryJson);
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
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetFormData(string keyValue)
        {
            var data = cooperativeOrganizationIBLL.GetEntity(keyValue);
            return Success(data);
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
            cooperativeOrganizationIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue,MechanismEntity entity)
        {
            cooperativeOrganizationIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
        }


        /// <summary>
        /// 上传机构图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyFile(HttpPostedFileBase Filedata)
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
                string standardPath = Config.GetValue("CooperationOrganization");

                //标准路径
                string virtualPath = string.Format("/" + standardPath + "/{0}",Guid.NewGuid() + name);
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
