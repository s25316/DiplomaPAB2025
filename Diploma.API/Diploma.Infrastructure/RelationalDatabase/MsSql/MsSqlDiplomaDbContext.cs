// ignore Spelling: Sql
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses;
using Diploma.Infrastructure.RelationalDatabase.MsSql.Configurations.Addresses;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Infrastructure.RelationalDatabase.MsSql
{
    // Add-Migration First -Project Diploma.Infrastructure -Context MsSqlDiplomaDbContext
    // Update-Database -Project Diploma.Infrastructure -Context MsSqlDiplomaDbContext
    public class MsSqlDiplomaDbContext : DiplomaDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=Diploma;User ID=sa;Password=YourStrong!Passw0rd;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Country>(new CountryEFConfiguration());
            modelBuilder.ApplyConfiguration<Division>(new DivisionEFConfiguration());
            modelBuilder.ApplyConfiguration<DivisionType>(new DivisionTypeEFConfiguration());
            modelBuilder.ApplyConfiguration<Street>(new StreetEFConfiguration());
            modelBuilder.ApplyConfiguration<StreetType>(new StreetTypeEFConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
