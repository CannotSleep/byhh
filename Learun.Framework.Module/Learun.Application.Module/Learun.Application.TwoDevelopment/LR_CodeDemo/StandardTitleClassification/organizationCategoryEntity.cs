using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-16 11:46
    /// 描 述：题录分类管理
    /// </summary>
    public class organizationCategoryEntity 
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public Guid Id { get; set; }
        /// <summary>
        /// 分类代码
        /// </summary>
        /// <returns></returns>
        [Column("CATEGORYCODE")]
        public string CategoryCode { get; set; }
        /// <summary>
        /// 分类描述
        /// </summary>
        /// <returns></returns>
        [Column("DESCRIBE")]
        public string Describe { get; set; }
        /// <summary>
        /// 分类地址
        /// </summary>
        /// <returns></returns>
        [Column("ADDRESS")]
        public string Address { get; set; }
        /// <summary>
        /// 分类地址码
        /// </summary>
        /// <returns></returns>
        [Column("ADDRESSCODE")]
        public string AddressCode { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        [Column("CREATEDATE")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYDATE")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string Remark { get; set; }
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

