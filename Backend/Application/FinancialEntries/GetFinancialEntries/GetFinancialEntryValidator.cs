using FluentValidation;

namespace Application.FinancialEntries.GetFinancialEntries;

public class GetFinancialEntryValidator : AbstractValidator<GetFinancialEntryRequest>
{
    public GetFinancialEntryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
