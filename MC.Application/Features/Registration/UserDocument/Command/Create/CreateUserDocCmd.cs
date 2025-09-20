using MediatR;
using Microsoft.AspNetCore.Http;

namespace MC.Application.Features.Registration.UserDocument.Command.Create
{
    public class CreateUserDocCmd : IRequest<Guid>
    {
        public Guid UserProfileId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsVerified { get; set; } = false;
        public IFormFile? FilePath { get; set; }
    }
}
