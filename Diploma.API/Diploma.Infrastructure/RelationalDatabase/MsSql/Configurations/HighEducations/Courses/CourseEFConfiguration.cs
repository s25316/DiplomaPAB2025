using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class CourseEFConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .ToTable(nameof(Course));
            builder
                .HasKey(x => x.CourseId)
                .HasName($"{nameof(Course)}_pk");
            builder
                .Property(x => x.CourseId)
                .HasDefaultValueSql("(newid())");
        }
    }
}
