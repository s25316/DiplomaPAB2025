using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses
{
    public class CourseProfileEFConfiguration : IEntityTypeConfiguration<CourseProfile>
    {
        public void Configure(EntityTypeBuilder<CourseProfile> builder)
        {
            builder
                .ToTable(nameof(CourseProfile));
            builder
                .HasKey(x => x.ProfileId)
                .HasName($"{nameof(CourseProfile)}_pk");
            builder
                .Property(x => x.ProfileId)
                .ValueGeneratedNever();

            builder
                .HasMany(x => x.Courses)
                .WithOne(x => x.Profile)
                .HasForeignKey(x => x.ProfileId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseProfile)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
