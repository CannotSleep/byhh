﻿using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-02-10 18:57
    /// 描 述：搜索记录
    /// </summary>
    public class SearchLogsMap : EntityTypeConfiguration<SearchLogsEntity>
    {
        public SearchLogsMap()
        {
            #region 表、主键
            //表
            this.ToTable("SEARCHLOGS");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

