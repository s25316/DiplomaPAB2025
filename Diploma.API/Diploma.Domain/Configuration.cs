using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Diploma.Domain
{
    public static class Configuration
    {
        public static IServiceCollection AddDomainConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(configuration => Assembly.GetExecutingAssembly());
            //services.AddMediatR(configuration => Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
