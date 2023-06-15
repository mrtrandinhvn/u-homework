using Domain.Entities;

namespace Application.Services.PrizeDrawSubmissions.Submit
{
    public interface IPrizeDrawSubmissionReadWriteRepository
    {
        Task<bool> AddAsync(ProductPrizeDrawSubmission productPrizeDrawSubmission);
    }
}
