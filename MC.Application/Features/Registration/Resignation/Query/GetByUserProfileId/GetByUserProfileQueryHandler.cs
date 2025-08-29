using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Query.GetByUserProfileId
{
    public class GetByUserProfileQueryHandler : IRequestHandler<GetByUserProfileQuery, ResignationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IResignationRepository _resignationRepository;

        public GetByUserProfileQueryHandler(IMapper mapper, IResignationRepository resignationRepository)
        {
            _mapper = mapper;
            _resignationRepository = resignationRepository;
        }

        public async Task<ResignationDetailDto> Handle(GetByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _resignationRepository.GetByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Resignation), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<ResignationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
