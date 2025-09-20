using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.UserDocument.Query.GetById
{
    public record GetByIdUserDocQuery(Guid Id) : IRequest<UserDocumentDetailDto>;
}
