using AutoMapper;
using DatabaseCompany = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.Company;
using DatabaseCompanyAddress = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyAddress;
using DatabaseCompanyName = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyName;
using UseCaseCompany = Diploma.UseCase.Models.Companies.Company;
using UseCaseCompanyAddress = Diploma.UseCase.Models.Companies.CompanyAddress;
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

            CreateMap<DatabaseCompanyAddress, UseCaseCompanyAddress>()
                .ConstructUsing(db => new UseCaseCompanyAddress
                {
                    AddressId = db.AddressId,
                    Date = db.Date,
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseCompany, UseCaseCompany>()
                .ConstructUsing((db, context) => new UseCaseCompany
                {
                    CompanyId = db.CompanyId,
                    CompanyShortName = db.CompanyShortName,
                    Regon = db.Regon,
                    Website = db.Website,
                    PhoneNumber = db.PhoneNumber,
                    Email = db.Email,
                    StartDate = db.StartDate,
                    EndDate = db.EndDate,
                    Addresses = context.Mapper
                        .Map<ICollection<UseCaseCompanyAddress>>(db.CompanyAddresses)
                        .OrderBy(x => x.Date)
                        .ToList(),
                    Names = context.Mapper
                        .Map<ICollection<UseCaseCompanyName>>(db.CompanyNames)
                        .OrderBy(x => x.Date)
                        .ToList(),
                })
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}
