using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public class DataAccessLayerConfiguration
    {
        public static void RegisterDepedencies(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}