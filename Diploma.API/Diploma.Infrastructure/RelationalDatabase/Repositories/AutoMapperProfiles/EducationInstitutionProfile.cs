using DatabaseEducationInstitution = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.EducationInstitution;
using UseCaseCompanyAddress = Diploma.UseCase.Models.Companies.CompanyAddress;
using UseCaseCompanyName = Diploma.UseCase.Models.Companies.CompanyName;
using UseCaseEducationInstitution = Diploma.UseCase.Models.EductionInstitutions.EducationInstitution;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.AutoMapperProfiles
{
    public class EducationInstitutionProfile : AddressProfile
    {
        public EducationInstitutionProfile()
        {
            CreateMap<DatabaseEducationInstitution, UseCaseEducationInstitution>()
                .ConstructUsing((db, context) => new UseCaseEducationInstitution
                {
                    CompanyId = db.Company.CompanyId,
                    CompanyShortName = db.Company.CompanyShortName,
                    Regon = db.Company.Regon,
                    Website = db.Company.Website,
                    PhoneNumber = db.Company.PhoneNumber,
                    Email = db.Company.Email,
                    StartDate = db.Company.StartDate,
                    EndDate = db.Company.EndDate,
                    Kind = new UseCase.Models.PairIdName<int>
                    {
                        Id = db.Kind.KindId,
                        Name = db.Kind.Name,
                    },
                    Addresses = context.Mapper
                        .Map<ICollection<UseCaseCompanyAddress>>(db.Company.CompanyAddresses)
                        .OrderBy(x => x.Date)
                        .ToList(),
                    Names = context.Mapper
                        .Map<ICollection<UseCaseCompanyName>>(db.Company.CompanyNames)
                        .OrderBy(x => x.Date)
                        .ToList(),
                })
                .ForAllMembers(opt => opt.Ignore());
        }
    }
}
