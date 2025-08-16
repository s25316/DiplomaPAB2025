// Ignore Spelling: Regon
using Diploma.Infrastructure.RelationalDatabase.Base.Models.HighEducations;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string? CompanyShortName { get; set; }
        public string? Regon { get; set; }
        public string? Website { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public virtual EducationInstitution? EducationInstitution { get; set; } = null;
        public virtual ICollection<CompanyName> CompanyNames { get; set; } = new List<CompanyName>();
        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();
    }
}
