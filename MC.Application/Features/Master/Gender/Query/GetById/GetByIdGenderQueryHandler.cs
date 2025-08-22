using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Gender.Query.GetById
{
    public class GetByIdGenderQueryHandler : IRequestHandler<GetByIdGenderQuery, GenderDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;

        public GetByIdGenderQueryHandler(IMapper mapper, IGenderRepository genderRepository)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
        }

        public async Task<GenderDetailDto> Handle(GetByIdGenderQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var gender = await _genderRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (gender == null)
                throw new NotFoundException(nameof(Gender), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<GenderDetailDto>(gender);

            // return DTO object
            return data;
        }
    }
}
