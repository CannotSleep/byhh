using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-20 10:39
    /// 描 述：合作机构
    /// </summary>
    public class MechanismEntity
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string id { get; set; }
        /// <summary>
        /// createDate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public DateTime? createDate { get; set; }
        /// <summary>
        /// modifyDate
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYDATE")]
        public DateTime? modifyDate { get; set; }
        /// <summary>
        /// name
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string name { get; set; }
        /// <summary>
        /// imgPath
        /// </summary>
        /// <returns></returns>
        [Column("IMGPATH")]
        public string imgPath { get; set; }
        /// <summary>
        /// htmlFilePath
        /// </summary>
        /// <returns></returns>
        [Column("HTMLFILEPATH")]
        public string htmlFilePath { get; set; }
        /// <summary>
        /// ouid
        /// </summary>
        /// <returns></returns>
        [Column("OUID")]
        public string ouid { get; set; }
        /// <summary>
        /// state
        /// </summary>
        /// <returns></returns>
        [Column("STATE")]
        public int? state { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.createDate = DateTime.Now;
            this.modifyDate = DateTime.Now;
            this.id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.modifyDate = DateTime.Now;
            this.id = keyValue;
        }
        #endregion
    }
}

