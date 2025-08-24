using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.People
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? HandName { get; set; }
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Description { get; set; } = null!;

        public virtual ICollection<PersonCompany> Employers { get; set; } = [];
        public virtual ICollection<PersonCourse> Courses { get; set; } = [];
        public virtual ICollection<PersonPassword> Passwords { get; set; } = [];
        public virtual ICollection<PersonAuthenticationLog> Authentications { get; set; } = [];
        public virtual ICollection<Project> Projects { get; set; } = [];
    }
}