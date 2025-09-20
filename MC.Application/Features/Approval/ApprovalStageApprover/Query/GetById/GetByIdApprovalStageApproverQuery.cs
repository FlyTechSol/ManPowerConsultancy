using MC.Application.ModelDto.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStageApprover.Query.GetById
{
   public record GetByIdApprovalStageApproverQuery(Guid Id) : IRequest<ApprovalStageApproverDto>;
}
