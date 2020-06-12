using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-01-16 11:46
    /// 描 述：题录分类管理
    /// </summary>
    public class organizationCategoryMap : EntityTypeConfiguration<organizationCategoryEntity>
    {
        public organizationCategoryMap()
        {
            #region 表、主键
            //表
            this.ToTable("ORGANIZATIONCATEGORY");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

