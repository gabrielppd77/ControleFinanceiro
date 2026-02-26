using FluentValidation;

namespace Application.Classifications.GetClassification;

public class GetClassificationValidator : AbstractValidator<GetClassificationRequest>
{
    public GetClassificationValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
