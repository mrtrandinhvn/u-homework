using Application.Services.PrizeDrawSubmissions.Read;
using Application.Services.PrizeDrawSubmissions.Submit;
using Application.Services.Products;
using Infrastructure.Caching;
using Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyRegistration
    {
        /// <summary>
        /// Register dependencies for Infrastructure project.
        /// </summary>
        /// <param name="services"></param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccessCache, MemoryCache>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IPrizeDrawSubmissionReadRepository, PrizeDrawSubmissionReadRepository>();
            services.AddScoped<IPrizeDrawSubmissionReadWriteRepository, PrizeDrawSubmissionReadWriteRepository>();
        }
    }
}
