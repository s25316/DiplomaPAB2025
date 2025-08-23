using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies
{
    public class CompanyAddress
    {
        public Guid CompanyAddressId { get; set; }
        public DateOnly Date { get; set; }

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
    }
}
