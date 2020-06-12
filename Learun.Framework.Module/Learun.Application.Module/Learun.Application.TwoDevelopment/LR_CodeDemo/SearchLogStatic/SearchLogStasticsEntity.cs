using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-02-10 19:00
    /// 描 述：搜索统计
    /// </summary>
    public class SearchLogStasticsEntity 
    {
        #region 实体成员
        /// <summary>
        /// Word
        /// </summary>
        /// <returns></returns>
        [Column("WORD")]
        public string Word { get; set; }
        /// <summary>
        /// SearchCount
        /// </summary>
        /// <returns></returns>
        [Column("SEARCHCOUNT")]
        public string SearchCount { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Word = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.Word = keyValue;
        }
        #endregion
    }
}

