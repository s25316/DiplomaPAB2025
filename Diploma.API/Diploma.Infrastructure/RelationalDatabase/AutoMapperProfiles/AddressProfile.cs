using AutoMapper;
using Diploma.UseCase.Shared.Models;
using DatabaseDivison = Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses.Division;
using DatabaseStreet = Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses.Street;
using UseCaseDivison = Diploma.UseCase.Shared.Models.Addresses.Division;
using UseCaseStreet = Diploma.UseCase.Shared.Models.Addresses.Street;

namespace Diploma.Infrastructure.RelationalDatabase.AutoMapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<DatabaseDivison, UseCaseDivison>()
                .ConstructUsing(db => new UseCaseDivison
                {
                    Id = db.DivisionId,
                    ParentId = db.ParentDivisionId,
                    Name = db.Name,
                    Type = new PairIdName<int>
                    {
                        Id = db.DivisionType.DivisionTypeId,
                        Name = db.DivisionType.Name,
                    },
                })
                .ForAllMembers(opt => opt.Ignore());

            CreateMap<DatabaseStreet, UseCaseStreet>()
               .ConstructUsing(db => new UseCaseStreet
               {
                   Id = db.StreetId,
                   Name = db.Name,
                   Type = db.StreetType == null
                    ? null
                    : new PairIdName<int>
                    {
                        Id = db.StreetType.StreetTypeId,
                        Name = db.StreetType.Name,
                    },
               })
               .ForAllMembers(opt => opt.Ignore());
        }
    }
}
