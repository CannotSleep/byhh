using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Util;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SearchEngine.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace SearchEngine
{
    public class SearchService
    {

        public IList<SearchResult> search(string keyword,string page,string pagesize,out int count)
        {
            string indexPath = Config.GetValue("searchIndex");
            //string indexPath1 = System.IO.Directory.GetCurrentDirectory().MapPath("~/Index"); // 索引文档保存位置
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            int totalCount = 0;
            #region v1.0 单条件查询
            //// 查询条件
            //PhraseQuery query = new PhraseQuery();
            //// 分词后加入查询
            //IEnumerable<string> keyList = SplitHelper.SplitWords(keyword);
            //foreach (var key in keyList)
            //{
            //    query.Add(new Term("msg", key));
            //}
            //// 两个词的距离大于100（经验值）就不放入搜索结果，因为距离太远相关度就不高了
            //query.SetSlop(100); 
            #endregion

            #region v2.0 多条件查询
            IEnumerable<string> keyList = SplitHelper.SplitWords(keyword);

            //标准号
            PhraseQuery queryTitle = new PhraseQuery();
            foreach (var key in keyList)
            {
                queryTitle.Add(new Term("StandNum", key));
            }
            queryTitle.SetSlop(100);

            //中文名称
            PhraseQuery queryMsg = new PhraseQuery();
            foreach (var key in keyList)
            {
                queryMsg.Add(new Term("Cn", key));
            }
            queryMsg.SetSlop(100);

            //英文名称
            PhraseQuery queryMsgEn = new PhraseQuery();
            foreach (var key in keyList)
            {
                queryMsgEn.Add(new Term("En", key));
            }
            queryMsgEn.SetSlop(100);

            //发布日期
            PhraseQuery relaDate = new PhraseQuery();
            foreach (var key in keyList)
            {
                relaDate.Add(new Term("Isd", key));
            }
            relaDate.SetSlop(100);

            //实施日期
            PhraseQuery impDate = new PhraseQuery();
            foreach (var key in keyList)
            {
                impDate.Add(new Term("Efd", key));
            }
            impDate.SetSlop(100);

            //ICS
            PhraseQuery ics = new PhraseQuery();
            foreach (var key in keyList)
            {
                ics.Add(new Term("ICS", key));
            }
            ics.SetSlop(100);

            //ccs
            PhraseQuery ccs = new PhraseQuery();
            foreach (var key in keyList)
            {
                ccs.Add(new Term("CCS", key));
            }
            ccs.SetSlop(100);

            //gbn
            PhraseQuery gbn = new PhraseQuery();
            foreach (var key in keyList)
            {
                gbn.Add(new Term("GBN", key));
            }
            gbn.SetSlop(100);

            //标准状态
            PhraseQuery standstatus = new PhraseQuery();
            foreach (var key in keyList)
            {
                standstatus.Add(new Term("StandStatus", key));
            }
            standstatus.SetSlop(100);

            //起草单位
            PhraseQuery draftingUnit = new PhraseQuery();
            foreach (var key in keyList)
            {
                draftingUnit.Add(new Term("DraftingUnit", key));
            }
            draftingUnit.SetSlop(100);

            //涉及行业
            PhraseQuery tableName = new PhraseQuery();
            foreach (var key in keyList)
            {
                tableName.Add(new Term("TableName", key));
            }
            tableName.SetSlop(100);

            BooleanQuery query = new BooleanQuery();
            //标准号
            query.Add(queryTitle, BooleanClause.Occur.SHOULD); // SHOULD => 可以有，但不是必须的
            //中文名称
            query.Add(queryMsg, BooleanClause.Occur.SHOULD); // SHOULD => 可以有
            //英文名称
            query.Add(queryMsgEn, BooleanClause.Occur.SHOULD); // SHOULD => 可以有
            //发布日期
            query.Add(relaDate, BooleanClause.Occur.SHOULD); // SHOULD => 可以有，但不
            //实施日期
            query.Add(impDate, BooleanClause.Occur.SHOULD); // SHOULD => 可以有，但不
            //ics
            query.Add(ics, BooleanClause.Occur.SHOULD);
            //ccs
            query.Add(ccs, BooleanClause.Occur.SHOULD);
            //gbn
            query.Add(gbn, BooleanClause.Occur.SHOULD);
            //标准状态
            query.Add(standstatus, BooleanClause.Occur.SHOULD);
            //起草单位
            query.Add(draftingUnit, BooleanClause.Occur.SHOULD);
            //设计行业
            query.Add(tableName, BooleanClause.Occur.SHOULD);

            #endregion

            // TopScoreDocCollector:盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            // 使用query这个查询条件进行搜索，搜索结果放入collector
            searcher.Search(query, null, collector);
            // 首先获取总条数
            totalCount = collector.GetTotalHits();
            int startpage = int.Parse(page);
            int pagesi = int.Parse(pagesize);
            int start = (startpage-1) * pagesi;
            int end = startpage * pagesi;

            // 从查询结果中取出第m条到第n条的数据
            ScoreDoc[] docs = collector.TopDocs(start, end).scoreDocs;
            // 遍历查询结果
            IList<SearchResult> resultList = new List<SearchResult>();
            for (int i = 0; i < docs.Length; i++)
            {
                // 拿到文档的id，因为Document可能非常占内存（DataSet和DataReader的区别）
                int docId = docs[i].doc;
                // 所以查询结果中只有id，具体内容需要二次查询
                // 根据id查询内容：放进去的是Document，查出来的还是Document
                Document doc = searcher.Doc(docId);
                SearchResult result = new SearchResult();
                result.Id = doc.Get("Id");
                //result.StandNum = HighlightHelper.HighLight(keyword,doc.Get("StandNum"));
                result.StandNum = doc.Get("StandNum");
                result.Cn = doc.Get("Cn");
                result.En = doc.Get("En");
                result.Isd = doc.Get("Isd");
                result.Efd = doc.Get("Efd");
                result.ICS = doc.Get("ICS");
                result.CCS = doc.Get("CCS");
                result.GBN = doc.Get("GBN");
                result.DraftingUnit = doc.Get("DraftingUnit");
                result.TableName = doc.Get("TableName");
                result.StandStatus = doc.Get("StandStatus");
                //result.StandNum = HighlightHelper.HighLight(keyword, doc.Get("StandNum"));
                //result.ChineseName = HighlightHelper.HighLight(keyword, doc.Get("ChineseName")) + "......";

                resultList.Add(result);
            }
            count = totalCount;
            //添加搜索记录和搜索次数
            SearchLogService searchLogService = new SearchLogService();
            SearchLogStaticService searchLogStaticService = new SearchLogStaticService();

            foreach (var item in keyList) {
                //搜索记录
                SearchLogsEntity searchLogsEntity = new SearchLogsEntity();
                searchLogsEntity.SearchDate = DateTime.Now;
                searchLogsEntity.Word = item;
                searchLogService.SaveEntity("", searchLogsEntity);
                //搜索次数
                //searchLogStaticService.Stastic();
            }

            return resultList;
        }

        public IList<SearchResult> AdvandceSearch(string ssnum, string scn, string sen, string sics, string sccs, string sstatus, string sfenlei, string sisd, string sefd, string page, string pagesize, out int count)
        {
            string indexPath = Config.GetValue("searchIndex");
            //string indexPath1 = System.IO.Directory.GetCurrentDirectory().MapPath("~/Index"); // 索引文档保存位置
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            int totalCount = 0;
            #region v1.0 单条件查询
            //// 查询条件
            //PhraseQuery query = new PhraseQuery();
            //// 分词后加入查询
            //IEnumerable<string> keyList = SplitHelper.SplitWords(keyword);
            //foreach (var key in keyList)
            //{
            //    query.Add(new Term("msg", key));
            //}
            //// 两个词的距离大于100（经验值）就不放入搜索结果，因为距离太远相关度就不高了
            //query.SetSlop(100); 
            #endregion

            #region v2.0 多条件查询
            //IEnumerable<string> keyList = SplitHelper.SplitWords(keyword);
            BooleanQuery query = new BooleanQuery();

            PhraseQuery queryTitle = new PhraseQuery();
            //标准号
            if (!string.IsNullOrWhiteSpace(ssnum)) {
                IEnumerable<string> keyListssnum = SplitHelper.SplitWords(ssnum);
                foreach (var key in keyListssnum)
                {
                    queryTitle.Add(new Term("StandNum", key));
                }
                //标准号
                query.Add(queryTitle, BooleanClause.Occur.SHOULD); // SHOULD => 可
            }

            //中文名称
            PhraseQuery queryMsg = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(scn))
            {
                IEnumerable<string> keyListscn = SplitHelper.SplitWords(scn);
                foreach (var key in keyListscn)
                {
                    queryMsg.Add(new Term("Cn", key));
                }
                //中文名称
                query.Add(queryMsg, BooleanClause.Occur.SHOULD); // SHOULD => 可以有
            }

            //英文名称
            PhraseQuery queryMsgEn = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sen))
            {
                IEnumerable<string> keyListsen = SplitHelper.SplitWords(sen);
                foreach (var key in keyListsen)
                {
                    queryMsgEn.Add(new Term("En", key));
                }
                //英文名称
                query.Add(queryMsgEn, BooleanClause.Occur.SHOULD); // SHOULD => 可以有
            }

            //发布日期
            PhraseQuery relaDate = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sisd))
            {
                IEnumerable<string> keyListsisd = SplitHelper.SplitWords(sisd);
                foreach (var key in keyListsisd)
                {
                    relaDate.Add(new Term("Isd", key));
                }
                //发布日期
                query.Add(relaDate, BooleanClause.Occur.SHOULD); // SHOULD => 可以有，但不
            }

            //实施日期
            PhraseQuery impDate = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sefd))
            {
                IEnumerable<string> keyListsefd = SplitHelper.SplitWords(sefd);
                foreach (var key in keyListsefd)
                {
                    impDate.Add(new Term("Efd", key));
                }
                //实施日期
                query.Add(impDate, BooleanClause.Occur.SHOULD); // SHOULD => 可以有，但不
            }

            //ICS
            PhraseQuery ics = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sics))
            {
                IEnumerable<string> keyListsics = SplitHelper.SplitWords(sics);
                foreach (var key in keyListsics)
                {
                    ics.Add(new Term("ICS", key));
                }
                //ics
                query.Add(ics, BooleanClause.Occur.SHOULD);
            }

            //ccs
            PhraseQuery ccs = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sccs))
            {
                IEnumerable<string> keyListsccs = SplitHelper.SplitWords(sccs);
                foreach (var key in keyListsccs)
                {
                    ccs.Add(new Term("CCS", key));
                }
                //ccs
                query.Add(ccs, BooleanClause.Occur.SHOULD);
            }


            ////gbn
            //PhraseQuery gbn = new PhraseQuery();
            //foreach (var key in keyList)
            //{
            //    gbn.Add(new Term("GBN", key));
            //}
            //gbn.SetSlop(100);

            //标准状态
            PhraseQuery standstatus = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sstatus))
            {
                IEnumerable<string> keyListsstatus = SplitHelper.SplitWords(sstatus);
                foreach (var key in keyListsstatus)
                {
                    standstatus.Add(new Term("StandStatus", key));
                }
                //标准状态
                query.Add(standstatus, BooleanClause.Occur.SHOULD);
            }

            //标准分类
            PhraseQuery standcategory = new PhraseQuery();
            if (!string.IsNullOrWhiteSpace(sfenlei))
            {
                IEnumerable<string> keyListsstatus = SplitHelper.SplitWords(sfenlei);
                foreach (var key in keyListsstatus)
                {
                    standcategory.Add(new Term("CategoryCode", key));
                }
                //标准分类
                query.Add(standcategory, BooleanClause.Occur.SHOULD);
            }

            //foreach (var key in keyList)
            //{
            //    standstatus.Add(new Term("StandStatus", key));
            //}
            //standstatus.SetSlop(100);

            ////起草单位
            //PhraseQuery draftingUnit = new PhraseQuery();
            //foreach (var key in keyList)
            //{
            //    draftingUnit.Add(new Term("DraftingUnit", key));
            //}
            //draftingUnit.SetSlop(100);

            //涉及行业
            //PhraseQuery tableName = new PhraseQuery();
            //foreach (var key in keyList)
            //{
            //    tableName.Add(new Term("TableName", key));
            //}
            //tableName.SetSlop(100);

            //gbn
            // query.Add(gbn, BooleanClause.Occur.SHOULD);

            //起草单位
            //query.Add(draftingUnit, BooleanClause.Occur.SHOULD);
            //设计行业
            //query.Add(tableName, BooleanClause.Occur.SHOULD);

            #endregion
            // TopScoreDocCollector:盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            // 使用query这个查询条件进行搜索，搜索结果放入collector
            searcher.Search(query, null, collector);
            // 首先获取总条数
            totalCount = collector.GetTotalHits();
            int startpage = int.Parse(page);
            int pagesi = int.Parse(pagesize);
            int start = (startpage - 1) * pagesi;
            int end = startpage * pagesi;

            // 从查询结果中取出第m条到第n条的数据
            ScoreDoc[] docs = collector.TopDocs(start, end).scoreDocs;
            // 遍历查询结果
            IList<SearchResult> resultList = new List<SearchResult>();
            for (int i = 0; i < docs.Length; i++)
            {
                // 拿到文档的id，因为Document可能非常占内存（DataSet和DataReader的区别）
                int docId = docs[i].doc;
                // 所以查询结果中只有id，具体内容需要二次查询
                // 根据id查询内容：放进去的是Document，查出来的还是Document
                Document doc = searcher.Doc(docId);
                SearchResult result = new SearchResult();
                result.Id = doc.Get("Id");
                //result.StandNum = HighlightHelper.HighLight(keyword,doc.Get("StandNum"));
                result.StandNum = doc.Get("StandNum");
                result.Cn = doc.Get("Cn");
                result.En = doc.Get("En");
                result.Isd = doc.Get("Isd");
                result.Efd = doc.Get("Efd");
                result.ICS = doc.Get("ICS");
                result.CCS = doc.Get("CCS");
                result.GBN = doc.Get("GBN");
                result.DraftingUnit = doc.Get("DraftingUnit");
                result.TableName = doc.Get("TableName");
                result.StandStatus = doc.Get("StandStatus");
                string catcode = doc.Get("CategoryCode");
                result.CategoryCode = catcode;
                //result.StandNum = HighlightHelper.HighLight(keyword, doc.Get("StandNum"));
                //result.ChineseName = HighlightHelper.HighLight(keyword, doc.Get("ChineseName")) + "......";
                if (!string.IsNullOrWhiteSpace(sfenlei))
                {
                    if (catcode.Equals(sfenlei))
                    {
                        resultList.Add(result);
                    }
                }
                else {
                    resultList.Add(result);
                }

            }
            count = resultList.Count;
            //添加搜索记录和搜索次数
            SearchLogService searchLogService = new SearchLogService();
            SearchLogStaticService searchLogStaticService = new SearchLogStaticService();

            //foreach (var item in keyList)
            //{
            //    //搜索记录
            //    SearchLogsEntity searchLogsEntity = new SearchLogsEntity();
            //    searchLogsEntity.SearchDate = DateTime.Now;
            //    searchLogsEntity.Word = item;
            //    searchLogService.SaveEntity("", searchLogsEntity);
                //搜索次数
                //searchLogStaticService.Stastic();
            //}

            return resultList;
        }
    }
}
