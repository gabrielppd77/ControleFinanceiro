namespace Application.FinancialEntries.GetFinancialEntries;

public record GetFinancialEntryResponse(
    Guid Id,
    DateTime Date,
    decimal Amount,
    Guid TypeId,
    Guid ClassificationId,
    string? Description);