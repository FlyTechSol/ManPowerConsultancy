using AutoMapper;
using MC.Application.Contracts.Persistence.Master;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Master.Master;
using MediatR;

namespace MC.Application.Features.Master.Branch.Query.GetById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, BranchDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public GetBranchByIdQueryHandler(IMapper mapper, IBranchRepository branchRepository)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
        }

        public async Task<BranchDetailDto> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var record = await _branchRepository.GetDetailsAsync(request.Id, cancellationToken);

            // verify that record exists
            if (record == null)
                throw new NotFoundException(nameof(Branch), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<BranchDetailDto>(record);

            // return DTO object
            return data;
        }
    }
}
