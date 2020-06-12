using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-03-26 15:54
    /// 描 述：标准子类
    /// </summary>
    public class AACC_N_WMap : EntityTypeConfiguration<StandardItem>
    {
        public AACC_N_WMap()
        {
            #region 表、主键
            //表
            this.ToTable("AACC_N_W");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

