namespace Application.FinancialEntries.CreateFinancialEntry;

public record CreateFinancialEntryRequest(DateTime Date, decimal Amount, Guid TypeId, Guid ClassificationId, string? Description);
