using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestDisciplines
{
    public class GetGuestDisciplinesHandler : IRequestHandler<GetGuestDisciplinesRequest, IEnumerable<Discipline>>
    {
        private readonly IDisciplineRepository disciplineRepository;


        public GetGuestDisciplinesHandler(IDisciplineRepository disciplineRepository)
        {
            this.disciplineRepository = disciplineRepository;
        }


        public async Task<IEnumerable<Discipline>> Handle(GetGuestDisciplinesRequest request, CancellationToken cancellationToken)
        {
            return await disciplineRepository.GetAllAsync(cancellationToken);
        }
    }
}
