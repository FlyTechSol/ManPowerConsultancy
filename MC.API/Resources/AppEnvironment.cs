using MC.Application.Contracts.Persistence.Common;

namespace MC.API.Resources
{
    public class AppEnvironment : IAppEnvironment
    {
        public AppEnvironment(IWebHostEnvironment env)
        {
            ContentRootPath = env.ContentRootPath;
            WebRootPath = env.WebRootPath;
        }

        public string ContentRootPath { get; }
        public string WebRootPath { get; }
    }

}
