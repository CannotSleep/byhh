using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Cache.Base;
using Learun.Cache.Factory;

namespace Learun.Application.TwoDevelopment.LR_CodeDemo
{
    /// <summary>
    /// 日 期：2020-03-03 14:36
    /// 描 述：会员管理
    /// </summary>
    public class VipMemberBLL : VipMemberIBLL
    {
        private VipMemberService vipMemberService = new VipMemberService();

        #region 属性
        private VipMemberService memberService = new VipMemberService();
        #endregion

        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "by_vip_user_";       // +公司主键
        private string cacheKeyAccount = "by_vip_user_account_";// +用户账号（账号不允许改动）
        private string cacheKeyId = "by_vip_user_Id_";// +用户账号（账号不允许改动）
        #endregion


        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<memberEntity> GetList( string queryJson )
        {
            try
            {
                return vipMemberService.GetList(queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体,通过用户账号
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <returns></returns>
        public memberEntity GetEntityByAccount(string account)
        {
            try
            {
                string userId = cache.Read<string>(cacheKeyAccount + account, CacheId.user);
                memberEntity member;
                if (string.IsNullOrEmpty(userId))
                {
                    member = memberService.GetEntityByAccount(account);
                    if (member != null)
                    {
                        cache.Write<string>(cacheKeyAccount + member.AccountName, member.Id, CacheId.user);
                        cache.Write<memberEntity>(cacheKeyId + member.Id, member, CacheId.user);
                    }
                }
                else
                {
                    member = cache.Read<memberEntity>(cacheKeyId + userId, CacheId.user);
                    if (member == null)
                    {
                        member = memberService.GetEntityByAccount(account);
                        if (member != null)
                        {
                            cache.Write<memberEntity>(cacheKeyId + member.Id, member, CacheId.user);
                        }
                    }
                }
                return member;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                } 
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<memberEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return vipMemberService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public memberEntity GetEntity(string keyValue)
        {
            try
            {
                return vipMemberService.GetEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                vipMemberService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, memberEntity entity)
        {
            try
            {
                //todo缓存
                cache.Remove(cacheKeyId + keyValue, CacheId.user);
                cache.Remove(cacheKey + "dic", CacheId.user);
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.AccountName = null;// 账号不允许改动
                }
                vipMemberService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #endregion

        #region 扩展方法
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码 MD5 32位 小写</param>
        /// <returns></returns>
        public memberEntity CheckLogin(string account, string password)
        {
            ////调用微信开放平台接口获得Token、OpenId
            //string appid = Config.GetValue("AppId");
            //string appsecret = Config.GetValue("AppSecret");
            //OpenTokenGet openTokenGet = new OpenTokenGet();
            //openTokenGet.appid = appid;
            //openTokenGet.secret = appsecret;
            //openTokenGet.code = "0815LTNN0EEei42rURNN0z5QNN05LTNS";
            //OpenTokenGetResult openInfo = openTokenGet.OpenSend();
            //string openid = openInfo.openid;
            //string token = openInfo.access_token;
            ////调用微信开放平台接口获得登录用户个人信息
            //OpenUserGet openuser = new OpenUserGet();
            //openuser.openid = openid;
            //openuser.access_token = token;
            //OpenUserGetResult userinfo = openuser.OpenSend();
            try
            {
                memberEntity member = GetEntityByAccount(account);
                if (member == null)
                {
                    member = new memberEntity()
                    {
                        LoginMsg = "账户不存在!",
                        LoginOk = false
                    };
                    return member;
                }
                member.LoginOk = false;
                if (member.isAccountEnabled == true)
                {
                    string dbPassword = Md5Helper.Encrypt(DESEncrypt.Encrypt(password.ToLower(),"").ToLower(), 32).ToLower();
                    if (dbPassword == member.Password)
                    {
                        member.LoginOk = true;
                    }
                    else
                    {
                        member.LoginMsg = "密码和账户名不匹配!";
                    } 
                }
                else
                {
                    member.LoginMsg = "账户被系统锁定,请联系管理员!";
                }
                return member;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="userId">用户ID</param>
        //public void GetImg(string userId)
        //{
        //    UserEntity entity = GetEntityByUserId(userId);
        //    string img = "";
        //    string fileHeadImg = Config.GetValue("fileHeadImg");
        //    if (entity != null)
        //    {
        //        if (!string.IsNullOrEmpty(entity.F_HeadIcon))
        //        {
        //            string fileImg = string.Format("{0}/{1}{2}", fileHeadImg, entity.F_UserId, entity.F_HeadIcon);
        //            if (DirFileHelper.IsExistFile(fileImg))
        //            {
        //                img = fileImg;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        img = string.Format("{0}/{1}", fileHeadImg, "on-boy.jpg");
        //    }
        //    if (string.IsNullOrEmpty(img))
        //    {
        //        if (entity.F_Gender == 0)
        //        {
        //            img = string.Format("{0}/{1}", fileHeadImg, "on-girl.jpg");
        //        }
        //        else
        //        {
        //            img = string.Format("{0}/{1}", fileHeadImg, "on-boy.jpg");
        //        }
        //    }
        //    FileDownHelper.DownLoadnew(img);
        //}
        #endregion
    }
}
