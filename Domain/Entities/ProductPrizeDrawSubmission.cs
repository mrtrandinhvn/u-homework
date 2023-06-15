namespace Domain.Entities
{
    public class ProductPrizeDrawSubmission
    {
        public required int Id { get; set; }
        public required string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; } = string.Empty;
        public string OwnerEmail { get; set; } = string.Empty;
        public string ProductSerialNumber { get; set; } = string.Empty;
        public Product? Product { get; set; }
    }
}
