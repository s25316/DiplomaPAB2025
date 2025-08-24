using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects
{
    public class ProjectPosition
    {
        public Guid ProjectPositionId { get; set; }
        public string Name { get; set; } = null!;

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public virtual ICollection<Discipline> Disciplines { get; set; } = [];
        public virtual ICollection<CourseName> CourseNames { get; set; } = [];
        public virtual ICollection<EducationInstitution> EducationInstitutions { get; set; } = [];
    }
}
