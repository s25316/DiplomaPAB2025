using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.HighEducations.Courses
{
    public class CourseEFConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));
            builder.HasKey(x => x.CourseId).HasName($"{nameof(Course)}_pk");
            builder.Property(x => x.CourseId).HasDefaultValueSql("(newid())");

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.LanguageId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseLanguage)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Form)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.FormId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseForm)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Title)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.TitleId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseTitle)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.ProfileId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseProfile)}_fk")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Level)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.LevelId)
                .HasConstraintName($"{nameof(Course)}_{nameof(CourseLevel)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
