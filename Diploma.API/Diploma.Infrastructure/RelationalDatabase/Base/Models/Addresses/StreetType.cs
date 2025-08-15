namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses
{
    public class StreetType
    {
        public int StreetTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}
