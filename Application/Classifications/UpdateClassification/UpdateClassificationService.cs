using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.Classifications;
using Domain.Exceptions;

namespace Application.Classifications.UpdateClassification;

public class UpdateClassificationService : IServiceHandler<UpdateClassificationRequest, Success>
{
    private readonly IClassificationRepository _classificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClassificationService(IClassificationRepository classificationRepository, IUnitOfWork unitOfWork)
    {
        _classificationRepository = classificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(UpdateClassificationRequest request)
    {
        var classification = await _classificationRepository.GetById(request.Id);

        if (classification is null) throw new NotFoundException("Não foi possível encontrar a Classificação");

        classification.Update(request.Name);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
