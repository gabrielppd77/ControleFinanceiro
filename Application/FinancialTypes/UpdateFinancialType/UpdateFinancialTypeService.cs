using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialTypes;
using Domain.Exceptions;

namespace Application.FinancialTypes.UpdateFinancialType;

public class UpdateFinancialTypeService : IServiceHandler<UpdateFinancialTypeRequest, Success>
{
    private readonly IFinancialTypeRepository _financialTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFinancialTypeService(IFinancialTypeRepository financialTypeRepository, IUnitOfWork unitOfWork)
    {
        _financialTypeRepository = financialTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(UpdateFinancialTypeRequest request)
    {
        var financialType = await _financialTypeRepository.GetById(request.Id);

        if (financialType is null) throw new NotFoundException("Não foi possível encontrar um Tipo");

        financialType.Update(request.Name);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
