namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsByFilter;
public class GetFunTranslationsByFilterQuery : IRequest<List<GetFunTranslationsByFilterVm>>
{
    public GetFunTranslationsByFilterQuery() { }
    public GetFunTranslationsByFilterQuery(string? text, string? translated, string? translation)
    {
        Text = text;
        Translated = translated;
        Translation = translation;
    }
    public string? Text { get; set; } = string.Empty;
    public string? Translation { get; set; } = string.Empty;
    public string? Translated { get; set; } = string.Empty;
}
