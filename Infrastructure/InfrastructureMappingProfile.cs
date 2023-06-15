using Application.Services.PrizeDrawSubmissions.Read;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure
{
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<ProductPrizeDrawSubmission, ProductPrizeDrawSubmissionReadModel>();
        }
    }
}
