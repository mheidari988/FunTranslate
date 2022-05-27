using FunTranslate.Application.Models.ExternalTranslation;

namespace FunTranslate.Application.Contracts.Infrastructure;
public interface IExternalTranslationService
{
    Task<TranslationResponse?> TranslateAsync(string text, string translation);
}
