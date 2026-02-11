using FluentValidation;

namespace Application.Classifications.DeleteClassification;

public class DeleteClassificationValidator : AbstractValidator<DeleteClassificationRequest>
{
    public DeleteClassificationValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
