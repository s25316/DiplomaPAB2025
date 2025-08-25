using Diploma.Infrastructure.RelationalDatabase.AutoMapperProfiles;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.Infrastructure.RelationalDatabase.MsSql;
using Diploma.Infrastructure.RelationalDatabase.Repositories;
using Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Interfaces.Repositories;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
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

            services.AddAutoMapper(x => x.AddProfiles([
                new AddressProfile(),
                new CompanyProfile(),
                new EducationInstitutionProfile(),
                new DictionariesProfile(),
                ]));

            services.AddSingleton(opt => new RegonService(regonKey));
            services.AddDbContext<DiplomaDbContext, MsSqlDiplomaDbContext>();

            // Dictionaries
            services.AddTransient<ICourseFormRepository, CourseFormRepository>();
            services.AddTransient<ICourseLanguageRepository, CourseLanguageRepository>();
            services.AddTransient<ICourseLevelRepository, CourseLevelRepository>();
            services.AddTransient<ICourseProfileRepository, CourseProfileRepository>();
            services.AddTransient<ICourseTitleRepository, CourseTitleRepository>();
            services.AddTransient<IDisciplineRepository, DisciplineRepository>();
            services.AddTransient<IEducationInstitutionKindRepository, EducationInstitutionKindRepository>();

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IEducationInstitutionRepository, EducationInstitutionRepository>();


            return services;
        }
    }
}
