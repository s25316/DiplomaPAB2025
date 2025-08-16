namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses
{
    public class Street
    {
        public string StreetId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int? StreetTypeId { get; set; }
        public virtual StreetType? StreetType { get; set; }

        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
    }
}
