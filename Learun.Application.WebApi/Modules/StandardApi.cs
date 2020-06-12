using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Nancy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Learun.Application.WebApi.Modules
{
    public class StandardApi : BaseApi
    {
        public StandardApi()
            : base("/by/standard")
        {
            Post["/getById"] = GetStandardById;
            Post["/getStandardCount"] = GetStandardCount;
            Post["/gethotword"] = GetHotword;
            Post["/getrecentlyreleased"] = GetRecentlyReleased;
            Post["/getcomingsoon"] = GetComingSoon;
            Post["/down"] = DownStandard;
            Post["/preview"] = PreviewStandard;
        }

        private StandardIBLL standardIBLL = new StandardBLL();
        private StandardItemIBLL standardItembll = new StandardItemBLL();
        private SearchLogStaticIBLL staticIBLL = new SearchLogStaticBLL();

        /// <summary>
        /// 搜索接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetStandardById(dynamic _)
        {
            String id = this.GetReqData();
            var data = standardIBLL.GetEntity(id);
            Standard standard = ((List<Standard>)data)[0];
            //获取子项数据
            var dataitem = (List<StandardItem>)standardItembll.GetItemEntityList(standard.Id, standard.TableName + "_W");
            standard.childList = dataitem;
            var jsonData = new
            {
                result = standard
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 数量获取接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetStandardCount(dynamic _)
        {
            var jsonData = new
            {
                result = standardIBLL.GetStandardCount()
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 热词获取接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetHotword(dynamic _)
        {
            String uploaddate = this.GetReqData();
            JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            int n = int.Parse(jo["n"].ToString());
            int  m = int.Parse(jo["m"].ToString());
            var jsonData = new
            {
                result = staticIBLL.GetStaticNumber(n,m)
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 近期发布标准
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetRecentlyReleased(dynamic _)
        {
            var jsonData = new
            {
                result = standardIBLL.GetRecentlyReleased()
            };
            return Success(jsonData);
        }

        /// <summary>
        /// 即将实施标准
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetComingSoon(dynamic _)
        {
            var jsonData = new
            {
                result = standardIBLL.GetComingSoon()
            };
            return Success(jsonData);
        }


        /// <summary>
        /// 标准下载
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response DownStandard(dynamic _)
        {
            // 获取标准文本地址
            string filepath = this.GetReqData();
            //JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            //string filepath = jo["textaddress"].ToString();
            //filepath = filepath.Substring(14, filepath.Length);
            string[] filearry = filepath.Split('\\');
            List<string> list = filearry.ToList();
            //删除前部分路径
            // \\Win-ho9ear61iic\gn\DB11\DB11_ 358-2011.pdf
            list.RemoveAt(0);
            list.RemoveAt(0);
            list.RemoveAt(0);
            list[0] = list[0].ToLower();
            filepath = list[0]+"/" + list[1] + "/" + list[2];
            string base64String;
            filepath = Config.GetValue("standardFile")+filepath;

            if (FileDownHelper.FileExists(filepath))
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                try
                {
                    byte[] buffur = new byte[fs.Length];
                    fs.Read(buffur, 0, (int)fs.Length);
                    base64String = Convert.ToBase64String(buffur);
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (fs != null)
                    {
                        //关闭资源
                        fs.Close();
                    }
                }
                var jsonData = new
                {
                    result = base64String,
                    info = list[2]
                };
                return Success(jsonData);
            }
            else {
                return Fail("当前标准没有文件");
            }
        }


        /// <summary>
        /// 标准预览
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response PreviewStandard(dynamic _)
        {
            // 获取标准文本地址
            string filepath = this.GetReqData();
            //JObject jo = Learun.Util.Extensions.ToObject<JObject>(uploaddate);
            //string filepath = jo["textaddress"].ToString();
            //filepath = filepath.Substring(14, filepath.Length);
            string[] filearry = filepath.Split('\\');
            List<string> list = filearry.ToList();
            //删除前部分路径
            // \\Win-ho9ear61iic\gn\DB11\DB11_ 358-2011.pdf
            list.RemoveAt(0);
            list.RemoveAt(0);
            list.RemoveAt(0);
            list[0] = list[0].ToLower();
            filepath = list[0] + "/" + list[1] + "/" + list[2];
            string base64String;
            filepath = Config.GetValue("standardFile") + filepath;

            if (FileDownHelper.FileExists(filepath))
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                try
                {
                    byte[] buffur = new byte[fs.Length];
                    fs.Read(buffur, 0, (int)fs.Length);
                    base64String = Convert.ToBase64String(buffur);
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (fs != null)
                    {
                        //关闭资源
                        fs.Close();
                    }
                }
                var jsonData = new
                {
                    result = base64String,
                    info = list[2]
                };
                return Success(jsonData);
            }
            else
            {
                return Fail("当前标准没有文件");
            }
        }
    }
}