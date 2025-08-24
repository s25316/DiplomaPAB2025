using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class EducationInstitutionCourseEFConfiguration : IEntityTypeConfiguration<EducationInstitutionCourse>
    {
        public void Configure(EntityTypeBuilder<EducationInstitutionCourse> builder)
        {
            builder
                .ToTable(nameof(EducationInstitutionCourse));
            builder
                .HasKey(x => x.InstitutionCourseId)
                .HasName($"{nameof(EducationInstitutionCourse)}_pk");
            builder
                .Property(x => x.InstitutionCourseId)
                .HasDefaultValueSql("(newid())");
            builder
                .Property(x => x.IsMainInstitution)
                .HasDefaultValue(false);

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.Institutions)
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName($"{nameof(EducationInstitutionCourse)}_{nameof(Course)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Institution)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.InstitutionId)
                .HasConstraintName($"{nameof(EducationInstitutionCourse)}_{nameof(EducationInstitution)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
