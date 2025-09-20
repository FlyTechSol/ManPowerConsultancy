using MC.Application.ModelDto.Approval;
using MediatR;

namespace MC.Application.Features.Approval.ApprovalStage.Query.GetById
{
   public record GetByIdApprovalStageQuery(Guid Id) : IRequest<ApprovalStagesDto>;
}
