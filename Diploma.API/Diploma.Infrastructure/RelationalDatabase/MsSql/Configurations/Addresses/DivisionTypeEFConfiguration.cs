using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class DivisionTypeEFConfiguration : IEntityTypeConfiguration<DivisionType>
    {
        public void Configure(EntityTypeBuilder<DivisionType> builder)
        {
            builder
                .ToTable(nameof(DivisionType));
            builder
                .HasKey(x => x.DivisionTypeId)
                .HasName($"{nameof(DivisionType)}_pk");
            builder
                .Property(x => x.DivisionTypeId)
                .UseIdentityColumn();

            builder
                .HasMany(x => x.Divisions)
                .WithOne(x => x.DivisionType)
                .HasForeignKey(x => x.DivisionTypeId)
                .HasConstraintName($"{nameof(Division)}_{nameof(DivisionType)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
