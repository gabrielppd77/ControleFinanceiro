namespace Application.Dashboards.GetStatisticsMonth.Response;

public record GetStatisticMonthItemResponse(
    string Id, 
    string Label, 
    string? Color, 
    decimal Value);