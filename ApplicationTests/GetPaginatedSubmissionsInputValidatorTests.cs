using Application.Services.PrizeDrawSubmissions.Read;
using FluentValidation.TestHelper;

namespace ApplicationTests
{
    public class GetPaginatedSubmissionsInputValidatorTests
    {
        [Fact]
        public async Task Validation_Should_Pass()
        {
            // setup
            GetPaginatedSubmissionsInputValidator _validator = new();

            // execution
            TestValidationResult<GetPaginatedSubmissionsInput> validationResult = await _validator.TestValidateAsync(new GetPaginatedSubmissionsInput
            {
                PageSize = 1,
                Page = 1,
            });

            // assertions
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Validation_Should_Fail()
        {
            // setup
            GetPaginatedSubmissionsInputValidator _validator = new();

            // execution
            TestValidationResult<GetPaginatedSubmissionsInput> validationResult = await _validator.TestValidateAsync(new GetPaginatedSubmissionsInput
            {
                PageSize = 0,
                Page = 0,
            });

            // assertions
            validationResult.ShouldHaveValidationErrorFor(x => x.PageSize);
            validationResult.ShouldHaveValidationErrorFor(x => x.Page);
        }
    }
}
