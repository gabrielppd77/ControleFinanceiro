using Application.Base;
using Application.Dashboards.GetStatisticsMonth.Response;
using Contracts.Authentications;
using Contracts.Repositories.FinancialEntries;
using Contracts.Repositories.FinancialTypes;
using Domain.FinancialEntries;

namespace Application.Dashboards.GetStatisticsMonth;

public class GetStatisticMonthService : IServiceHandler<GetStatisticMonthRequest, GetStatisticMonthResponse>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IFinancialTypeRepository _financialTypeRepository;
    private readonly IUserAuthenticated _userAuthenticated;

    public GetStatisticMonthService(
        IFinancialEntryRepository financialEntryRepository,
        IFinancialTypeRepository financialTypeRepository,
        IUserAuthenticated userAuthenticated)
    {
        _financialEntryRepository = financialEntryRepository;
        _financialTypeRepository = financialTypeRepository;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<GetStatisticMonthResponse> Handle(GetStatisticMonthRequest request)
    {
        var userId = _userAuthenticated.GetUserId();

        var financialTypesData = await _financialTypeRepository.GetAll(userId);
        var classificationsData = (ClassificationEnum[])Enum.GetValues(typeof(ClassificationEnum));
        var financialEntriesMonth = await _financialEntryRepository.GetEntriesOfMonth(request.Date, userId);
        var classificationsOfYear = await _financialEntryRepository.GetChartDataOfYear(request.Date, userId);

        var financialTypesResponse = new List<GetStatisticMonthItemResponse>();
        var classificationsResponse = new List<GetStatisticMonthItemResponse>();

        foreach (var financialType in financialTypesData)
        {
            var sumFinancialType = financialEntriesMonth.Where(x => x.TypeId == financialType.Id).Sum(x => x.Amount);
            financialTypesResponse.Add(new GetStatisticMonthItemResponse(financialType.Id.ToString(), financialType.Name, financialType.Color, sumFinancialType));
        }


        foreach (var classification in classificationsData)
        {
            var sumClassification = financialEntriesMonth.Where(x => x.Classification == classification).Sum(x => x.Amount);
            classificationsResponse.Add(new GetStatisticMonthItemResponse(classification.ToString(), classification.GetName(), classification.GetColor(), sumClassification));
        }

        financialTypesResponse = financialTypesResponse.OrderByDescending(x => x.Value).ToList();
        classificationsResponse = classificationsResponse.OrderByDescending(x => x.Value).ToList();

        return new GetStatisticMonthResponse(financialTypesResponse, classificationsResponse, classificationsOfYear);
    }
}
