namespace Website.Models
{
    public class PrizeDrawSubmissionRequest
    {
        public string OwnerFirstName { get; set; } = string.Empty;
        public string OwnerLastName { get; set; } = string.Empty;
        public string OwnerEmail { get; set; } = string.Empty;
        public string ProductSerialNumber { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}