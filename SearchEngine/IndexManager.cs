using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System.IO;
using log4net;
using System.Web.Hosting;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Learun.Application.Base.SystemModule;

namespace SearchEngine
{
    public class IndexManager
    {
        public static readonly IndexManager Instance = new IndexManager();
        private static readonly string IndexPath = Config.GetValue("searchIndex");
        //private static readonly string IndexPath = HostingEnvironment.MapPath("~/Index");
        private static ILog log = LogManager.GetLogger(typeof(IndexManager));

        private IndexManager()
        { }

        static IndexManager()
        { }

        public void Start()
        {
            Thread thread = new Thread(WatchIndexTask);
            thread.IsBackground = true;
            thread.Start();
            log.Debug("IndexManager has been lunched successfully!");
        }

        private Queue<IndexTask> indexQueue = new Queue<IndexTask>();
        private void WatchIndexTask()
        {
            while (true)
            {
                if (indexQueue.Count > 0)
                {
                    // 索引文档保存位置
                    FSDirectory directory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NativeFSLockFactory());
                    bool isUpdate = IndexReader.IndexExists(directory); //判断索引库是否存在
                    //log.Debug(string.Format("The status of index : {0}", isUpdate));
                    if (isUpdate)
                    {
                        //  如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                        //  Lucene.Net在写索引库之前会自动加锁，在close的时候会自动解锁
                        //  不能多线程执行，只能处理意外被永远锁定的情况
                        if (IndexWriter.IsLocked(directory))
                        {
                            //log.Debug("The index is existed, need to unlock.");
                            IndexWriter.Unlock(directory);  //unlock:强制解锁，待优化
                        }
                    }
                    //  创建向索引库写操作对象  IndexWriter(索引目录,指定使用盘古分词进行切词,最大写入长度限制)
                    //  补充:使用IndexWriter打开directory时会自动对索引库文件上锁
                    IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate,
                        IndexWriter.MaxFieldLength.UNLIMITED);
                    log.Debug(string.Format("Total number of task : {0}", indexQueue.Count));

                    while (indexQueue.Count > 0)
                    {
                        try {
                            IndexTask task = indexQueue.Dequeue();
                            string id = task.TaskId;
                            if (task.TaskType == TaskTypeEnum.Delete)
                            {
                                //  防止重复索引，如果不存在则删除0条
                                writer.DeleteDocuments(new Term("Id", id.ToString()));// 防止已存在的数据 => delete from t where id=i
                            }
                            else
                            {
                                //选择数据视图
                                StandardService articleService = new StandardService();
                                SearchLogService searchLogService = new SearchLogService();
                                SearchLogsEntity searchLogsEntity = new SearchLogsEntity();

                                List<Standard> standardlist = (List<Standard>)articleService.GetViewEntity(id);
                                Standard standard = standardlist[0];
                                if (standard == null)
                                {
                                    continue;
                                }
                                searchLogsEntity.SearchDate = DateTime.Now;
                                searchLogsEntity.Word = indexQueue.Count.ToString() + standard.TableName;
                                searchLogService.SaveEntity("8A6C807C-D500-4205-A398-03DEFF8BB7C6", searchLogsEntity);

                                //  一条Document相当于一条记录
                                Document document = new Document();
                                //  每个Document可以有自己的属性（字段），所有字段名都是自定义的，值都是string类型
                                //  Field.Store.YES不仅要对文章进行分词记录，也要保存原文，就不用去数据库里查一次了
                                document.Add(new Field("Id", id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                                //  需要进行全文检索的字段加 Field.Index. ANALYZED
                                //  Field.Index.ANALYZED:指定文章内容按照分词后结果保存，否则无法实现后续的模糊查询 
                                //  WITH_POSITIONS_OFFSETS:指示不仅保存分割后的词，还保存词之间的距离
                                //标准号
                                if (!string.IsNullOrWhiteSpace(standard.StandNum))
                                {
                                    document.Add(new Field("StandNum", standard.StandNum, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.Cn))
                                {
                                    //中文名称
                                    document.Add(new Field("Cn", standard.Cn, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.En))
                                {
                                    //英文名称
                                    document.Add(new Field("En", standard.En, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.Isd.ToString()))
                                {
                                    //发布日期
                                    document.Add(new Field("Isd", standard.Isd.ToString(), Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.Efd.ToString()))
                                {
                                    //实施日期
                                    document.Add(new Field("Efd", standard.Efd.ToString(), Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.Ics))
                                {
                                    //ICS
                                    document.Add(new Field("ICS", standard.Ics, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.Ccs))
                                {
                                    //中标分类号
                                    document.Add(new Field("CCS", standard.Ccs, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.Gbn))
                                {
                                    //国标号
                                    document.Add(new Field("GBN", standard.Gbn, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.StandStatus))
                                {
                                    //标准状态
                                    document.Add(new Field("StandStatus", standard.StandStatus, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.DraftingUnit))
                                {
                                    //起草单位
                                    document.Add(new Field("DraftingUnit", standard.DraftingUnit, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }
                                if (!string.IsNullOrWhiteSpace(standard.TableName))
                                {
                                    //涉及行业
                                    document.Add(new Field("TableName", standard.TableName, Field.Store.YES, Field.Index.ANALYZED,
                                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                                }

                                if (task.TaskType == TaskTypeEnum.Update)
                                {
                                    //  防止重复索引，如果不存在则删除0条
                                    writer.DeleteDocuments(new Term("Id", id.ToString()));// 防止已存在的数据 => delete from t where id=i
                                    writer.AddDocument(document);
                                }

                                if (task.TaskType == TaskTypeEnum.Add)
                                {
                                    writer.AddDocument(document);
                                }
                            }
                            //  把文档写入索引库
                            //log.Debug(string.Format("Index {0} has been writen to index library!", id.ToString()));
                        } 
                        catch (Exception e) {

                            LogEntity logEntity = new LogEntity();
                            logEntity.F_CategoryId = 4;
                            logEntity.F_OperateTime = DateTime.Now;
                            logEntity.F_ExecuteResult = -1;
                            logEntity.F_ExecuteResultJson = e.ToString();
                            logEntity.WriteLog();

                        }
                    }
                    writer.Close(); // Close后自动对索引库文件解锁
                    directory.Close();  //  不要忘了Close，否则索引结果搜不到
                    //log.Debug("The index library has been closed!");
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
        }

        public void AddArticle(IndexTask task)
        {
            task.TaskType = TaskTypeEnum.Add;
            object synObj = new object();
            lock (synObj)
            {
                indexQueue.Enqueue(task);
            }
        }

        public void UpdateArticle(IndexTask task)
        {
            task.TaskType = TaskTypeEnum.Update;
            indexQueue.Enqueue(task);
        }

        public void DeleteArticle(IndexTask task)
        {
            task.TaskType = TaskTypeEnum.Delete;
            indexQueue.Enqueue(task);
        }


        public void DeleteArticle()
        {
            // 索引文档保存位置
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NativeFSLockFactory());
            bool isUpdate = IndexReader.IndexExists(directory); //判断索引库是否存在
            log.Debug(string.Format("The status of index : {0}", isUpdate));
            if (isUpdate)
            {
                //  如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                //  Lucene.Net在写索引库之前会自动加锁，在close的时候会自动解锁
                //  不能多线程执行，只能处理意外被永远锁定的情况
                if (IndexWriter.IsLocked(directory))
                {
                    log.Debug("The index is existed, need to unlock.");
                    IndexWriter.Unlock(directory);  //unlock:强制解锁，待优化
                }
            }
            //  创建向索引库写操作对象  IndexWriter(索引目录,指定使用盘古分词进行切词,最大写入长度限制)
            //  补充:使用IndexWriter打开directory时会自动对索引库文件上锁
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate,
                IndexWriter.MaxFieldLength.UNLIMITED);
            writer.DeleteAll();// 防止已存在的数据 => delete from t where id=i

            writer.Close(); // Close后自动对索引库文件解锁
            directory.Close();  //  不要忘了Close，否则索引结果搜不到

        }

        //同步更新索引数据
        public void AddStandardSync(Standard standard,int count)
        {
            // 索引文档保存位置
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(IndexPath), new NativeFSLockFactory());
            bool isUpdate = IndexReader.IndexExists(directory); //判断索引库是否存在
            //log.Debug(string.Format("The status of index : {0}", isUpdate));
            if (isUpdate)
            {
                //  如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                //  Lucene.Net在写索引库之前会自动加锁，在close的时候会自动解锁
                //  不能多线程执行，只能处理意外被永远锁定的情况
                if (IndexWriter.IsLocked(directory))
                {
                    log.Debug("The index is existed, need to unlock.");
                    IndexWriter.Unlock(directory);  //unlock:强制解锁，待优化
                }
            }
            //  创建向索引库写操作对象  IndexWriter(索引目录,指定使用盘古分词进行切词,最大写入长度限制)
            //  补充:使用IndexWriter打开directory时会自动对索引库文件上锁
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate,IndexWriter.MaxFieldLength.UNLIMITED);
            //log.Debug(string.Format("Total number of task : {0}", indexQueue.Count));
            try
            {
                //string id = sid;
                //选择数据视图
                StandardService articleService = new StandardService();
                SearchLogService searchLogService = new SearchLogService();
                SearchLogsEntity searchLogsEntity = new SearchLogsEntity();

                //List<Standard> standardlist = (List<Standard>)articleService.GetViewEntity(id);
                //Standard standard = standardlist[0];

                searchLogsEntity.SearchDate = DateTime.Now;
                searchLogsEntity.Word = standard.Id + standard.TableName + count;
                searchLogService.SaveEntity("6E519117-551C-45FB-931E-05922D479288", searchLogsEntity);

                //  一条Document相当于一条记录
                Document document = new Document();
                //  每个Document可以有自己的属性（字段），所有字段名都是自定义的，值都是string类型
                //  Field.Store.YES不仅要对文章进行分词记录，也要保存原文，就不用去数据库里查一次了
                document.Add(new Field("Id", standard.Id, Field.Store.YES, Field.Index.NOT_ANALYZED));
                //  需要进行全文检索的字段加 Field.Index. ANALYZED
                //  Field.Index.ANALYZED:指定文章内容按照分词后结果保存，否则无法实现后续的模糊查询 
                //  WITH_POSITIONS_OFFSETS:指示不仅保存分割后的词，还保存词之间的距离
                //标准号
                if (!string.IsNullOrWhiteSpace(standard.StandNum))
                {
                    document.Add(new Field("StandNum", standard.StandNum, Field.Store.YES,Field.Index.ANALYZED,Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.Cn))
                {
                    //中文名称
                    document.Add(new Field("Cn", standard.Cn, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.En))
                {
                    //英文名称
                    document.Add(new Field("En", standard.En, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.Isd.ToString()))
                {
                    //发布日期
                    document.Add(new Field("Isd", standard.Isd.ToString(), Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.Efd.ToString()))
                {
                    //实施日期
                    document.Add(new Field("Efd", standard.Efd.ToString(), Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.Ics))
                {
                    //ICS
                    document.Add(new Field("ICS", standard.Ics, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.Ccs))
                {
                    //中标分类号
                    document.Add(new Field("CCS", standard.Ccs, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.Gbn))
                {
                    //国标号
                    document.Add(new Field("GBN", standard.Gbn, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.StandStatus))
                {
                    //标准状态
                    document.Add(new Field("StandStatus", standard.StandStatus, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.CategoryCode))
                {
                    //标准分类
                    document.Add(new Field("CategoryCode",standard.CategoryCode, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.DraftingUnit))
                {
                    //起草单位
                    document.Add(new Field("DraftingUnit", standard.DraftingUnit, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.TableName))
                {
                    //涉及行业
                    document.Add(new Field("TableName", standard.TableName, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }
                if (!string.IsNullOrWhiteSpace(standard.OrganizationNumber))
                {
                    //标准题录
                    document.Add(new Field("OrganizationNumber", standard.OrganizationNumber, Field.Store.YES, Field.Index.ANALYZED,
                        Field.TermVector.WITH_POSITIONS_OFFSETS));
                }

                writer.AddDocument(document);
            //  把文档写入索引库
            //log.Debug(string.Format("Index {0} has been writen to index library!", id.ToString()));
            }
            catch (Exception e)
            {

                LogEntity logEntity = new LogEntity();
                logEntity.F_CategoryId = 4;
                logEntity.F_OperateTime = DateTime.Now;
                logEntity.F_ExecuteResult = -1;
                logEntity.F_ExecuteResultJson = e.ToString();
                logEntity.WriteLog();

            }
            writer.Close(); // Close后自动对索引库文件解锁
            directory.Close();  //  不要忘了Close，否则索引结果搜不到
        }
    }

    public class IndexTask
    {
        public string TaskId { get; set; }

        public TaskTypeEnum TaskType { get; set; }
    }

    public enum TaskTypeEnum
    {
        Add,
        Update,
        Delete
    }
}
