using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Title.Query.GetById;

public class GetByIdTitleQueryHandler : IRequestHandler<GetByIdTitleQuery, TitleDetailDto>
{
    private readonly IMapper _mapper;
    private readonly ITitleRepository _titleRepository;

    public GetByIdTitleQueryHandler(IMapper mapper, ITitleRepository titleRepository)
    {
        _mapper = mapper;
        _titleRepository = titleRepository;
    }
    public async Task<TitleDetailDto> Handle(GetByIdTitleQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var title = await _titleRepository.GetDetailsAsync(request.Id, cancellationToken);

        // verify that record exists
        if (title == null)
            throw new NotFoundException(nameof(Title), request.Id);

        // convert data object to DTO object
        var data = _mapper.Map<TitleDetailDto>(title);

        // return DTO object
        return data;
    }

}
