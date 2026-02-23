using FluentValidation;

namespace Application.FinancialTypes.GetFinancialType;

public class GetFinancialTypeValidator : AbstractValidator<GetFinancialTypeRequest>
{
    public GetFinancialTypeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
