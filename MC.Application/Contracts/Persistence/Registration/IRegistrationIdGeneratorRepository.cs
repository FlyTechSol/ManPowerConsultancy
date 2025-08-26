namespace MC.Application.Contracts.Persistence.Registration
{
    public interface IRegistrationIdGeneratorRepository
    {
        Task<int> GetNextRegistrationIdAsync();
    }
}
