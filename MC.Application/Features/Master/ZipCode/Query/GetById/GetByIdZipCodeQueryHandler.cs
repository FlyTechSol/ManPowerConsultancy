using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetById;

public class GetByIdZipCodeQueryHandler : IRequestHandler<GetByIdZipCodeQuery, ZipCodeDetailDto>
{
    private readonly IMapper _mapper;
    private readonly IZipCodeRepository _zipCodeRepository;

    public GetByIdZipCodeQueryHandler(IMapper mapper, IZipCodeRepository zipCodeRepository)
    {
        _mapper = mapper;
        _zipCodeRepository = zipCodeRepository;
    }

    public async Task<ZipCodeDetailDto> Handle(GetByIdZipCodeQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var response = await _zipCodeRepository.GetDetailsAsync(request.Id, cancellationToken);

        // verify that record exists
        if (response == null)
            throw new NotFoundException(nameof(ZipCode), request.Id);

        // convert data object to DTO object
        var data = _mapper.Map<ZipCodeDetailDto>(response);

        // return DTO object
        return data;
    }
}
