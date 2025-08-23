using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.People
{
    internal class PersonPasswordEFConfiguration : IEntityTypeConfiguration<PersonPassword>
    {
        public void Configure(EntityTypeBuilder<PersonPassword> builder)
        {
            builder
                .ToTable(nameof(PersonPassword));
            builder
                .HasKey(x => x.PersonPasswordId)
                .HasName($"{nameof(PersonPassword)}_pk");
            builder
                .Property(x => x.PersonPasswordId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Passwords)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName($"{nameof(Person)}_{nameof(PersonPassword)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
