using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.Family.Query.GetById
{
    public class GetFamilyByIdQueryHandler : IRequestHandler<GetFamilyByIdQuery, FamilyDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository _familyRepository;

        public GetFamilyByIdQueryHandler(IMapper mapper, IFamilyRepository familyRepository)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
        }

        public async Task<FamilyDetailDto> Handle(GetFamilyByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _familyRepository.GetFamilyByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Domain.Entity.Registration.Family), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<FamilyDetailDto>(response);

            // return DTO object
            return data;
        }
    }
}
