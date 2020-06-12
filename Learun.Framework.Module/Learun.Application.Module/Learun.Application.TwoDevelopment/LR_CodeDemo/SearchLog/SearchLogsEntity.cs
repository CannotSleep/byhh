using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 日 期：2020-02-10 18:57
    /// 描 述：搜索记录
    /// </summary>
    public class SearchLogsEntity 
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public Guid Id { get; set; }
        /// <summary>
        /// Word
        /// </summary>
        /// <returns></returns>
        [Column("WORD")]
        public string Word { get; set; }
        /// <summary>
        /// SearchDate
        /// </summary>
        /// <returns></returns>
        [Column("SEARCHDATE")]
        public DateTime? SearchDate { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Id = Guid.NewGuid();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.Id = new Guid(keyValue);
        }
        #endregion
    }
}

