using FluentValidation;

namespace Application.FinancialTypes.DeleteFinancialType;

public class DeleteFinancialTypeValidator : AbstractValidator<DeleteFinancialTypeRequest>
{
    public DeleteFinancialTypeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
