using Application.Services.PrizeDrawSubmissions.Read;
using Application.Services.PrizeDrawSubmissions.Submit;
using Application.Services.Products;
using FluentValidation.TestHelper;
using Moq;

namespace ApplicationTests
{
    public class PrizeDrawSubmissionInputValidatorTests
    {
        private readonly Mock<IPrizeDrawSubmissionReadRepository> _mockPrizeDrawSubmissionReadRepository;
        private readonly Mock<IProductReadRepository> _mockProductReadRepository;

        public PrizeDrawSubmissionInputValidatorTests()
        {
            _mockPrizeDrawSubmissionReadRepository = new Mock<IPrizeDrawSubmissionReadRepository>();
            _mockProductReadRepository = new Mock<IProductReadRepository>();
        }

        [Fact]
        public async Task Validation_Should_Pass()
        {
            // setup
            const string serialNumber = "serialNumber";
            _mockProductReadRepository
                .Setup(x => x.ExistsAsync(serialNumber))
                .ReturnsAsync(true);
            _mockPrizeDrawSubmissionReadRepository
                .Setup(x => x.GetSubmissionCountBySerialNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(1);
            PrizeDrawSubmissionInputValidator _validator = new(
                _mockPrizeDrawSubmissionReadRepository.Object,
                _mockProductReadRepository.Object);

            // execution
            TestValidationResult<PrizeDrawSubmissionInput> validationResult = await _validator.TestValidateAsync(new PrizeDrawSubmissionInput
            {
                OwnerFirstName = "first name",
                OwnerLastName = "last name",
                OwnerEmail = "email",
                ProductSerialNumber = serialNumber,
                Age = 18
            });

            // assertions
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Validation_Should_Fail()
        {
            // setup
            const string serialNumber = "serialNumber";
            _mockProductReadRepository
                .Setup(x => x.ExistsAsync(serialNumber))
                .ReturnsAsync(true);
            _mockPrizeDrawSubmissionReadRepository
                .Setup(x => x.GetSubmissionCountBySerialNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(2);
            PrizeDrawSubmissionInputValidator _validator = new(
                _mockPrizeDrawSubmissionReadRepository.Object,
                _mockProductReadRepository.Object);

            // execution
            TestValidationResult<PrizeDrawSubmissionInput> validationResult = await _validator.TestValidateAsync(new PrizeDrawSubmissionInput
            {
                OwnerFirstName = string.Empty,
                OwnerLastName = string.Empty,
                OwnerEmail = string.Empty,
                ProductSerialNumber = string.Empty,
                Age = 17,
            });

            // assertions
            validationResult.ShouldHaveValidationErrorFor(x => x.OwnerFirstName);
            validationResult.ShouldHaveValidationErrorFor(x => x.OwnerLastName);
            validationResult.ShouldHaveValidationErrorFor(x => x.OwnerEmail);
            validationResult.ShouldHaveValidationErrorFor(x => x.ProductSerialNumber);
            validationResult.ShouldHaveValidationErrorFor(x => x.Age);
            validationResult.ShouldHaveValidationErrorFor("MaxSubmissionReached");
        }
    }
}
