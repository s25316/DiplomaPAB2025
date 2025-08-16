using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations.Courses
{
    public class CourseLanguageEFConfiguration : IEntityTypeConfiguration<CourseLanguage>
    {
        public void Configure(EntityTypeBuilder<CourseLanguage> builder)
        {
            builder.ToTable($"{nameof(CourseLanguage)}");
            builder.HasKey(x => x.LanguageId).HasName($"{nameof(CourseLanguage)}_pk");
        }
    }
}
