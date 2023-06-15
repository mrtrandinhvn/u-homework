using Application.Services.PrizeDrawSubmissions.Submit;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<PrizeDrawSubmissionInput, ProductPrizeDrawSubmission>(MemberList.Source)
                .ForSourceMember(x => x.Age, opt => opt.DoNotValidate());
        }
    }
}
