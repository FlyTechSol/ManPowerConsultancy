using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserGeneralDetail.Query.GetById
{
    public class GetUserGeneralByIdQueryHandler : IRequestHandler<GetUserGeneralByIdQuery, UserGeneralDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserGeneralDetailRepository _userGeneralDetailRepository;

        public GetUserGeneralByIdQueryHandler(IMapper mapper, IUserGeneralDetailRepository userGeneralDetailRepository)
        {
            _mapper = mapper;
            _userGeneralDetailRepository = userGeneralDetailRepository;
        }

        public async Task<UserGeneralDetailDto> Handle(GetUserGeneralByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _userGeneralDetailRepository.GetUserGeneralByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.UserGeneralDetail), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<UserGeneralDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
