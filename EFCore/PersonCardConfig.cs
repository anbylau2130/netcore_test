using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore;

public class PersonCardConfig:IEntityTypeConfiguration<PersonCard>

{
    public void Configure(EntityTypeBuilder<PersonCard> builder)
    {
        builder.ToTable("T_PersonCard");
        builder.HasOne<Person>(x => x.Person)
            .WithOne(x => x.PersonCard)
            .HasForeignKey<PersonCard>(x=>x.PersonId)
            .IsRequired(false);

    }
}