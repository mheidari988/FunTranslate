namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
public class GetFunTranslationByQueryValidator : AbstractValidator<GetFunTranslationByQuery>
{
    public GetFunTranslationByQueryValidator()
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
