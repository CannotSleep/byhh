using Learun.Util;
using System.Data;
using System.Collections.Generic;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 日 期：2020-03-03 14:36
    /// 描 述：会员管理
    /// </summary>
    public interface VipMemberIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<memberEntity> GetList( string queryJson );
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<memberEntity> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        memberEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取实体,通过用户账号
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        memberEntity GetEntityByAccount(string account);

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
        void SaveEntity(string keyValue, memberEntity entity);
        #endregion

        #region 扩展方法
        /// <summary>
        /// 验证登录 F_UserOnLine 0 不成功,1成功
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="password">密码 MD5 32位 小写</param>
        /// <returns></returns>
        memberEntity CheckLogin(string username, string password);
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="userId">用户ID</param>
        //void GetImg(string userId);
        #endregion
    }
}
