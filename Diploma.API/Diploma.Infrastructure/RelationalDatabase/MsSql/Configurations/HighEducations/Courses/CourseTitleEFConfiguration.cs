using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class CourseTitleEFConfiguration : IEntityTypeConfiguration<CourseTitle>
    {
        public void Configure(EntityTypeBuilder<CourseTitle> builder)
        {
            builder
                .ToTable(nameof(CourseTitle));
            builder
                .HasKey(x => x.TitleId)
                .HasName($"{nameof(CourseTitle)}_pk");
            builder
                .Property(x => x.TitleId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Title)
                .HasForeignKey(x => x.TitleId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseTitle)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
