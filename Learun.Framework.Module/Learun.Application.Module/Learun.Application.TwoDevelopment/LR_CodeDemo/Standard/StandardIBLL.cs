using Learun.Util;
using System.Data;
using System.Collections.Generic;
using static Learun.Application.TwoDevelopment.LR_CodeDemo.Standard;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-02-11 10:42
    /// 描 述：功能搜索和添加
    /// </summary>
    public interface StandardIBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取所有表
        /// <summary>
        /// <returns></returns>
        IEnumerable<string> GetAllTable();
        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetList( string queryJson );
        /// <summary>
        /// 根据表名获取表格数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetListByTableName(string tname);
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取地标列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetDbPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetEntity(string keyValue);
        /// <summary>
        /// 获取标准数量数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        StandardStatic GetStandardCount();
        /// <summary>
        /// 标准追踪
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> TrackStandard(string keyValue);

        /// <summary>
        /// 标准模糊追踪
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> TrackMohuStandard(string keyValue);

        /// <summary>
        /// 近期发布标准
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetRecentlyReleased();

        /// <summary>
        /// 即将实施标准
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<Standard> GetComingSoon();
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue,string tableName);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, Standard entity);
        #endregion

    }
}
