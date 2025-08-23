using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class StreetEFConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder
                .ToTable(nameof(Street));
            builder
                .HasKey(x => x.StreetId)
                .HasName($"{nameof(Street)}_pk");
            builder
                .Property(x => x.StreetId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Addresses)
                .WithOne(x => x.Street)
                .HasForeignKey(x => x.StreetId)
                .HasConstraintName($"{nameof(Address)}_{nameof(Street)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
