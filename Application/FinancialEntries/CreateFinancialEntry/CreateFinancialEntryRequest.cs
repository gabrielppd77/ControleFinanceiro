using Domain.FinancialEntries;

namespace Application.FinancialEntries.CreateFinancialEntry;

public record CreateFinancialEntryRequest(
    DateTime? ReplicateUntilDate, 
    DateTime Date, 
    decimal Amount, 
    Guid TypeId, 
    ClassificationEnum Classification, 
    string? Description);
