namespace Application.FinancialEntries.ListFinancialEntry;

public record ListFinancialEntryResponse(
    Guid Id,
    DateTime Date,
    decimal Amount,
    Guid TypeId,
    string TypeName,
    string? TypeColor,
    Guid ClassificationId,
    string ClassificationName,
    string? ClassificationColor,
    string? Description);