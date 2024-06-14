using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDDDTest.DDDEnum;

public class ProductConfig:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("T_Product");

        //将枚举转换为字符串存储
        builder.Property(e => e.Currency).HasConversion<string>().HasMaxLength(5);
    }
}