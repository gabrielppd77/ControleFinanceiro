using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories;
using Contracts.Repositories.Classifications;
using Domain.Classifications;

namespace Application.Classifications.CreateClassification;

public class CreateClassificationService : IServiceHandler<CreateClassificationRequest, Success>
{
    private readonly IClassificationRepository _classificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAuthenticated _userAuthenticated;

    public CreateClassificationService(IClassificationRepository classificationRepository, IUnitOfWork unitOfWork, IUserAuthenticated userAuthenticated)
    {
        _classificationRepository = classificationRepository;
        _unitOfWork = unitOfWork;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<Success> Handle(CreateClassificationRequest request)
    {
        var userId = _userAuthenticated.GetUserId();

        var classification = new Classification(request.Name, userId);

        await _classificationRepository.Add(classification);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
