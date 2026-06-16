using Domain.FinancialEntries;

namespace Application.FinancialEntries.GetFinancialEntries;

public record GetFinancialEntryResponse(
    Guid Id,
    DateOnly Date,
    decimal Amount,
    Guid? TypeId,
    Guid? AccountId,
    ClassificationEnum Classification,
    string? Description,
    DateOnly? DatePayment,
    bool IsConfirmed);