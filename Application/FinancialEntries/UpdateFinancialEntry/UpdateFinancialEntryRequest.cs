using Domain.FinancialEntries;

namespace Application.FinancialEntries.UpdateFinancialEntry;

public record UpdateFinancialEntryRequest(
    Guid Id,
    DateOnly Date,
    decimal Amount,
    Guid TypeId,
    ClassificationEnum Classification,
    string? Description,
    DateOnly? DatePayment,
    Guid? AccountId);