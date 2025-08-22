using AutoMapper;
using MC.Application.Contracts.Persistence.Menu;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Menu.Menu.Command.Create
{
   public class CreateMenuCmdHandler : IRequestHandler<CreateMenuCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCmdHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<Guid> Handle(CreateMenuCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateMenuCmdValidator(_menuRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Menu", validationResult);

            // convert to domain entity object
            var menuToCreate = _mapper.Map<Domain.Entity.Menu.Menu>(request);

            // add to database
            await _menuRepository.CreateAsync(menuToCreate, cancellationToken);

            // retun record id
            return menuToCreate.Id;
        }
    }
}
