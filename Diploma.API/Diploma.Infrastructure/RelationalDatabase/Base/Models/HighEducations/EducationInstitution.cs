using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations.Courses;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations
{
    public class EducationInstitution
    {
        public Guid InstitutionId { get; set; }

        public int KindId { get; set; }
        public virtual EducationInstitutionKind Kind { get; set; } = null!;

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<EducationInstitutionCourse> Courses { get; set; } = [];
    }
}
