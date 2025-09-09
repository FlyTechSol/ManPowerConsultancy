using MC.Application.ModelDto.Common.Pagination;
using MC.Application.ModelDto.Registration;
using MC.Domain.Entity.Registration;

namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<PaginatedResponse<AddressDetailDto>?> GetAllDetailsAsync(Guid userProfileId, QueryParams queryParams, CancellationToken cancellationToken);
        Task<AddressDetailDto?> GetActiveAddressByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<List<AddressDetailDto>?> GetInactiveAddressByRegistrationIdAsync(string registrationId, CancellationToken cancellationToken);
        Task<AddressDetailDto?> GetActiveAddressByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<List<AddressDetailDto>?> GetInactiveAddressByUserProfileIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task<AddressDetailDto?> GetAddressByIdAsync(Guid Id, CancellationToken cancellationToken);
        Task<List<Address>> GetAllByUserIdAsync(Guid userProfileId, CancellationToken cancellationToken);
        Task UpdateRangeAsync(IEnumerable<Address> addresses, CancellationToken cancellationToken);
    }
}
