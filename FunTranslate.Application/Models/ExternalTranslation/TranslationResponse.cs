namespace FunTranslate.Application.Models.ExternalTranslation;
public class TranslationResponse
{
    public SuccessField Success { get; set; } = null!;
    public ContentField Contents { get; set; } = null!;
}
