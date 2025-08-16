using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations
{
    public class EducationInstitutionEFConfiguration : IEntityTypeConfiguration<EducationInstitution>
    {
        public void Configure(EntityTypeBuilder<EducationInstitution> builder)
        {
            builder.ToTable(nameof(EducationInstitution));
            builder.HasKey(x => x.InstitutionId).HasName($"{nameof(EducationInstitution)}_pk");

            builder.HasOne(x => x.Company)
                .WithOne(x => x.EducationInstitution)
                .HasForeignKey<EducationInstitution>(x => x.InstitutionId)
                .HasConstraintName($"{nameof(Company)}_{nameof(EducationInstitution)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Kind)
                .WithMany(x => x.Institutions)
                .HasForeignKey(x => x.KindId)
                .HasConstraintName($"{nameof(EducationInstitution)}_{nameof(EducationInstitutionKind)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
