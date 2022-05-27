namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
public class CreateFunTranslationCommandValidator : AbstractValidator<CreateFunTranslationCommand>
{
    public CreateFunTranslationCommandValidator()
    {
        RuleFor(fun => fun.Text)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(FunTranslationConsts.Text.MaximumLength)
                .WithMessage($"Maximum allowed length is {FunTranslationConsts.Text.MaximumLength}");
        RuleFor(fun => fun.Translated)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(FunTranslationConsts.Translated.MaximumLength)
                .WithMessage($"Maximum allowed length is {FunTranslationConsts.Translated.MaximumLength}");

        RuleFor(fun => fun.Translation)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(FunTranslationConsts.Translation.MaximumLength)
                .WithMessage($"Maximum allowed length is {FunTranslationConsts.Translation.MaximumLength}");
    }
}
