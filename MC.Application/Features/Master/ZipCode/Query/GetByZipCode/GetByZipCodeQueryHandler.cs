using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.ZipCode.Query.GetByZipCode;

public class GetByZipCodeQueryHandler : IRequestHandler<GetByZipCodeQuery, ZipCodeDetailDto>
{
    private readonly IMapper _mapper;
    private readonly IZipCodeRepository _zipCodeRepository;

    public GetByZipCodeQueryHandler(IMapper mapper, IZipCodeRepository zipCodeRepository)
    {
        _mapper = mapper;
        _zipCodeRepository = zipCodeRepository;
    }

    public async Task<ZipCodeDetailDto> Handle(GetByZipCodeQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var response = await _zipCodeRepository.GetDetailsByZipCodeAsync(request.zipCode, cancellationToken);

        // convert data object to DTO object
        var data = _mapper.Map<ZipCodeDetailDto>(response);

        // return DTO object
        return data;
    }
}
