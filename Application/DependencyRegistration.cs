using Application.Services.PrizeDrawSubmissions.Submit;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<PrizeDrawSubmissionInputValidator>();
            services.AddScoped<IPrizeDrawSubmitService, PrizeDrawSubmitService>();
        }
    }
}
