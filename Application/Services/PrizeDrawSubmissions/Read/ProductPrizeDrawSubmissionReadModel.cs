namespace Application.Services.PrizeDrawSubmissions.Read
{
    public class ProductPrizeDrawSubmissionReadModel
    {
        public required int Id { get; set; }
        public required string OwnerFirstName { get; set; }
        public required string OwnerLastName { get; set; }
        public required string OwnerEmail { get; set; }
        public required string ProductSerialNumber { get; set; }
    }
}