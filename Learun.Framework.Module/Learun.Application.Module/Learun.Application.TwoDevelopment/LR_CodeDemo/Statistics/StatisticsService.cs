using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo.Statistics
{
    public class StatisticsService
    {
        public string LoadPublishingUnit()
        {
            string json = string.Empty;
            string sql = "select  PublishingUnit,count(id) Num from [dbo].[standard] where PublishingUnit is not null and PublishingUnit<>'' and PublishingUnit like '%内蒙古%' group by PublishingUnit";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadPublishingUnitYear()
        {
            string json = string.Empty;
            string sql = "select  PublishingUnit,year(isd) Year,count(id) Num from [dbo].[standard] where PublishingUnit is not null and PublishingUnit<>'' and PublishingUnit = '内蒙古自治区质量技术监督局' group by PublishingUnit,year(isd) ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadOraganizationType()
        {
            string json = string.Empty;
            string sql = "select a.Describe,count(c.id) Num from [dbo].[organizationCategory] a,[dbo].[organization] b,[dbo].[standard] c where a.CategoryCode=b.CategoryCode and c.TableName=b.OraganizationCode group by a.Describe";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }

        public string LoadOraganizationTypeYear()
        {
            string json = string.Empty;
            string sql = "select a.Describe,year(isd) YearVal,count(c.id) Num from [dbo].[organizationCategory] a,[dbo].[organization] b,[dbo].[standard] c where a.CategoryCode=b.CategoryCode and c.TableName=b.OraganizationCode and c.isd is not null and isd <> '201-07-07'   group by a.Describe,year(isd)  order by a.Describe,YearVal ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadOraganizationTypeYearData()
        {
            string json = string.Empty;
            string sql = "select DISTINCT  year(CONVERT(datetime,isd)) year from [dbo].[organizationCategory] a,[dbo].[organization] b,[dbo].[standard] c where a.CategoryCode=b.CategoryCode and c.TableName=b.OraganizationCode and c.isd is not null and isd <> '201-07-07'   order by year(CONVERT(datetime,isd)) ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadStatusData()
        {
            string json = string.Empty;
            string sql = "select a.Status,count(id) Num from standard a group by a.Status ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadMaxOrderData()
        {
            string json = string.Empty;
            string sql = "select top 10 count(id) Num,a.productName from OrderItem a where a.productName is not null group by  a.productName order by Num desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadMaxAmountOrderData()
        {
            string json = string.Empty;
            string sql = "select top 10 a.standardName,sum(a.totalAmount) totalAmount from orders a where a.standardName is not null and a.standardName<>'' and a.standardName not like '%null%' group by a.standardName order by totalAmount desc";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadYearOrderData()
        {
            string json = string.Empty;
            string sql = "select count(id) Num,year(a.createDate) year from OrderItem a group by  year(a.createDate) order by year(a.createDate) ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
        public string LoadYearAmountOrderData()
        {
            string json = string.Empty;
            string sql = "select  year(a.createDate) year,sum(a.totalAmount) totalAmount from orders a  group by year(a.createDate) order by year(a.createDate) ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return json;
        }
    }
}
