using FluentValidation;

namespace Application.Classifications.CreateClassification;

public class CreateClassificationValidator : AbstractValidator<CreateClassificationRequest>
{
    public CreateClassificationValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
