using net_kata.Interface;
using net_kata.Repositories;

namespace net_kata.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
