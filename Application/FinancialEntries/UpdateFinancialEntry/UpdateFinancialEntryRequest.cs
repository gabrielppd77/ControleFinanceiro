using Domain.FinancialEntries;

namespace Application.FinancialEntries.UpdateFinancialEntry;

public record UpdateFinancialEntryRequest(
    Guid Id, 
    DateTime Date, 
    decimal Amount,
    Guid TypeId, 
    ClassificationEnum Classification, 
    string? Description);
 