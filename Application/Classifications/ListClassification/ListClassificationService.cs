using Application.Base;
using Contracts.Repositories.Base;
using Domain.Classifications;

namespace Application.Classifications.ListClassification;

public class ListClassificationService : IServiceHandler<Unit, List<ListClassificationResponse>>
{
    private readonly IBaseRepository<Classification> _classificationRepository;

    public ListClassificationService(IBaseRepository<Classification> classificationRepository)
    {
        _classificationRepository = classificationRepository;
    }

    public async Task<List<ListClassificationResponse>> Handle(Unit request)
    {
        var classifications = await _classificationRepository.GetAll();

        return classifications.Select(x => new ListClassificationResponse(x.Id, x.Name)).ToList();
    }
}
