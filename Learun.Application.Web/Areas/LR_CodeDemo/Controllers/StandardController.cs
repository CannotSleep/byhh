using Aspose.Words;
using Aspose.Words.Saving;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Learun.Util.File;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Word = Microsoft.Office.Interop.Word;

namespace Learun.Application.Web.Areas.LR_CodeDemo.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-02-11 10:42
    /// 描 述：功能搜索和添加
    /// </summary>
    [HandlerErrorAttribute]
    public class StandardController : MvcControllerBase
    {
        private StandardIBLL standardIBLL = new StandardBLL();
        private StandardItemIBLL standardItembll = new StandardItemBLL();
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
        /// 详情页
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }
        /// <summary>
        /// 新增
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 编辑
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// 碎片化内容
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Fragmentation()
        {
            return View();
        }


        /// <summary>
        /// 选择pdf
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Chosepdf()
        {
            return View();
        }

        /// <summary>
        /// 总添加
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddTotal()
        {
            return View();
        }

        /// <summary>
        /// 标准查新
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StandardGetNew()
        {
            return View();
        }
        /// <summary>
        /// 标准模糊查询
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChoseStandard()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 根据ID获取数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetById(string queryJson)
        {
            var data = standardIBLL.GetEntity(queryJson);
            Standard standard = ((List<Standard>)data)[0];
            //获取子项数据
            var dataitem = (List<StandardItem>)standardItembll.GetItemEntityList(standard.Id,standard.TableName+"_W");
            standard.childList = dataitem;
            return Success(standard);
        }
        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList( string queryJson )
        {
            var data = standardIBLL.GetList(queryJson);
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
            var data = standardIBLL.GetPageList(paginationobj, queryJson);
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
            var data = standardIBLL.GetEntity(keyValue);
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
            IndexTask task = new IndexTask();
            task.TaskId = keyValue;
            IndexManager.Instance.DeleteArticle(task);
            var data = standardIBLL.GetEntity(keyValue);
            Standard standard = ((List<Standard>)data)[0];
            standardIBLL.DeleteEntity(keyValue, standard.TableName);
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
        public ActionResult SaveForm(string keyValue,Standard entity)
        {
            //表格和组织号分割分割
            string[] tf = entity.TableName.Split(',');
            entity.TableName = tf[0];
            entity.OrganizationNumber = tf[1];
            string standardPath = Config.GetValue("StandardItemResource");
            if (string.IsNullOrWhiteSpace(entity.Id)) {
                entity.Id = Guid.NewGuid().ToString();
            }
            //对子项文件路径进行编辑
            if (entity.childList!=null) {
                foreach (var item in entity.childList)
                {
                    if (!string.IsNullOrWhiteSpace(item.pic))
                    {
                        //术语图片
                        item.pic = string.Format("/" + standardPath + "/{0}", item.pic);
                    }
                    if (!string.IsNullOrWhiteSpace(item.tech_pic))
                    {
                        //结构化图片
                        item.tech_pic = string.Format("/" + standardPath + "/{0}", item.tech_pic);
                    }
                    item.tableName = entity.TableName + "_W";
                    item.BId = entity.Id;
                }
            }
            standardIBLL.SaveEntity(keyValue, entity);
            if (string.IsNullOrWhiteSpace(keyValue)) {
                //新增索引
                IndexTask task = new IndexTask();
                task.TaskId = entity.Id;
                IndexManager.Instance.AddArticle(task);
            }else{
                //更新索引
                IndexTask task = new IndexTask();
                task.TaskId = entity.Id;
                IndexManager.Instance.UpdateArticle(task);
            }
            return Success(entity.Id);
        }


        /// <summary>
        /// 上传文件(修改文件名字)
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
                string standardPath = Config.GetValue("standardResource");
                //水印图片
                string Imagepath = Config.GetValue("waterResource");
                //标准路径
                string virtualPath = string.Format("~/"+ standardPath + "/{0}","原版"+ name);
                string waterPath = string.Format("~/" + standardPath + "/{0}", name);
                //标准全路径
                string fullFileName = this.Server.MapPath(virtualPath);
                string waterfullFileName = this.Server.MapPath(waterPath);
                //创建文件夹
                string path = Path.GetDirectoryName(fullFileName);
                Directory.CreateDirectory(path);
                if (!System.IO.File.Exists(fullFileName))
                {
                    //保存文件
                    Filedata.SaveAs(fullFileName);
                }
                PDFHelper.PDFWatermark(fullFileName, waterfullFileName, Imagepath);
                return Success(waterPath);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }


        /// <summary>
        /// 上传文件(子项)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadifyFileItem(HttpPostedFileBase Filedata)
        {
            try
            {
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
                string standardPath = Config.GetValue("StandardItemResource");


                string virtualPath = string.Format("~/" + standardPath + "/{0}", name);
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
        /// 标准追踪
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TrackStandard(string standardArray)
        {
            var data = standardIBLL.TrackStandard(standardArray);
            return Success(data);
        }

        /// <summary>
        /// 标准模糊复查
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TrackMohuStandard(string standnum)
        {
            var data = standardIBLL.TrackMohuStandard(standnum);
            return Success(data);
        }


        /// <summary>
        /// 标准时效性查证word内容获取
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetWord(HttpPostedFileBase Filedata)
        {

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
            string name = Filedata.FileName;
            string tword = Config.GetValue("TemplateWord");
            //标准路径
            string twordd = string.Format(tword + "{0}", name);
            //创建文件夹
            //保存文件
            Filedata.SaveAs(twordd);

            //需要生成的标准数组
            string mubanFile = twordd;

            object oFileName = mubanFile;//文件路径
            object oReadOnly = true;
            object oMissing = System.Reflection.Missing.Value;

            Word.Application oWord;
            Word.Document oDoc;
            oWord = new Word.Application();
            // oWord.Visible = true; 打开本地文件可看
            oDoc = oWord.Documents.Open(ref oFileName, ref oMissing, ref oReadOnly, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            List<string> standnumlist = new List<string>();

            for (int tablePos = 1; tablePos <= oDoc.Tables.Count; tablePos++)
            {
                //分为第几个表
                //第一个表
                if (tablePos == 1)
                {
                    Word.Table nowTable = oDoc.Tables[tablePos];
                    //表行数
                    for (int rowPos = 11; rowPos <= nowTable.Rows.Count; rowPos++)
                    {
                        string item = nowTable.Cell(rowPos, 2).Range.Text;
                        if (!item.Equals("\r\a")) {
                            standnumlist.Add(item.Replace("\r\a", ""));
                        }
                    }
                }
                else {
                    //后续表
                    Word.Table nowTable = oDoc.Tables[tablePos];
                    //表行数
                    for (int rowPos = 2; rowPos <= nowTable.Rows.Count; rowPos++)
                    {
                        string item = nowTable.Cell(rowPos, 2).Range.Text;
                        if (!item.Equals("\r\a"))
                        {
                            standnumlist.Add(item.Replace("\r\a",""));
                        }
                    }
                }
            }
            oDoc.Close();
            
            var jsonData = new
            {
                rows = JsonConvert.SerializeObject(standnumlist)
            };
            return Success(jsonData);
        }



        /// <summary>
        /// 标准追踪word导出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ExportWord(string objdata)
        {
            //需要生成的标准数组
            JArray json = (JArray)JsonConvert.DeserializeObject(objdata);
            string mubanFile = Config.GetValue("TemplateWord")+ "template.docx";
            string filename = Guid.NewGuid() + ".docx";
            string outputPath = Config.GetValue("TemplateWord") + filename;
            //string templatePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, mubanFile);
            //最外层表格
            DataTable dt1 = new DataTable("All");
            dt1.Columns.Add("datec");
            dt1.Columns.Add("total");//
            dt1.Columns.Add("dtotal");//
            dt1.Columns.Add("gtotal");//
            DataRow dr1 = dt1.NewRow();
            dr1["datec"] = DateTime.Now.ToShortDateString();//
            dr1["total"] = json.Count;//
            //统计国标和地标数量
            int dt = 0;
            int gt = 0;
            for (int i = 0; i < json.Count; i++)
            {
                //if (!string.IsNullOrWhiteSpace(json[i]["TableName"].ToString())) {
                string tbgen = json[i]["TableName"].ToString();
                    if (tbgen.Equals("GB") || tbgen.Equals("GBJ"))
                    {
                        gt += 1;
                    }
                    if (tbgen.Equals("DB11") || tbgen.Equals("DB37"))
                    {
                        dt += 1;
                    }
                //}
            }
            dr1["dtotal"] = dt;//地标
            dr1["gtotal"] = gt;//国标

            //主表添加
            dt1.Rows.Add(dr1);

            //子项表格
            DataTable dt2 = new DataTable("Item");
            dt2.Columns.Add("Numc");
            dt2.Columns.Add("StandardNum");
            dt2.Columns.Add("StandardName");
            dt2.Columns.Add("Status");


            for (int i = 0; i < json.Count; i++) {
                DataRow dri1 = dt2.NewRow();
                dri1["Numc"] = i + 1;//
                dri1["StandardNum"] = json[i]["StandNum"].ToString();
                dri1["StandardName"] = json[i]["Cn"].ToString();
                string status = json[i]["StandStatus"].ToString();
                if (status.Equals("废止"))
                {
                    dri1["Status"] = "[" + status + "]" + " " + json[i]["AbolitionDate"] + "为止，被" + json[i]["SubstituteStandard"] + "代替";//
                }
                else if (status.Equals("现行"))
                {
                    dri1["Status"] = "[现行有效]";//
                    if (!string.IsNullOrWhiteSpace(json[i]["AbolitionDate"].ToString())) {
                        dri1["Status"] += json[i]["AbolitionDate"] + "为止";
                    }
                    if (!string.IsNullOrWhiteSpace(json[i]["SubstituteStandard"].ToString()))
                    {
                        dri1["Status"] += "被"+json[i]["SubstituteStandard"] + "代替";
                    }
                }
                else {
                    dri1["Status"] = "[" + status + "]";//
                }
                dt2.Rows.Add(dri1);
            }

            //数据表格赋值
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);

            Document doc = new Document(mubanFile);
            doc.MailMerge.ExecuteWithRegions(ds);
            doc.Save(outputPath,SaveOptions.CreateSaveOptions(SaveFormat.Docx));


            //FileStream fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read, FileShare.Read); //打开文件

            //// 读取文件Byte[]
            //byte[] bytes = new byte[fileStream.Length];
            //fileStream.Read(bytes, 0, bytes.Length);
            //fileStream.Close();
            //Stream stream = new MemoryStream(bytes); //byte[]转换为Stream
            return Success(filename);
        }
        #endregion

    }
}
