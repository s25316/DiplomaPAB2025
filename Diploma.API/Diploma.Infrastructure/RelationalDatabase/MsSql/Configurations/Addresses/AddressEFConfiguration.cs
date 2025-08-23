using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class AddressEFConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable(nameof(Address));
            builder
                .HasKey(x => x.AddressId)
                .HasName($"{nameof(Address)}_pk");
            builder
                .Property(x => x.AddressId)
                .HasDefaultValueSql("(newid())");
        }
    }
}
