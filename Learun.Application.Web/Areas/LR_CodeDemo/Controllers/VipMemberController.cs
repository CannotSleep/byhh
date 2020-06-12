using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using System.Data;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-03-03 14:36
    /// 描 述：会员管理
    /// </summary>
    public class VipMemberController : MvcControllerBase
    {
        private VipMemberIBLL vipMemberIBLL = new VipMemberBLL();
        private RechargeRecordIBLL rechargeRecordIBLL = new RechargeRecordBLL();


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
        /// 充值
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Recharge()
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
            var data = vipMemberIBLL.GetList(queryJson);
            return Success(data);
        }
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetPageList(string pagination, string queryJson, string page, string limit,string vipname)
        {
            //Pagination paginationobj = pagination.ToObject<Pagination>();
            Pagination paginationobj = new Pagination();
            paginationobj.page = int.Parse(page);
            paginationobj.rows = int.Parse(limit);
            paginationobj.sidx = "createDate";
            paginationobj.sord = "desc";
            var data = vipMemberIBLL.GetPageList(paginationobj, vipname);

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
            var data = vipMemberIBLL.GetEntity(keyValue);
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
            vipMemberIBLL.DeleteEntity(keyValue);
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
        public ActionResult SaveForm(string keyValue,memberEntity entity)
        {
            vipMemberIBLL.SaveEntity(keyValue, entity);
            RechargeRecordEntity rechargeRecord = new RechargeRecordEntity();
            rechargeRecord.UId = keyValue;
            rechargeRecord.BRecharge = entity.BRecharge;
            rechargeRecord.ARecharge = entity.TatolDeposit.ToString();
            rechargeRecordIBLL.SaveEntity("",rechargeRecord);
            return Success("保存成功！");
        }
        #endregion

    }
}
