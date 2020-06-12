using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-26 17:30
    /// 描 述：标准费用计算
    /// </summary>
    public class StandardCountMap : EntityTypeConfiguration<StandardCountEntity>
    {
        public StandardCountMap()
        {
            #region 表、主键
            //表
            this.ToTable("STANDARDCOUNT");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

