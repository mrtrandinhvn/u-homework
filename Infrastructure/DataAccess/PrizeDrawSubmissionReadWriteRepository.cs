using Application.Services.PrizeDrawSubmissions.Submit;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Caching;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Website.Data;

namespace Infrastructure.DataAccess
{
    public class PrizeDrawSubmissionReadWriteRepository : IPrizeDrawSubmissionReadWriteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PrizeDrawSubmissionReadWriteRepository> _logger;

        public PrizeDrawSubmissionReadWriteRepository(
            ApplicationDbContext dbContext,
            IDataAccessCache cache,
            IMapper mapper,
            ILogger<PrizeDrawSubmissionReadWriteRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddAsync(ProductPrizeDrawSubmission productPrizeDrawSubmission)
        {
            try
            {
                _dbContext.Add(productPrizeDrawSubmission);
                int result = await _dbContext.SaveChangesAsync();
                if (result != 1)
                {
                    _logger.LogError("Failed to store the data to db. Input: {Input}.", JsonSerializer.Serialize(productPrizeDrawSubmission));
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to store the data to db. Input: {Input}.", JsonSerializer.Serialize(productPrizeDrawSubmission));
                return false;
            }
        }
    }
}
