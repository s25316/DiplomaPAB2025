using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.People
{
    public class PersonCompanyEFConfiguration : IEntityTypeConfiguration<PersonCompany>
    {
        public void Configure(EntityTypeBuilder<PersonCompany> builder)
        {
            builder
                .ToTable(nameof(PersonCompany));
            builder
                .HasKey(x => x.PersonCompanyId)
                .HasName($"{nameof(PersonCompany)}_pk");
            builder
                .Property(x => x.PersonCompanyId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Employers)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName($"{nameof(Person)}_{nameof(PersonCompany)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName($"{nameof(Company)}_{nameof(PersonCompany)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
