using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2020-02-11 10:42
    /// 描 述：功能搜索和添加
    /// </summary>
    public class AA_NMap : EntityTypeConfiguration<Standard>
    {
        public AA_NMap()
        {
            #region 表、主键
            //表
            this.ToTable("AA_N");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

