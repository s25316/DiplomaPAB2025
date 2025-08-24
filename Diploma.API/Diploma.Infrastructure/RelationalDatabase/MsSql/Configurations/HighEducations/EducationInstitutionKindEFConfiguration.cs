using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations
{
    internal class EducationInstitutionKindEFConfiguration : IEntityTypeConfiguration<EducationInstitutionKind>
    {
        public void Configure(EntityTypeBuilder<EducationInstitutionKind> builder)
        {
            builder
                .ToTable(nameof(EducationInstitutionKind));
            builder
                .HasKey(x => x.KindId)
                .HasName($"{nameof(EducationInstitutionKind)}_pk");
            builder
                .Property(x => x.KindId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Institutions)
                .WithOne(x => x.Kind)
                .HasForeignKey(x => x.KindId)
                .HasConstraintName($"{nameof(EducationInstitution)}_{nameof(EducationInstitutionKind)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
