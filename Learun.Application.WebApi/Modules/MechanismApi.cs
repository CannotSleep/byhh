using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class MechanismApi: BaseApi
    {

        public MechanismApi()
           : base("/by/mechanism")
        {
            Post["/getlist"] = GetList;
        }

        private CooperativeOrganizationIBLL cooperative = new CooperativeOrganizationBLL();

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetList(dynamic _)
        {
            String uploaddate = this.GetReqData();
            var data = cooperative.GetList("");
            var jsonData = new
            {
                result = data
            };
            return Success(jsonData);
        }
    }
}