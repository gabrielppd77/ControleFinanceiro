namespace Contracts.Repositories.FinancialEntries.Dtos;

public record ChartDataOfYearDto(
    string Month, 
    string Label, 
    string? Color, 
    decimal Value);