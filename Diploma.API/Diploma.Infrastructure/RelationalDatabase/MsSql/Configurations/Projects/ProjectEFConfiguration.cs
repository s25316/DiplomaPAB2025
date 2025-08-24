using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Projects
{
    public class ProjectEFConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .ToTable(nameof(Project));
            builder
                .HasKey(x => x.ProjectId)
                .HasName($"{nameof(Project)}_pk");
            builder
                .Property(x => x.ProjectId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasMany(x => x.Positions)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId)
                .HasConstraintName($"{nameof(Project)}_{nameof(ProjectPosition)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
