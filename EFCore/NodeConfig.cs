using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore;

public class NodeConfig : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        builder.ToTable("T_Node");
        #region 全局查询过滤器
        //全局查询过滤器，每次查询都会携带的过滤条件
        builder.HasQueryFilter(x => x.IsDeleted == true);
        //忽略全局过滤器的写法：ctx.Entity.IgnoreQueryFilters().Where(x=>x.Id>1);
        #endregion

        #region 并发令牌--适用于单个列

        //并发令牌字段，每次查询都会携带原值
        //builder.Property(h=>h.Name).IsConcurrencyToken();
        /*
         通过
        try{
                ctx.SaveChanges();
        }
        catch(DbUpdateConcurrencyException ex){
           var entry=ex.Entries.First();
           string newValue=entry.GetDatabaseValues().GetValue<string>("Name");
        }
         
         */
        #endregion


        #region 行版本配置并发
        builder.Property(h => h.RowVersion).IsRowVersion();
        #endregion

        builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(255);
        builder.HasOne(item => item.Parent)
            .WithMany(item => item.Children)
            .HasForeignKey(x => x.ParentId).IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

    }
}