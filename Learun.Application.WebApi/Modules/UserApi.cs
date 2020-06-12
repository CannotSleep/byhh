using Learun.Application.Base.SystemModule;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.LR_CodeDemo;
using Learun.Cache.Redis;
using Learun.Util;
using Learun.Util.Operat;
using Nancy;
using System;

namespace Learun.Application.WebApi
{
    /// <summary>
    /// 日 期：2017.05.12
    /// 描 述：用户信息
    /// </summary>
    public class UserApi : BaseApi
    {
        /// <summary>
        /// 注册接口
        /// </summary>
        public UserApi()
            : base("/by/adms/user")
        {
            Post["/login"] = Login;
            Post["/modifypw"] = ModifyPassword;
            Post["/verify"] = GetVerifyCode;
            Post["/register"] = Register;

            Get["/info"] = Info;
            Get["/map"] = GetMap;
            Get["/img"] = GetImg;
        }
        private UserIBLL userIBLL = new UserBLL();
        private PostIBLL postIBLL = new PostBLL();
        private RoleIBLL roleIBLL = new RoleBLL();
        private VipMemberIBLL memberIBLL = new VipMemberBLL();

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Login(dynamic _)
        {
            LoginModel loginModel = this.GetReqData<LoginModel>();

            #region 内部账户验证
            memberEntity member = memberIBLL.CheckLogin(loginModel.username, loginModel.password);

            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.F_OperateAccount = loginModel.username + "(" + member.UserName + ")";
            logEntity.F_OperateUserId = !string.IsNullOrEmpty(member.Id) ? member.Id : loginModel.username;
            logEntity.F_Module = Config.GetValue("SoftName");
            #endregion

            if (!member.LoginOk)//登录失败
            {
                //写入日志
                logEntity.F_ExecuteResult = 0;
                logEntity.F_ExecuteResultJson = "登录失败:" + member.LoginMsg;
                logEntity.WriteLog();
                return Fail(member.LoginMsg);
            }
            else
            {
                string token = OperatorHelper.Instance.AddLoginUser(member.AccountName, "Learun_ADMS_6.1_App", this.loginMark, false);//写入缓存信息
                //写入日志
                logEntity.F_ExecuteResult = 1;
                logEntity.F_ExecuteResultJson = "登录成功";
                logEntity.WriteLog();

                OperatorResult res = OperatorHelper.Instance.IsVipOnLine(token, this.loginMark);
                res.userInfo.password = null;
                res.userInfo.secretkey = null;

                var jsonData = new
                {
                    baseinfo = res.userInfo
                    //post = postIBLL.GetListByPostIds(res.userInfo.postIds),
                    //role = roleIBLL.GetListByRoleIds(res.userInfo.roleIds)
                };
                return Success(jsonData);
            }
            #endregion
        }


        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response Register(dynamic _)
        {
            RegisterModel registerModel = this.GetReqData<RegisterModel>();

            #region 验证正在使用账号是否重复
            memberEntity member = memberIBLL.GetEntityByAccount(registerModel.username);
            if (member != null &&!string.IsNullOrWhiteSpace(member.AccountName)) {
                //如果有重复
                return Fail("用户名已存在请更换用户名");
            }
            #endregion
            #region 验证邮件验证码是否过期
            string vcode =  RedisCache.Get<string>(registerModel.email, 2);
            if (string.IsNullOrWhiteSpace(vcode) || !vcode.Equals(registerModel.verifycode)) {
                return Fail("验证码过期请重新获取");
            }
            #endregion
            #region 写入日志
            LogEntity logEntity = new LogEntity();
            logEntity.F_CategoryId = 1;
            logEntity.F_OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.F_OperateType = EnumAttribute.GetDescription(OperationType.Register);
            logEntity.F_OperateAccount = registerModel.username;
            logEntity.F_OperateUserId = registerModel.username;
            logEntity.F_Module = Config.GetValue("SoftName");
            #endregion
            //写入用户信息
            memberEntity entity = new memberEntity();
            entity.AccountName = registerModel.username;
            entity.Password = registerModel.password;
            entity.Email = registerModel.email;
            entity.MemberRankId = "402881fb5a112ff7015ab1b4db5a09b6";
            entity.CreateDate = DateTime.Now;
            entity.RegisterIp = Net.Ip;
            entity.isAccountEnabled = true;
            entity.isAccountLocked = false;
            entity.isAccountExpired = false;
            entity.isCredentialsExpired = false;
            //todo 审核
            memberIBLL.SaveEntity("", entity);
            //写入日志
            logEntity.F_ExecuteResult = 1;
            logEntity.F_ExecuteResultJson = "注册成功";
            logEntity.WriteLog();
            return Success("注册成功");
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns> 
        private Response Info(dynamic _)
        {
            var data = userInfo;
            data.password = null;
            data.secretkey = null;

            var jsonData = new
            {
                baseinfo = data,
                //post = postIBLL.GetListByPostIds(data.postIds),
                //role = roleIBLL.GetListByRoleIds(data.roleIds)
            };

            return Success(jsonData);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response ModifyPassword(dynamic _)
        {
            ModifyModel modifyModel = this.GetReqData<ModifyModel>();
            #region 验证邮件验证码是否过期
            string vcode = RedisCache.Get<string>(modifyModel.email, 2);
            if (string.IsNullOrWhiteSpace(vcode) || !vcode.Equals(modifyModel.verifycode))
            {
                return Fail("验证码过期请重新获取");
            }
            #endregion
            if (userInfo.isSystem)
            {
                return Fail("当前账户不能修改密码");
            }
            else
            {
                bool res = userIBLL.ReviseVipPassword(modifyModel.newpassword, modifyModel.oldpassword);
                if (!res)
                {
                    return Fail("原密码错误，请重新输入");
                }
                else
                {
                    return Success("密码修改成功");
                }
            }
        }


        /// <summary>
        /// 获取所有员工账号列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response GetList(dynamic _)
        {
            var data = userInfo;
            data.password = null;
            data.secretkey = null;
            var jsonData = new
            {
                baseinfo = data,
                post = postIBLL.GetListByPostIds(data.postIds),
                role = roleIBLL.GetListByRoleIds(data.roleIds)
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取用户映射表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetMap(dynamic _)
        {
            string ver = this.GetReqData();// 获取模板请求数据
            var data = userIBLL.GetModelMap();
            string md5 = Md5Helper.Encrypt(data.ToJson(), 32);
            if (md5 == ver)
            {
                return Success("no update");
            }
            else
            {
                var jsondata = new
                {
                    data = data,
                    ver = md5
                };
                return Success(jsondata);
            }
        }
        /// <summary>
        /// 获取人员头像图标
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetImg(dynamic _)
        {
            string userId = this.GetReqData();// 获取模板请求数据
            userIBLL.GetImg(userId);
            return Success("获取成功");
        }
        /// <summary>
        /// 获取邮箱验证码
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Response GetVerifyCode(dynamic _)
        {
            string mail = this.GetReqData();// 获取模板请求数据
            Random rd = new Random();
            int Randoms = rd.Next(100000, 999999);//六位随机数
            MailHelper.SendByThread(mail, "内蒙古标准文献平台验证码,验证码15分钟有效!", ""+ Randoms);
            TimeSpan ts1 = new TimeSpan(0, 15, 0);
            RedisCache.Set<string>(mail,Randoms.ToString(), ts1, 2);
            return Success("获取成功");
        }
    }

    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }

    /// <summary>
    /// 注册信息
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public string verifycode { get; set; }
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    public class ModifyModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public string verifycode { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string newpassword { get; set; }
        /// <summary>
        /// 旧密码
        /// </summary>
        public string oldpassword { get; set; }
    }
}