using Application.Base;
using Contracts.Repositories.Base;
using Domain.Classifications;

namespace Application.Classifications.CreateClassification;

public class CreateClassificationService : IServiceHandler<CreateClassificationRequest, Success>
{
    private readonly IBaseRepository<Classification> _classificationRepository;

    public CreateClassificationService(IBaseRepository<Classification> classificationRepository)
    {
        _classificationRepository = classificationRepository;
    }

    public async Task<Success> Handle(CreateClassificationRequest request)
    {
        var classification = new Classification(request.Name);

        await _classificationRepository.Add(classification);

        await _classificationRepository.SaveChanges();

        return Success.Value;
    }
}
