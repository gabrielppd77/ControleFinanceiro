namespace Application.Dashboards.GetStatisticsMonth.Response;

public record GetStatisticMonthResponse(
    List<GetStatisticMonthItemResponse> Types, 
    List<GetStatisticMonthItemResponse> Classifications);