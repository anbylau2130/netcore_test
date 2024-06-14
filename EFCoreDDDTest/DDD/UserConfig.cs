using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDDDTest.DDD;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("T_User");
        builder.Property("passwordHash");
        builder.Property(e => e.Remark).HasField("remark");
        builder.Ignore("Tag");
    }
}