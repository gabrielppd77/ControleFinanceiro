using FluentValidation;

namespace Application.FinancialAccounts.DeleteFinancialAccount;

public class DeleteFinancialAccountValidator : AbstractValidator<DeleteFinancialAccountRequest>
{
    public DeleteFinancialAccountValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
