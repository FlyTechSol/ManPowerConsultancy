using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Resignation.Query.GetByRegistrationId
{
    public class GetByResignationIdQueryHandler : IRequestHandler<GetByResignationIdQuery, ResignationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IResignationRepository _resignationRepository;

        public GetByResignationIdQueryHandler(IMapper mapper, IResignationRepository resignationRepository)
        {
            _mapper = mapper;
            _resignationRepository = resignationRepository;
        }

        public async Task<ResignationDetailDto> Handle(GetByResignationIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _resignationRepository.GetByRegistrationIdAsync(request.RegistrationId, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Resignation), request.RegistrationId);

            // convert data object to DTO object
            var data = _mapper.Map<ResignationDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
