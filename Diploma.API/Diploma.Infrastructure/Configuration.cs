using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.Infrastructure.RelationalDatabase.MsSql;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddDbContext<DiplomaDbContext, MsSqlDiplomaDbContext>();
            return services;
        }
    }
}
