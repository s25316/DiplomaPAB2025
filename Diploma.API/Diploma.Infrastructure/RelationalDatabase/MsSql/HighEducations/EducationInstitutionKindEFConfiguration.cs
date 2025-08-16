using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations
{
    internal class EducationInstitutionKindEFConfiguration : IEntityTypeConfiguration<EducationInstitutionKind>
    {
        public void Configure(EntityTypeBuilder<EducationInstitutionKind> builder)
        {
            builder.ToTable(nameof(EducationInstitutionKind));
            builder.HasKey(x => x.KindId).HasName($"{nameof(EducationInstitutionKind)}_pk");
            builder.Property(x => x.KindId).ValueGeneratedNever();
        }
    }
}
