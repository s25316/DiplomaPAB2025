using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.Infrastructure.RelationalDatabase.MsSql;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructureConfiguration(
            this IServiceCollection services/*,
            IConfiguration configuration*/)
        {
            //services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<DiplomaDbContext, MsSqlDiplomaDbContext>();
            return services;
        }
    }
}
