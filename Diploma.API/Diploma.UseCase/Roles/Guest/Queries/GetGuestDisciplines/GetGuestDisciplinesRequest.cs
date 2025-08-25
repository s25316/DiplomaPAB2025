using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestDisciplines
{
    public class GetGuestDisciplinesRequest : IRequest<IEnumerable<Discipline>>
    {
    }
}
