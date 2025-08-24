namespace Diploma.Infrastructure.RelationalDatabase.Base.Models.People
{
    public class PersonAuthenticationLog
    {
        public Guid LogId { get; set; }
        public string Jwt { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public DateOnly? RefreshTokenValidTo { get; set; }

        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
    }
}
