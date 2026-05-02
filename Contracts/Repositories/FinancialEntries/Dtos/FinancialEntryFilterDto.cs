using Domain.FinancialEntries;

namespace Contracts.Repositories.FinancialEntries.Dtos;

public record FinancialEntryFilterDto(
    DateTime? InitialDate,
    DateTime? FinalDate,
    decimal? InitialAmount,
    decimal? FinalAmount,
    string? SearchText,
    Guid? TypeId,
    ClassificationEnum? Classification);