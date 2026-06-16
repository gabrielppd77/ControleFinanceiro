using Domain.FinancialEntries;

namespace Application.RecurringEntries.CreateRecurringEntry;

public record CreateRecurringEntryRequest(
    string? Description,
    decimal Amount,
    ClassificationEnum Classification,
    int DayOfMonth,
    DateOnly StartDate,
    DateOnly? EndDate,
    Guid TypeId,
    Guid? AccountId);
