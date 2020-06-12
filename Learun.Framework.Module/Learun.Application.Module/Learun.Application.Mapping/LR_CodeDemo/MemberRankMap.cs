using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-26 16:25
    /// 描 述：会员等级
    /// </summary>
    public class MemberRankMap : EntityTypeConfiguration<MemberRankEntity>
    {
        public MemberRankMap()
        {
            #region 表、主键
            //表
            this.ToTable("MEMBERRANK");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

