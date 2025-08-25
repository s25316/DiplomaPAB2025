using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestEducationInstitutionKinds
{
    public class GetGuestEducationInstitutionKindsHandler : IRequestHandler<GetGuestEducationInstitutionKindsRequest, IEnumerable<EducationInstitutionKind>>
    {
        private readonly IEducationInstitutionKindRepository educationInstitutionKindRepository;


        public GetGuestEducationInstitutionKindsHandler(IEducationInstitutionKindRepository educationInstitutionKindRepository)
        {
            this.educationInstitutionKindRepository = educationInstitutionKindRepository;
        }


        public async Task<IEnumerable<EducationInstitutionKind>> Handle(GetGuestEducationInstitutionKindsRequest request, CancellationToken cancellationToken)
        {
            return await educationInstitutionKindRepository.GetAllAsync(cancellationToken);
        }
    }
}
