using Domain.Entities;

namespace Application.Services.PrizeDrawSubmissions.Submit
{
    /// <summary>
    /// This class contains methods that change submission data in persistent layer.
    /// </summary>
    public interface IPrizeDrawSubmissionReadWriteRepository
    {
        Task<bool> AddAsync(ProductPrizeDrawSubmission productPrizeDrawSubmission);
    }
}
