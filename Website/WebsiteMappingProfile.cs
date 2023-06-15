using Application.Services.PrizeDrawSubmissions.Submit;
using AutoMapper;
using Website.Models;

namespace Website
{
    public class WebsiteMappingProfile : Profile
    {
        public WebsiteMappingProfile()
        {
            CreateMap<PrizeDrawSubmissionRequest, PrizeDrawSubmissionInput>();
        }
    }
}
