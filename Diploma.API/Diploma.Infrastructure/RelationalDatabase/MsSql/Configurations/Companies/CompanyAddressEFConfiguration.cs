using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Companies
{
    public class CompanyAddressEFConfiguration : IEntityTypeConfiguration<CompanyAddress>
    {
        public void Configure(EntityTypeBuilder<CompanyAddress> builder)
        {
            builder
                .ToTable(nameof(CompanyAddress));
            builder
                .HasKey(x => x.CompanyAddressId)
                .HasName($"{nameof(CompanyAddress)}_pk");
            builder
                .Property(x => x.CompanyAddressId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasOne(x => x.Address)
                .WithMany(x => x.CompanyAddresses)
                .HasForeignKey(x => x.AddressId)
                .HasConstraintName($"{nameof(CompanyAddress)}_{nameof(Address)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyAddresses)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(CompanyAddress)}_{nameof(Company)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
