using FluentValidation;

namespace Application.FinancialTypes.CreateFinancialType;

public class CreateFinancialTypeValidator : AbstractValidator<CreateFinancialTypeRequest>
{
    public CreateFinancialTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
