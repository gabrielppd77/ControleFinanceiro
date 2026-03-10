using Application.Base;
using Application.Classifications.Common;
using Contracts.Authentications;
using Contracts.Repositories.Classifications;

namespace Application.Classifications.ListClassification;

public class ListClassificationService : IServiceHandler<Unit, List<ClassificationResponse>>
{
    private readonly IClassificationRepository _classificationRepository;
    private readonly IUserAuthenticated _userAuthenticated;

    public ListClassificationService(IClassificationRepository classificationRepository, IUserAuthenticated userAuthenticated)
    {
        _classificationRepository = classificationRepository;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<List<ClassificationResponse>> Handle(Unit request)
    {
        var userId = _userAuthenticated.GetUserId();

        var classifications = await _classificationRepository.GetAll(userId);

        return classifications.Select(x => new ClassificationResponse(x.Id, x.Name)).ToList();
    }
}
