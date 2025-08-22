using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.RecruitmentType.Query.GetById
{
    public class GetByIdRecruitmentTypeQueryHandler : IRequestHandler<GetByIdRecruitmentTypeQuery, RecruitmentTypeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IRecruitmentTypeRepository _recruitmentTypeRepository;

        public GetByIdRecruitmentTypeQueryHandler(IMapper mapper, IRecruitmentTypeRepository recruitmentTypeRepository)
        {
            _mapper = mapper;
            _recruitmentTypeRepository = recruitmentTypeRepository;
        }

        public async Task<RecruitmentTypeDetailDto> Handle(GetByIdRecruitmentTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _recruitmentTypeRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(RecruitmentType), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<RecruitmentTypeDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
