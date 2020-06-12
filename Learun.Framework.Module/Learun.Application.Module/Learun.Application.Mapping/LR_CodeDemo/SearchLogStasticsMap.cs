using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-02-10 19:00
    /// 描 述：搜索统计
    /// </summary>
    public class SearchLogStasticsMap : EntityTypeConfiguration<SearchLogStasticsEntity>
    {
        public SearchLogStasticsMap()
        {
            #region 表、主键
            //表
            this.ToTable("SEARCHLOGSTASTICS");
            //主键
            this.HasKey(t => t.Word);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

