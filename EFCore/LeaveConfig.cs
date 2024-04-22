using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore;

public class LeaveConfig : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> builder)
    {
        builder.ToTable("T_Bill_Leave");
        //设置反向导航
        builder.HasOne<User>(l => l.Approver).WithMany().OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<User>(l => l.Requester).WithMany().OnDelete(DeleteBehavior.Restrict);
    }
}