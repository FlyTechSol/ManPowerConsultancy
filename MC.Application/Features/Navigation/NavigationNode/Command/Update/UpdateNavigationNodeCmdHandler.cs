using AutoMapper;
using MC.Application.Contracts.Navigation;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Navigation.NavigationNode.Command.Update
{
    public class UpdateNavigationNodeCmdHandler : IRequestHandler<UpdateNavigationNodeCmd, Unit>
    {
        private readonly IMapper _mapper;
        private readonly INavigationNodeRepository _repository;

        public UpdateNavigationNodeCmdHandler(IMapper mapper, INavigationNodeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateNavigationNodeCmd request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNavigationNodeCmdValidator(_repository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid update request", validationResult);

            var node = _mapper.Map<MC.Domain.Entity.Navigation.NavigationNode>(request);
            await _repository.UpdateWithRolesAsync(node, request.RoleIds, cancellationToken);
            return Unit.Value;
        }
    }

}
