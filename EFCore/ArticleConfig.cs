using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("T_Article");

        //builder.HasMany<Comment>(a=>a.Comments).WithOne(c => c.Article).IsRequired();
    }
}