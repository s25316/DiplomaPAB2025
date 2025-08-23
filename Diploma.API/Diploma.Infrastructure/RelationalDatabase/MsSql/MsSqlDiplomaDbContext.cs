// ignore Spelling: Sql
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses;
using Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Companies;
using Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations;
using Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.HighEducations.Courses;
using Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.People;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql
{
    // Add-Migration First -Project Diploma.Infrastructure -Context MsSqlDiplomaDbContext
    // Update-Database -Project Diploma.Infrastructure -Context MsSqlDiplomaDbContext
    public class MsSqlDiplomaDbContext : DiplomaDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=Diploma;User ID=sa;Password=YourStrong!Passw0rd;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Division>(new DivisionEFConfiguration());
            modelBuilder.ApplyConfiguration<DivisionType>(new DivisionTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<Street>(new StreetEFConfiguration());
            modelBuilder.ApplyConfiguration<StreetType>(new StreetTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<Address>(new AddressEFConfiguration());


            modelBuilder.ApplyConfiguration<Company>(new CompanyEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyName>(new CompanyNameEFConfiguration());
            modelBuilder.ApplyConfiguration<CompanyAddress>(new CompanyAddressEFConfiguration());


            modelBuilder.ApplyConfiguration<Discipline>(new DisciplineEFConfiguration());
            modelBuilder.ApplyConfiguration<EducationInstitution>(new EducationInstitutionEFConfiguration());
            modelBuilder.ApplyConfiguration<EducationInstitutionKind>(new EducationInstitutionKindEFConfiguration());

            modelBuilder.ApplyConfiguration<Course>(new CourseEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseName>(new CourseNameEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseForm>(new CourseFormEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseLanguage>(new CourseLanguageEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseLevel>(new CourseLevelEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseProfile>(new CourseProfileEFConfiguration());
            modelBuilder.ApplyConfiguration<CourseTitle>(new CourseTitleEFConfiguration());
            modelBuilder.ApplyConfiguration<DisciplineCourse>(new DisciplineCourseEFConfiguration());
            modelBuilder.ApplyConfiguration<EducationInstitutionCourse>(new EducationInstitutionCourseEFConfiguration());

            modelBuilder.ApplyConfiguration<Person>(new PersonEFConfiguration());
            modelBuilder.ApplyConfiguration<PersonCompany>(new PersonCompanyEFConfiguration());
            modelBuilder.ApplyConfiguration<PersonCourse>(new PersonCourseEFConfiguration());
            modelBuilder.ApplyConfiguration<PersonPassword>(new PersonPasswordEFConfiguration());
            modelBuilder.ApplyConfiguration<PersonAuthenticationLog>(new PersonAuthenticationLogEFConfiguration());

            //modelBuilder.ApplyConfiguration<>(new EFConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
