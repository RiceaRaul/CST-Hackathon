using Microsoft.Extensions.DependencyInjection;

namespace ExternalServices
{
    public class ExternalServicesConfiguration
    {
        public static void RegisterDepedencies(IServiceCollection services)
        {
           // services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}