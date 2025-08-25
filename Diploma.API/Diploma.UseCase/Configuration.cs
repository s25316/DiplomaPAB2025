using Microsoft.Extensions.DependencyInjection;

namespace Diploma.UseCase
{
    public static class Configuration
    {
        public static IServiceCollection AddUseCaseConfiguration(this IServiceCollection services)
        {
            return services;
        }
    }
}
