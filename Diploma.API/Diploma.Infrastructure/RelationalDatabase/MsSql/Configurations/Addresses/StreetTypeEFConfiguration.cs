using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses
{
    public class StreetTypeEFConfiguration : IEntityTypeConfiguration<StreetType>
    {
        public void Configure(EntityTypeBuilder<StreetType> builder)
        {
            builder.ToTable(nameof(StreetType));
            builder.HasKey(x => x.StreetTypeId).HasName($"{nameof(StreetType)}_pk");
            builder.Property(x => x.StreetTypeId).UseIdentityColumn();
        }
    }
}
