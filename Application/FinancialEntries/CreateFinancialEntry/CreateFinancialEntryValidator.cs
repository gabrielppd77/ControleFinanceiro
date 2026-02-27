using FluentValidation;

namespace Application.FinancialEntries.CreateFinancialEntry;

public class CreateFinancialEntryValidator : AbstractValidator<CreateFinancialEntryRequest>
{
    public CreateFinancialEntryValidator()
    {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.TypeId).NotEmpty();
        RuleFor(x => x.ClassificationId).NotEmpty();
    }
}
