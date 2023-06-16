using Application.Services.PrizeDrawSubmissions.Read;
using Application.Services.Products;
using FluentValidation;

namespace Application.Services.PrizeDrawSubmissions.Submit
{
    /// <summary>
    /// User submitted data from prize draw form.
    /// </summary>
    public class PrizeDrawSubmissionInput
    {
        public required string OwnerFirstName { get; set; }
        public required string OwnerLastName { get; set; }
        public required string OwnerEmail { get; set; }
        public required string ProductSerialNumber { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// This class contains validation rules for user submitted data.
    /// </summary>
    public class PrizeDrawSubmissionInputValidator : AbstractValidator<PrizeDrawSubmissionInput>
    {
        public PrizeDrawSubmissionInputValidator(
            IPrizeDrawSubmissionReadRepository prizeDrawSubmissionReadRepository,
            IProductReadRepository productReadRepository)
        {
            RuleFor(x => x.OwnerFirstName).NotEmpty().MaximumLength(255).WithName("First name");
            RuleFor(x => x.OwnerLastName).NotEmpty().MaximumLength(255).WithName("Last name");
            RuleFor(x => x.OwnerEmail).NotEmpty().MaximumLength(254).WithName("Email");
            RuleFor(x => x.ProductSerialNumber)
                .NotEmpty()
                .MaximumLength(38)
                .MustAsync((x, ct) => productReadRepository.ExistsAsync(x))
                .WithMessage("Serial number does not exist in our system");
            RuleFor(x => x)
                .MustAsync(async (x, ct) => await prizeDrawSubmissionReadRepository.GetSubmissionCountBySerialNumberAsync(x.ProductSerialNumber) <= 1)
                .WithName("MaxSubmissionReached")
                .WithMessage("The submission allowance for each serial number is limited to two, and this serial number already reached that limit.");
            RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("You must be at least 18 years old in order to enter the draw");
        }
    }
}