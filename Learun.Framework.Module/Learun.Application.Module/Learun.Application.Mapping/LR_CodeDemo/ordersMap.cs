using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-09 16:25
    /// 描 述：订单管理
    /// </summary>
    public class ordersMap : EntityTypeConfiguration<ordersEntity>
    {
        public ordersMap()
        {
            #region 表、主键
            //表
            this.ToTable("ORDERS");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

