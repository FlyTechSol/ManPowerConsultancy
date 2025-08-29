using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.PoliceVerification.Query.GetById
{
   public class GetPoliceVeriByIdQueryHandler : IRequestHandler<GetPoliceVeriByIdQuery, PoliceVerificationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IPoliceVerificationRepository _policeVerificationRepository;

        public GetPoliceVeriByIdQueryHandler(IMapper mapper, IPoliceVerificationRepository policeVerificationRepository)
        {
            _mapper = mapper;
            _policeVerificationRepository = policeVerificationRepository;
        }

        public async Task<PoliceVerificationDetailDto> Handle(GetPoliceVeriByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _policeVerificationRepository.GetByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.PoliceVerification), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<PoliceVerificationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
