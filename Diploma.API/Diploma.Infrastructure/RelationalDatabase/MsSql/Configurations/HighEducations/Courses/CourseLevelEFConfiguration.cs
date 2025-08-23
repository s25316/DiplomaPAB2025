using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    internal class CourseLevelEFConfiguration : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder
                .ToTable($"{nameof(CourseLevel)}");
            builder
                .HasKey(x => x.LevelId)
                .HasName($"{nameof(CourseLevel)}_pk");
            builder
                .Property(x => x.LevelId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Level)
                .HasForeignKey(x => x.LevelId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseLevel)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
