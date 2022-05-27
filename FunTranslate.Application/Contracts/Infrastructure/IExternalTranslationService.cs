namespace FunTranslate.Application.Contracts.Infrastructure;
public interface IExternalTranslationService<T> where T : class
{
    Task<T> Translate(string text);
}
