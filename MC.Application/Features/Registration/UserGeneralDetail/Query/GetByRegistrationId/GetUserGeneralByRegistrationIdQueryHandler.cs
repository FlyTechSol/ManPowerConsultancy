using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Query.GetByRegistrationId
{
    public class GetUserGeneralByRegistrationIdQueryHandler : IRequestHandler<GetUserGeneralByRegistrationIdQuery, UserGeneralDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public GetUserGeneralByRegistrationIdQueryHandler(IMapper mapper, IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _mapper = mapper;
            _userGeneralDetailRepository = userGeneralDetailRepository;
        }

        public async Task<UserGeneralDetailDto> Handle(GetUserGeneralByRegistrationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _userGeneralDetailRepository.GetUserGeneralByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserGeneralDetail), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<UserGeneralDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
