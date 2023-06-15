using FluentValidation;

namespace Application.Common
{
    public class PaginationInput
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class PaginationInputValidator : AbstractValidator<PaginationInput>
    {
        public PaginationInputValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        }
    }
}
