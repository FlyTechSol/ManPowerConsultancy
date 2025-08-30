using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Category.Query.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDetailDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _categoryRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Category), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<CategoryDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
