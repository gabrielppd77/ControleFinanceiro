using Domain.FinancialEntries;

namespace Application.FinancialEntries.GetFinancialEntries;

public record GetFinancialEntryResponse(
    Guid Id,
    DateTime Date,
    decimal Amount,
    Guid TypeId,
    ClassificationEnum Classification,
    string? Description);