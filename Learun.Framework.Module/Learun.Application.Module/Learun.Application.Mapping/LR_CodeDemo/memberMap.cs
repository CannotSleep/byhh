﻿using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-03-03 14:36
    /// 描 述：会员管理
    /// </summary>
    public class memberMap : EntityTypeConfiguration<memberEntity>
    {
        public memberMap()
        {
            #region 表、主键
            //表
            this.ToTable("MEMBER");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

