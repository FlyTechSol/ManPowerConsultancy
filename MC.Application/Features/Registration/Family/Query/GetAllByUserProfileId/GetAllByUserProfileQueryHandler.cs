using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Family.Query.GetAllByUserProfileId
{
    public class GetAllByUserProfileQueryHandler : IRequestHandler<GetAllByUserProfileQuery, List<FamilyDetailDto>>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository _familyRepository;

        public GetAllByUserProfileQueryHandler(IMapper mapper, IFamilyRepository familyRepository)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
        }

        public async Task<List<FamilyDetailDto>> Handle(GetAllByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _familyRepository.GetAllFamilyByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Family), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<List<FamilyDetailDto>>(response);

            // return DTO object
            return data;
        }
    }
}
