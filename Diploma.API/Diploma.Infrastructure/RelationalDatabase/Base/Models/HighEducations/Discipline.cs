using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations
{
    public class Discipline
    {
        public string DisciplineId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<DisciplineCourse> Courses { get; set; } = [];
    }
}
