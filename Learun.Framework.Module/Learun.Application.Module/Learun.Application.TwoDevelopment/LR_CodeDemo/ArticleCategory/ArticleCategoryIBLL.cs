using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-13 10:05
    /// 描 述：文章分类表
    /// </summary>
    public interface ArticleCategoryIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<ArticleCategoryEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取页面列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<ArticleCategoryEntity> GetList(string queryJson);
        /// <summary>
        /// 获取ArticleCategory表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ArticleCategoryEntity GetArticleCategoryEntity(string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, ArticleCategoryEntity entity);
        #endregion

    }
}
