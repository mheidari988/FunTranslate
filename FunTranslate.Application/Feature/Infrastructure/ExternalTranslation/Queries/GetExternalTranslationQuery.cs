namespace FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
public class GetExternalTranslationQuery : IRequest<ExternalTranslationVm>
{
    public GetExternalTranslationQuery() { }
    public GetExternalTranslationQuery(string text, string translation)
    {
        Text = text;
        Translation = translation;
    }

    public string Text { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
