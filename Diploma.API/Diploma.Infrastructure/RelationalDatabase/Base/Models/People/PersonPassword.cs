namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.People
{
    public class PersonPassword
    {
        public Guid PersonPasswordId { get; set; }
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public DateTime Date { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
    }
}
