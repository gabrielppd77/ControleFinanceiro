using Domain.FinancialEntries;

namespace Application.FinancialEntries.ListFinancialEntry;

public record ListFinancialEntryResponse(
    Guid Id,
    DateOnly Date,
    decimal Amount,
    Guid? TypeId,
    string? TypeName,
    string? TypeColor,
    ClassificationEnum Classification,
    string ClassificationName,
    string? ClassificationColor,
    string? Description,
    bool IsConfirmed);