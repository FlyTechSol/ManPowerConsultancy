using MC.Application.Contracts.Persistence.Approval;
using MC.Application.Contracts.Persistence.Registration;
using MC.Application.Contracts.UnitOfWork;
using MC.Persistence.DatabaseContext;

namespace MC.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDatabaseContext _context;

        public IApprovalActionRepository ApprovalActions { get; }
        public IApprovalRequestStageRepository ApprovalRequestStages { get; }
        public IApprovalWorkflowRepository ApprovalWorkflows { get; }
        public IApprovalStageRepository ApprovalStages { get; }
        public IBankAccountRepository BankAccounts { get; }

        public UnitOfWork(
            ApplicationDatabaseContext context,
            IApprovalActionRepository approvalActionRepository,
            IApprovalRequestStageRepository approvalRequestStageRepository,
            IApprovalWorkflowRepository approvalWorkflowRepository,
            IApprovalStageRepository approvalStageRepository,
            IBankAccountRepository bankAccountRepository)
        {
            _context = context;
            ApprovalActions = approvalActionRepository;
            ApprovalRequestStages = approvalRequestStageRepository;
            ApprovalWorkflows = approvalWorkflowRepository;
            ApprovalStages = approvalStageRepository;
            BankAccounts = bankAccountRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
