using Domain.FinancialEntries;

namespace Application.RecurringEntries.Common;

public record RecurringEntryResponse(
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
