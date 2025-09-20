using MC.Application.ModelDto.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalWorkflow.Query.GetById
{
    public record GetByIdApprovalWorkflowQuery(Guid Id) : IRequest<ApprovalWorkflowDto>;
}
