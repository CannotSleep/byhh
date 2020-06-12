using Learun.Application.Base.SystemModule;
using Learun.Application.TwoDevelopment.LR_CodeDemo.Statistics;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using Learun.Util.Operat;
using System.Web.Mvc;

namespace Learun.Application.Web.Controllers
{
    /// <summary>
    /// 日 期：2017.03.09
    /// 描 述：主页控制器
    /// </summary>
    public class HomeController : MvcControllerBase
    {
        #region 视图功能
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            string learn_UItheme = WebHelper.GetCookie("Learn_ADMS_V6.1_UItheme");
            switch (learn_UItheme)
            {
                case "1":
                    return View("AdminDefault");      // 经典版本
                case "2":
                    return View("AdminAccordion");    // 手风琴版本
                case "3":
                    return View("AdminWindos");       // Windos版本
                case "4":
                    return View("AdminTop");          // 顶部菜单版本
                default:
                    return View("AdminDefault");      // 经典版本
            }
        }
        /// <summary>
        /// 首页桌面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktop()
        {
            return View();
        }
        /// <summary>
        /// 首页模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AdminDesktopTemp()
        {
            return View();
        }
        #endregion

        private ICache cache = CacheFactory.CaChe();

        #region 清空缓存
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult ClearRedis()
        {
            for (int i = 0; i < 16; i++)
            {
                cache.RemoveAll(i);
            }
            return Success("清空成功");
        }
        #endregion

        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleName, string moduleUrl)
        {
            UserInfo userInfo = LoginUserInfo.Get();
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 2;
            logEntity.F_OperateTypeId = ((int)OperationType.Visit).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Visit);
            logEntity.F_OperateAccount = userInfo.account;
            logEntity.F_OperateUserId = userInfo.userId;
            logEntity.F_Module = moduleName;
            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "访问地址：" + moduleUrl;
            logEntity.WriteLog();
            return Success("ok");
        }
        [HttpGet]
        public string LoadPublishingUnit()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadPublishingUnit();
            return json;
        }
        [HttpGet]
        public string LoadPublishingUnitYear()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadPublishingUnitYear();
            return json;
        }
        [HttpGet]
        public string LoadOraganizationType()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadOraganizationType();
            return json;
        }
        [HttpGet]
        public string LoadOraganizationTypeYear()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadOraganizationTypeYear();
            return json;
        }
        [HttpGet]
        public string LoadOraganizationTypeYearData()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadOraganizationTypeYearData();
            return json;
        }
        [HttpGet]
        public string LoadStatusData()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadStatusData();
            return json;
        }
        [HttpGet]
        public string LoadMaxOrderData()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadMaxOrderData();
            return json;
        }
        [HttpGet]
        public string LoadMaxAmountOrderData()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadMaxAmountOrderData();
            return json;
        }
        [HttpGet]
        public string LoadYearOrderData()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadYearOrderData();
            return json;
        }
        [HttpGet]
        public string LoadYearAmountOrderData()
        {
            StatisticsService bll = new StatisticsService();
            string json = bll.LoadYearAmountOrderData();
            return json;
        }
    }
}