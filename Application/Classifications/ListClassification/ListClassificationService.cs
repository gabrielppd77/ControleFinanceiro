using Application.Base;
using Application.Classifications.Common;
using Contracts.Repositories.Base;
using Domain.Classifications;

namespace Application.Classifications.ListClassification;

public class ListClassificationService : IServiceHandler<Unit, List<ClassificationResponse>>
{
    private readonly IBaseRepository<Classification> _classificationRepository;

    public ListClassificationService(IBaseRepository<Classification> classificationRepository)
    {
        _classificationRepository = classificationRepository;
    }

    public async Task<List<ClassificationResponse>> Handle(Unit request)
    {
        var classifications = await _classificationRepository.GetAll();

        return classifications.Select(x => new ClassificationResponse(x.Id, x.Name)).ToList();
    }
}
