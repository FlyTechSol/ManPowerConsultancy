using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Designation.Query.GetById
{
    public class GetDesignationByIdQueryHandler : IRequestHandler<GetDesignationByIdQuery, DesignationDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IDesignationRepository _designationRepository;

        public GetDesignationByIdQueryHandler(IMapper mapper, IDesignationRepository designationRepository)
        {
            _mapper = mapper;
            _designationRepository = designationRepository;
        }

        public async Task<DesignationDetailDto> Handle(GetDesignationByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _designationRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Designation), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<DesignationDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
