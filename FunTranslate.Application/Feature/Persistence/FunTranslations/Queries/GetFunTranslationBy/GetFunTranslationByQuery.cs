namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
public class GetFunTranslationByQuery : IRequest<FunTranslationByVm?>
{
    public GetFunTranslationByQuery() { }
    public GetFunTranslationByQuery(string text, string translation)
    {
        Text = text;
        Translation = translation;
    }

    public string Text { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
