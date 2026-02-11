using FluentValidation;

namespace Application.Classifications.UpdateClassification;

public class UpdateClassificationValidator : AbstractValidator<UpdateClassificationRequest>
{
    public UpdateClassificationValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}
