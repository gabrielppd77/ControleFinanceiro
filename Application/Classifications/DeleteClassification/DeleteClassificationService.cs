using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.Classifications;
using Domain.Exceptions;

namespace Application.Classifications.DeleteClassification;

public class DeleteClassificationService : IServiceHandler<DeleteClassificationRequest, Success>
{
    private readonly IClassificationRepository _classificationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClassificationService(IClassificationRepository classificationRepository, IUnitOfWork unitOfWork)
    {
        _classificationRepository = classificationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(DeleteClassificationRequest request)
    {
        var classification = await _classificationRepository.GetById(request.Id);

        if (classification is null) throw new NotFoundException("Não foi possível encontrar a Classificação");

        _classificationRepository.Remove(classification);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
