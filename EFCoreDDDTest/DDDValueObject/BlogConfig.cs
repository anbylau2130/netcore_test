using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDDDTest.DDDValueObject;

public class BlogConfig:IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("T_Blog");
        builder.OwnsOne(e => e.Title, x =>
        {
            x.Property(t => t.English).HasMaxLength(50).HasColumnType("varchar").IsUnicode();
            x.Property(t => t.Chinese).HasMaxLength(255).IsUnicode();
        });
        builder.OwnsOne(e => e.Body, x =>
        {
            x.Property(t => t.English).HasMaxLength(50).HasColumnType("varchar").IsUnicode();
            x.Property(t => t.Chinese).HasMaxLength(255).IsUnicode();
        });
    }
}