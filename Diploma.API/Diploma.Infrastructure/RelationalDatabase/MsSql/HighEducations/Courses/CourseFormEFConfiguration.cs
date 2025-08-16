using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations.Courses
{
    public class CourseFormEFConfiguration : IEntityTypeConfiguration<CourseForm>
    {
        public void Configure(EntityTypeBuilder<CourseForm> builder)
        {
            builder.ToTable($"{nameof(CourseForm)}");
            builder.HasKey(x => x.FormId).HasName($"{nameof(CourseForm)}_pk");
            builder.Property(x => x.FormId).ValueGeneratedNever();
        }
    }
}
