using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.People
{
    public class PersonCompany
    {
        public Guid PersonCompanyId { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly? DateTo { get; set; }
        public string Position { get; set; } = null!;

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
    }
}
