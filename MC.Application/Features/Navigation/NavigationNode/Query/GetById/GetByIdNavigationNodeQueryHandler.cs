using AutoMapper;
using MC.Application.Contracts.Navigation;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Navigation;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Query.GetById
{
    public class GetByIdNavigationNodeQueryHandler : IRequestHandler<GetByIdNavigationNodeQuery, NavigationNodeDto>
    {
        private readonly IMapper _mapper;
        private readonly INavigationNodeRepository _repository;

        public GetByIdNavigationNodeQueryHandler(IMapper mapper, INavigationNodeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<NavigationNodeDto> Handle(GetByIdNavigationNodeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var response = await _repository.GetNavigationByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (response == null)
                throw new NotFoundException(nameof(Menu), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<NavigationNodeDto>(response);

            // return DTO object
            return data;
        }
    }
}
