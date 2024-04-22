using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore;

public class CommentConfig:IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("T_Comment");
        builder.Property(c=>c.Content).IsUnicode().HasMaxLength(1000).IsRequired();
        //一对多的关系，尽可能配置在多的一方。便于修改
        builder.HasOne<Article>(a => a.Article).WithMany(c => c.Comments).IsRequired();
    }
}