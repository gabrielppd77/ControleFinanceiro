using Domain.FinancialEntries;

namespace Application.RecurringEntries.UpdateRecurringEntry;

public record UpdateRecurringEntryRequest(
    Guid Id,
    string? Description,
    decimal Amount,
    ClassificationEnum Classification,
    int DayOfMonth,
    DateOnly StartDate,
    DateOnly? EndDate,
    bool IsActive,
    Guid TypeId,
    Guid? AccountId);
