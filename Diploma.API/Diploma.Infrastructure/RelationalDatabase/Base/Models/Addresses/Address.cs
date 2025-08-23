using Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies;

namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public string? FlatNumber { get; set; } = null!;


        public string DivisionId { get; set; } = null!;
        public virtual Division Division { get; set; } = null!;

        public string? StreetId { get; set; } = null!;
        public virtual Street? Street { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = [];
    }
}
