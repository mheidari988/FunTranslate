namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
public class CreateFunTranslationCommand : IRequest<Guid>
{
    public CreateFunTranslationCommand() { }
    public CreateFunTranslationCommand(string text, string translated, string translation)
    {
        Text = text;
        Translated = translated;
        Translation = translation;
    }

    public string Text { get; set; } = string.Empty;
    public string Translated { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
