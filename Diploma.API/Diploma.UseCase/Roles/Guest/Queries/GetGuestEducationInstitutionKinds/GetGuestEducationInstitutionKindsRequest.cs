using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestEducationInstitutionKinds
{
    public class GetGuestEducationInstitutionKindsRequest : IRequest<IEnumerable<EducationInstitutionKind>>
    {
    }
}
