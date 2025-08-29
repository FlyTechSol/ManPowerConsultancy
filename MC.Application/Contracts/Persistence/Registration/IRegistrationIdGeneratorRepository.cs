namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IRegistrationIdGeneratorRepository
    {
        Task<string> GetNextRegistrationIdAsync(Guid companyId);
    }
}
