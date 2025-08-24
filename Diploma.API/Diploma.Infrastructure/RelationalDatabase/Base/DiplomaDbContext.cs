using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.People;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Infrastructure.RelationalDatabase.Base
{
    public class DiplomaDbContext : DbContext
    {
        protected DiplomaDbContext()
        {
        }

        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<DivisionType> DivisionTypes { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<StreetType> StreetTypes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }


        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyName> CompanyNames { get; set; }
        public virtual DbSet<CompanyAddress> CompanyAddresses { get; set; }


        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<EducationInstitution> EducationInstitutions { get; set; }
        public virtual DbSet<EducationInstitutionKind> EducationInstitutionKinds { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseName> CourseNames { get; set; }
        public virtual DbSet<CourseForm> CourseForms { get; set; }
        public virtual DbSet<CourseLanguage> CourseLanguages { get; set; }
        public virtual DbSet<CourseLevel> CourseLevels { get; set; }
        public virtual DbSet<CourseProfile> CourseProfiles { get; set; }
        public virtual DbSet<CourseTitle> CourseTitles { get; set; }
        public virtual DbSet<DisciplineCourse> DisciplineCourses { get; set; }
        public virtual DbSet<EducationInstitutionCourse> EducationInstitutionCourses { get; set; }


        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonCompany> PersonCompanies { get; set; }
        public virtual DbSet<PersonCourse> PersonCourses { get; set; }
        public virtual DbSet<PersonPassword> PersonPasswords { get; set; }
        public virtual DbSet<PersonAuthenticationLog> PersonAuthentications { get; set; }


        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectPosition> ProjectPositions { get; set; }
    }
}
