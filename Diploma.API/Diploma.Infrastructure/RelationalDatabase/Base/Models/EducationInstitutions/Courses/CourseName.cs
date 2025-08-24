using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.Courses
{
    public class CourseName
    {
        public int CourseNameId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; } = [];
        public virtual ICollection<ProjectPosition> ProjectPositions { get; set; } = [];
    }
}
