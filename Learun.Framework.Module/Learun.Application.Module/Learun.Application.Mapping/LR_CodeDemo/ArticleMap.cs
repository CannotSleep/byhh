using Learun.Application.TwoDevelopment.LR_CodeDemo;
using System.Data.Entity.ModelConfiguration;

namespace  Learun.Application.Mapping
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-04-13 16:52
    /// 描 述：文章信息
    /// </summary>
    public class ArticleMap : EntityTypeConfiguration<ArticleEntity>
    {
        public ArticleMap()
        {
            #region 表、主键
            //表
            this.ToTable("ARTICLE");
            //主键
            this.HasKey(t => t.id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}

