using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Companies
{
    public class CompanyNameEFConfiguration : IEntityTypeConfiguration<CompanyName>
    {
        public void Configure(EntityTypeBuilder<CompanyName> builder)
        {
            builder.ToTable(nameof(CompanyName));
            builder.HasKey(x => x.CompanyNameId).HasName($"{nameof(CompanyName)}_pk");
            builder.Property(x => x.CompanyNameId).HasDefaultValueSql("(newid())");

            builder.HasOne(x => x.Company)
                .WithMany(x => x.CompanyNames)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(CompanyName)}_{nameof(Company)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
