using Application.Services.Products;
using Infrastructure.Caching;
using Microsoft.EntityFrameworkCore;
using Website.Data;

namespace Infrastructure.DataAccess
{
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDataAccessCache _cache;

        public ProductReadRepository(
            ApplicationDbContext dbContext,
            IDataAccessCache cache)
        {
            this._dbContext = dbContext;
            this._cache = cache;
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsAsync(string serialNumber)
        {
            serialNumber = serialNumber.ToUpper(); // normalize serial number
            string cacheKey = "exists_" + serialNumber;
            bool? cacheData = await _cache.GetAsync<bool?>(cacheKey);
            if (cacheData != null)
            {
                return cacheData.Value;
            }

            bool dbResult = await _dbContext.Products.Where(x => x.SerialNumber == serialNumber).AnyAsync();
            await _cache.SetAsync(cacheKey, dbResult);
            return dbResult;
        }
    }
}
