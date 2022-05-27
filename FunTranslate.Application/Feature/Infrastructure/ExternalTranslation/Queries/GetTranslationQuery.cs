namespace FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
public class GetTranslationQuery : IRequest<ExternalTranslationVm>
{
    public string Text { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}
