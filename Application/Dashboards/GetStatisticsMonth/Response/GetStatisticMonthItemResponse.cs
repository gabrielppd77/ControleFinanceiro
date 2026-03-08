namespace Application.Dashboards.GetStatisticsMonth.Response;

public record GetStatisticMonthItemResponse(
    Guid Id, 
    string Label, 
    decimal Value);