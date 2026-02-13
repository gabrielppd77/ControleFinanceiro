using FluentValidation;

namespace Application.FinancialEntrys.DeleteFinancialEntry;

public class DeleteFinancialEntryValidator : AbstractValidator<DeleteFinancialEntryRequest>
{
    public DeleteFinancialEntryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
