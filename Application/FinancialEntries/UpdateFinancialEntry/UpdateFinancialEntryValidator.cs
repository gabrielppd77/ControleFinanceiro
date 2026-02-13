using FluentValidation;

namespace Application.FinancialEntrys.UpdateFinancialEntry;

public class UpdateFinancialEntryValidator : AbstractValidator<UpdateFinancialEntryRequest>
{
    public UpdateFinancialEntryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.TypeId).NotEmpty();
        RuleFor(x => x.ClassificationId).NotEmpty();
    }
}
