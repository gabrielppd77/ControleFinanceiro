using Domain.FinancialEntries;

namespace Contracts.Repositories.FinancialEntries.Dtos;

public record FinancialEntryFilterDto(
    DateOnly? InitialDate,
    DateOnly? FinalDate,
    decimal? InitialAmount,
    decimal? FinalAmount,
    string? SearchText,
    Guid? TypeId,
    ClassificationEnum? Classification,
    Boolean? IsConfirmed);