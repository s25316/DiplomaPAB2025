namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations
{
    public class EducationInstitutionKind
    {
        public int KindId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<EducationInstitution> Institutions { get; set; } = [];
    }
}
