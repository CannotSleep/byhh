using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-06-08 09:22
    /// 描 述：充值记录
    /// </summary>
    public class RechargeRecordMap : EntityTypeConfiguration<RechargeRecordEntity>
    {
        public RechargeRecordMap()
        {
            #region 表、主键
            //表
            this.ToTable("RECHARGERECORD");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

