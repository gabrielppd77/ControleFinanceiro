using FluentValidation;

namespace Application.FinancialAccounts.CreateFinancialAccount;

public class CreateFinancialAccountValidator : AbstractValidator<CreateFinancialAccountRequest>
{
    public CreateFinancialAccountValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
