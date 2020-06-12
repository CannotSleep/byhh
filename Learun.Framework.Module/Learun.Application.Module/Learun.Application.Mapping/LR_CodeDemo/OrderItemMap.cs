using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-15 11:32
    /// 描 述：订单子项
    /// </summary>
    public class OrderItemMap : EntityTypeConfiguration<OrderItemEntity>
    {
        public OrderItemMap()
        {
            #region 表、主键
            //表
            this.ToTable("ORDERITEM");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

