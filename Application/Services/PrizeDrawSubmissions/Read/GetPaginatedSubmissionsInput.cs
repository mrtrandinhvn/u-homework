using Application.Common;
using FluentValidation;

namespace Application.Services.PrizeDrawSubmissions.Read
{
    /// <summary>
    /// Contains user input for get submission data api.
    /// </summary>
    public class GetPaginatedSubmissionsInput : PaginationInput
    {
    }

    /// <summary>
    /// This class validates user input.
    /// </summary>
    public class GetPaginatedSubmissionsInputValidator : AbstractValidator<GetPaginatedSubmissionsInput>
    {
        public GetPaginatedSubmissionsInputValidator()
        {
            RuleFor(x => x).SetValidator(new PaginationInputValidator());
        }
    }
}