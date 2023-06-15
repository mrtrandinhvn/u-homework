namespace Domain.Entities
{
    public class Product
    {
        public string SerialNumber { get; set; } = string.Empty;
        public ICollection<ProductPrizeDrawSubmission> PrizeSubmissions { get; set; } = new HashSet<ProductPrizeDrawSubmission>();
    }
}