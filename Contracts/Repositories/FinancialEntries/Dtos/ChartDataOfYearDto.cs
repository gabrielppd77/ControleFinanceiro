namespace Contracts.Repositories.FinancialEntries.Dtos;

public record ChartDataOfYearDto(
    string Month, 
    string Label, 
    decimal Value);