using MC.Application.ModelDto.Registration;
using MediatR;

namespace MC.Application.Features.Registration.BankAccount.Query.DownloadBankAccount
{
    public record DownloadPassbookQuery(Guid BankAccountId) : IRequest<FileResponseDto>;
}
