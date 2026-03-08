using Application.Base;
using Application.Dashboards.GetStatisticsMonth.Response;
using Contracts.Repositories.Base;
using Contracts.Repositories.FinancialEntries;
using Domain.Classifications;
using Domain.FinancialTypes;

namespace Application.Dashboards.GetStatisticsMonth;

public class GetStatisticMonthService : IServiceHandler<GetStatisticMonthRequest, GetStatisticMonthResponse>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;
    private readonly IBaseRepository<Classification> _classificationRepository;

    public GetStatisticMonthService(
        IFinancialEntryRepository financialEntryRepository,
        IBaseRepository<FinancialType> financialTypeRepository,
        IBaseRepository<Classification> classificationRepository)
    {
        _financialEntryRepository = financialEntryRepository;
        _financialTypeRepository = financialTypeRepository;
        _classificationRepository = classificationRepository;
    }

    public async Task<GetStatisticMonthResponse> Handle(GetStatisticMonthRequest request)
    {
        var financialTypesData = await _financialTypeRepository.GetAll();
        var classificationsData = await _classificationRepository.GetAll();
        var financialEntriesMonth = await _financialEntryRepository.GetEntriesOfMonth(request.Date);
        var classificationsOfYear = await _financialEntryRepository.GetChartDataOfYear(request.Date);

        var financialTypesResponse = new List<GetStatisticMonthItemResponse>();
        var classificationsResponse = new List<GetStatisticMonthItemResponse>();

        foreach (var financialType in financialTypesData)
        {
            var sumFinancialType = financialEntriesMonth.Where(x => x.TypeId == financialType.Id).Sum(x => x.Amount);
            financialTypesResponse.Add(new GetStatisticMonthItemResponse(financialType.Id, financialType.Name, sumFinancialType));
        }

        foreach (var classification in classificationsData)
        {
            var sumClassification = financialEntriesMonth.Where(x => x.ClassificationId == classification.Id).Sum(x => x.Amount);
            classificationsResponse.Add(new GetStatisticMonthItemResponse(classification.Id, classification.Name, sumClassification));
        }

        financialTypesResponse = financialTypesResponse.OrderByDescending(x => x.Value).ToList();
        classificationsResponse = classificationsResponse.OrderByDescending(x => x.Value).ToList();

        return new GetStatisticMonthResponse(financialTypesResponse, classificationsResponse, classificationsOfYear);
    }
}
