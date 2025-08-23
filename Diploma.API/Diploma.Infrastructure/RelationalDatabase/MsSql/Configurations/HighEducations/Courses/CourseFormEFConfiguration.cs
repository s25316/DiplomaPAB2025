using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class CourseFormEFConfiguration : IEntityTypeConfiguration<CourseForm>
    {
        public void Configure(EntityTypeBuilder<CourseForm> builder)
        {
            builder
                .ToTable(nameof(CourseForm));
            builder
                .HasKey(x => x.FormId)
                .HasName($"{nameof(CourseForm)}_pk");
            builder
                .Property(x => x.FormId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Form)
                .HasForeignKey(x => x.FormId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseForm)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
