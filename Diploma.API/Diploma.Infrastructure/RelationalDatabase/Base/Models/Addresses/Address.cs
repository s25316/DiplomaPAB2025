namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public string? FlatNumber { get; set; } = null!;


        public int DivisionId { get; set; }
        public virtual Division Division { get; set; } = null!;

        public int? StreetId { get; set; }
        public virtual Street? Street { get; set; }
    }
}
