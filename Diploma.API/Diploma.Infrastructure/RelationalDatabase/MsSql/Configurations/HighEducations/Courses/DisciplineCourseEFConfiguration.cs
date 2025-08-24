using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class DisciplineCourseEFConfiguration : IEntityTypeConfiguration<DisciplineCourse>
    {
        public void Configure(EntityTypeBuilder<DisciplineCourse> builder)
        {
            builder
                .ToTable(nameof(DisciplineCourse));
            builder
                .HasKey(x => x.DisciplineCourseId)
                .HasName($"{nameof(DisciplineCourse)}_pk");
            builder
                .Property(x => x.DisciplineCourseId)
                .HasDefaultValueSql("(newid())");
            builder
                .Property(x => x.IsMain)
                .HasDefaultValue(false);

            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.Disciplines)
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName($"{nameof(DisciplineCourse)}_{nameof(Course)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Discipline)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.DisciplineId)
                .HasConstraintName($"{nameof(DisciplineCourse)}_{nameof(Discipline)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
