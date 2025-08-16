namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies
{
    public class CompanyName
    {
        public Guid CompanyNameId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
    }
}
