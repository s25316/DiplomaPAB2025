using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class CourseNameEFConfiguration : IEntityTypeConfiguration<CourseName>
    {
        public void Configure(EntityTypeBuilder<CourseName> builder)
        {
            builder
                .ToTable(nameof(CourseName));
            builder
                .HasKey(x => x.CourseNameId)
                .HasName($"{nameof(CourseName)}_pk");
            builder
                .Property(x => x.CourseNameId)
                .UseIdentityColumn();

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Name)
                .HasForeignKey(x => x.CourseNameId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseName)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
