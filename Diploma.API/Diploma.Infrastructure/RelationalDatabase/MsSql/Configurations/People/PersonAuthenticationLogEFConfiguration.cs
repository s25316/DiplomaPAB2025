using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.People
{
    public class PersonAuthenticationLogEFConfiguration : IEntityTypeConfiguration<PersonAuthenticationLog>
    {
        public void Configure(EntityTypeBuilder<PersonAuthenticationLog> builder)
        {
            builder
                .ToTable(nameof(PersonAuthenticationLog));
            builder
                .HasKey(x => x.LogId)
                .HasName($"{nameof(PersonAuthenticationLog)}_pk");
            builder
                .Property(x => x.LogId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Authentications)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName($"{nameof(Person)}_{nameof(PersonAuthenticationLog)}_fk")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
