using FluentValidation;

namespace Application.FinancialTypes.CreateFinancialType;

public class UpdateFinancialTypeValidator : AbstractValidator<CreateFinancialTypeRequest>
{
    public UpdateFinancialTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
