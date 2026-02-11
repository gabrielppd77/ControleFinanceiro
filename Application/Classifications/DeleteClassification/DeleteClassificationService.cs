using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.Classifications;

namespace Application.Classifications.DeleteClassification;

public class DeleteClassificationService : IServiceHandler<DeleteClassificationRequest, Success>
{
    private readonly IBaseRepository<Classification> _classificationRepository;

    public DeleteClassificationService(IBaseRepository<Classification> classificationRepository)
    {
        _classificationRepository = classificationRepository;
    }

    public async Task<Success> Handle(DeleteClassificationRequest request)
    {
        var classification = await _classificationRepository.GetById(request.Id);

        if (classification is null) throw new NotFoundException("Não foi possível encontrar a Classificação");

        _classificationRepository.Remove(classification);

        await _classificationRepository.SaveChanges();

        return Success.Value;
    }
}
