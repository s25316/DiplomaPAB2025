using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.People
{
    public class PersonCourseEFConfiguration : IEntityTypeConfiguration<PersonCourse>
    {
        public void Configure(EntityTypeBuilder<PersonCourse> builder)
        {
            builder
                .ToTable(nameof(PersonCourse));
            builder
                .HasKey(x => x.PersonCourseId)
                .HasName($"{nameof(PersonCourse)}_pk");
            builder
                .Property(x => x.PersonCourseId)
                .HasDefaultValueSql("(newid())");

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.PersonId)
                .HasConstraintName($"{nameof(Person)}_{nameof(PersonCourse)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Course)
                .WithMany(x => x.People)
                .HasForeignKey(x => x.CourseId)
                .HasConstraintName($"{nameof(Company)}_{nameof(PersonCourse)}_fk")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
