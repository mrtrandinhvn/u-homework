using Application.Common;
using FluentValidation;

namespace Application.Services.PrizeDrawSubmissions.Read
{
    public class GetPaginatedSubmissionsInput : PaginationInput
    {
    }

    public class GetPaginatedSubmissionsInputValidator : AbstractValidator<GetPaginatedSubmissionsInput>
    {
        public GetPaginatedSubmissionsInputValidator()
        {
            RuleFor(x => x).SetValidator(new PaginationInputValidator());
        }
    }
}