using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class DivisionEFConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable(nameof(Division));
            builder.HasKey(x => x.DivisionId).HasName($"{nameof(Division)}_pk");
            builder.Property(x => x.DivisionId).ValueGeneratedNever();

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Divisions)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName($"{nameof(Country)}_{nameof(Division)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DivisionType)
                .WithMany(x => x.Divisions)
                .HasForeignKey(x => x.DivisionTypeId)
                .HasConstraintName($"{nameof(DivisionType)}_{nameof(Division)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ParentDivision)
                .WithMany(x => x.Divisions)
                .HasConstraintName($"{nameof(Division)}_{nameof(Division)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Streets)
                .WithMany(x => x.Divisions)
                .UsingEntity<Dictionary<string, object>>(
                $"{nameof(Division)}{nameof(Street)}",
                l => l.HasOne<Street>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Street.StreetId)}")
                    .HasConstraintName($"{nameof(Division)}{nameof(Street)}_{nameof(Street)}_fk")
                    .OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne<Division>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Division.DivisionId)}")
                    .HasConstraintName($"{nameof(Division)}{nameof(Street)}_{nameof(Division)}_fk")
                    .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
