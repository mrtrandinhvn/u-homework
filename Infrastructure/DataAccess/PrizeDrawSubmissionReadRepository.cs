using Application.Common;
using Application.Services.PrizeDrawSubmissions.Read;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Caching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Website.Data;

namespace Infrastructure.DataAccess
{
    public class PrizeDrawSubmissionReadRepository : IPrizeDrawSubmissionReadRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDataAccessCache _cache;
        private readonly IMapper _mapper;
        private readonly ILogger<PrizeDrawSubmissionReadRepository> _logger;

        public PrizeDrawSubmissionReadRepository(
            ApplicationDbContext dbContext,
            IDataAccessCache cache,
            IMapper mapper,
            ILogger<PrizeDrawSubmissionReadRepository> logger)
        {
            _dbContext = dbContext;
            _cache = cache;
            this._mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginationOutput<ProductPrizeDrawSubmissionReadModel>> GetPaginatedResultAsync(GetPaginatedSubmissionsInput input)
        {
            try
            {
                int totalRecords = await _dbContext.ProductPrizeDrawSubmissions.CountAsync();

                int skip = (input.Page - 1) * input.PageSize;
                List<ProductPrizeDrawSubmissionReadModel> records = await _dbContext.ProductPrizeDrawSubmissions
                    .Skip(skip)
                    .Take(input.PageSize)
                    .ProjectTo<ProductPrizeDrawSubmissionReadModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return new PaginationOutput<ProductPrizeDrawSubmissionReadModel>
                {
                    Data = records,
                    TotalRecords = totalRecords,
                    CurrentPage = input.Page,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get the data from db. Page number: {PageNumber}; PageSize: {PageSize}.", input.Page, input.PageSize);
                return new PaginationOutput<ProductPrizeDrawSubmissionReadModel>
                {
                    CurrentPage = input.Page,
                };
            }
        }

        public Task<int> GetSubmissionCountBySerialNumberAsync(string serialNumber)
        {
            return _dbContext.ProductPrizeDrawSubmissions
                .Where(x => x.ProductSerialNumber == serialNumber)
                .Select(x => x.Id)
                .CountAsync();
        }
    }
}
