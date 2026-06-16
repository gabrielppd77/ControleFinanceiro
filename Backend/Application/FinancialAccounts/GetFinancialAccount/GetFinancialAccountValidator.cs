using FluentValidation;

namespace Application.FinancialAccounts.GetFinancialAccount;

public class GetFinancialAccountValidator : AbstractValidator<GetFinancialAccountRequest>
{
    public GetFinancialAccountValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
