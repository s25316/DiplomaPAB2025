using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class CourseLanguageEFConfiguration : IEntityTypeConfiguration<CourseLanguage>
    {
        public void Configure(EntityTypeBuilder<CourseLanguage> builder)
        {
            builder
                .ToTable($"{nameof(CourseLanguage)}");
            builder
                .HasKey(x => x.LanguageId)
                .HasName($"{nameof(CourseLanguage)}_pk");

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.LanguageId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseLanguage)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
