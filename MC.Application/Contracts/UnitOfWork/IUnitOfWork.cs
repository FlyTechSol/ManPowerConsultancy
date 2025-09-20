using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Registration;

namespace MC.Application.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IApprovalActionRepository ApprovalActions { get; }
        IApprovalRequestStageRepository ApprovalRequestStages { get; }
        IApprovalWorkflowRepository ApprovalWorkflows { get; }
        IApprovalStageRepository ApprovalStages { get; }
        IBankAccountRepository BankAccounts { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
