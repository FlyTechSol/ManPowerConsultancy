using AutoMapper;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Exceptions;
using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Query.GetById
{
    public class GetByIdUserDocQueryHandler : IRequestHandler<GetByIdUserDocQuery, UserDocumentDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserDocumentRepository _userDocumentRepository;

        public GetByIdUserDocQueryHandler(IMapper mapper, IUserDocumentRepository userDocumentRepository)
        {
            _mapper = mapper;
            _userDocumentRepository = userDocumentRepository;
        }

        public async Task<UserDocumentDetailDto> Handle(GetByIdUserDocQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var bankDetail = await _userDocumentRepository.GetUserDocumentByIdAsync(request.Id, cancellationToken);

            // verify that record exists
            if (bankDetail == null)
                throw new NotFoundException(nameof(UserDocument), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<UserDocumentDetailDto>(bankDetail);

            // return DTO object
            return data;
        }
    }
}
