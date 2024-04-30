using LAB_APP.Application.Services;
using LAB_APP.Data.Repositories;
using LAB_APP.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LAB_APP.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            return services;
        } 
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<IEscolaService, EscolaService>();

            return services;
        }
    }
}
