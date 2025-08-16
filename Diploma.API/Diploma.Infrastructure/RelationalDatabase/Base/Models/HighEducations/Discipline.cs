using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations
{
    public class Discipline
    {
        public string DisciplineId { get; set; } = null!;
        public string NamePl { get; set; } = null!;
        public string NameEn { get; set; } = null!;

        public virtual ICollection<DisciplineCourse> Courses { get; set; } = new List<DisciplineCourse>();
    }
}
