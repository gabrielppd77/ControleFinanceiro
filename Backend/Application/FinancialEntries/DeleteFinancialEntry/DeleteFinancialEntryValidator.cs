using FluentValidation;

namespace Application.FinancialEntries.DeleteFinancialEntry;

public class DeleteFinancialEntryValidator : AbstractValidator<DeleteFinancialEntryRequest>
{
    public DeleteFinancialEntryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
