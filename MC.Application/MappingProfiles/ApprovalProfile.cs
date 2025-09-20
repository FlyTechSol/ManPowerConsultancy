using AutoMapper;
using MC.Application.Features.Approval.ApprovalAction.Command.Create;
using MC.Application.Features.Approval.ApprovalStage.Command.Create;
using MC.Application.Features.Approval.ApprovalStage.Command.Update;
using MC.Application.Features.Approval.ApprovalStageApprover.Command.Create;
using MC.Application.Features.Approval.ApprovalStageApprover.Command.Update;
using MC.Application.Features.Approval.ApprovalWorkflow.Command.Create;
using MC.Application.Features.Approval.ApprovalWorkflow.Command.Update;
using MC.Application.ModelDto.Approval;
using MC.Domain.Entity.Approval;

namespace MC.Application.MappingProfiles
{
    public class ApprovalProfile : Profile
    {
        public ApprovalProfile()
        {
            CreateMap<ApprovalAction, ApprovalActionDto>().ReverseMap();
            CreateMap<ApprovalAction, ApprovalActionDto>();
            CreateMap<ApprovalActionCmd, ApprovalAction>();
            
            CreateMap<ApprovalStage, ApprovalStagesDto>().ReverseMap();
            CreateMap<ApprovalStage, ApprovalStagesDto>();
            CreateMap<CreateApprovalStageCmd, ApprovalStage>();
            CreateMap<UpdateApprovalStageCmd, ApprovalStage>();

            CreateMap<ApprovalStageApprover, ApprovalStageApproverDto>().ReverseMap();
            CreateMap<ApprovalStageApprover, ApprovalStageApproverDto>();
            CreateMap<CreateApprovalStageApproverCmd, ApprovalStageApprover>();
            CreateMap<UpdateApprovalStageApproverCmd, ApprovalStageApprover>();

            CreateMap<ApprovalWorkflow, ApprovalWorkflowDto>().ReverseMap();
            CreateMap<ApprovalWorkflow, ApprovalWorkflowDto>();
            CreateMap<CreateApprovalWorkflowCmd, ApprovalWorkflow>();
            CreateMap<UpdateApprovalWorkflowCmd, ApprovalWorkflow>();

            
        }
    }
}
