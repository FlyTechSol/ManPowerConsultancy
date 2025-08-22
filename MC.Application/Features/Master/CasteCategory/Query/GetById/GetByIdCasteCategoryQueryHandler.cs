using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.CasteCategory.Query.GetById
{
    public class GetByIdCasteCategoryQueryHandler : IRequestHandler<GetByIdCasteCategoryQuery, CasteCategoryDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ICasteCategoryRepository _casteCategoryRepositor;

        public GetByIdCasteCategoryQueryHandler(IMapper mapper, ICasteCategoryRepository casteCategoryRepositor)
        {
            _mapper = mapper;
            _casteCategoryRepositor = casteCategoryRepositor;
        }

        public async Task<CasteCategoryDetailDto> Handle(GetByIdCasteCategoryQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _casteCategoryRepositor.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(CasteCategory), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<CasteCategoryDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
