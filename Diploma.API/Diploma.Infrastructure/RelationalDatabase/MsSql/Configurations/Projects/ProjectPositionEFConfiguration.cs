using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Projects
{
    public class ProjectPositionEFConfiguration : IEntityTypeConfiguration<ProjectPosition>
    {
        public void Configure(EntityTypeBuilder<ProjectPosition> builder)
        {
            builder
                .ToTable(nameof(ProjectPosition));
            builder
                .HasKey(x => x.ProjectPositionId)
                .HasName($"{nameof(ProjectPosition)}_pk");
            builder
                .Property(x => x.ProjectPositionId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasMany(x => x.Disciplines)
                .WithMany(x => x.ProjectPositions)
                .UsingEntity<Dictionary<string, object>>(
                $"{nameof(ProjectPosition)}{nameof(Discipline)}",
                l => l.HasOne<Discipline>()
                    .WithMany()
                    .HasForeignKey($"{nameof(Discipline.DisciplineId)}")
                    .HasConstraintName($"{nameof(ProjectPosition)}{nameof(Discipline)}_{nameof(Discipline)}_fk")
                    .OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne<ProjectPosition>()
                    .WithMany()
                    .HasForeignKey($"{nameof(ProjectPosition.ProjectPositionId)}")
                    .HasConstraintName($"{nameof(ProjectPosition)}{nameof(Discipline)}_{nameof(ProjectPosition)}_fk")
                    .OnDelete(DeleteBehavior.Cascade)
                );

            builder
                .HasMany(x => x.CourseNames)
                .WithMany(x => x.ProjectPositions)
                .UsingEntity<Dictionary<string, object>>(
                $"{nameof(ProjectPosition)}{nameof(CourseName)}",
                l => l.HasOne<CourseName>()
                    .WithMany()
                    .HasForeignKey($"{nameof(CourseName.CourseNameId)}")
                    .HasConstraintName($"{nameof(ProjectPosition)}{nameof(CourseName)}_{nameof(CourseName)}_fk")
                    .OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne<ProjectPosition>()
                    .WithMany()
                    .HasForeignKey($"{nameof(ProjectPosition.ProjectPositionId)}")
                    .HasConstraintName($"{nameof(ProjectPosition)}{nameof(CourseName)}_{nameof(ProjectPosition)}_fk")
                    .OnDelete(DeleteBehavior.Cascade)
                );

            builder
                .HasMany(x => x.EducationInstitutions)
                .WithMany(x => x.ProjectPositions)
                .UsingEntity<Dictionary<string, object>>(
                $"{nameof(ProjectPosition)}{nameof(EducationInstitution)}",
                l => l.HasOne<EducationInstitution>()
                    .WithMany()
                    .HasForeignKey($"{nameof(EducationInstitution.InstitutionId)}")
                    .HasConstraintName($"{nameof(ProjectPosition)}{nameof(EducationInstitution)}_{nameof(EducationInstitution)}_fk")
                    .OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne<ProjectPosition>()
                    .WithMany()
                    .HasForeignKey($"{nameof(ProjectPosition.ProjectPositionId)}")
                    .HasConstraintName($"{nameof(ProjectPosition)}{nameof(EducationInstitution)}_{nameof(ProjectPosition)}_fk")
                    .OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
