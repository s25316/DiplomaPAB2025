using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class StreetTypeEFConfiguration : IEntityTypeConfiguration<StreetType>
    {
        public void Configure(EntityTypeBuilder<StreetType> builder)
        {
            builder
                .ToTable(nameof(StreetType));
            builder
                .HasKey(x => x.StreetTypeId)
                .HasName($"{nameof(StreetType)}_pk");
            builder
                .Property(x => x.StreetTypeId)
                .UseIdentityColumn();

            builder
                .HasMany(x => x.Streets)
                .WithOne(x => x.StreetType)
                .HasForeignKey(x => x.StreetTypeId)
                .HasConstraintName($"{nameof(Street)}_{nameof(StreetType)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
