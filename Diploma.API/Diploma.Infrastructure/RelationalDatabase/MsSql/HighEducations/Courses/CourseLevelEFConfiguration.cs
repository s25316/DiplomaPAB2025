using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations.Courses
{
    internal class CourseLevelEFConfiguration : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder.ToTable($"{nameof(CourseLevel)}");
            builder.HasKey(x => x.LevelId).HasName($"{nameof(CourseLevel)}_pk");
            builder.Property(x => x.LevelId).ValueGeneratedNever();
        }
    }
}
