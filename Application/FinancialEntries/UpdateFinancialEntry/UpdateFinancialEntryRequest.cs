namespace Application.FinancialEntries.UpdateFinancialEntry;

public record UpdateFinancialEntryRequest(
    Guid Id, 
    DateTime Date, 
    decimal Amount,
    Guid TypeId, 
    Guid ClassificationId, 
    string? Description);
 