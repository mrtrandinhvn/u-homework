using Application.Common;

namespace Application.Services.PrizeDrawSubmissions.Read
{
    /// <summary>
    /// This class contains methods to read submission data from persistent layer.
    /// </summary>
    public interface IPrizeDrawSubmissionReadRepository
    {
        Task<int> GetSubmissionCountBySerialNumberAsync(string serialNumber);
        Task<PaginationOutput<ProductPrizeDrawSubmissionReadModel>> GetPaginatedResultAsync(GetPaginatedSubmissionsInput input);
    }
}
