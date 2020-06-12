using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-20 10:39
    /// 描 述：合作机构
    /// </summary>
    public class MechanismMap : EntityTypeConfiguration<MechanismEntity>
    {
        public MechanismMap()
        {
            #region 表、主键
            //表
            this.ToTable("COMPANY");
            //主键
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

