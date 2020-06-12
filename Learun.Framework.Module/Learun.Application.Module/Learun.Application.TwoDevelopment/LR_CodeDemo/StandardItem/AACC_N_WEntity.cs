using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo

{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-03-26 15:54
    /// 描 述：标准子类
    /// </summary>
    public class StandardItem
    {
        #region 实体成员
        /// <summary>
        /// type
        /// </summary>
        /// <returns></returns>
        [Column("TYPE")]
        public string type { get; set; }
        /// <summary>
        /// clg_id
        /// </summary>
        /// <returns></returns>
        [Column("CLG_ID")]
        public string clg_id { get; set; }
        /// <summary>
        /// clg_name
        /// </summary>
        /// <returns></returns>
        [Column("CLG_NAME")]
        public string clg_name { get; set; }
        /// <summary>
        /// n_docum
        /// </summary>
        /// <returns></returns>
        [Column("N_DOCUM")]
        public string n_docum { get; set; }
        /// <summary>
        /// app_id
        /// </summary>
        /// <returns></returns>
        [Column("APP_ID")]
        public string app_id { get; set; }
        /// <summary>
        /// app_body
        /// </summary>
        /// <returns></returns>
        [Column("APP_BODY")]
        public string app_body { get; set; }
        /// <summary>
        /// ref_item
        /// </summary>
        /// <returns></returns>
        [Column("REF_ITEM")]
        public string ref_item { get; set; }
        /// <summary>
        /// t_id
        /// </summary>
        /// <returns></returns>
        [Column("T_ID")]
        public string t_id { get; set; }
        /// <summary>
        /// t_cn
        /// </summary>
        /// <returns></returns>
        [Column("T_CN")]
        public string t_cn { get; set; }
        /// <summary>
        /// t_en
        /// </summary>
        /// <returns></returns>
        [Column("T_EN")]
        public string t_en { get; set; }
        /// <summary>
        /// t_def
        /// </summary>
        /// <returns></returns>
        [Column("T_DEF")]
        public string t_def { get; set; }
        /// <summary>
        /// t_note
        /// </summary>
        /// <returns></returns>
        [Column("T_NOTE")]
        public string t_note { get; set; }
        /// <summary>
        /// t_exp
        /// </summary>
        /// <returns></returns>
        [Column("T_EXP")]
        public string t_exp { get; set; }
        /// <summary>
        /// pic
        /// </summary>
        /// <returns></returns>
        [Column("PIC")]
        public string pic { get; set; }
        /// <summary>
        /// tech_itid
        /// </summary>
        /// <returns></returns>
        [Column("TECH_ITID")]
        public string tech_itid { get; set; }
        /// <summary>
        /// tech_itname
        /// </summary>
        /// <returns></returns>
        [Column("TECH_ITNAME")]
        public string tech_itname { get; set; }
        /// <summary>
        /// tech_ptbody
        /// </summary>
        /// <returns></returns>
        [Column("TECH_PTBODY")]
        public string tech_ptbody { get; set; }
        /// <summary>
        /// tech_level
        /// </summary>
        /// <returns></returns>
        [Column("TECH_LEVEL")]
        public string tech_level { get; set; }
        /// <summary>
        /// tech_pic
        /// </summary>
        /// <returns></returns>
        [Column("TECH_PIC")]
        public string tech_pic { get; set; }
        /// <summary>
        /// BId
        /// </summary>
        /// <returns></returns>
        [Column("BID")]
        public string BId { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string Id { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.Id = keyValue;
        }
        #endregion
    }
}

