
namespace MC.Application.Contracts.Persistence.Common
{
    public interface IAppEnvironment
    {
        string ContentRootPath { get; }
        string WebRootPath { get; }
    }

}
