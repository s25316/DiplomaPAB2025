using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Infrastructure.RelationalDatabase.Base
{
    public class DiplomaDbContext : DbContext
    {
        protected DiplomaDbContext()
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<DivisionType> DivisionTypes { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<StreetType> StreetTypes { get; set; }
    }
}
