namespace Application.Services.Products
{
    /// <summary>
    /// This class contains methods that read product data from a persistent layer.
    /// </summary>
    public interface IProductReadRepository
    {
        /// <summary>
        /// Check if any product with this serial number exists.
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string serialNumber);
    }
}