using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface ITrainingRepository : IGenericRepository<Training>
    {
        Task<List<TrainingDetailDto>?> GetAllTrainingByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<TrainingDetailDto>?> GetAllTrainingByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<TrainingDetailDto?> GetTrainingByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
