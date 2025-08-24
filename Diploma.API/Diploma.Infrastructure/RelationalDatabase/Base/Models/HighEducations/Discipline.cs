using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Projects;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations
{
    public class Discipline
    {
        public string DisciplineId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<DisciplineCourse> Courses { get; set; } = [];
        public virtual ICollection<ProjectPosition> ProjectPositions { get; set; } = [];
    }
}
