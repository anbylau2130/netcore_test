using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore;

public class StudentConfig:IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("T_Student");
        builder.HasMany<Teacher>(x => x.Teachers)
            .WithMany(x => x.Students)
            .UsingEntity(x => x.ToTable("T_Student_Teacher_Relationship"));

    }
}