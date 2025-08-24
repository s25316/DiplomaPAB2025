using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.People
{
    public class PersonEFConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable(nameof(Person));
            builder
                .HasKey(x => x.PersonId)
                .HasName($"{nameof(Person)}_pk");
            builder
                .Property(x => x.PersonId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasAlternateKey(x => x.Email)
                .HasName($"{nameof(Person)}_{nameof(Person.Email)}_UNIQUE");

            builder
                .HasMany(x => x.Projects)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .HasConstraintName($"{nameof(Person)}_{nameof(Project)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
