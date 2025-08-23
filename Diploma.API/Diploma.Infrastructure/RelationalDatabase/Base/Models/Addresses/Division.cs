namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses
{
    public class Division
    {
        public string DivisionId { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int DivisionTypeId { get; set; }
        public virtual DivisionType DivisionType { get; set; } = null!;

        public string? ParentDivisionId { get; set; } = null;
        public virtual Division? ParentDivision { get; set; } = null;
        public virtual ICollection<Division> ChildDivisions { get; set; } = [];


        public virtual ICollection<Street> Streets { get; set; } = [];
        public virtual ICollection<Address> Addresses { get; set; } = [];
    }
}
