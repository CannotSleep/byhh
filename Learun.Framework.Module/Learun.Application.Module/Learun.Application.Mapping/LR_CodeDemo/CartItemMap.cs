using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-16 09:18
    /// 描 述：购物车
    /// </summary>
    public class CartItemMap : EntityTypeConfiguration<CartItemEntity>
    {
        public CartItemMap()
        {
            #region 表、主键
            //表
            this.ToTable("CARTITEM");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

