using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class StreetEFConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.ToTable(nameof(Street));
            builder.HasKey(x => x.StreetId).HasName($"{nameof(Street)}_pk");
            builder.Property(x => x.StreetId).ValueGeneratedNever();

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Streets)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName($"{nameof(Country)}_{nameof(Street)}_fk")
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.StreetType)
                .WithMany(x => x.Streets)
                .HasForeignKey(x => x.StreetTypeId)
                .HasConstraintName($"{nameof(StreetType)}_{nameof(Street)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
