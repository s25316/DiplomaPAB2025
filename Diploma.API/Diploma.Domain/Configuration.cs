using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Diploma.Domain
{
    public static class Configuration
    {
        public static IServiceCollection AddDomainConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(
                Assembly.GetExecutingAssembly()
                ));


            return services;
        }
    }
}
