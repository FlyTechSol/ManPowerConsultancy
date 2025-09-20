using MediatR;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Features.Registration.UserDocument.Command.Update
{
    public class UpdateUserDocCmd : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserProfileId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsVerified { get; set; } = false;
        public IFormFile? FilePath { get; set; }
    }
}
