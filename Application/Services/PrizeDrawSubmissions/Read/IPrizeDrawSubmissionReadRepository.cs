using Application.Common;

namespace Application.Services.PrizeDrawSubmissions.Read
{
    public interface IPrizeDrawSubmissionReadRepository
    {
        Task<int> GetSubmissionCountBySerialNumberAsync(string serialNumber);
        Task<PaginationOutput<ProductPrizeDrawSubmissionReadModel>> GetPaginatedResultAsync(GetPaginatedSubmissionsInput input);
    }
}
