namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses
{
    public class DivisionType
    {
        public int DivisionTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
    }
}
