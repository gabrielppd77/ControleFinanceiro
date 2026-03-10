using Application.Base;
using Application.Classifications.Common;
using Contracts.Repositories.Classifications;
using Domain.Exceptions;

namespace Application.Classifications.GetClassification;

public class GetClassificationService : IServiceHandler<GetClassificationRequest, ClassificationResponse>
{
    private readonly IClassificationRepository _classificationRepository;

    public GetClassificationService(IClassificationRepository classificationRepository)
    {
        _classificationRepository = classificationRepository;
    }

    public async Task<ClassificationResponse> Handle(GetClassificationRequest request)
    {
        var classification = await _classificationRepository.GetById(request.Id);

        if (classification is null) throw new NotFoundException("Não foi possível encontrar a Classificação");

        return new ClassificationResponse(classification.Id, classification.Name);
    }
}