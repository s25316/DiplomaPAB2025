using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class DivisionEFConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder
                .ToTable(nameof(Division));
            builder
                .HasKey(x => x.DivisionId)
                .HasName($"{nameof(Division)}_pk");
            builder
                .Property(x => x.DivisionId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Addresses)
                .WithOne(x => x.Division)
                .HasForeignKey(x => x.DivisionId)
                .HasConstraintName($"{nameof(Address)}_{nameof(Division)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.ParentDivision)
                .WithMany(x => x.ChildDivisions)
                .HasForeignKey(x => x.ParentDivisionId)
                .HasConstraintName($"{nameof(Division)}_{nameof(Division)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Streets)
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
