using LAB_APP.Application.Services;
using LAB_APP.Data.Repositories;
using LAB_APP.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LAB_APP.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
            return services;
        } 
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<IEscolaService, EscolaService>();
            services.AddScoped<IProvinciaService, ProvinciaService>();
            services.AddScoped<IExcelService, ExcelService>();

            return services;
        }
        public static void ConfigSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LAB API", Version = "v1" });
            });
        }
    }
}
