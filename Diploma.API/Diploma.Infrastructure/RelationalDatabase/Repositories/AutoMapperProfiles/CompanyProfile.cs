using AutoMapper;
using DatabaseCompanyName = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyName;
using UseCaseCompanyName = Diploma.UseCase.Models.Companies.CompanyName;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.AutoMapperProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<DatabaseCompanyName, UseCaseCompanyName>()
                .ConstructUsing(db => new UseCaseCompanyName
                {
                    Name = db.Name,
                    Date = db.Date,
                })
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}
