using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.SecurityDeposit.Query.GetByUserProfileId
{
    public class GetByUserProfileQueryHandler : IRequestHandler<GetByUserProfileQuery, SecurityDepositDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ISecurityDepositRepository _securityDepositRepository;

        public GetByUserProfileQueryHandler(IMapper mapper, ISecurityDepositRepository securityDepositRepository)
        {
            _mapper = mapper;
            _securityDepositRepository = securityDepositRepository;
        }

        public async Task<SecurityDepositDetailDto> Handle(GetByUserProfileQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _securityDepositRepository.GetSecurityDepositByUserProfileIdAsync(request.UserProfileId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.SecurityDeposit), request.UserProfileId);

            // convert data object to DTO object
            var data = _mapper.Map<SecurityDepositDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
