namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
public class CreateFunTranslationCommand : IRequest<Guid>
{
    public string Text { get; set; } = string.Empty;
    public string Translated { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
