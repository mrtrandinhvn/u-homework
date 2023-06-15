namespace Application.Services.Products
{
    public interface IProductReadRepository
    {
        Task<bool> ExistsAsync(string serialNumber);
    }
}