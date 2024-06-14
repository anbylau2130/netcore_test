using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDDDTest.DDDValueObject;

public class ShopConfig:IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder.ToTable("T_Shop");

        //对于复杂类型的存储
        //EFCore中会存储为：对象名_属性名
        builder.OwnsOne(x => x.Location);
    }
}