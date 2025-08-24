using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.Infrastructure.RelationalDatabase.MsSql;
using Diploma.Infrastructure.RelationalDatabase.Repositories;
using Diploma.Infrastructure.RelationalDatabase.Repositories.AutoMapperProfiles;
using Diploma.UseCase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegonPlugin;

namespace Diploma.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var regonKey = configuration["RegonKey"]
                ?? throw new ArgumentException("RegonKey");

            services.AddSingleton(opt => new RegonService(regonKey));

            services.AddDbContext<DiplomaDbContext, MsSqlDiplomaDbContext>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();


            services.AddAutoMapper(x => x.AddProfiles([
                new AddressProfile(),
                new CompanyProfile(),
                ]));
            return services;
        }
    }
}
