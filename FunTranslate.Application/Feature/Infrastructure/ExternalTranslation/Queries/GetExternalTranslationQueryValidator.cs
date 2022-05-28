namespace FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
public class GetExternalTranslationQueryValidator : AbstractValidator<GetExternalTranslationQuery>
{
    public GetExternalTranslationQueryValidator()
    {
        RuleFor(fun => fun.Text)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(FunTranslationConsts.Text.MaximumLength)
                .WithMessage($"Maximum allowed length is {FunTranslationConsts.Text.MaximumLength}");

        RuleFor(fun => fun.Translation)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(FunTranslationConsts.Translation.MaximumLength)
                .WithMessage($"Maximum allowed length is {FunTranslationConsts.Translation.MaximumLength}");
    }
}
