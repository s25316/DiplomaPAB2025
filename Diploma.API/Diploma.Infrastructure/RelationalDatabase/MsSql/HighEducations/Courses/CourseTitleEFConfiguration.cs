using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations.Courses
{
    public class CourseTitleEFConfiguration : IEntityTypeConfiguration<CourseTitle>
    {
        public void Configure(EntityTypeBuilder<CourseTitle> builder)
        {
            builder.ToTable($"{nameof(CourseTitle)}");
            builder.HasKey(x => x.TitleId).HasName($"{nameof(CourseTitle)}_pk");
            builder.Property(x => x.TitleId).ValueGeneratedNever();
        }
    }
}
