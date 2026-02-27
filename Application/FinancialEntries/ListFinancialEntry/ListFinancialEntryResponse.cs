namespace Application.FinancialEntries.ListFinancialEntry;

public record ListFinancialEntryResponse(
    Guid Id,
    DateTime Date,
    decimal Amount,
    Guid TypeId,
    string TypeName,
    Guid ClassificationId,
    string ClassificationName,
    string? Description);