using FluentValidation;

namespace Application.RecurringEntries.CreateRecurringEntry;

public class CreateRecurringEntryValidator : AbstractValidator<CreateRecurringEntryRequest>
{
    public CreateRecurringEntryValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Classification).IsInEnum();
        RuleFor(x => x.DayOfMonth).InclusiveBetween(1, 31);
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage("A data de encerramento deve ser maior que a data de início.");
    }
}
