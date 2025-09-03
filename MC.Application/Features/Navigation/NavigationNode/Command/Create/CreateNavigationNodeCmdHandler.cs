using AutoMapper;
using MC.Application.Contracts.Navigation;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Create
{
    public class CreateNavigationNodeCmdHandler : IRequestHandler<CreateNavigationNodeCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly INavigationNodeRepository _navigationNodeRepository;

        public CreateNavigationNodeCmdHandler(
            IMapper mapper,
            INavigationNodeRepository navigationNodeRepository)
        {
            _mapper = mapper;
            _navigationNodeRepository = navigationNodeRepository;
        }

        public async Task<Guid> Handle(CreateNavigationNodeCmd request, CancellationToken cancellationToken)
        {
            var validator = new CreateNavigationNodeCmdValidator(_navigationNodeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid navigation node record", validationResult);

            var node = _mapper.Map<MC.Domain.Entity.Navigation.NavigationNode>(request);

            var id = await _navigationNodeRepository.CreateWithRolesAsync(node, request.RoleIds, cancellationToken);

            return id;
        }
    }
}
