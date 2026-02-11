using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.Classifications;

namespace Application.Classifications.UpdateClassification;

public class UpdateClassificationService : IServiceHandler<UpdateClassificationRequest, Success>
{
    private readonly IBaseRepository<Classification> _classificationRepository;

    public UpdateClassificationService(IBaseRepository<Classification> classificationRepository)
    {
        _classificationRepository = classificationRepository;
    }

    public async Task<Success> Handle(UpdateClassificationRequest request)
    {
        var classification = await _classificationRepository.GetById(request.Id);

        if (classification is null) throw new NotFoundException("Não foi possível encontrar a Classificação");

        classification.Update(request.Name);

        await _classificationRepository.SaveChanges();

        return Success.Value;
    }
}
