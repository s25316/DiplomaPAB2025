using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Companies
{
    internal class CompanyEFConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));
            builder.HasKey(x => x.CompanyId).HasName($"{nameof(Company)}_pk");
            builder.Property(x => x.CompanyId).HasDefaultValueSql("(newid())");


        }
    }
}
