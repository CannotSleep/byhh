﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learun.Application.Web.Areas.LR_CodeGeneratorModule.Controllers
{
    /// <summary>
    /// 日 期：2017.03.09
    /// 描 述：移动端代码生成器
    /// </summary>
    public class TemplateAPPController : MvcControllerBase
    {
        #region 视图功能
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}