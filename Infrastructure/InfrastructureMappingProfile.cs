using Application.Services.PrizeDrawSubmissions.Read;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure
{
    /// <summary>
    /// Contains model mapping profile for Infrastructure project.
    /// </summary>
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<ProductPrizeDrawSubmission, ProductPrizeDrawSubmissionReadModel>();
        }
    }
}
