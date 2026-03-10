using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.Classifications;
using Domain.Classifications;

namespace Application.Classifications.CreateClassification;

public class CreateClassificationService : IServiceHandler<CreateClassificationRequest, Success>
{
    private readonly IClassificationRepository _classificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateClassificationService(IClassificationRepository classificationRepository, IUnitOfWork unitOfWork)
    {
        _classificationRepository = classificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(CreateClassificationRequest request)
    {
        var classification = new Classification(request.Name);

        await _classificationRepository.Add(classification);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
