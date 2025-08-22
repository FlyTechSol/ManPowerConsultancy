using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MediatR;

namespace MC.Application.Features.Master.Title.Command.Create
{
   public class CreateTitleCmdHandler : IRequestHandler<CreateTitleCmd, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;

        public CreateTitleCmdHandler(IMapper mapper, ITitleRepository titleRepository)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
        }

        public async Task<Guid> Handle(CreateTitleCmd request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateTitleCmdValidator(_titleRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid title type", validationResult);

            // convert to domain entity object
            var titleToCreate = _mapper.Map<Domain.Entity.Master.Title>(request);

            // add to database
            await _titleRepository.CreateAsync(titleToCreate);

            // retun record id
            return titleToCreate.Id;
        }
    }
}
