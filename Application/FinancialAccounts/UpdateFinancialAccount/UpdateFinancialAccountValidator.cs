using FluentValidation;

namespace Application.FinancialAccounts.UpdateFinancialAccount;

public class UpdateFinancialAccountValidator : AbstractValidator<UpdateFinancialAccountRequest>
{
    public UpdateFinancialAccountValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}
